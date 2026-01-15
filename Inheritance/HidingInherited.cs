namespace Inheritance;

public class A { public int Counter = 1; }
public class B : A { public int Counter = 2; }

public class A2 { public int Counter = 1; }
public class B2 : A2 { public new int Counter = 2; }

public class BaseClass
{
    public virtual void Foo() { Console.WriteLine("BaseClass.Foo"); }
}

public class Overrider : BaseClass
{
    // Overrides virtual method
    public override void Foo() { Console.WriteLine("Overrider.Foo"); }
}

public class Hider : BaseClass
{
    // Hides base method
    public new void Foo() { Console.WriteLine("Hider.Foo"); }
}

public static class HidingInherited
{
    public static void Main()
    {
        Console.WriteLine("\nHiding Inherited Members");

        // Hiding();
        NewOverride();
    }

    static void Hiding()
    {
        A a = new B();
        Console.WriteLine($"a.Counter: {a.Counter}");

        B b = new B();
        Console.WriteLine($"b.Counter: {b.Counter}");

        A2 a2 = new B2();
        Console.WriteLine($"a2.Counter: {a2.Counter}");

        B2 b2 = new B2();
        Console.WriteLine($"b2.Counter: {b2.Counter}");
    }

    static void NewOverride()
    {
        Overrider over = new Overrider();
        BaseClass b1 = over;
        // Output: Overrider.Foo (direct call)
        over.Foo();
        // Output: Overrider.Foo (polymorphism applies)
        b1.Foo();

        Hider h = new Hider();
        BaseClass b2 = h;
        // Output: Hider.Foo (direct call)
        h.Foo();
        // Output: BaseClass.Foo (hiding: polymorphism does NOT apply for 'new' methods)
        b2.Foo();
    }
}
