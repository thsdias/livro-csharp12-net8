namespace Packt.Shared;

public class Rectangle : Shape
{
    public Rectangle()
    {
    }

    public double Height { get; set; }

    public double Width { get; set; }

    public override double Area
    {
        get { return Height * Width; }
    }
}