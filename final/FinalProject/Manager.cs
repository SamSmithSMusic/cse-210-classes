using System.Runtime.CompilerServices;
using System.Xml.Linq;

public abstract class Manager{
    protected bool _running = true;
    protected bool _success = false;

    public abstract void CreateItem();
    public abstract void ListItems();
    public abstract void Save();
    public abstract void Load();
    public abstract void RemoveItem();
}