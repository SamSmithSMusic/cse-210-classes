using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Scripture
{
    private string referance = "";
    private List<Word> words = new List<Word>();
    private Array temparray;

    public Scripture(string Refer,string text)
    {
        referance = Refer;
        temparray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordtxt in temparray)
        {
            Word word = new Word(wordtxt);
            words.Add(word);
        }
    }

    public void HideRandomWords()
    {

    }

    public string GetRenderedText()
    {
        return "";
    }
}