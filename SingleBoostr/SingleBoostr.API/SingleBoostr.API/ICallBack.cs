using System;

namespace SingleBoostr
{
    public interface ICallback
    {
        int Id { get; }

        bool Server { get; }

        void Run(IntPtr param);
    }
}
