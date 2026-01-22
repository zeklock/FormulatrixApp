using System.Globalization;
using FrameworkFundamentals.Formatter;

namespace FrameworkFundamentals;

public class FormattingParsing
{
    public static void Main()
    {
        Console.WriteLine("\nFormatting and Parsing");

        FormattingParsingExample();
        CultureSensitivity();
        FormatProviders();
        CustomFormatter();
    }

    static void FormattingParsingExample()
    {
        Console.WriteLine("\nFormatting and Parsing Example");

        // Boolean types
        string s = true.ToString();
        bool b = bool.Parse(s);
        Console.WriteLine($"boolean to string: {s}");
        Console.WriteLine($"string to boolean: {b}");

        // Numeric types
        bool failure = int.TryParse("qwerty", out int i1);
        bool success = int.TryParse("123", out int i2);
        Console.WriteLine($"parsing qwerty: {failure}, {i1}");
        Console.WriteLine($"parsing 123: {success}, {i2}");

        bool wasParsed = int.TryParse("456", out int result);
        // If you only care about success/failure and not the value:
        // Using a discard `_`
        bool isValidInput = int.TryParse("789", out int _);
        Console.WriteLine($"parsing 456: {wasParsed}, {result}");
        Console.WriteLine($"parsing 789: {isValidInput}");
    }

    static void CultureSensitivity()
    {
        Console.WriteLine("\nCulture Sensitivity");

        Console.WriteLine($"parsing 1.234: {double.Parse("1.234")}");
        Console.WriteLine($"parsing 1,234: {double.Parse("1,234")}");

        double x = double.Parse("1.234", CultureInfo.InvariantCulture);
        string y = 1.234.ToString(CultureInfo.InvariantCulture);
        Console.WriteLine($"parsing 1.234: {x}");
        Console.WriteLine($"parsing 1,234: {y}");
    }

    static void FormatProviders()
    {
        Console.WriteLine("\nFormat Providers");

        NumberFormatInfo f = new NumberFormatInfo();
        f.CurrencySymbol = "$$";
        Console.WriteLine(@$"3 dollars: {3.ToString("C", f)}");

        CultureInfo ukCulture = CultureInfo.GetCultureInfo("en-GB");
        Console.WriteLine(@$"3 pounds: {3.ToString("C", ukCulture)}");

        DateTime dt = new DateTime(2000, 1, 2);
        CultureInfo invariantCulture = CultureInfo.InvariantCulture;
        Console.WriteLine(dt.ToString(invariantCulture));
        Console.WriteLine(dt.ToString("d", invariantCulture));
    }

    static void CustomFormatter()
    {
        Console.WriteLine("\nCustom Formatter");

        double n = -123.45;
        IFormatProvider fp = new WordyFormatProvider();
        Console.WriteLine(string.Format(fp, "{0:C} in words is {0:W}", n));
    }
}
