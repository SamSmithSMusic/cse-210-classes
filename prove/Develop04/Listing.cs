public class Listing : Activity
{
    private int _count;
    private List<string> _prompts;

    public Listing(string name, string desc, string duration) : base(name,desc,duration)
    {

    }
    public void Run()
    {
        


        StartingMessage();
        
    }
}