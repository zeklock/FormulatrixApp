Console.WriteLine("Logic Exercise\n");

Console.Write("Input a number: ");

string? input = Console.ReadLine();

printsNumber(ref input);

static void printsNumber(ref string? input)
{
    if (!int.TryParse(input, out int parseInteger))
    {
        Console.WriteLine("Invalid input. Please enter a valid integer.");
        return;
    }

    for (int i = 1; i <= parseInteger; i++)
    {
        if (i > 1)
            Console.Write(", ");

        if (i % 3 == 0 && i % 5 == 0)
            Console.Write("foobar");
        else if (i % 3 == 0)
            Console.Write("foo");
        else if (i % 5 == 0)
            Console.Write("bar");
        else
            Console.Write(i);
    }
}
