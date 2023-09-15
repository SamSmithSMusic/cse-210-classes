using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
         bool playing = true;
        bool success = true;
        string tempchoice = "";

        while (playing)
        {
            DisplayWelcome();
            string name = PromptUserName();
            int num = PromptUserNumber();
            int sqnum = SquareNumber(num);
            DisplayResult(name, sqnum);





            success = false;
            while (!success)
            {
                Console.WriteLine("Would you like to go again? (Y/n) ");
                tempchoice = Console.ReadLine();
                if ((tempchoice.ToLower() == "y") || (tempchoice.ToLower() == "n"))
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("Invalid Entry, Please try again. ");
                }
            }
            
            if (tempchoice.ToLower() == "n")
            {
                playing = false;
                Console.WriteLine("See you next time!");
            }

        }
    }

    private static void DisplayResult(string name, int sqnum)
    {
        System.Console.WriteLine($"{name}, the square of your number is {sqnum}");
    }

    private static int SquareNumber(int num)
    {
        int sqnum = num * num;
        return sqnum;
    }

    private static int PromptUserNumber()
    {
        int num = 0;
        System.Console.WriteLine("Please enter your favorite number: ");
        bool success = false;
                while (!success)
                {
                     try
                        {
                            num = int.Parse(Console.ReadLine());
                            success = true;
                        }
                    catch (System.FormatException)
                        {
                            Console.Write("Oops! Please enter only the number and in integer form. ");
                        }
                }
        return num;
    }

    private static string PromptUserName()
    {
        System.Console.WriteLine("Please enter your full name: ");
        string name = Console.ReadLine();
        return name;
    }

    private static void DisplayWelcome()
    {
        System.Console.WriteLine("Welcome to Die Machine!");
    }
}