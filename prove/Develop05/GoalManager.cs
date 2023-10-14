using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();

    private bool success = false;
    private int totalPoints = 0;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            success = false;
            Console.WriteLine($"You have {totalPoints} points.\n");
            Console.WriteLine("Goal Manager Menu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "4":
                    CreateGoal();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    SaveGoals();
                    break;
                case "7":
                    LoadGoals();
                    break;
                case "8":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    { 
        Console.WriteLine($"You have {totalPoints} points.\n");
    }

    public void ListGoals()
    {
        int i = 0;
        Console.WriteLine("Your current goals are:");
        foreach (Goal goal in goals)
        {
            i++;
            if (goal.IsComplete())
            {
                Console.Write($"{i} : [X] {goal.GetName()} ({goal.GetDesc()})");
            }
            else if (!goal.IsComplete())
            {
                Console.Write($"{i} : [ ] {goal.GetName()} ({goal.GetDesc()})");
            }
            else{
                Console.Write("Debug in listgoals()");
            }  

            if (goal is ChecklistGoal)
            {
                ChecklistGoal check = (ChecklistGoal)goal;
                Console.WriteLine($" ꟷ Currently Completed: {check.GetAmountCompleted()}");
            }
            else{
                Console.WriteLine("\n");
            }
            
        }
    }

    public void CreateGoal()
    {
        int points;
        string name;
        string description;
        while (!success)
        {
            Console.Write("The types of Goals are:\n   1 : Simple Goal\n   2 : Eternal Goal\n   3 : Checklist Goal\nWhich type of goal would you like to create? ");
            string tempChoice = Console.ReadLine();
            switch (tempChoice)
            {
                case "1":
                    Console.Write("Enter Goal Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Goal Description: ");
                    description = Console.ReadLine();
                    Console.Write("Enter Goal Points Integer: ");
                    points = int.Parse(Console.ReadLine());

                    goals.Add(new SimpleGoal(name,description,points,false));

                    success =true;
                break;

                case "2":
                    Console.Write("Enter Goal Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Goal Description: ");
                    description = Console.ReadLine();
                    Console.Write("Enter Goal Points Integer: ");
                    points = int.Parse(Console.ReadLine());

                    goals.Add(new EternalGoal(name,description,points));

                    success =true;
                break;

                case "3":
                    Console.Write("Enter Goal Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Goal Description: ");
                    description = Console.ReadLine();
                    Console.Write("Base Point Reward: ");
                    points = int.Parse(Console.ReadLine());
                    Console.Write("Times Completed for Bonus: ");
                    int checklistLength = int.Parse(Console.ReadLine());
                    Console.Write("Bonus Amount: ");
                    int bonusPoints = int.Parse(Console.ReadLine());

                    goals.Add(new ChecklistGoal(name, description, points, checklistLength, bonusPoints, 0,false));

                success =true;
                break;

                default:
                success =false;
                Console.WriteLine("Invalid Choice");
                break;
            }
        }
        Console.WriteLine("Goal created and added to the list.");
    }

    public void RecordEvent()
    {
        ListGoals();
        int choice = 0;
        success= false;
        while (!success)
        {
            Console.Write("Which goal did you accomplish? ");
            string tempChoice = Console.ReadLine();
            if (int.TryParse(tempChoice, out int i))
            {
                choice = i;
                success = true;
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }
        if (!goals[choice - 1].IsComplete())
        {
            AddPoints(goals[choice -1].RecordEvent());
        }
        else if (goals[choice - 1].IsComplete())
        {
            Console.WriteLine("This goal cannot be re-completed.");
        }
        else{
            Console.WriteLine("Error in recordevent redudancy");
        }
    }

    public void AddPoints(int amount)
    {
        totalPoints += amount;
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalPoints);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRep());
            }
        }
        Console.WriteLine("Goals saved to file.");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    //points
                    if (parts.Length == 1)
                    {
                        totalPoints = int.Parse(parts[0]);
                    }
                    //Simple
                    if (parts.Length == 4)
                    {
                        string name = parts[0];
                        string desc = parts[1];
                        int points = int.Parse(parts[2]);
                        bool completed = bool.Parse(parts[3]);

                        SimpleGoal goal = new SimpleGoal(name, desc, points, completed);
                        goals.Add(goal);
                    }
                    //Eternal
                    else if (parts.Length == 3)
                    {
                        string name = parts[0];
                        string desc = parts[1];
                        int points = int.Parse(parts[2]);

                        EternalGoal goal = new EternalGoal(name, desc, points);
                        goals.Add(goal);
                    }
                    //Checklist
                    else if (parts.Length == 7)
                    {
                        string name = parts[0];
                        string desc = parts[1];
                        int points = int.Parse(parts[2]);
                        int target = int.Parse(parts[3]);
                        int bonus = int.Parse(parts[4]);
                        int completed = int.Parse(parts[5]);
                        bool complete = bool.Parse(parts[6]);

                        ChecklistGoal goal = new ChecklistGoal(name, desc, points, target, bonus, completed, complete);
                        goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded from file.");
        }
        else
        {
            Console.WriteLine("No goals file found.");
        }
    }
}