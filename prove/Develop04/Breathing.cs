public class Breathing : Activity
{
    public Breathing(string name, string description, string duration):base(name,description,duration)
    {

    }

    public void Run()
    {
        //make window full screen maybe?

        base.StartingMessage();
        Console.WriteLine("We are going to take six breaths.");
        Thread.Sleep(2000);
        Console.WriteLine("When the text says inhale, inhale");
        Thread.Sleep(2000);
        Console.WriteLine("When the text says exhale, exhale.");
        Thread.Sleep(2000);
        Console.WriteLine("Make Sense?");
        Thread.Sleep(2000);
        Console.WriteLine("Here we go :)");
        base.ShowCountdown(3);

        Console.Clear();
        //make the counting six times.
    }
}