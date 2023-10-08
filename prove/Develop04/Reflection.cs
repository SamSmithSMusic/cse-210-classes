
using System.Reflection.Metadata.Ecma335;

public class Reflection : Activity
{
    private List<string> _prompts = new List<string>{"Think of a time when you stood up for someone else.","Think of a time when you did something really difficult.","Think of a time when you helped someone in need.","Think of a time when you did something truly selfless."};
    private List<string> _questions = new List<string>{"How did you feel when it was complete?","What did you learn about yourself through this experience?","What could you learn from this experience that applies to other situations?","What is your favorite thing about this experience?","Have you ever done anything like this before?","Why was this experience meaningful to you?"};
    private List<string> _response = new List<string>{"",""};
    private string logString;

    public Reflection(string title, string desc, string duration) : base(title, desc, duration)
    {

    }

    public void Run()
    {
        StartingMessage();

        Random random = new Random();
        Console.Write("You will be given a prompt, then 10 seconds to only think before being allowed to write. \nOnce you've written your complete answer, press enter and it will be logged. \nThe next question will then be shown with the same process following.\nThe program will start in : ");
        ShowCountdown(10,1500);
        Console.Clear();
        Console.WriteLine(_prompts[random.Next(4)]);
        ShowCountdown(10,1500);

        _response[0] = Console.ReadLine();

        Console.WriteLine(_questions[random.Next(6)]);
        ShowCountdown(10,1500);

        _response[1] = Console.ReadLine();

        LogEntry(_response, "Reflection Activity Logs.txt");

        Console.WriteLine("Your entrys have been logged in the \"Reflection Activity Logs.txt\" document.");
        EndingMessage();
    }

    private void LogEntry(List<string> response,string tempRef)
    {
        logString = string.Join(" Response: ", _response);

        using (StreamWriter writer = new StreamWriter(tempRef, true))
        {
                writer.WriteLine(logString);
                writer.WriteLine();
        }
    }
}