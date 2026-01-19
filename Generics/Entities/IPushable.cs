namespace Generics.Entities;

// T is contravariant (input position)
public interface IPushable<in T> { void Push(T obj); }
