Console.WriteLine("Tasks");

StartingTask();
WaitMethod();
ReturningValues();
ExecptionHandlingTasks();
Continuations();
TaskCompletionSourceMethod();

void StartingTask()
{
    Console.WriteLine("\nStarting a Task");

    Task.Run(() => Console.WriteLine("Foo"));
}

void WaitMethod()
{
    Console.WriteLine("\nWait Method");

    Task task = Task.Run(() =>
    {
        // Simulate work
        Thread.Sleep(2000);
        Console.WriteLine("Foo");
    });

    // Output: False (initially)
    Console.WriteLine($"task.IsCompleted: {task.IsCompleted}");
    // Blocks until task is complete
    task.Wait();
    // Output: True (after completion)
    Console.WriteLine($"task.IsCompleted: {task.IsCompleted}");
}

void ReturningValues()
{
    Console.WriteLine("\nReturningValues");

    Task<int> task = Task.Run(() => { Console.WriteLine("Calculating..."); return 3 + 2; });

    // ... other work on the current thread ...

    // Accesses the result; blocks if the task has not finished
    int result = task.Result;
    // Output: 5
    Console.WriteLine($"result 3 + 2: {result}");
}

void ExecptionHandlingTasks()
{
    Console.WriteLine("\nExecption Handling in Tasks");

    Task task = Task.Run(() => { throw new NullReferenceException("Oops!"); });

    try
    {
        task.Wait();
    }
    catch (AggregateException aex)
    {
        // Tasks wrap exceptions in an AggregateException
        if (aex.InnerException is NullReferenceException)
        {
            Console.WriteLine("NullReferenceException caught!");
        }
        else
        {
            // Re-throw other unexpected exceptions
            throw;
        }
    }
}

void Continuations()
{
    Console.WriteLine("\nContinuations");

    Task<int> primeNumberTask = Task.Run(() =>
        Enumerable.Range(2, 3000000).Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

    var awaiter = primeNumberTask.GetAwaiter();
    awaiter.OnCompleted(() =>
    {
        // Accesses result, rethrows exceptions directly
        int result = awaiter.GetResult();
        Console.WriteLine(result);
    });
}

void TaskCompletionSourceMethod()
{
    Console.WriteLine("\nTask Completion Source");

    Task<int> GetAnswerToLife()
    {
        var tcs = new TaskCompletionSource<int>();
        // Create a timer that will fire once after 5 seconds
        var timer = new System.Timers.Timer(5000) { AutoReset = false };
        timer.Elapsed += (sender, e) =>
        {
            // Clean up the timer
            timer.Dispose();
            // Manually complete the task with result 42
            tcs.SetResult(42);
        };
        timer.Start();
        // Return the controllable task
        return tcs.Task;
    }

    // Attach a continuation to print the result without blocking a thread
    GetAnswerToLife().GetAwaiter().OnCompleted(() =>
        Console.WriteLine(GetAnswerToLife().GetAwaiter().GetResult()));
}
