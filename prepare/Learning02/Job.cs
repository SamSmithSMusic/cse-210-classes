public class Job
{
    public string _company;
    public string _startYear;
    public string _endYear;
    public string _jobTitle;

    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}