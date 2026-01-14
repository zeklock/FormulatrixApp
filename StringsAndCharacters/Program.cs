// Strings and Characters
Console.WriteLine("Strings and Characters");

// CharType();
// StringType();
RawStringLiterals();

static void CharType()
{
    Console.WriteLine("\nChar Type");

    char c = 'A';
    Console.WriteLine($"c: {c}");

    char copyrightSymbol = '\u00A9'; // Unicode for (c)
    char omegaSymbol = '\u03A9'; // Unicode for Ω
    char newLine = '\u000A'; // Unicode for Line Feed (same as \n)
    Console.WriteLine($"copyrightSymbol: {copyrightSymbol}");
    Console.WriteLine($"omegaSymbol: {omegaSymbol}");
    Console.WriteLine($"This is the first line.{newLine}This is the second line.");
}

static void StringType()
{
    Console.WriteLine("\nString Type");

    string a = "test";
    string b = "test";
    Console.WriteLine($"a: {a}");
    Console.WriteLine($"b: {b}");
    Console.WriteLine($"a == b: {a == b}");

    string a0 = "Here's a tab:\t";
    string a1 = "\\\\server\\fileshare\\helloworld.cs";
    string a2 = @"\\server\fileshare\helloworld.cs";
    Console.WriteLine($"a0: {a0}");
    Console.WriteLine($"a1: {a1}");
    Console.WriteLine($"a2: {a2}");

    string escaped = "First Line\r\nSecond Line";
    string verbatim = @"First Line
Second Line";
    Console.WriteLine($"escaped: {escaped}");
    Console.WriteLine($"verbatim: {verbatim}");
    Console.WriteLine($"escaped == verbatim: {escaped == verbatim}");

    string xml = $@"<root attribute=""{a}""/>";
    Console.WriteLine($"xml: {xml}");
}

static void RawStringLiterals()
{
    Console.WriteLine("\nRaw String Literals");

    string raw = """This string contains "double quotes" without escaping.""";
    string raw2 = """"The """ sequence denotes raw string literals."""";
    Console.WriteLine($"raw: {raw}");
    Console.WriteLine($"raw2: {raw2}");
    Console.WriteLine("""
    {
        "Name" : "Joe"
    }
    """);
}
