using System.Collections;

namespace stack_minimumov
{
    public class StackMinimumov<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _items;
        private T[] _minimums;
        private const int _defaultCapacity = 4;

        public int Count { get; private set; }
        public bool IsEmpty { get => Count == 0; }

        public StackMinimumov()
        {
            _items = new T[_defaultCapacity];
            _minimums = new T[_defaultCapacity];

            Count = 0;
        }
        public StackMinimumov(int capacity)
        {
            _items = new T[capacity];
            _minimums = new T[capacity];

            Count = 0;
        }
        public StackMinimumov(IEnumerable<T> items)
        {
            _items = new T[items.Count()];
            _minimums = new T[items.Count()];
            foreach (var item in items)
            {
                Push(item);
            }

            Count = items.Count();
        }

        public void Push(T item)
        {
            if (Count == _items.Length)
            {
                Array.Resize(ref _items, Count * 2);
                Array.Resize(ref _minimums, Count * 2);
            }
            _items[Count] = item;
            _minimums[Count] = (item.CompareTo(_minimums[Count - 1]) < 0)
                ? item
                : _minimums[Count - 1];

            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _items[Count - 1];
        }
        public bool TryPeek(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }

            result = Peek();
            return true;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T item = _items[Count - 1];
            _items[Count - 1] = default;
            _minimums[Count - 1] = default;
            Count--;

            return item;
        }
        public bool TryPop(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }

            result = Pop();
            return true;
        }

        public void Clear()
        {
            _items = new T[_defaultCapacity];
            _minimums = new T[_defaultCapacity];

            Count = 0;
        }

        public bool Contains(T item)
        {
            bool found = false;

            for (int i = Count - 1; i >= 0; i--)
            {
                if (_items[i].Equals(item))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public T Min()
        {
            return _minimums[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}