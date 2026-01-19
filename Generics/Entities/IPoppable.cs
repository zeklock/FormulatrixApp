namespace Generics.Entities;

// T is covariant (output position)
public interface IPoppable<out T> { T Pop(); }
