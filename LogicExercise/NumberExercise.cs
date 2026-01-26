namespace LogicExercise;

public class NumberExercise
{
    public static void Print(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            if (i > 1)
                Console.Write(", ");

            string print = Convert(i);

            Console.Write(string.IsNullOrEmpty(print) ? i : print);
        }
    }

    public static string Convert(int x)
    {
        string word = string.Empty;

        if (x % 3 == 0)
            word += "foo";

        if (x % 4 == 0)
            word += "baz";

        if (x % 5 == 0)
            word += "bar";

        if (x % 7 == 0)
            word += "jazz";

        if (x % 9 == 0)
            word += "huzz";

        return word;
    }
}
