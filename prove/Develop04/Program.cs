using System;

class Program
{
    static void Main(string[] args)
    {
            Breathing breathing = new Breathing("Breathing to Relaxation","In this activity you'll be walked through deep breaths and should feel a sense of calm towards the end and throughout the activity.","2 Minutes");
            Reflection reflection = new Reflection("Reflection in Time","In this activity you will be prompted with two questions. After answering the initial prompt, a follow up question will also be displayed. After you answer that question the activity will end.","3 Minutes");
            Listing listing = new Listing("Breadth Notation","In this activity you will be prompting with a question and are encouraged to respond with as many answers as you can. Press enter after each answer and enter \"Done\" when you've completed your answer list.","2 Minutes");

            bool playing = true;
            while (playing)
            {
                Console.WriteLine("What would you like to do?");
                Console.Write(@"
1 : Breathing Activity
2 : Reflection Activity
3 : Listing Activity
4 : Quit
Enter the corresponding number : ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice < 5)
                {
                    switch(choice)
                    {
                        case 1:
                            breathing.Run();
                        break;
                        
                        case 2:

                        break;
                        
                        case 3:

                        break;
                        
                        case 4:

                        break;
                        ;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }

    }
}