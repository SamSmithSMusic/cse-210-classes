using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstN = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastN = Console.ReadLine();

        Console.WriteLine($"Your name is {lastN}, {firstN} {lastN}.");
    }
}