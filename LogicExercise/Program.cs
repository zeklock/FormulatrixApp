using LogicExercise;

Console.WriteLine("Logic Exercise\n");

bool validInput = false;
int inputNumber = 0;

while (!validInput)
{
    Console.Write("Input a number: ");

    string? input = Console.ReadLine();

    if (!int.TryParse(input, out inputNumber))
    {
        Console.WriteLine("Invalid input. Please enter a valid integer.");
        continue;
    }

    validInput = true;
}

NumberExercise numberExercise = new NumberExercise();

// 1st Logic Exercise Rules
numberExercise.AddRule(3, "foo");
numberExercise.AddRule(5, "bar");

// 2nd Logic Exercise Rules
numberExercise.AddRule(7, "jazz");

// 3rd Logic Exercise Rules
numberExercise.AddRule(4, "baz");
numberExercise.AddRule(9, "huzz");

numberExercise.Print(inputNumber);

Console.WriteLine();
Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
