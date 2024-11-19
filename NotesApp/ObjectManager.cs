using System.Xml.Serialization;

namespace NotesApp;
public class ObjectManager
{
    private static ObjectManager _instance = new ObjectManager();
    public static ObjectManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ObjectManager();
            }

            return _instance;
        }
        
        private set
        {
            _instance = value;
        }
    }

    private List<Object> objects = new List<Object>();

    public ObjectManager()
    {

    }
    
    public ObjectManager(List<Object> d)
    {
        objects = d;
    }

    public void ClearAll()
    {
        objects.Clear();
    }
    

    public IReadOnlyList<Object> GetAllData()
    {
        return objects.AsReadOnly();
    }

    public void AddObject<T>(T d)
    {
        if (d == null)
            throw new ArgumentNullException("Object added cannot be null");
        objects.Add(d);
    }

    public void RemoveObj<T>(T d)
    {
        if (d == null) return;
        objects.Remove(d);
    }
}
