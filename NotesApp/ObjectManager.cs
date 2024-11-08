using System.Xml.Serialization;

namespace NotesApp;
public static class ObjectManager
{

    private static List<Object> objects = new List<Object>();

    public static void init(List<Object> d)
    {
        objects = d;
    }

    public static IReadOnlyList<Object> getAllData()
    {
        return objects.AsReadOnly();
    }

    public static void addObject(IDisposable d)
    {
        objects.Add(d);
    }

    public static void removeObj(IDisposable d)
    {
        objects.Remove(d);
    }
}
