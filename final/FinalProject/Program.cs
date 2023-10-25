using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        UserManager userM = new UserManager();
        TaskManager taskM = new TaskManager(userM);
        Calendar calendar = new Calendar(taskM);
        while (running)
        {
            Console.WriteLine("- Main Menu -");
            Console.WriteLine("1 : User Interface");
            Console.WriteLine("2 : Task Interface");
            Console.WriteLine("3 : View Calendar");
            Console.WriteLine("4 : Save and Quit Program");
            Console.WriteLine("5 : Quit Without Saving Program");
            Console.Write("Where would you like to go? ");
            string whack = Console.ReadLine();

            switch (whack)
            {
                case "1":
                    userM.Run();
                break;
                case "2":
                    taskM.Run();
                break;
                case "3":
                    calendar.Run();
                break;
                case "4":
                    taskM.Save();
                    userM.Save();
                    running = false;
                break;
                case "5":
                    running = false;
                break;
                default:
                    Console.WriteLine("Invalid Input, please try again.");
                break;
            }
        } 
    }
}