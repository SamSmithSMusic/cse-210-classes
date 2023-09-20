using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new();
        Job job2 = new();
        Resume resume = new();

        job1._jobTitle = "Software Engineer";
        job1._company = "Amazon";
        job1._startYear = "1989";
        job1._endYear = "2008";

        job2._jobTitle = "Cheese Softener";
        job2._company = "Reed's Dairy";
        job2._startYear = "2008";
        job2._endYear = "2020";

        resume._name = "Smamantham";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();

    }
}