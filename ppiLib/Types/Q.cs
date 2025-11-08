using System.Numerics;

namespace ppiLib.Types;

/// <summary>
/// Also known as UDim (t). 
/// Q - using reference, scale, and offset, derive derived.
/// Reference (in absolute, world values)
/// Scale (in relative, local, 0 to 1 values)
/// Offset (in absolute, world values)
/// Derived (in absolute, world values)
/// </summary>
/// <typeparam name="T"></typeparam>
public class Q<T> where T : IAdditionOperators<T, T, T>, IMultiplyOperators<T, T, T>
{
    private T _scale;
    private T _offset;
    private T _reference;
    
    public Q (T scale, T offset, T reference)
    {
        Update(scale, offset, reference);
    }

    public void Update (T scale, T offset, T reference)
    {
        _scale = scale;
        _offset = offset;
        _reference = reference;
        Derived = scale * reference + offset;
    }
    
    public T Scale
    {
        get => _scale;
        set => Update(value, Offset, Reference); 
    }

    public T Offset
    {
        get => _offset; 
        set => Update(Scale, value, Reference);
    }

    public T Reference
    {
        get => _reference; 
        set => Update(Scale, Offset, value);
    }

    public T Derived
    {
        get;
        private set;
    }
    
    
}