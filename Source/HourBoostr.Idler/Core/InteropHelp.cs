using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HourBoostr.Idler.Core
{
    public class InteropHelp
    {
        public static string DecodeANSIReturn(string buffer) => Encoding.UTF8.GetString(Encoding.Default.GetBytes(buffer));

        public static TClass CastInterface<TClass>(IntPtr address) where TClass : INativeWrapper, new()
        {
            if (address == IntPtr.Zero) return default(TClass);
            var rez = new TClass();
            rez.SetupFunctions(address);
            return rez;
        }

        public interface INativeWrapper
        {
            void SetupFunctions(IntPtr objectAddress);
        }

        public abstract class NativeWrapper<TNativeFunctions> : INativeWrapper
        {
            protected IntPtr ObjectAddress;
            protected TNativeFunctions Functions;
            private Dictionary<IntPtr, Delegate> FunctionCache = new Dictionary<IntPtr, Delegate>();
            public IntPtr Interface { get => ObjectAddress; }

            public void SetupFunctions(IntPtr objectAddress)
            {
                ObjectAddress = objectAddress;
                IntPtr vtableptr = Marshal.ReadIntPtr(ObjectAddress);
                Functions = (TNativeFunctions)Marshal.PtrToStructure(vtableptr, typeof(TNativeFunctions));
            }
            protected Delegate GetDelegate<TDelegate>(IntPtr pointer)
            {
                Delegate function;
                if (FunctionCache.ContainsKey(pointer) == false)
                {
                    function = Marshal.GetDelegateForFunctionPointer(pointer, typeof(TDelegate));
                    FunctionCache[pointer] = function;
                }
                else 
                    function = FunctionCache[pointer];

                return function;
            }
            protected TDelegate GetFunction<TDelegate>(IntPtr pointer) where TDelegate : class => (TDelegate)((object)GetDelegate<TDelegate>(pointer));
            protected void Call<TDelegate>(IntPtr pointer, params object[] args) => GetDelegate<TDelegate>(pointer).DynamicInvoke(args);
            protected TReturn Call<TReturn, TDelegate>(IntPtr pointer, params object[] args) => (TReturn)GetDelegate<TDelegate>(pointer).DynamicInvoke(args);
            public override string ToString() => string.Format("Steam Interface<{0}> #{1:X8}", typeof(TNativeFunctions), ObjectAddress.ToInt32());
        }

        internal class BitVector64
        {
            private ulong data;
            public BitVector64() { }
            public BitVector64(ulong value) => data = value;
            public ulong Data { get => data; set => data = value; }
            public ulong this[uint bitoffset, ulong valuemask]
            {
                get => (data >> (ushort)bitoffset) & valuemask;
                set => data = (data & ~(valuemask << (ushort)bitoffset)) | ((value & valuemask) << (ushort)bitoffset);
            }
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        internal class InterfaceVersionAttribute : Attribute
        {
            public string Identifier { get; set; }
            public InterfaceVersionAttribute(string versionIdentifier) => Identifier = versionIdentifier;
        }

        [AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
        internal class CallbackIdentityAttribute : Attribute
        {
            public int Identity { get; set; }
            public CallbackIdentityAttribute(int callbackNum) => Identity = callbackNum;
        }
    }
}