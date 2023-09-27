using System.Runtime.CompilerServices;

public class Scripture
{
    private string referance = "";
    private List<Word> words = new List<Word>();

    public Scripture(string Refer,string text)
    {
        referance = Refer;
        words = new List<Word>(text.Split(" ", StringSplitOptions.RemoveEmptyEntries));
    }

    public void LogEntry()
    {

    }

    public void PullEntry()
    {

    }

    public void HideRandomWords()
    {

    }

    public string GetRenderedText()
    {
        return;
    }
}