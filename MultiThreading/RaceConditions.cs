namespace MultiThreading;

public class RaceConditions
{
    // A dedicated object for locking
    private static readonly object counterLock = new object();
    private static int counter = 0;

    public static void Main()
    {
        Console.WriteLine("\nWrite Conditions");

        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);
        t1.Start();
        t2.Start();

        Console.WriteLine($"Counter: {counter}");
    }

    public static void Increment()
    {
        // Only one thread can enter this block at a time using counterLock
        lock (counterLock)
        {
            // Critical section
            counter++;
        }
    }
}
