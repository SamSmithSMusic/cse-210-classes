using System;
using System.Net.WebSockets;

class Program
{
    static void Main(string[] args)
    {

        Fraction fraction = new Fraction();
        Fraction fullFraction = new Fraction(7,3);
        Fraction halfFraction = new Fraction(7);

        bool success = false;
        Console.WriteLine("Set top Number");
        while (!success)
        {
            string temp = Console.ReadLine();

            if (int.TryParse(temp, out int tnum))
            {
                fraction.SetTop(tnum);
                success = true;
            }
            else 
            {
                Console.WriteLine("Invalid Input, please input an integer.");
            }
        }

        success = false;
        Console.WriteLine("Set bottom Number");
        while (!success)
        {
            string temp = Console.ReadLine();

            if (int.TryParse(temp, out int bnum))
            {
                fraction.SetBottom(bnum);
                success = true;
            }
            else 
            {
                Console.WriteLine("Invalid Input, please input an integer.");
            }
        }

        Console.Write($@"
        Your fraction is {fraction.GetFractionString()}.
        Your decimal is {fraction.GetDecimalValue()}.
        ");

        Console.Write($@"
        Your fraction is {fullFraction.GetFractionString()}.
        Your decimal is {fullFraction.GetDecimalValue()}.
        ");

        Console.Write($@"
        Your fraction is {halfFraction.GetFractionString()}.
        Your decimal is {halfFraction.GetDecimalValue()}.
        ");
    }
}