using System.Collections;
using System.Runtime.CompilerServices;

public class TaskManager : Manager
{
    private List<Task> tasks = new List<Task>();
    public TaskManager(): base()
    {

    }

    public void Run()
    {
        while (base._running)
        {
            Load();
            Console.WriteLine("- Task Menu -");
            Console.WriteLine("1 : Create Task");
            Console.WriteLine("2 : Remove Task");
            Console.WriteLine("3 : Add Task to User");
            Console.WriteLine("4 : Remove Task from User");
            Console.WriteLine("5 : See Completed Tasks for a User");
            Console.WriteLine("6 : List Tasks");
            Console.WriteLine("7 : Save and Exit to Main Menu");
            Console.WriteLine("8 : Exit Without Saving");
            string whack = Console.ReadLine();

            switch (whack)
            {
                case "1":
                CreateItem();
                break;
                case "2":
                RemoveItem();
                break;
                case "3":
                AddToUser();
                break;
                case "4":
                RemoveFromUser();
                break;
                case "5":
                GetCompletedTasks();
                break;
                case "6":
                ListItems();
                break;
                case "7":
                Save();
                _running = false;
                break;
                case "8":
                _running = false;
                break;
                default:
                    Console.WriteLine("Invalid Entry, please try again.");
                break;
            }
        }
    }
    public void AddToUser()
    {

    }
    public void RemoveFromUser()
    {

    }
    public List<Task> GetCompletedTasks()
    {
            return tasks;
    }
    public override void CreateItem()
    {
        
    }
    public override void ListItems()
    {

    }
    public override void Save()
    {

    }
    public override void Load()
    {

    }
    public override void RemoveItem()
    {

    }
    
}