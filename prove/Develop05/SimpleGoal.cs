public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string desc, int points, bool complete):base(name, desc, points)
    {
    _isComplete = complete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRep()
    {
        return $"{_shortName};{_description};{_points};{IsComplete()}";
    }
}