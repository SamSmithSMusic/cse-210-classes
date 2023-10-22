public abstract class Task
{
    private string _stringRep;
    private string _title;
    private string _description;
    private int _dueDate;
    private int _priority;
    private bool _isComplete;
    private int _frequency;

    public Task(string name, string desc, int due, int priority, bool complete, int frequency)
    {
        _title = name;
        _description = desc;
        _dueDate = due;
        _priority = priority;
        _isComplete = complete;
        _frequency = frequency;
    }
    public string GetName()
    {
        return _title;
    }
    public string GetDesc()
    {
        return _description;
    }
    public int GetFreq()
    {
        return _frequency;
    }
    public abstract void RecordEvent();
    public abstract void IsComplete();
    public abstract string GetStringRep();
}