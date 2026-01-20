namespace Delegates;

public class MulticastDelegates
{
    public static void Main()
    {
        Console.WriteLine("\nMulticast Delegates");

        Console.WriteLine("Press any key to start process ...");
        Console.ReadLine();

        ProgressReporter p = WriteProgressToConsole;
        p += WriteProgressToFile;

        Util.HardWork(p);
    }

    static void WriteProgressToConsole(int percentComplete) =>
    Console.WriteLine($"Console: {percentComplete}%");

    static void WriteProgressToFile(int percentComplete) =>
    File.WriteAllText("progress.txt", percentComplete.ToString());
}
