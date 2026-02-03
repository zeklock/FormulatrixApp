using Threading;

Console.WriteLine("Threading");

StartingThread();
JoinThread();
SleepThread();
LocalVariables();
SharedState();
ThreadSafe.Main();
PassingDataLambda();
PassingDataParameterized();
CaputedVariables();
ExceptionHandling();
Signaling();
TheThreadPool();

void StartingThread()
{
    Console.WriteLine("\nStarting Thread");

    // Create a new thread, instructing it to run WriteY()
    Thread t = new Thread(WriteY);

    // Start the new thread's execution
    t.Start();

    // Meanwhile, the main thread continues its own work
    for (int i = 0; i < 1000; i++) Console.Write("x");
}

void WriteY()
{
    for (int i = 0; i < 1000; i++) Console.Write("y");
}

void JoinThread()
{
    Console.WriteLine("\nJoin Thread");

    Thread t = new Thread(Go);
    t.Start();
    // Main thread waits until 't' finishes
    t.Join();
    Console.WriteLine("Thread t has ended!");
}

void Go()
{
    for (int i = 0; i < 1000; i++) Console.Write("Go!");
}

void SleepThread()
{
    Console.WriteLine("\nSleep Thread");

    Thread t = new Thread(Go);
    t.Start();
    Thread.Sleep(2000);

    Console.WriteLine("Thread t has ended!");
}

void LocalVariables()
{
    Console.WriteLine("\nLocal Variables");

    new Thread(Go).Start();
    Go();

    void Go()
    {
        for (int cycles = 0; cycles < 5; cycles++) Console.Write("?");
    }
}

void SharedState()
{
    Console.WriteLine("\nShared State");

    bool _done = false;
    new Thread(Go).Start();
    Go();

    void Go()
    {
        if (!_done) { _done = true; Console.WriteLine("Done"); }
    }
}

void PassingDataLambda()
{
    Console.WriteLine("\nPassing Data Lambda");

    Thread t = new Thread(() => Print("Hello from t!"));
    t.Start();

    void Print(string message) => Console.WriteLine(message);
}

void PassingDataParameterized()
{
    Console.WriteLine("\nPassing Data Parameterized");

    Thread t = new Thread(Print);
    t.Start("Hello from t!");

    void Print(object messageObj)
    {
        // Requires casting
        string message = (string)messageObj;
        Console.WriteLine(message);
    }
}

void CaputedVariables()
{
    Console.WriteLine("\nCaptured Variables");

    Console.WriteLine("Without temporary variable");
    for (int i = 0; i < 10; i++)
        new Thread(() => Console.Write(i)).Start();

    Console.WriteLine("\nWith temporary variable");
    for (int i = 0; i < 10; i++)
    {
        int temp = i;
        new Thread(() => Console.Write(temp)).Start();
    }
}

void ExceptionHandling()
{
    Console.WriteLine("\nException Handling");

    new Thread(Go).Start();

    void Go()
    {
        try
        {
            throw null;
        }
        catch (Exception)
        {
            Console.WriteLine("Exception catch");
        }
    }
}

void Signaling()
{
    Console.WriteLine("\nSignaling");

    // Initially closed
    var signal = new ManualResetEvent(false);

    new Thread(() =>
    {
        Console.WriteLine("Waiting for signal...");
        // Block until signal.Set() is called
        signal.WaitOne();
        // Release the event
        signal.Dispose();
        Console.WriteLine("Got signal!");
    }).Start();

    // Simulate some work on the main thread
    Thread.Sleep(2000);
    // Signal the waiting thread
    signal.Set();
}

void TheThreadPool()
{
    Console.WriteLine("\nThe Thread Pool");

    // Recommended for modern C#
    Task.Run(() => Console.WriteLine("Hello from the thread pool"));

    // Legacy
    ThreadPool.QueueUserWorkItem(notUsed => Console.WriteLine("Hello from QueueUserWorkItem"));
}
