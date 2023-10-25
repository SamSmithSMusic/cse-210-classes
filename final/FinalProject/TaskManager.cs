using System.Collections;
using System.Runtime.CompilerServices;

public class TaskManager : Manager
{
    private UserManager userM = new UserManager();
    public TaskManager(UserManager UserM): base()
    {
        UserManager userM = UserM;
    }
    public TaskManager()
    {
        Load();
    }
    private List<Task> _tasks = new List<Task>();
    private List<User> _users = new List<User>();
    public void Run()
    {
        _running = true;
        _users = userM.GetUserList();
        while (base._running)
        {
            Load();
            Console.WriteLine("- Task Menu -");
            Console.WriteLine("1 : Create Task");
            Console.WriteLine("2 : Remove Task");
            Console.WriteLine("3 : Complete a Task");
            Console.WriteLine("4 : List Tasks");
            Console.WriteLine("5 : Save and Exit to Main Menu");
            Console.WriteLine("6 : Exit Without Saving");
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
                RecordEvent();
                break;
                case "4":
                ListItems();
                break;
                case "5":
                Save();
                _running = false;
                break;
                case "6":
                _running = false;
                break;
                default:
                    Console.WriteLine("Invalid Entry, please try again.");
                break;
            }
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("In order to log an event please login.");
        userM.Login();

        ListItems();
        Console.WriteLine("Which task would you like to complete?");
        string temp = Console.ReadLine();
        if(_tasks[int.Parse(temp)].IsComplete())
        {
            Console.WriteLine("You cannot re-complete this task.");
        }
        else
        {
            _tasks[int.Parse(temp)].RecordEvent();
            Console.WriteLine("Event Recorded");
        }
        User eventUser = userM.GetLoggedInUser();
        eventUser.SetCompleted(1);
    }
    public override void CreateItem()
    {
        Console.WriteLine(" Would you like to create a (1)One time task, or a (2) repeated task?");
        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Enter the task name : ");
                string title = Console.ReadLine();

                Console.Write("Enter a short Task description : ");
                string desc = Console.ReadLine();

                DateTime duedate = new DateTime();
                _success = false;
                while (!_success)
                {
                Console.Write("Enter the task due date (yyyy-MM-dd) : ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    duedate = dueDate;
                    _success  =true;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please Try Again.");
                }
                }
                
                int priority = 0;
                _success = false;
                while (!_success)
                {
                Console.WriteLine("What priority is this task? (1)Low (2)Medium (3)High : ");
                string temp = Console.ReadLine();
                if (temp == "1" || temp == "2" || temp == "3")
                {
                    priority = int.Parse(temp);
                    _success = true;
                }
                else
                {
                    Console.WriteLine("Invalid Entry, Please Try again.");
                }
                }

                _tasks.Add(new SimpleTask(title,desc,duedate,priority,false,0));
                Console.WriteLine("Simple Task Created.");
            break;

            case "2":
                Console.Write("Will this Task ever be fully completed? (0)Yes (1)No : ");
                int type = int.Parse(Console.ReadLine());

                Console.Write("Enter the task name : ");
                string title1 = Console.ReadLine();

                Console.Write("Enter a short Task description : ");
                string desc1 = Console.ReadLine();

                DateTime duedate1 = new DateTime();
                if (type == 0)
                {
                _success = false;
                while (!_success)
                {
                Console.Write("Enter the task due date (yyyy-MM-dd) : ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    duedate1 = dueDate;
                    _success  =true;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please Try Again.");
                }
                }    
                }
                
                int priority1 = 0;
                _success = false;
                while (!_success)
                {
                    Console.WriteLine("What priority is this task? (1)Low (2)Medium (3)High : ");
                    string temp = Console.ReadLine();
                    if (temp == "1" || temp == "2" || temp == "3")
                    {
                        priority = int.Parse(temp);
                        _success = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry, Please Try again.");
                    }
                }

                int frequency = 00;
                _success = false;
                while (!_success)
                {
                    Console.WriteLine("How often would you like to be reminded of this task? (1)Daily (2)Weekly (3)Monthly : ");
                    string temp = Console.ReadLine();
                    if (temp == "1" || temp == "2" || temp == "3")
                    {
                        frequency = int.Parse(temp);
                        _success = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry, Please Try again.");
                    }
                }

                _tasks.Add(new RepeatedTask(type,title1,desc1,duedate1,priority1,false,0));
                Console.WriteLine("Repeated Task Created.");
            break;
        } 
    }
    public override void ListItems()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            Console.WriteLine("- List of Tasks -");
            for (int i = 0; i < _tasks.Count; i++)
            {
                Task task = _tasks[i];
                if (!task.IsComplete())
                {
                    Console.WriteLine($"{i + 1} : {task.GetName()} [ ]- Due Date: {task.GetDue().ToShortDateString()} - Priority: {task.GetPriority()}");
                }
                if (task.IsComplete())
                {
                    Console.WriteLine($"{i +1} : {task.GetName()} [X] COMPLETED");
                }
            }
        }
    }
    public override void Save()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("taskData.txt"))
            {
                foreach (Task task in _tasks)
                {
                    writer.WriteLine(task.GetStringRep());
                }

                Console.WriteLine("Task data saved successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving task data: {ex.Message}");
        }
    }
    public override void Load()
    {
        try
        {
            using (StreamReader reader = new StreamReader("taskData.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 7)
                    {
                        int type = int.Parse(parts[0]);
                        string title = parts[1];
                        string description = parts[2];
                        DateTime dueDate = DateTime.Parse(parts[3]);
                        int priority = int.Parse(parts[4]);
                        bool complete = bool.Parse(parts[5]);
                        int frequency = int.Parse(parts[6]);
                        _tasks.Add(new RepeatedTask(type,title,description,dueDate,priority,complete,frequency));
                    }
                    else if (parts.Length == 6)
                    {
                        string title = parts[0];
                        string description = parts[1];
                        DateTime dueDate = DateTime.Parse(parts[2]);
                        int priority = int.Parse(parts[3]);
                        bool complete = bool.Parse(parts[4]);
                        int frequency = int.Parse(parts[5]);
                        _tasks.Add(new SimpleTask(title,description,dueDate,priority,complete,frequency));
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading task data: {ex.Message}");
        }

        if (File.Exists("userData.txt"))
        {
            try
            {
                using (StreamReader reader = new StreamReader("userData.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length == 3)
                        {
                            string username = parts[0];
                            string password = parts[1];
                            int tasks = int.Parse(parts[2]);
                            
                            _users.Add(new User(username,password,tasks));
                        }
                    }

                    Console.WriteLine("User data loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Users: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("No User txt file found.");
        }

    }
    public override void RemoveItem()
    {
        ListItems();

        if (_tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to remove.");
            return;
        }

        Console.Write("Enter the task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= _tasks.Count)
        {
            _tasks.RemoveAt(taskNumber-1);
            Console.WriteLine("Task removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid task number. No task removed.");
        }
    }
    
    public List<Task> GetTasks()
    {
        return _tasks;
    }
}