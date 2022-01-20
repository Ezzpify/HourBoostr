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

    class ConcurrentHashSet<T> : ICollection<T>, IDisposable
    {
        public int Count
        {
            get
            {
                Lock.EnterReadLock();

                try
                {
                    return HashSet.Count;
                }
                finally
                {
                    Lock.ExitReadLock();
                }
            }
        }

        public bool IsReadOnly => false;

        private readonly HashSet<T> HashSet = new HashSet<T>();
        private readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();

        public void Clear()
        {
            Lock.EnterWriteLock();

            try
            {
                HashSet.Clear();
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }

        public bool Contains(T item)
        {
            Lock.EnterReadLock();

            try
            {
                return HashSet.Contains(item);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Lock.EnterReadLock();

            try
            {
                HashSet.CopyTo(array, arrayIndex);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public void Dispose() => Lock.Dispose();
        public IEnumerator<T> GetEnumerator() => new ConcurrentEnumerator<T>(HashSet, Lock);

        public bool Remove(T item)
        {
            Lock.EnterWriteLock();

            try
            {
                return HashSet.Remove(item);
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }

        void ICollection<T>.Add(T item) => Add(item);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal void Add(T item)
        {
            Lock.EnterWriteLock();

            try
            {
                HashSet.Add(item);
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }

        internal void ClearAndTrim()
        {
            Lock.EnterWriteLock();

            try
            {
                HashSet.Clear();
                HashSet.TrimExcess();
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }

        internal bool ReplaceIfNeededWith(ICollection<T> items)
        {
            Lock.EnterUpgradeableReadLock();

            try
            {
                if (HashSet.SetEquals(items))
                {
                    return false;
                }

                ReplaceWith(items);
                return true;
            }
            finally
            {
                Lock.ExitUpgradeableReadLock();
            }
        }

        internal void ReplaceWith(IEnumerable<T> items)
        {
            Lock.EnterWriteLock();

            try
            {
                HashSet.Clear();

                foreach (T item in items)
                {
                    HashSet.Add(item);
                }

                HashSet.TrimExcess();
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
    }
}
