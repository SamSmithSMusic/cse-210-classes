public class EternalGoal : Goal
{
    

    public EternalGoal(string name, string desc, int points):base(name, desc, points)
    {
    
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetStringRep()
    {
        return $"{_shortName},{_description},{_points}";
    }

    public override bool IsComplete()
    {
        return false;
    }
}