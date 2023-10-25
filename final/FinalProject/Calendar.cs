public class Calendar
{
    private string _year;
    private string _month;
    private string _day;
    private string _date;
    private bool _running = true;
    TaskManager _taskM = new TaskManager();
    List<Task> _tasks = new List<Task>();

    public Calendar(TaskManager Taskm)
    {
        _taskM = Taskm;
    }
    public void Run()
    {
        _running = true;
        _tasks = _taskM.GetTasks();
        while (_running)
        {
            Console.WriteLine("- Calendar Menu -");
            Console.WriteLine("1 : View Daily Calendar");
            Console.WriteLine("2 : View Weekly Calendar");
            Console.WriteLine("3 : View Monthly Calendar");
            Console.WriteLine("4 : Return to Main Menu");
            string whack = Console.ReadLine();

            switch (whack)
            {
                case "1":
                    DailyView();
                break;
                case "2":
                    WeeklyView();
                break;
                case "3":
                    MonthlyView();
                break;
                case "4":
                    _running = false;
                break;
            }
        }
    }
    public DateTime GetToday()
    {
        return DateTime.Now;
    }
    public void DailyView()
    {
        {
        DateTime currentDate = GetToday();

        Console.WriteLine("- Daily Calendar -");
        Console.WriteLine($"Today's Date: {currentDate.ToShortDateString()}");

        List<Task> dailyTasks = new List<Task>();

        foreach (Task task in _tasks)
        {
            bool isDueToday = false;

            if (task.GetFreq() == 0)
            {
                isDueToday = task.GetDue().Year == currentDate.Year && task.GetDue().Month == currentDate.Month && task.GetDue().Day == currentDate.Day;
            }
            else if (task.GetFreq() == 1)
            {
                isDueToday = true;
            }
            if (isDueToday)
            {
                dailyTasks.Add(task);
            }
        }

        if (dailyTasks.Count == 0)
        {
            Console.WriteLine("No tasks for today.");
        }
        else
        {
            Console.WriteLine("Tasks for Today:");
            foreach (Task task in dailyTasks)
            {
                Console.WriteLine($"- {task.GetName()} ({task.GetDesc()})");
            }
        }
        }   
    }
    public void MonthlyView()
    {
        DateTime currentDate = GetToday();

        Console.WriteLine("- Monthly Calendar -");
        Console.WriteLine($"Current Month: {currentDate.ToString("MMMM yyyy")}");

        List<Task> monthlyTasks = new List<Task>();

        foreach (Task task in _tasks)
        {

            bool isDueThisMonth = false;

            if (task.GetFreq() == 0)
            {
                isDueThisMonth = task.GetDue().Year == currentDate.Year && task.GetDue().Month == currentDate.Month && task.GetDue().Day == currentDate.Day;
            }
            else if (task.GetFreq() == 3)
            {
                isDueThisMonth = task.GetDue().Year == currentDate.Year && task.GetDue().Month == currentDate.Month;
            }

            if (isDueThisMonth)
            {
                monthlyTasks.Add(task);
            }
        }

        if (monthlyTasks.Count == 0)
        {
            Console.WriteLine("No tasks for this month.");
        }
        else
        {
            Console.WriteLine("Tasks for This Month:");
            foreach (Task task in monthlyTasks)
            {
                Console.WriteLine($"- {task.GetName()} ({task.GetDesc()})");
            }
        }
    }
    public void WeeklyView()
    {
        DateTime currentDate = GetToday();

        Console.WriteLine("- Weekly Calendar -");
        Console.WriteLine($"Current Week: {currentDate.ToString("MMMM dd, yyyy")} - {currentDate.AddDays(6).ToString("MMMM dd, yyyy")}");

        List<Task> weeklyTasks = new List<Task>();

        DateTime weekStart = currentDate.AddDays(-(int)currentDate.DayOfWeek);
        DateTime weekEnd = weekStart.AddDays(6);

        foreach (Task task in _tasks)
        {
            bool isDueThisWeek = false;
            if (task.GetFreq() == 0)
            {
                isDueThisWeek = task.GetDue().Date == currentDate.Date;
            }
            else
            {
                isDueThisWeek = task.GetDue() >= weekStart && task.GetDue() <= weekEnd;
            }

            if (isDueThisWeek)
            {
                weeklyTasks.Add(task);
            }
        }

        if (weeklyTasks.Count == 0)
        {
            Console.WriteLine("No tasks for this week.");
        }
        else
        {
            Console.WriteLine("Tasks for This Week:");
            foreach (Task task in weeklyTasks)
            {
                Console.WriteLine($"- {task.GetName()} ({task.GetDesc()}) - Due Date: {task.GetDue().ToShortDateString()}");
            }
        }
    }
    public void AllTasks()
    {
        _taskM.ListItems();
    }
}