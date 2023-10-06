public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string textbookSection,string problems, string name, string topic) : base(name, topic)
    {
        _textbookSection = textbookSection;
        problems = _problems;
    }

    public string GetHomeworkList()
    {
        return $"{_textbookSection} - {_problems}";
    }
}