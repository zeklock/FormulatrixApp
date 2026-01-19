using Generics.Entities;

namespace Generics;

public class GenericVariance
{
    public static void Main()
    {
        Console.WriteLine("\nGeneric Variance");

        Covariance();
        Contravariance();
    }

    static void Covariance()
    {
        Console.WriteLine("\nCovariance");

        // Example with Stack<T> implementing IPoppable<T>
        var bears = new Entities.Stack<Bear>();
        bears.Push(new Bear());
        // Legal! Can assign a stack of bears to a pop-able animal interface.
        IPoppable<Animal> animals = bears;
        // Safely pops an Animal (which will be a Bear)
        Animal a = animals.Pop();
        Console.WriteLine($"a: {a}");
    }

    static void Contravariance()
    {
        Console.WriteLine("\nContravariance");

        IPushable<Animal> animals = new Entities.Stack<Animal>();
        // Legal! Assigning a push-able animal interface to a push-able bear interface.
        IPushable<Bear> bears = animals;
        // Safely pushes a Bear (which is an Animal)
        bears.Push(new Bear());
        Console.WriteLine($"a: {bears}");
    }
}
