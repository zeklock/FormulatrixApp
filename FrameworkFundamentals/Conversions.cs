using System.Xml;

namespace FrameworkFundamentals;

public class Conversions
{
    public static void Main()
    {
        Console.WriteLine("\nOther Conversion");

        RoundingReal();
        ParsingNumberBase();
        DynamicConversions();
        XmlSpecific();
        BinaryConversions();
    }

    static void RoundingReal()
    {
        Console.WriteLine("\nRounding Real to Integral");

        double d1 = 3.9;
        // i1 == 4 (rounds up)
        int i1 = Convert.ToInt32(d1);
        Console.WriteLine($"Rounding 3.9: {i1}");

        double d2 = 3.2;
        // i2 == 3 (rounds down)
        int i2 = Convert.ToInt32(d2);
        Console.WriteLine($"Rounding 3.2: {i2}");


        double d3 = 3.5;
        // i3 == 4 (banker's rounding: rounds to nearest even number)
        int i3 = Convert.ToInt32(d3);
        Console.WriteLine($"banker's rounding 3.5: {i3}");

        double d4 = 4.5;
        // i4 == 4 (banker's rounding: rounds to nearest even number)
        int i4 = Convert.ToInt32(d4);
        Console.WriteLine($"banker's rounding 4.5: {i4}");
    }

    static void ParsingNumberBase()
    {
        Console.WriteLine("\nParsing Number Base");

        // Parses "1E" as a hexadecimal (base 16) number: thirty == 30
        int thirty = Convert.ToInt32("1E", 16);
        Console.WriteLine($"1E hexadecimal: {thirty}");

        // Parses "101" as a binary (base 2) number: five == 5
        uint five = Convert.ToUInt32("101", 2);
        Console.WriteLine($"101 binary: {five}");
    }

    static void DynamicConversions()
    {
        Console.WriteLine("\nDynamic Conversions");

        Type targetType = typeof(int);
        object source = "42";
        object result = Convert.ChangeType(source, targetType);

        Console.WriteLine($"source: {source} ({source.GetType()})");
        Console.WriteLine($"result: {result} ({result.GetType()})");
    }

    static void XmlSpecific()
    {
        Console.WriteLine("\nXML Specific Convert");

        string s = XmlConvert.ToString(true);
        bool isTrue = XmlConvert.ToBoolean(s);
        Console.WriteLine($"boolean to xml string: {s}");
        Console.WriteLine($"string to xml boolean: {isTrue}");
    }

    static void BinaryConversions()
    {
        Console.WriteLine("\nBinary Conversion");

        double d = 3.5;
        Console.WriteLine($"double: {d}");
        Console.Write("bytes: ");

        foreach (byte b in BitConverter.GetBytes(d))
        {
            // Output depends on endianness of your system (e.g., 0 0 0 0 0 0 12 64)
            Console.Write(b + " ");
        }
        Console.WriteLine();

        // Example bytes for 3.5 (little-endian)
        byte[] bytes = new byte[] { 0, 0, 0, 0, 0, 0, 12, 64 };
        Console.Write("bytes: ");

        foreach (byte b in bytes)
        {
            Console.Write(b + " ");
        }
        Console.WriteLine();

        // restoredDouble = 3.5
        double restoredDouble = BitConverter.ToDouble(bytes, 0);
        Console.WriteLine($"double: {restoredDouble}");
    }
}
