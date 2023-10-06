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
        Console.WriteLine($"Welcome to {_name}:\n{_description}\nThis activity should take {_duration} to complete.");
        Thread.Sleep(300);
        Console.WriteLine("The activity will start soon.");
        ShowCountdown(5);
    }

    public void EndingMessage()
    {
        Console.WriteLine($"You have completed {_name}");
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds ;i>=0;i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}