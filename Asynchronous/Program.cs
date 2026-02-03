Console.WriteLine("Asynchronous");

// DisplayPrimeCounts();
// await DisplayPrimeCountsAsync();
// await Foo(CancellationToken.None);
// var progress = new Progress<int>(i => Console.WriteLine($"Progress: {i}%"));
// await ProgressRerporting(progress);
await TaskWhenAnyAsync();
await TaskWhenAllAsync();

int GetPrimesCount(int start, int count)
{
    // Computes prime numbers using ParallelEnumerable
    return ParallelEnumerable.Range(start, count).Count(n =>
        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
}

void DisplayPrimeCounts()
{
    Console.WriteLine("\nDisplay Prime Counts");

    for (int i = 0; i < 10; i++)
        Console.WriteLine(GetPrimesCount(i * 1000000 + 2, 1000000) +
            " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
    Console.WriteLine("Done!");
}

Task<int> GetPrimesCountAsync(int start, int count)
{
    // Offloads computation to a thread pool thread
    return Task.Run(() =>
        ParallelEnumerable.Range(start, count).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
}

async Task DisplayPrimeCountsAsync()
{
    Console.WriteLine("\nDisplay Prime Counts Async");

    for (int i = 0; i < 10; i++)
        // 'await' pauses execution here
        Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000) +
            " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
    Console.WriteLine("Done!");
}

async Task Foo(CancellationToken cancellationToken)
{
    Console.WriteLine("\nCancellation Token");

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(i);
        // Pass the token to Task.Delay, which internally monitors for cancellation
        await Task.Delay(1000, cancellationToken);
        // No explicit ThrowIfCancellationRequested is needed here if Task.Delay handles it
    }
}

async Task ProgressRerporting(IProgress<int> onProgressPercentChanged)
{
    Console.WriteLine("\nProgress Rerporting");

    await Task.Run(() =>
    {
        for (int i = 0; i < 1000; i++)
        {
            if (i % 10 == 0) onProgressPercentChanged.Report(i / 10);
            // Simulate compute-bound work
            Thread.Sleep(1);
        }
    });
}

async Task TaskWhenAnyAsync()
{
    Console.WriteLine("\nTask WhenAny");

    async Task<int> Delay1() { await Task.Delay(1000); return 1; }
    async Task<int> Delay2() { await Task.Delay(2000); return 2; }
    async Task<int> Delay3() { await Task.Delay(3000); return 3; }

    // Example usage:
    Task<int> winningTask = await Task.WhenAny(Delay1(), Delay2(), Delay3());
    // Output: 1 (after ~1 second)
    Console.WriteLine($"winningTask: {await winningTask}");
}

async Task TaskWhenAllAsync()
{
    Console.WriteLine("\nTask WhenAll");

    async Task<int> Delay1() { await Task.Delay(1000); return 1; }
    async Task<int> Delay2() { await Task.Delay(2000); return 2; }
    async Task<int> Delay3() { await Task.Delay(3000); return 3; }

    // Completes after ~3 seconds
    await Task.WhenAll(Delay1(), Delay2(), Delay3());
    Console.WriteLine("All delays complete!");

    Task<int> task1 = Task.Run(() => 1);
    Task<int> task2 = Task.Run(() => 2);
    // results will be {1, 2}
    int[] results = await Task.WhenAll(task1, task2);
    Console.WriteLine($"results: {string.Join(", ", results)}");
}
