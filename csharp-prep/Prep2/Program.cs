using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // Var Declaration
        bool success = false;
        int userGrade = 0;
        string gradeLetter = "Grade Assign Error";
        string preciseGrade;
        string message;

        // Grade Retrieval
        Console.Write("Welcome to the Grade Letter Interpreter! Please input your grade percentage followed by pressing the \"Enter\" Key. ");
        while (!success)
        {
            try
            {
                userGrade = int.Parse(Console.ReadLine());
                success = true;
            }
            catch (System.FormatException)
            {
                Console.Write("Oops! Please enter only the number of your grade in integer form. ");
            }
        }

        //  Logic & Variable assignment
        if (userGrade >= 90)
        {
            gradeLetter = "A";
        }
        else if (userGrade >= 80)
        {
            gradeLetter = "B";
        }
        else if (userGrade >= 70)
        {
            gradeLetter = "C";
        }
        else if (userGrade >= 60)
        {
            gradeLetter = "D";
        }
        else if (userGrade >= 50)
        {
            gradeLetter = "F";
        }

        if ((userGrade % 10) > 6 && (gradeLetter != "A" && gradeLetter != "F"))
        {
            preciseGrade = "+";
        }
        else if ((userGrade % 10) < 4 && gradeLetter != "F")
        {
            preciseGrade = "-";
        }
        else
        {
            preciseGrade = "";
        }

        if (userGrade >= 70)
        {
            message = "Congrats on passing!";
        }
        else 
        {
            message = "You'll get em' next time!";
        }

        // Return
        Console.WriteLine($"Your letter grade is {gradeLetter}{preciseGrade}. {message}");
    }
}