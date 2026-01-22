namespace FrameworkFundamentals;

public class DatesTimes
{
    public static void Main()
    {
        Console.WriteLine("\nDates and Times");

        IntervalTime();
    }

    static void IntervalTime()
    {
        Console.WriteLine("\nAn Interval of Time");

        // 02:30:00 (2 hours, 30 minutes, 0 seconds)
        Console.WriteLine(new TimeSpan(2, 30, 0));
        // 02:30:00
        Console.WriteLine(TimeSpan.FromHours(2.5));
        // -02:30:00
        Console.WriteLine(TimeSpan.FromHours(-2.5));

        // 02:30:00
        TimeSpan duration = TimeSpan.FromHours(2) + TimeSpan.FromMinutes(30);
        Console.WriteLine($"duration: {duration.ToString()}");
        // 9.23:59:59
        TimeSpan nearlyTenDays = TimeSpan.FromDays(10) - TimeSpan.FromSeconds(1);
        Console.WriteLine($"nearlyTenDays: {nearlyTenDays.TotalDays}");
    }
}
