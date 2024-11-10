using System.Xml.Serialization;

namespace NotesApp;
public static class ObjectManager
{

    private static List<Object> objects = new List<Object>();

    public static void Init(List<Object> d)
    {
        objects = d;
    }

    public static IReadOnlyList<Object> GetAllData()
    {
        return objects.AsReadOnly();
    }

    public static void AddObject<T>(T d)
    {
        if (d == null) return;
        objects.Add(d);
    }

    public static void RemoveObj<T>(T d)
    {
        if (d == null) return;
        objects.Remove(d);
    }
}
