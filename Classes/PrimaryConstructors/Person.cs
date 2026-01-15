namespace Classes.PrimaryConstructors;

// Primary constructor parameters
public class Person(string firstName, string lastName)
{
    // Field initialized with primary constructor param
    public readonly string FirstName = firstName;

    // Property initialized with primary constructor param
    public string LastName { get; } = lastName;

    public void Print() => Console.WriteLine($"Fullname: {firstName} {lastName}");
}
