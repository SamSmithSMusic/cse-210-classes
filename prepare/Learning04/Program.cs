using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("sam","Math");
        Console.WriteLine(assignment.GetSummary());
    }
}