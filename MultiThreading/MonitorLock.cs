namespace MultiThreading;

public class MonitorLock
{
    static object lockObject = new object();

    public static void Main()
    {
        Console.WriteLine("\nMonitor and Lock");

        // TryEnter attempts to acquire the lock and returns immediately if unsuccessful
        if (Monitor.TryEnter(lockObject))
        {
            try
            {
                Console.WriteLine("Inside critical section.");
                Thread.Sleep(1000);
            }
            finally
            {
                // Ensures lock is released even if exception occurs
                Monitor.Exit(lockObject);
            }
        }
        else
        {
            Console.WriteLine("Failed to enter critical section.");
        }
    }
}
