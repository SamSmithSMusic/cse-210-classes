public class SimpleTask : Task
{
    public SimpleTask(string title, string desc, DateTime due, int priority, bool complete, int frequency) : base(title, desc, due, priority, complete, frequency)
    {

    }
    public override void RecordEvent()
    {
        _isComplete = true;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRep()
    {
        return  $"{_title};{_description};{_dueDate};{_priority};{_isComplete};{_frequency}";
    }
}