public class Listing : Activity
{
    private string _currentPrompt;
    private string _response;
    private List<string> _answerList = new List<string>();
    private string _tempAnswer = "";

    private List<string> _prompts = new List<string>{"Who are people that you appreciate?","What are personal strengths of yours?","Who are some of your personal heroes?","When have you felt the Holy Ghost this month?","Who are people that you have helped this week?"};

    public Listing(string name, string desc, string duration) : base(name,desc,duration)
    {
        
    }
    public void Run()
    {

        _answerList?.Clear();

        StartingMessage();
        

        Random random = new Random();
        Console.WriteLine("Enter \"Done\" when you're finished with your list.");
        _currentPrompt = _prompts[random.Next(5)];
        Console.WriteLine(_currentPrompt);

        while (_tempAnswer.ToLower() != "done")
        {
            _tempAnswer = Console.ReadLine();

            _answerList.Add(_tempAnswer);

        }

        LogEntry(_answerList, "Listing Activity Responses.txt");
        
        Console.WriteLine($"You wrote {_answerList.Count()} items and they have been logged in \"Listing Activity Responses.txt\"");
        Delay(3);
        EndingMessage();
    }

    private void LogEntry(List<string> response,string tempRef)
    {
        _response = string.Join(" ", response);

        using (StreamWriter writer = new StreamWriter(tempRef, true))
        {
                writer.WriteLine(_currentPrompt);
                writer.WriteLine(_response);
                writer.WriteLine();
        }
    }
}