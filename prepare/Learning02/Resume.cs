using System.ComponentModel.DataAnnotations;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.Write($"\nName: {_name}\nJobs:");
        foreach (Job j in _jobs)
        {
            j.DisplayJobDetails();
        }
    }
}