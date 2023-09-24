

class Entry
{
    public string Prompt;
    public string Content;
    public DateTime Date;

    public Entry(string prompt, string content)
    {
        Prompt = prompt;
        Content = content;
        Date = DateTime.Now;
    }
    public override string ToString()
    {
        return $"This Entry was on {Date}: {Prompt} \n {Content} \n";
    }
}