using System;

namespace SingleBoostr
{
    public interface INativeWrapper
    {
        void SetupFunctions(IntPtr objectAddress);
    }
}
