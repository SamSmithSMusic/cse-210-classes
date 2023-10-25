using System.Reflection;

public class RepeatedTask : Task{

    private int _type;
    public RepeatedTask(int type,string title, string desc, DateTime due, int priority, bool complete, int frequency) : base(title, desc, due, priority, complete, frequency)
    {
        _type = type;
    }
    public override void RecordEvent()
    {
        _isComplete = true;
    }
    public override bool IsComplete()
    {
        if (_type == 1)
        {
            return false;
        }
        else
        {
            return _isComplete;
        }
    }
    public override string GetStringRep()
    {
        return $"{_type};{_title};{_description};{_dueDate};{_priority};{_isComplete};{_frequency}";
    }
}