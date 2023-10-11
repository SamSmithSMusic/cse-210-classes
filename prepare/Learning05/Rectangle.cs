using System.Runtime.CompilerServices;

public class Rectangle : Shape
{
    private double _length = 10;
    private double _width = 5;

    public override double GetArea()
    {
        return _length * _width;
    }
}