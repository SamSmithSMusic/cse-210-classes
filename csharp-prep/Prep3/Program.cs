using System;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;

class Program
{
    static void Main(string[] args)
    {
        bool playing = true;
        bool success = false;
        string tempchoice = "";
        int answer = 0;
        int guess = 1;
        string direction = "cheese";
        Random random = new Random();
        int min = 1; // inclusive
        int max = 101; // exlusive
        int guesscount = 0;

        Console.WriteLine("Welcome to the guessing game, I'll pick a number and you try to guess it! I'll tell you if the number is higher or lower than your guess, here we go!");

        while (playing)
        {
            guesscount = 0;
            answer = random.Next(min,max);
            Console.WriteLine($"A number between {min} and {max - 1} has been chosen.");

            while (guess != answer)
            {
                System.Console.WriteLine("What is your guess?");
                success = false;
                while (!success)
                {
                     try
                        {
                            guess = int.Parse(Console.ReadLine());
                            success = true;
                        }
                    catch (System.FormatException)
                        {
                            Console.Write("Oops! Please enter only the number and in integer form. ");
                        }
                }
                
                if (guess > answer)
                {
                    direction = "Lower!";
                }
                else if (guess < answer)
                {
                    direction = "Greater!";
                }
                else
                {
                    direction = "You've guessed it!";
                }

                System.Console.WriteLine(direction);

                guesscount++;

            }

            System.Console.WriteLine($"It took you {guesscount} tries!");

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
}