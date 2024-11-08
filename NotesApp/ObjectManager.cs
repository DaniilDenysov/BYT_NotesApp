using System.Xml.Serialization;

namespace NotesApp;
public static class ObjectManager
{

    private static List<IDisposable> objects = new List<IDisposable>();

    public static void init(List<IDisposable> d)
    {
        objects = d;
    }

    public static IReadOnlyList<IDisposable> getAllData()
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
