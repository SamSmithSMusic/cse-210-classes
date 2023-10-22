using System.ComponentModel.DataAnnotations;

public class UserManager : Manager
{
    public UserManager() : base()
    {

    }
        public void Run()
    {
        while (base._running)
        {
            Load();
            Console.WriteLine("- Task Menu -");
            Console.WriteLine("1 : Create User");
            Console.WriteLine("2 : Remove User");
            Console.WriteLine("3 : Display LeaderBoard");
            Console.WriteLine("4 : Login");
            Console.WriteLine("5 : Logout");
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
    public void DisplayLeaders()
    {

    }
    public void Login()
    {

    }
    public void Logout()
    {

    }
}