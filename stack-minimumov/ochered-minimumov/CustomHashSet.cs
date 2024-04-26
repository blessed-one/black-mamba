using System.Collections;
using System.Data;

namespace ochered_minimumov;

public class CustomHashSet<T>: IEnumerable<T> where T : IComparable<T>
{
    private const int _startSize = 5;
    private LinkedList<T>[] _hashset = new LinkedList<T>[_startSize];
    public int Count { get; set; }
    private T _minimum;

    public T Minimum
    {
        get
        {
            return _minimum;
        }
    }

    private T GetMinimum(T firstVal, T secondVal)
    {
        return firstVal.CompareTo(secondVal) > 0 ? secondVal : firstVal;
    }
    public bool Contains(T item)
    {
        return _hashset[item.GetHashCode() % _hashset.Length].Contains(item);
    }

    public void Add(T item)
    {
        if (!Contains(item))
        {
            if (Count == _hashset.Length)
            {
                var newHashset = new LinkedList<T>[_hashset.Length * 2];
                for (int i = 0; i < _hashset.Length; i++)
                {
                    foreach (var oldItem in _hashset[i])
                    {
                        newHashset[oldItem.GetHashCode() % (_hashset.Length * 2)].AddLast(oldItem);
                    }
                }
                _hashset = newHashset;
            }

            _hashset[item.GetHashCode() % _hashset.Length].AddLast(item);
            Count++;
        }
    }

    public T Remove(T item)
    {
        if (!Contains(item))
            throw new DataException("No Data in HashSet");
        _hashset[item.GetHashCode() % _hashset.Length].Remove(item);
        Count--;
        return item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _hashset.Length; i++)
        {
            foreach (var item in _hashset[i])
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override int GetHashCode()
    {
        return _hashset.SelectMany(bucket => bucket)
            .Aggregate(0, (sum, item) => sum + item.GetHashCode() * 307);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is CustomHashSet<T>))
        {
            return false;
        }

       CustomHashSet<T> other = (CustomHashSet<T>)obj;
       return this.GetHashCode() == other.GetHashCode();
    }
}