public class Word
{
    public bool IsHidden;

    public Word()
    {
        IsHidden = false;
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