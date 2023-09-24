class Journal
{
    List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string content)
    {
        Entry newEntry = new Entry(prompt, content);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        Console.WriteLine("Journol Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}: {entry.Prompt}");
                writer.WriteLine(entry.Content);
                writer.WriteLine();
            }
        }
        Console.WriteLine($"Journal saved to your file: {fileName}");
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                string cPrompt = "";
                string cContent = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == null || line == "")
                    {
                        if (!(cPrompt == null || cPrompt == "") && !(cContent == null || cContent == ""))
                        {
                            AddEntry(cPrompt, cContent);
                        }
                        cPrompt = "";
                        cContent = "";
                    }
                    else if (string.IsNullOrEmpty(cPrompt))
                    {
                        cPrompt = line;
                    }
                    else
                    {
                        cContent += line + "\n";
                    }
                }
            }
            Console.WriteLine("Journal loaded from file");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Couldn't find that file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong: {ex.Message}");
        }
    }
}