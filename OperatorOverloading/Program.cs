using OperatorOverloading;

Console.WriteLine("Operator Overloading");

const string semitone = "semitone(s) from A";

OperatorFunctions();
OperatorConversions();

static void OperatorFunctions()
{
    Console.WriteLine("\nOperator Functions");

    Note B = new Note(2);
    Console.WriteLine($"Note B: {B.Value} {semitone}");

    Note CSharp = B + 2;
    Console.WriteLine($"Note C#: {CSharp.Value} {semitone}");

    CSharp += 2;
    Console.WriteLine($"Note D#: {CSharp.Value} {semitone}");

    // Note other = checked(B + int.MaxValue);
    // Console.WriteLine($"Note other: {other.Value} {semitone}");
}

static void OperatorConversions()
{
    Console.WriteLine("\nImplicit Explicit Conversions");

    double f = 554.37;
    Console.WriteLine($"Note Frequency: {f}");

    Note n = (Note)f;
    Console.WriteLine($"Explicit Double to Note: {n.Value} {semitone}");

    double x = n;
    Console.WriteLine($"Implicit Note to Double: {x}");
}
