namespace OperatorOverloading;

public struct Note
{
    // Semitones from a base 'A' note
    int value;
    public readonly int Value { get { return value; } }

    public Note(int semitonesFromA) { value = semitonesFromA; }

    // Overloading the '+' operator
    // This allows us to add an integer (semitones) to a Note
    public static Note operator +(Note x, int semitones)
    {
        return new Note(x.value + semitones);
    }

    public static Note operator checked +(Note x, int semitones)
    {
        return checked(new Note(x.value + semitones));
    }

    // Implicit conversion from Note to double (frequency in Hertz)
    // No information loss, always succeeds.
    public static implicit operator double(Note x)
    {
        return 440 * Math.Pow(2, (double)x.value / 12);
    }

    // Information might be lost (rounding to nearest semitone), so explicit is required.
    public static explicit operator Note(double x)
    {
        return new Note((int)(0.5 + 12 * (Math.Log(x / 440) / Math.Log(2))));
    }
}
