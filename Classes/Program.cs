using System.Text;
using Classes;
using Classes.Deconstructors;
using Classes.Fields;
using Classes.Indexers;
using Classes.InstanceConstructors;
using Classes.ObjectInitializers;
using Classes.Partial;
using Classes.PrimaryConstructors;
using Classes.Properties;

Console.WriteLine("Classes");

ClassMembersFields();
ClassMembersConstants();
ClassMembersMethods();
InstanceConstructors();
OverloadingConstructors();
Deconstructors();
ObjectInitializers();
Properties();
PrivateSetters();
InitOnlyProperties();
Indexers();
PrimaryConstructors();
PartialTypes();
NameofOperator();

static void ClassMembersFields()
{
    Console.WriteLine("\nClass Members Fields");

    Octopus octopus = new Octopus();
    Console.WriteLine($"The octopus is {octopus.Age} years old.");
}

static void ClassMembersConstants()
{
    Console.WriteLine("\nClass Members Constants");

    Test test = new Test();
    Console.WriteLine($"Constant Test Message: {Test.Message}");
}

static void ClassMembersMethods()
{
    Console.WriteLine("\nClass Members Methods");

    Methods methods = new Methods();

    methods.Foo(5);
    methods.Foo(5.5);
    methods.Foo(3, 4.5f);
    methods.Foo(4.5f, 3);

    int result = methods.FooValue(10);
    Console.WriteLine($"FooValue returned: {result}");

    methods.FooVoid(20);
    methods.WriteCubes();
}

static void InstanceConstructors()
{
    Console.WriteLine("\nInstance Constructors");

    Panda p = new Panda("Petey");
    Console.WriteLine($"A panda has been created.");
}

static void OverloadingConstructors()
{
    Console.WriteLine("\nOverloading Constructors");

    Wine wine1 = new Wine(19.95m);
    Console.WriteLine($"Wine 1 - Price: {wine1.Price}, Year: {wine1.Year}");

    Wine wine2 = new Wine(29.95m, 2020);
    Console.WriteLine($"Wine 2 - Price: {wine2.Price}, Year: {wine2.Year}");
}

static void Deconstructors()
{
    Console.WriteLine("\nDeconstructors");

    var rect = new Rectangle(3, 4);

    // Deconstruction call
    (float width, float height) = rect;

    Console.WriteLine($"Width: {width}, Height: {height}");
}

static void ObjectInitializers()
{
    Console.WriteLine("\nObject Initializers");

    // Using object initializers:
    // Note: Parameterless constructors can omit empty parentheses 
    Bunny b1 = new Bunny { Name = "Bo", LikesCarrots = true, LikesHumans = false };
    Bunny b2 = new Bunny("Bo") { LikesCarrots = true, LikesHumans = false };
    Console.WriteLine($"Bunny 1: Name={b1.Name}, LikesCarrots={b1.LikesCarrots}, LikesHumans={b1.LikesHumans}");
    Console.WriteLine($"Bunny 2: Name={b2.Name}, LikesCarrots={b2.LikesCarrots}, LikesHumans={b2.LikesHumans}");
}

static void Properties()
{
    Console.WriteLine("\nProperties");

    Stock msft = new Stock();
    msft.CurrentPrice = 30;
    Console.WriteLine($"msft current price: {msft.CurrentPrice}");
}

static void PrivateSetters()
{
    Console.WriteLine("\nPrivate Setters");

    Foo foo = new Foo();
    Console.WriteLine($"Initial foo.X: {foo.X}");
}

static void InitOnlyProperties()
{
    Console.WriteLine("\nInit-Only Properties");

    var note = new Note { Pitch = 50 };
    Console.WriteLine($"Note pitch: {note.Pitch}");
}

static void Indexers()
{
    Console.WriteLine("\nIndexers");

    Sentence s = new Sentence();
    Console.WriteLine($"s[3]: {s[3]}");
    s[3] = "kangaroo";
    Console.WriteLine($"s[3]: {s[3]}");

    // Last element using Index
    Console.WriteLine($"s[^1]: {s[^1]}");

    // Range from start to index 2
    string[] firstTwoWords = s[..2];
    Console.WriteLine($"firstTwoWords: {string.Join(", ", firstTwoWords)}");
}

static void PrimaryConstructors()
{
    Console.WriteLine("\nPrimary Constructors");

    Person p = new Person("Alice", "Jones");
    p.Print();
    Console.WriteLine($"Firstname: {p.FirstName}");
    Console.WriteLine($"Lastname: {p.LastName}");
}

static void PartialTypes()
{
    Console.WriteLine("\nPartial Types");

    PaymentForm payment = new PaymentForm();
    payment.ValidatePayment(20);
}

static void NameofOperator()
{
    Console.WriteLine("\nThe nameof Operator");

    int count = 123;
    string name = nameof(count);
    Console.WriteLine($"nameof count: {name}");

    string name2 = nameof(StringBuilder.Length);
    Console.WriteLine($"nameof StringBuilder.Length: {name2}");
}
