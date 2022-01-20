namespace HourBoostr_Beta.Core
{
    internal class Utils
    {
    }
}

//Workaround: compiler throws error (Predefined type 'System.Runtime.CompilerServices.IsExternalInit' is not defined or imported)
//because we're compiling .NET 5 features in .NET Framework
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}