// Arrays
using Point;

Console.WriteLine("Arrays");

// Initialization();
// DefaultElement();
// Indices();
Ranges();

static void Initialization()
{
    Console.WriteLine("\nInitialization");

    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
    char[] vowels2 = { 'a', 'e', 'i', 'o', 'u' };
    char[] vowels3 = ['a', 'e', 'i', 'o', 'u'];
    Console.WriteLine($"vowels: {string.Join(", ", vowels)}");
    Console.WriteLine($"vowels2: {string.Join(", ", vowels2)}");
    Console.WriteLine($"vowels3: {string.Join(", ", vowels3)}");
}

static void DefaultElement()
{
    Console.WriteLine("\nDefault Element");

    int[] a = new int[1000];
    Console.WriteLine("a[123]: " + a[123]);

    PointStruct[] b = new PointStruct[1000];
    int x = b[500].X;
    Console.WriteLine($"x: {x}");

    PointClass[] c = new PointClass[1000];
    // This would cause a NullReferenceException at runtime!
    // int y = c[500].Y;
    // Console.WriteLine($"y: {y}");

    for (int i = 0; i < c.Length; i++)
        c[i] = new PointClass();

    int z = c[500].X;
    Console.WriteLine($"z: {z}");
}

static void Indices()
{
    Console.WriteLine("\nIndices");

    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
    Console.WriteLine($"vowels: {string.Join(", ", vowels)}");

    char lastElement = vowels[^1];
    char secondToLast = vowels[^2];
    Console.WriteLine($"lastElement: {lastElement}");
    Console.WriteLine($"secondToLast: {secondToLast}");

    Index first = 0;
    Index last = ^1;
    char firstElement = vowels[first];
    lastElement = vowels[last];
    Console.WriteLine($"first: {first}");
    Console.WriteLine($"last: {last}");
    Console.WriteLine($"firstElement: {firstElement}");
    Console.WriteLine($"lastElement: {lastElement}");
}

static void Ranges()
{
    Console.WriteLine("\nRanges");

    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
    Console.WriteLine($"vowels: {string.Join(", ", vowels)}");

    char[] firstTwo = vowels[..2];
    char[] lastThree = vowels[2..];
    char[] middleOne = vowels[2..3];
    Console.WriteLine($"firstTwo: {string.Join(", ", firstTwo)}");
    Console.WriteLine($"lastThree: {string.Join(", ", lastThree)}");
    Console.WriteLine($"middleOne: {string.Join(", ", middleOne)}");

    char[] lastTwo = vowels[^2..];
    Console.WriteLine($"lastTwo: {string.Join(", ", lastTwo)}");

    Range firstTwoRange = 0..2;
    firstTwo = vowels[firstTwoRange];
    Console.WriteLine($"firstTwoRange: {string.Join(", ", firstTwo)}");
}
