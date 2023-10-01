using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Scripture
{
    private string referance = "";
    private List<Word> words = new List<Word>();
    private Array temparray;
    private List<Word> templist;

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
        Random random = new Random();
        List<Word> visibleWords = words.FindAll(word => !word.isHidden);

        if (visibleWords.Count() >0)
        {
            decimal numWordsToBeHidden = Math.Round( (decimal)visibleWords.Count() /100 * 10);
            List<int> removeIndexes = new List<int>();
            for (int i =0; i < numWordsToBeHidden; i++)
            {
                removeIndexes.Add(random.Next(0,visibleWords.Count()));
            }
            foreach (int i in removeIndexes)
            {
                words[i].Hide();
            }
        }
    }

    public string GetRenderedText()
    {
        List<string> outputList = new List<string>();
        foreach (Word word in words)
        {
            if (word.isHidden)
            {
                outputList.Add("_____");
            }
            else
            {
                outputList.Add(word.wordtxt);
            }
        }
        return string.Join(" ", outputList);
    }
}