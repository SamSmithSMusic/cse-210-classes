using System;
using System.Security.Cryptography;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        string[] prompts = {
            "Tell me about your day.",
            "What was the best part of you're day?",
            "What are you greateful for today?",
            "What was the strongest emotion you felt today?",
            "If you had one thing you could do over today, what would it be?",
            "What's on your mind right now?"
        };

        Random random = new Random();
        int min = 0;
        int max = prompts.Length - 1;

        bool playing = true;
        while (playing)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write an entry");
            Console.WriteLine("2. Display your loaded journal");
            Console.WriteLine("3. Save your journal to file");
            Console.WriteLine("4. Load your journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            
                switch ((choice))
                {
                    case 1:
                        Console.WriteLine("Here's your prompt:");
                        string tempchoice = prompts[random.Next(min, max)];
                        Console.WriteLine(tempchoice);
                        
                        Console.Write("Enter your journal entry: ");
                        string content = Console.ReadLine();
                        journal.AddEntry(tempchoice, content);
                        Console.WriteLine("Entry Added, good job!");
                        break;

                    case 2:
                        journal.DisplayEntries();
                        break;

                    case 3:
                        Console.Write("Enter the filename you want to save to: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        break;

                    case 4:
                        Console.Write("Enter the filename of the journal you want to load: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadFromFile(loadFileName);
                        break;

                    case 5:
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;

                }
            
            else
            {
                Console.WriteLine("Error in the swtich case broseff");
            }
        }
    }
}