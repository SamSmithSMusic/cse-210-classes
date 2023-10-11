using System.Runtime.CompilerServices;

public class Circle : Shape
{
    private double _radius = 5;

    public override double GetArea()
    {
        return Math.PI * _radius;
    }
}