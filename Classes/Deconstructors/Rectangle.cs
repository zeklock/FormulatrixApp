namespace Classes.Deconstructors;

public class Rectangle
{
    public readonly float Width, Height;

    public Rectangle(float width, float height)
    {
        Width = width;
        Height = height;
    }

    // Deconstructor definition
    public void Deconstruct(out float width, out float height)
    {
        width = Width;
        height = Height;
    }
}
