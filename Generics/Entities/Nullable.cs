namespace Generics.Entities;

// T is from the struct declaration
public struct Nullable<T>
{
    // Uses T
    public T Value { get; }
}
