using System.Reflection.Metadata;
using Microsoft.VisualBasic;

public class Logger
{
    //PATH TO STORAGE DOCUMENT
    string documentPath = @"C:\Users\samsm\OneDrive - BYU-Idaho\School\PC Coding\cse-210-classes\prove\Develop03\Documents.txt";
    private List<List<string>> entrylist = new List<List<string>>();
    private List<string> entry = new List<string>(); 
    private string[] temparray;

    public void LogEntry(string tempRef, string tempText)
    {
        using (StreamWriter writer = new StreamWriter("Documents.txt", true))
        {
                writer.WriteLine($"{tempRef} Ȟ {tempText}");
                writer.WriteLine();
        }
        Console.WriteLine($"Document {tempRef} has been logged.");
    }

    public List<List<string>> getEntrylist()
    {
        try
        {
            entrylist.Clear();
            entry.Clear();
        } catch {}
        
        // @"C:\Users\samsm\OneDrive - BYU-Idaho\School\PC Coding\cse-210-classes\prove\Develop03\Documents.txt"
        string[] lines = File.ReadAllLines(documentPath);
        
        for (int i =0; i < lines.Length; i++)
        {
            if (lines[i] != "" || !string.IsNullOrEmpty(lines[i]) || !string.IsNullOrWhiteSpace(lines[i]))
            {
            temparray = lines[i].Split('Ȟ', StringSplitOptions.RemoveEmptyEntries);
            entry = temparray.ToList();
            entrylist.Add(entry);
            }        
        }
        
        return entrylist;
    }
}