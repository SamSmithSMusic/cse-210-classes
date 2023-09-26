
public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 0;
        _bottom = 0;
    }

    public Fraction(int wholeNumber)
    {
        _top = 1;
        _bottom = wholeNumber;
    }

    public Fraction (int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"({_top}/{_bottom})";
    }

    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}