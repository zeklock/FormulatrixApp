using MultiThreading;

Console.WriteLine("Multi Threading");

CreatingAndNamingThreads();
ThreadStartDelegate();
ThreadStartLambda();
ThreadJoin();
RaceConditions.Main();
Deadlocks.Main();
MonitorLock.Main();
UsingMutex();
SemaphoreSync();
AutoResetEventSignal();
ThreadPoolLegacy.Main();

void CreatingAndNamingThreads()
{
    Console.WriteLine("\nCreating and Naming Threads");

    Console.WriteLine("Main Thread Started");

    // Creating threads with custom names for easier identification
    Thread t1 = new Thread(Method1) { Name = "Thread1" };
    Thread t2 = new Thread(Method2) { Name = "Thread2" };
    Thread t3 = new Thread(Method3) { Name = "Thread3" };

    // Begins execution of Method1 on Thread1
    t1.Start();
    // Begins execution of Method2 on Thread2
    t2.Start();
    // Begins execution of Method3 on Thread3
    t3.Start();

    Console.WriteLine("Main Thread Ended");
    // Keeps console open
    Console.Read();

    void Method1() { Console.WriteLine("Thread1"); }
    void Method2() { Thread.Sleep(10000); Console.WriteLine("Thread2"); }
    void Method3() { Console.WriteLine("Thread3"); }
}

void ThreadStartDelegate()
{
    Console.WriteLine("\nThread Start Delegate");

    ThreadStart obj = new ThreadStart(DisplayNumbers);
    Thread t1 = new Thread(obj);
    t1.Start();

    void DisplayNumbers() { Console.WriteLine("Numbers"); }
}

void ThreadStartLambda()
{
    Console.WriteLine("\nThread Start Lambda");

    Thread t1 = new Thread(() =>
    {
        Console.WriteLine("Running from a lambda thread");
    });
    t1.Start();
}

void ThreadJoin()
{
    Console.WriteLine("\nThread Join");

    Thread t1 = new Thread(ThreadMethod);
    t1.Start();
    // Main thread waits here until t1 completes
    t1.Join();

    Console.WriteLine("Thread t1 has finished executing.");

    // Checking thread status
    // Will be false
    Console.WriteLine("Is t1 alive? " + t1.IsAlive);
    Console.ReadLine();

    void ThreadMethod()
    {
        Console.WriteLine("ThreadMethod started.");
        // Simulate work
        Thread.Sleep(3000);
        Console.WriteLine("ThreadMethod finished.");
    }
}

void UsingMutex()
{
    Console.WriteLine("\nUsing Mutex");

    using (Mutex mutex = new Mutex(false, "MutexDemo"))
    {
        // Attempt to acquire the mutex for 5 seconds
        if (!mutex.WaitOne(5000, false))
        {
            Console.WriteLine("An instance is already running.");
            // Exit if another instance holds the mutex
            return;
        }
        Console.WriteLine("Application is running...");
        Console.ReadKey();
    }
}

void SemaphoreSync()
{
    Console.WriteLine("\nSemaphore");

    // Initialize semaphore with initial count 2 and maximum count 2
    Semaphore semaphore = new Semaphore(2, 2, "SemaphoreDemo");

    // Decrements count, blocks if count is zero
    semaphore.WaitOne();
    Console.WriteLine("Thread acquired the semaphore.");
    // Critical section code here... (up to 2 threads can be in this section)
    // Increments count
    semaphore.Release();
}

void AutoResetEventSignal()
{
    Console.WriteLine("\nAuto Reset Event Signal");

    // Initially non-signaled
    AutoResetEvent autoEvent = new AutoResetEvent(false);

    // In one thread (e.g., a worker thread):
    Console.WriteLine("Waiting for signal...");
    // Blocks until signal is received
    autoEvent.WaitOne();
    Console.WriteLine("Received signal, proceeding...");

    // In another thread (e.g., the main thread or another worker):
    // Signals the waiting thread
    autoEvent.Set();
}
