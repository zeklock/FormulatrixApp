namespace Delegates;

public class Delegates
{
    static int Square(int x) => x * x;
    static int Cube(int x) => x * x * x;

    public static void Main()
    {
        Transformer<int, int> t = Square;
        int side = 0;

        while (side == 0)
        {
            Console.Write("Input size: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out side) || input == "0")
            {
                Console.WriteLine("Invalid number. Try Again!");
                continue;
            }
        }

        int result = t(side);
        Console.WriteLine($"Square({side}) = {result}");

        int[] values = [side];
        Util.Transform(values, Cube);
        foreach (int i in values)
            Console.WriteLine($"Cube({side}) = {i}");
    }
}
