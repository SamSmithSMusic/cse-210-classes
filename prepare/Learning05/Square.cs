using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

public class Square : Shape
{
    private double _side = 5;

    public override double GetArea()
    {
        return _side * _side;
    }
}