using System.Drawing;
using System.Formats.Asn1;

public abstract class Shape
{
    private string _color = "black";

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public virtual double GetArea()
    {
        return 0;
    }
}