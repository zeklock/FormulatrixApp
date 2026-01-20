namespace Delegates;

public delegate TResult Transformer<TArg, TResult>(TArg arg);

public delegate void ProgressReporter(int percentComplete);

public class Util
{
    public static void HardWork(ProgressReporter p)
    {
        int progressStep = 10;
        int sleepTime = 100;

        for (int i = 0; i <= progressStep; i++)
        {
            p(i * progressStep);
            Thread.Sleep(sleepTime);
        }

        Console.WriteLine("Progress Complete!");
    }

    public static void Transform<T>(T[] values, Func<T, T> transformer)
    {
        for (int i = 0; i < values.Length; i++)
            values[i] = transformer(values[i]);
    }
}
