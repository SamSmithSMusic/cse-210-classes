using System;

class Program
{
    static void Main(string[] args)
    {
        bool playing = true;
        while (playing)
        {
            Console.WriteLine("Welcome to the text memorizer! What would you like to do? \n1. Memorize a logged document. \n2. Log a new document. \nPlease enter the number associated with your choice : ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch(choice)
                {
                    case 1:
                    Console.Write("one");
                    break;

                    case 2:
                    
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