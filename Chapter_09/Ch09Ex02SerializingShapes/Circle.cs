namespace Packt.Shared;

public class Circle : Shape
{
    public Circle()
    {
    }

    public double Radius { get; set; }

    public override double Area
    {
        get { return Math.PI * Radius * Radius; }
    }
}