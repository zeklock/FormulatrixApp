namespace LogicExercise;

public class NumberExercise
{
    private Dictionary<int, string>? _rules;

    public void Print(int n)
    {
        Console.Write($"n({n}) : ");

        for (int i = 1; i <= n; i++)
        {
            if (i > 1)
                Console.Write(", ");

            string print = Convert(i);

            Console.Write(string.IsNullOrEmpty(print) ? i : print);
        }
    }

    private string Convert(int x)
    {
        string word = string.Empty;

        if (_rules is null)
            return word;

        foreach (var rule in _rules)
        {
            if (x % rule.Key == 0)
            {
                word += rule.Value;
            }
        }

        return word;
    }

    public void AddRule(int input, string output)
    {
        _rules ??= new Dictionary<int, string>();
        _rules[input] = output;
        SortRules();
    }

    private void SortRules()
    {
        if (_rules is not null)
        {
            _rules = _rules.OrderBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
        }
    }
}
