public class Circle : Shape
{
    private double _radius;
    private const double PI = 3.14159;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return PI * _radius * _radius;
    }
}