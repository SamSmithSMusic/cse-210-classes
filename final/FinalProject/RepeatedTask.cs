public class RepeatedTask : Task{

    public RepeatedTask(string title, string desc, int due, int priority, bool complete, int frequency) : base(title, desc, due, priority, complete, frequency)
    {

    }
    public override void RecordEvent()
    {

    }
    public override void IsComplete()
    {
        throw new NotImplementedException();
    }
    public override string GetStringRep()
    {
        throw new NotImplementedException();
    }
}