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
        return $"Section {_textbookSection} - Problems {_problems}";
    }
}