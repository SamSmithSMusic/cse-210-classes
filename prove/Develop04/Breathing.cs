public class Breathing : Activity
{
    public Breathing(string name, string description, string duration):base(name,description,duration)
    {

    }

    public void Run()
    {
        //make window full screen maybe?

        StartingMessage();
        Console.WriteLine("We are going to take six breaths.");
        Thread.Sleep(2000);
        Console.WriteLine("When the text says inhale, inhale");
        Thread.Sleep(2000);
        Console.WriteLine("When the text says exhale, exhale.");
        Thread.Sleep(2000);
        Console.WriteLine("Make Sense?");
        Thread.Sleep(2000);
        Console.WriteLine("Here we go :)");
        ShowCountdown(3, 1000);

        Console.Clear();
        
        for (int i = 0;i<6;i++)
        {
            Console.WriteLine("Inahle");
            ShowCountdown(5, 1500);
            Console.WriteLine("Hold");
            ShowCountdown(5, 1500);
            Console.WriteLine("Exhale");
            ShowCountdown(5, 1500);
            Console.WriteLine("Hold");
            ShowCountdown(5,1500);
        }

        EndingMessage();
    }
}