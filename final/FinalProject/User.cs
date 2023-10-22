public class User
{
    private string _username;
    private string _password;

    User(string username,string password)
    {
        _username = username;
        _password = password;
    }
    public string GetUsername()
    {
        return _username;
    }
    public bool CheckLogin()
    {
        return false;
    }
}