namespace MultiThreading;

public class ThreadPoolLegacy
{
    public static void Main()
    {
        Console.WriteLine("\nThread Pool Legacy");

        for (int i = 0; i < 10; i++)
        {
            // Queues MyMethod to run on a thread pool thread
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod));
        }
        Console.Read();
    }

    public static void MyMethod(object? state)
    {
        Thread current = Thread.CurrentThread;
        Console.WriteLine($"Background: {current.IsBackground}, Thread Pool: {current.IsThreadPoolThread}, Thread ID: {current.ManagedThreadId}");
    }
}
