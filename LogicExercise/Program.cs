using LogicExercise;

Console.WriteLine("Logic Exercise\n");

Console.Write("Input a number: ");

string? input = Console.ReadLine();

if (!int.TryParse(input, out int inputNumber))
{
    Console.WriteLine("Invalid input. Please enter a valid integer.");
    return;
}

NumberExercise.Print(inputNumber);
