using System.Collections;

namespace RXVBack.Concurrency
{
    public class ConcurrentQueue<T> : IEnumerable<T>, ICollection<T>
    {
        private readonly Queue<T> _queue;
        private readonly ReaderWriterLockSlim _lock;

        public ConcurrentQueue(IEnumerable<T> items)
        {
            _queue = new Queue<T>(items);
            _lock = new ReaderWriterLockSlim();
        }

        public ConcurrentQueue()
        {
            _queue = new Queue<T>();
            _lock = new ReaderWriterLockSlim();
        }
        public int Count
        {
            get
            {
                try
                {
                    _lock.EnterReadLock();
                    return _queue.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            try
            {
                _lock.EnterWriteLock();
                _queue.Enqueue(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Enqueue(T item)
        {
            try
            {
                _lock.EnterWriteLock();
                _queue.Enqueue(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public T Dequeue()
        {
            try
            {
                _lock.EnterReadLock();
                return _queue.Dequeue();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool TryDequeue(out T result)
        {
            try
            {
                _lock.EnterReadLock();
                return _queue.TryDequeue(out result);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                _lock.EnterReadLock();
                Queue<T> queue = new Queue<T>();
                foreach (T item in _queue)
                    queue.Enqueue(item);
                return queue;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public T Peek()
        {
            try
            {
                _lock.EnterReadLock();
                return _queue.Peek();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool TryPeek(out T result)
        {
            try
            {
                _lock.EnterReadLock();
                return _queue.TryPeek(out result);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void Clear()
        {
            try
            {
                _lock.EnterWriteLock();
                _queue.Clear();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public bool Contains(T item)
        {
            try
            {
                _lock.EnterReadLock();
                return _queue.Contains(item) ? true : false;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            try
            {
                _lock.EnterWriteLock();
                _queue.CopyTo(array, arrayIndex);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public IEnumerable<T> Enumerate()
        {
            try
            {
                _lock.EnterReadLock();
                foreach (T item in _queue)
                    yield return item;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public IEnumerator<T> GetEnumerator()
            => Enumerate().GetEnumerator();

        public bool Remove(T item) => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator()
            => Enumerate().GetEnumerator();
    }
}
