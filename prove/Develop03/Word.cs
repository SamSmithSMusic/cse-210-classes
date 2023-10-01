public class Word
{
    public bool isHidden;
    public string wordtxt;

    public Word(string wordtext)
    {
        isHidden = false;
        wordtxt = wordtext;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public void Show()
    {
        isHidden = false;
    }
}