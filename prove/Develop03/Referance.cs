public class Reference
{
    private string identifier;
    private string text;
    public Reference(string tempidentifier, string temptext)
    {
        identifier = tempidentifier;
        temptext = text;
    }

    public string Identifier()
    {
        return identifier;
    }

    public string Text()
    {
        return text;
    }

}