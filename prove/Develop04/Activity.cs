using System.Xml.Serialization;

public class Activity
{
    protected string _name;
    protected string _description;
    protected string _duration;

    public Activity(string name, string description, string duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    
    public void StartingMessage()
    {
        //make window full screen maybe? if GUI isn't added
        Console.WriteLine($"Welcome to {_name}:\n{_description}\nThis activity should take {_duration} to complete.");
        Delay(1);
        Console.WriteLine("The activity will start soon.");
        ShowCountdown(10, 1500);
        Console.Clear();
    }

    public void EndingMessage()
    {
        Console.WriteLine($"You have completed {_name}");
        Thread.Sleep(1500);
        Console.Write("Returning to main menu in ");
        ShowCountdown(5, 1500);
        Console.Write("\n");
    }

    public void ShowCountdown(int seconds, int spaceInMilliseconds)
    {
        for (int i = seconds ;i>=0;i--)
        {
            Console.Write(i);
            Thread.Sleep(spaceInMilliseconds);
            Console.SetCursorPosition(Console.CursorLeft - i.ToString().Length, Console.CursorTop);
        }
    }

    public void Delay(int seconds)
    {

        Thread.Sleep(seconds * 1000);
    }
}