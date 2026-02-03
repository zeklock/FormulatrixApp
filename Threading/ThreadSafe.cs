namespace Threading;

class ThreadSafe
{
    static bool _done;
    // A dedicated object for locking
    static readonly object _locker = new object();

    public static void Main()
    {
        Console.WriteLine("\nLocking and Thread Safety");

        new Thread(Go).Start();
        Go();
    }

    static void Go()
    {
        // Only one thread can enter this block at a time for _locker
        lock (_locker)
        {
            if (!_done) { Console.WriteLine("Done"); _done = true; }
        }
    }
}
