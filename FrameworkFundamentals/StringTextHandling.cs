using System.Text;

namespace FrameworkFundamentals;

public class StringTextHandling
{
    public static void Main()
    {
        Console.WriteLine("\nString and Text Handling");

        CharUnicode();
        ConstructingStrings();
        NullEmptyStrings();
        AccessingCharacters();
        StringFormatInterpolated();
        StringEqualityComparison();
        MutableStrings();
        EncodingUnicode();
    }

    static void CharUnicode()
    {
        Console.WriteLine("\nChar Unicode");

        char c = 'c';
        char newLine = '\n';
        Console.WriteLine($"c ToUpper: {char.ToUpper(c)}");
        Console.WriteLine(@$"\n IsWhiteSpace: {char.IsWhiteSpace(newLine)}");

        // Culture Sensitivity Caution
        Console.WriteLine($"i ToUpperInvariant: {char.ToUpperInvariant('i')}");
    }

    static void ConstructingStrings()
    {
        Console.WriteLine("\nConstructing Strings");

        // Literal
        string s1 = "Hello";
        string s2 = "First Line\r\nSecond Line";
        string s3 = @"C:\Path\File.txt";
        Console.WriteLine($"string Hello: {s1}");
        Console.WriteLine($"Escape Sequence: {s2}");
        Console.WriteLine($"Verbatim string literal: {s3}");

        // Repeating Characters
        Console.WriteLine($"new string * 10: {new string('*', 10)}");

        // Char array
        char[] ca = "Hello".ToCharArray();
        string s = new string(ca);
        Console.WriteLine($"From char array: {s}");
    }

    static void NullEmptyStrings()
    {
        Console.WriteLine("\nNull vs Empty Strings");

        // Empty string
        string empty = "";
        Console.WriteLine($"Empty string: {empty}");
        Console.WriteLine($"Length == 0: {empty.Length == 0}");
        Console.WriteLine($"empty == string.Empty: {empty == string.Empty}");

        // Null string
        string? nullString = null;
        Console.WriteLine($"Null string: {nullString}");
        Console.WriteLine($"nullString == null: {nullString == null}");
        Console.WriteLine(@$"nullString == "": {nullString == ""}");
        Console.WriteLine($"nullString length: {nullString?.Length}");
        Console.WriteLine($"nullString IsNullOrEmpty: {string.IsNullOrEmpty(nullString)}");
    }

    static void AccessingCharacters()
    {
        Console.WriteLine("\nAccessing Characters");

        // Indexer
        string str = "abcde";
        char letter = str[1];
        Console.WriteLine($"abcde index 1: {letter}");

        // foreach
        Console.Write($"foreach 123: ");
        foreach (char c in "123")
            Console.Write($"{c},");

        Console.WriteLine();
    }

    static void StringFormatInterpolated()
    {
        Console.WriteLine("\nString Format and Interpolated Strings");

        // String Format
        string composite = "It's {0} degrees in {1} on this {2} morning";
        string s = string.Format(composite, 35, "Perth", DateTime.Now.DayOfWeek);
        Console.WriteLine($"String format: {s}");

        // Interpolated
        string s2 = $"It's hot this {DateTime.Now.DayOfWeek} morning";
        Console.WriteLine($"String interpolated: {s2}");

        // You can still use alignment and format strings:
        Console.WriteLine($"Name={"Mary",-20} Credit Limit={500,15:C}");
    }

    static void StringEqualityComparison()
    {
        Console.WriteLine("\nString Equality Comparison");

        Console.WriteLine($"string equals foo FOO OrdinalIgnoreCase: {string.Equals("foo", "FOO", StringComparison.OrdinalIgnoreCase)}");
    }

    static void MutableStrings()
    {
        Console.WriteLine("\nMutable Strings");

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < 50; i++)
        {
            sb.Append(i).Append(',');
        }

        Console.WriteLine($"StringBuilder: {sb.ToString()}");
    }

    static void EncodingUnicode()
    {
        Console.WriteLine("\nEncoding Unicode");

        // Writes in UTF-16
        File.WriteAllText("data.txt", "Testing...", Encoding.Unicode);

        // Convert Byte Arrays
        byte[] utf8Bytes = Encoding.UTF8.GetBytes("0123456789");
        byte[] utf16Bytes = Encoding.Unicode.GetBytes("0123456789");
        string original1 = Encoding.UTF8.GetString(utf8Bytes);
        Console.WriteLine($"utf8Bytes: {utf8Bytes}");
        Console.WriteLine($"utf8Bytes: {utf16Bytes}");
        Console.WriteLine($"utf8Bytes: {original1}");
    }
}
