public class Calendar
{
    private string _year;
    private string _month;
    private string _day;
    private string _date;
    private bool running = true;
    public void Run()
    {
        while (running)
        {
            Console.WriteLine("- Calendar Menu -");
            Console.WriteLine("1 : View Daily Calendar");
            Console.WriteLine("2 : View Weekly Calendar");
            Console.WriteLine("3 : Viwe Monthly Calendar");
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
                    running = false;
                break;
            }
        }
    }
    public string GetToday()
    {
        return "TODAY ERROR";
    }
    public void DailyView()
    {

    }
    public void MonthlyView()
    {

    }
    public void WeeklyView()
    {

    }
    public void AllTasks()
    {
        
    }
}