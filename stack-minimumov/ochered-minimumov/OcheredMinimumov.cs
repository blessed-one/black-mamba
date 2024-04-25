using System.Collections;
using stack_minimumov;

namespace ochered_minimumov;

public class OcheredMinimumov<T>:IEnumerable<T> where T : IComparable<T>
{
    private StackMinimumov<T> _inStack = new StackMinimumov<T>();
    private StackMinimumov<T> _outStack = new StackMinimumov<T>();
    public int Count
    {
        get
        {
            return _inStack.Count + _outStack.Count;
        }
    }
    public void Push(T data)
    {
        _inStack.Push(data);
    }

    public T Pop()
    {
        if (_outStack.IsEmpty)
        {
            while (!_inStack.IsEmpty)
            {
                _outStack.Push(_inStack.Pop());
            }
        }
        return _outStack.Pop();
    }

    public T GetFirst()
    {
        if (_outStack.IsEmpty && _inStack.IsEmpty)
        {
            throw new InvalidOperationException();
        }

        return (!_inStack.IsEmpty) ? _inStack.GetFirst() : _outStack.Peek();
    }

    public T GetLast()
    {
        if (_outStack.IsEmpty && _inStack.IsEmpty)
        {
            throw new InvalidOperationException();
        }

        return (!_outStack.IsEmpty) ? _outStack.GetFirst() : _inStack.Peek();
    }

    public T GetMinimum()
    {
        if (_outStack.IsEmpty && _inStack.IsEmpty)
        {
            throw new InvalidOperationException();
        }

        return (!_inStack.IsEmpty && !_outStack.IsEmpty)? GetMinimum(_inStack.Min(), _outStack.Min()):
            (!_inStack.IsEmpty && _outStack.IsEmpty) ? _inStack.Min():
            _outStack.Min();
    }

    private T GetMinimum(T firstVal, T secondVal)
    {
        return firstVal.CompareTo(secondVal) > 0 ? secondVal: firstVal;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach(var item in _inStack)
        {
            yield return item;
        }

        while (!_outStack.IsEmpty)
        {
            yield return _outStack.Pop();
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}