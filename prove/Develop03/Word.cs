public class Word
{
    public bool IsHidden;
    public string wordtxt;

    public Word(string wordtext)
    {
        IsHidden = false;
        wordtext = wordtxt;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Show()
    {
        IsHidden = false;
    }
}