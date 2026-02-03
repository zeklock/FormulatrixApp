namespace MultiThreading;

public class Deadlocks
{
    static readonly object lock1 = new object();
    static readonly object lock2 = new object();

    public static void Main()
    {
        Console.WriteLine("\nDeadlocks");

        Thread t1 = new Thread(DeadlockMethod1);
        Thread t2 = new Thread(DeadlockMethod2);
        t1.Start();
        t2.Start();
    }

    static void DeadlockMethod1()
    {
        // Thread 1 acquires lock1
        lock (lock1)
        {
            // Simulates work
            Thread.Sleep(1000);

            // Thread 1 tries to acquire lock2
            lock (lock2)
            {
                Console.WriteLine("Thread 1 acquired lock2");
            }
        }
    }

    static void DeadlockMethod2()
    {
        // Thread 2 acquires lock2
        lock (lock2)
        {
            // Simulates work
            Thread.Sleep(1000);

            // Thread 2 tries to acquire lock1
            lock (lock1)
            {
                Console.WriteLine("Thread 2 acquired lock1");
            }
        }
    }
}
