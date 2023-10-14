using System.ComponentModel;

public abstract class Goal {
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string desc, int points)
    {
        _shortName = name;
        _description = desc;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString() {return "i";}
    public abstract string GetStringRep();
    public string GetName()
    {
        return _shortName;
    }
    public string GetDesc()
    {
        return _description;
    }
    public int GetPoints()
    {
        return _points;
    }
}