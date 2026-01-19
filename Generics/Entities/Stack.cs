namespace Generics.Entities;

// Declares a type parameter T
public class Stack<T> : IPoppable<T>, IPushable<T>
{
    int position;
    // Array of type T
    T[] data = new T[100];

    // Accepts type T
    public void Push(T obj) => data[position++] = obj;
    // Returns type T
    public T Pop() => data[--position];
}
