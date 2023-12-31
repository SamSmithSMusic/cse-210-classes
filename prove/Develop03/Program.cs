using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();

        bool correct = false;
        bool playing = true;
        while (playing)
        {
            Console.WriteLine("Welcome to the text memorizer! What would you like to do? \n1. Memorize a logged document. \n2. Log a new document. \n3. Quit\nPlease enter the number associated with your choice : ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch(choice)
                {
                    case 1:
                    Console.Write("\n\n\n\n");
                    List<List<string>> outterList = logger.getEntrylist();
                    for (int i = 0; i < outterList.Count; i++)
                    {
                        Console.Write((i+1) + " : ");
                        List<string> innerList = outterList[i];
                        Console.WriteLine($"{innerList[0]}");
                    }
                    Console.Write("Please enter the number of the identifing text for your doctument : ");

                    List<string> scriptList = new List<string>(2);

                    correct = false;
                    while (!correct)
                    {
                        if (int.TryParse(Console.ReadLine(), out int refChoice) && refChoice >= 1 && refChoice <= outterList.Count )
                        {
                            correct = true;
                            scriptList = outterList[refChoice -1];
                            
                        }
                        else 
                        {
                            Console.Write("Invalid Entry, Please try again : ");
                        }
                        
                    }
                    
                    Scripture scripture = new Scripture(scriptList[0],scriptList[1]);
                    Console.WriteLine("10% of the words will be removed each time. \nPress \"Enter\" to continue or type \"quit\" to end the program.\n\n");
                    Thread.Sleep(2000);
                    Console.WriteLine(scripture.GetRenderedText());

                    bool complete = false;
                    while (!complete)
                    {
                        string enterChoice = Console.ReadLine().ToLower();
                        if (enterChoice == "quit")
                        {
                            break;
                        }
                        else {
                            Console.Clear();
                            scripture.HideRandomWords();
                            Console.WriteLine(scripture.GetRenderedText());
                        }
                    }

                    
                    break;

                    case 2:
                    Console.Write("Please enter the referance text you would like associated with your text : ");
                    string tempReference = Console.ReadLine();
                    Console.WriteLine("Please enter the text you would like to be logged to the above reference : ");
                    string tempText = Console.ReadLine();
                    logger.LogEntry(tempReference, tempText);
                    break;

                    case 3:
                    playing = false;
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input.");
            }
        }
    }
}