public class User
{
    private string _username;
    private string _password;
    private int _completed;

    public User(string username,string password, int completed)
    {
        _username = username;
        _password = password;
        _completed = completed;
    }
    public string GetUsername()
    {
        return _username;
    }
    public string GetPassword()
    {
        return _password;
    }

    public string GetStringRep()
    {
        return $"{_username} ; {_password}";
    }

    public int GetCompletedNum()
    {
        return _completed;
    }

    public void SetCompleted(int i)
    {
        _completed += i;
    }

}