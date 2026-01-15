namespace Classes.Fields;

class Octopus
{
    // A private field
    string name;
    // A public field initialized to 10
    public int Age = 10;
    // Field initializer
    // Initializer with method call
    static readonly string TempFolder = System.IO.Path.GetTempPath();
    // Declaring multiple fields
    static readonly int legs = 8, eyes = 2;
}
