using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace HourBoostr
{
    /*
     * Credits for this part goes to JustArchi at:
     * https://github.com/JustArchi/ArchiSteamFarm
     */

    class ConcurrentEnumerator<T> : IEnumerator<T>
    {
        public T Current => Enumerator.Current;

        private readonly IEnumerator<T> Enumerator;
        private readonly ReaderWriterLockSlim Lock;

        object IEnumerator.Current => Current;

        internal ConcurrentEnumerator(ICollection<T> collection, ReaderWriterLockSlim rwLock)
        {
            if ((collection == null) || (rwLock == null))
            {
                throw new ArgumentNullException(nameof(collection) + " || " + nameof(rwLock));
            }

            rwLock.EnterReadLock();

            Lock = rwLock;
            Enumerator = collection.GetEnumerator();
        }

        public void Dispose() => Lock?.ExitReadLock();

        public bool MoveNext() => Enumerator.MoveNext();
        public void Reset() => Enumerator.Reset();
    }
}
