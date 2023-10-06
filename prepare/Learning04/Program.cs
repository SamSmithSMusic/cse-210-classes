using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("sam","Math");
        Console.WriteLine(assignment.GetSummary()); 

        MathAssignment m1 = new MathAssignment("6.9", "4 - 20", "Jake Peralta", "Mafs");
        Console.WriteLine(m1.GetSummary() + "\n" + m1.GetHomeworkList());

        WritingAssignment w1 = new WritingAssignment("Why Shrek is the Extra Most Bestest Movie", "Mrs. Peralta", "Music and the Humanities");
        Console.WriteLine(w1.GetSummary() + "\n" + w1.GetWritingInformation());
    }
}