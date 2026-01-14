// Numeric Types

Console.WriteLine("Numeric Types");

// IntegralLiterals();
// RealLiterals();
// NumericLiteralTypeInference();
// NumericSuffixes();
// NumericConversions();
// IncrementDecrementOperators();
// SpecializedOperations();
// OverflowIntegral();
// OverflowCheckOperators();
// OverflowUncheckedOperators();
// BitIntegralTypes();
// SpecialValues();
RealRoundingErrors();

static void IntegralLiterals()
{
    Console.WriteLine("\nIntegral Literals");

    int x = 127;
    long y = 0x7F;
    Console.WriteLine($"x: {x}");
    Console.WriteLine($"y: {y}");

    int million = 1_000_000;
    var b = 0b1010_1011_1100_1101_1110_1111;
    Console.WriteLine($"million: {million}");
    Console.WriteLine($"b: {b}");
}

static void RealLiterals()
{
    Console.WriteLine("\nReal Literals");

    double d = 1.5;
    double million = 1E06;
    Console.WriteLine($"d: {d}");
    Console.WriteLine($"million: {million}");
}

static void NumericLiteralTypeInference()
{
    Console.WriteLine("\nNumeric Literal Type Inference");

    Console.WriteLine($"type of 1.0: {1.0.GetType()}");
    Console.WriteLine($"type of 1E06: {1E06.GetType()}");
    Console.WriteLine($"type of 1: {1.GetType()}");
    Console.WriteLine($"type of 0xF0000000: {0xF0000000.GetType()}");
    Console.WriteLine($"type of 0x100000000: {0x100000000.GetType()}");
}

static void NumericSuffixes()
{
    Console.WriteLine("\nNumeric Suffixes");
    // However, the F and M suffixes are crucial for float and decimal literals, respectively.
    // Without the F suffix, 4.5 would be inferred as a double, which cannot be implicitly
    // converted to a float, leading to a compile-time error.
    // Similarly, the M suffix is necessary for decimal literals.

    float f = 4.5F;
    // float f2 = 4.5;          // error
    decimal d = -1.23M;
    // decimal d2 = -1.23;      // error
    Console.WriteLine($"type of f: {f.GetType()}");
    // Console.WriteLine($"type of f2: {f2.GetType()}");
    Console.WriteLine($"type of d: {d.GetType()}");
    // Console.WriteLine($"type of d2: {d2.GetType()}");

}

static void NumericConversions()
{
    Console.WriteLine("\nNumeric Conversions");

    int x = 12345;           // 32-bit integer
    long y = x;              // Implicit conversion to 64-bit long (no data loss)
    short z = (short)x;      // Explicit conversion to 16-bit short (potential data loss)
    Console.WriteLine($"x: {x}");
    Console.WriteLine($"y: {y}");
    Console.WriteLine($"z: {z}");

    int i = 1;
    float f = i;            // Implicit conversion
    int i2 = (int)f;        // Explicit conversion
    Console.WriteLine($"i: {i}");
    Console.WriteLine($"f: {f}");
    Console.WriteLine($"i2: {i2}");

    int i1 = 100000001;
    float f2 = i1;          // Magnitude preserved, but precision may be lost
    int i3 = (int)f2;       // i3 will be 100000000, not 100000001
    Console.WriteLine($"i1: {i1}");
    Console.WriteLine($"f2: {f2}");
    Console.WriteLine($"i3: {i3}");
}

static void IncrementDecrementOperators()
{
    Console.WriteLine("\nIncrement Decrement Operators");

    int x = 0, y = 0;
    Console.WriteLine(x++); // Outputs 0; x is now 1 (post-increment)
    Console.WriteLine(++y); // Outputs 1; y is now 1 (pre-increment)
}

static void SpecializedOperations()
{
    Console.WriteLine("\nSpecialized Operations");

    int a = 2 / 3;      // 0
    int b = 0;
    // int c = 5 / b;   // Throws DivideByZeroException at runtime
    // int d = 5 / 0;   // Compile-time error
    Console.WriteLine($"a: {a}");
    Console.WriteLine($"b: {b}");
    // Console.WriteLine($"c: {c}");
    // Console.WriteLine($"d: {d}");
}

static void OverflowIntegral()
{
    Console.WriteLine("\nOverflow Integral");

    int a = int.MinValue;
    a--;
    Console.WriteLine($"a: {a == int.MaxValue}"); // True

    int b = int.MaxValue;
    b++;
    Console.WriteLine($"b: {b == int.MinValue}"); // True
}

static void OverflowCheckOperators()
{
    Console.WriteLine("\nOverflow Check Operators");

    int a = 1000000;
    int b = 1000000;
    int c = checked(a * b); // Checks only the expression

    checked
    {
        // ...
        c = a * b; // Checks all expressions within this block
        // ...
        Console.WriteLine($"c: {c}");
    }

    Console.WriteLine("Check Completed");
}

static void OverflowUncheckedOperators()
{
    Console.WriteLine("\nOverflow Unchecked Operators");

    int x = int.MaxValue;
    int y = unchecked(x + 1); // No error, even if project is checked

    // No error for operations within this block
    unchecked
    {
        int z = x + 1; Console.WriteLine($"z: {z}");
    }

    Console.WriteLine($"y: {y}");

    // int x2 = int.MaxValue + 1;             // Compile-time error
    int y2 = unchecked(int.MaxValue + 1);  // No errors
    // Console.WriteLine($"x2: {x2}");
    Console.WriteLine($"y2: {y2}");

    Console.WriteLine("Unchecked Completed");
}

static void BitIntegralTypes()
{
    Console.WriteLine("\nBit Integral Types");

    short x = 1, y = 1;
    // Compile-time error: x and y are converted to int, result is int, 
    // cannot implicitly cast back to short
    // short z = x + y; 
    short z = (short)(x + y); // OK: Explicit cast is required
    Console.WriteLine($"z: {z}");
}

static void SpecialValues()
{
    Console.WriteLine("\nSpecial Values");

    Console.WriteLine($"double.NegativeInfinity: {double.NegativeInfinity}");
    Console.WriteLine($"double.PositiveInfinity: {double.PositiveInfinity}");

    Console.WriteLine($"1.0 / 0.0: {1.0 / 0.0}");   //  Infinity
    Console.WriteLine($"-1.0 / 0.0: {-1.0 / 0.0}");   // -Infinity

    Console.WriteLine($"0.0 / 0.0: {0.0 / 0.0}");                                   //  NaN
    Console.WriteLine($"(1.0 / 0.0) - (1.0 / 0.0): {(1.0 / 0.0) - (1.0 / 0.0)}");   //  NaN

    Console.WriteLine($"0.0 / 0.0 == double.NaN: {0.0 / 0.0 == double.NaN}");   // False
    Console.WriteLine($"double.IsNaN(0.0 / 0.0): {double.IsNaN(0.0 / 0.0)}");   // True
}

static void RealRoundingErrors()
{
    Console.WriteLine("\nReal Rounding Errors");

    float x = 0.1f; // Not exactly 0.1 in base 2
    Console.WriteLine($"x: {x}");
    Console.WriteLine(x + x + x + x + x + x + x + x + x + x); // Output: 1.0000001

    decimal m = 1M / 6M;                 // 0.1666666666666666666666666667M
    double d = 1.0 / 6.0;               // 0.16666666666666666
    Console.WriteLine($"m: {m}");
    Console.WriteLine($"d: {d}");

    decimal notQuiteWholeM = m + m + m + m + m + m; // 1.0000000000000000000000000002M
    double notQuiteWholeD = d + d + d + d + d + d; // 0.99999999999999989
    Console.WriteLine($"notQuiteWholeM: {notQuiteWholeM}");
    Console.WriteLine($"notQuiteWholeD: {notQuiteWholeD}");

    Console.WriteLine($"notQuiteWholeM == 1M: {notQuiteWholeM == 1M}");  // False
    Console.WriteLine($"notQuiteWholeD < 1.0: {notQuiteWholeD < 1.0}");  // True
}
