namespace Ch06Ex02Inheritance;

public class Shape
{
    public double Height { get; set; }

    public double Width { get; set; }

    public double Area { get; set; }
}

public class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }
}

public class Square : Shape
{
    public Square(double value)
    {
        // implementation  
    }
}

public class Circle : Shape
{
    public Circle(double radius)
    {
        // implementation 
    }
}
