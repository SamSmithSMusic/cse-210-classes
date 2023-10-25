public abstract class Task
{
    protected string _stringRep;
    protected string _title;
    protected string _description;
    protected DateTime _dueDate;
    protected int _priority;
    protected bool _isComplete;
    protected int _frequency;

    public Task(string name, string desc, DateTime due, int priority, bool complete, int frequency)
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
    public DateTime GetDue()
    {
        return _dueDate;
    }
    public string GetPriority()
    {
        if (_priority == 1)
        {
            return "Low";
        }
        else if (_priority == 2)
        {
            return "Medium";
        }
        else if (_priority == 3)
        {
            return "High";
        }
        else
        {
            return "Error in priority return";
        }
    }
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRep();
}