using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

public class UserManager : Manager
{
    public UserManager() : base()
    {

    }
    private List<User> _users = new List<User>();
    private User LoggedInUser =null;
    private List<User> sortedUsers = new List<User>();

    public void Run()
    {
        _running = true;
        while (base._running)
        {
            Load();
            Console.WriteLine("- User Menu -");
            Console.WriteLine("1 : Create User");
            Console.WriteLine("2 : Remove User");
            Console.WriteLine("3 : Display LeaderBoard");
            Console.WriteLine("4 : Login");
            Console.WriteLine("5 : Logout");
            Console.WriteLine("6 : List Users");
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
                DisplayLeaders();
                break;
                case "4":
                Login();
                break;
                case "5":
                Logout();
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
    public override void CreateItem()
    {
        Console.WriteLine("What would you like the name of the user to be?");
        string username = Console.ReadLine();

        Console.WriteLine("Enter the password for the new user: ");
        string password = Console.ReadLine();

        _users.Add(new User(username, password, 0));

        Console.WriteLine("User Created Successfully!");
    }
    public override void ListItems()
    {
        Load();
        if (_users.Count == 0)
        {
            Console.WriteLine("No users found.");
        }
        else
        {
            int i = 1;
            Console.WriteLine("List of Users:");
            foreach (User user in _users)
            {
                Console.WriteLine($"{i} : {user.GetUsername()}");
                i++;
            }
        }
    }
    public override void Save()
    {   
        try
        {
            using (StreamWriter writer = new StreamWriter("userData.txt"))
            {
                foreach (User user in _users)
                {
                    writer.WriteLine(user.GetStringRep());
                }

                Console.WriteLine("User data saved successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving user data: {ex.Message}");
        }
    }
    public override void Load()
    {
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
        _success = false;
        while (!_success)
        {
            ListItems();
            Console.WriteLine((_users.Count() + 1) + " : Nevermind");
            Console.Write("Please enter the number of the user you would like to remove: ");
            
            int choice = _users.Count() + 1;
            try
            {
            choice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid Choice.");
            }
            if (choice == _users.Count() + 1)
            {
                break;
            }
            else 
            {
                _users.RemoveAt(choice -1);
                Console.WriteLine($"User Removed : {_users[choice-1].GetUsername()}");
                _success = true;
            }
        }
    }
    public void DisplayLeaders()
    {
        Console.WriteLine("Leaderboard: (* Logged In User)");
    
    sortedUsers = _users.OrderByDescending(user => user.GetCompletedNum()).ToList();
    
    foreach (User user in sortedUsers)
    {
        int i = 0;
        string userString = $"{i + 1}. {user.GetUsername()} (Completed Tasks: {user.GetCompletedNum()})";
        
        if (LoggedInUser != null && user == LoggedInUser)
        {
            userString += " *";
        }
        
        Console.WriteLine(userString);
    }
    }
    public void Login()
    {
        Load();
        _success = false;
        while (!_success)
        {
            Console.Write("\nEnter Your Username (Not Case Sensitive): ");
            string enteredU = Console.ReadLine();
            foreach (User user in _users)
            {
                if (user.GetUsername().ToLower().Trim() == enteredU.ToLower().Trim())
                {
                    _success = true;
                    Console.WriteLine($"User \"{user.GetUsername()}\" found.");
                    break;
                }
            }
            if (!_success)
            {
                Console.WriteLine("Username not found, please try again.");
            }
        }
        _success = false;
        while (!_success)
        {
            Console.Write("\nEnter Your Password (Case Sensitive): ");
            string enteredP = Console.ReadLine();
            foreach (User user in _users)
            {
                if (user.GetPassword().Trim() == enteredP.Trim())
                {
                    _success = true;
                    Console.WriteLine($"Logged in as \"{user.GetUsername()}\"");
                    LoggedInUser = user;
                    break;
                }
            }
            if (!_success)
            {
                Console.WriteLine("Incorrect Password.");
            }
        }
    }
    public void Logout()
    {
        if (LoggedInUser == null)
        {
        Console.WriteLine("No one is currently logged in.");
        }
        else
        {
            LoggedInUser = null;
            Console.WriteLine("Successfully Logged Out.\n");
        }
    }
    public List<User> GetUserList()
    {
        return _users;
    }

    public User GetLoggedInUser()
    {
        return LoggedInUser;
    }
}