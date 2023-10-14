public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private bool _isComplete;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus, int completed, bool complete):base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = completed;
        _isComplete = complete;
    }

    public override int RecordEvent()
    {
        _amountCompleted += 1;
        if (_amountCompleted == _target)
        {
            _isComplete = true;
            return _bonus + _points;
        }
        else
        {
            return _points;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return "i";
    }

    public override string GetStringRep()
    {
        return $"{_shortName};{_description};{_points};{_bonus};{_target};{_amountCompleted};{IsComplete()}";
    }

    public string GetAmountCompleted()
    {
        return $"{_amountCompleted}/{_target}";
    }
}