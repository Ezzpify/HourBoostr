using System;
using System.Reflection;

namespace HourBoostr_Beta.Core
{
    internal class ProgramAssembly
    {
        internal Assembly _assembly = typeof(Program).Assembly;
        internal string Path => System.IO.Path.GetDirectoryName(_assembly.Location);
        internal string Name => Assembly.GetExecutingAssembly().GetName().Name;

        internal ProgramAssembly() => AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolver;
        
        private Assembly AssemblyResolver(object sender, ResolveEventArgs args)
        {
            var askedAssembly = new AssemblyName(args.Name);
            lock (this)
            {
                var stream = _assembly.GetManifestResourceStream($"{Name}.Embedded.Assemblies.{askedAssembly.Name}.dll");
                if (stream == null) return null;

                Assembly assembly = null;
                try
                {
                    var assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    assembly = Assembly.Load(assemblyData);
                }
                catch (Exception e)
                {
                    throw new Exception($"Loading embedded assembly: {askedAssembly.Name}{Environment.NewLine}Has thrown a unhandled exception: {e}");
                }
                return assembly;
            }
        }
    }
}
