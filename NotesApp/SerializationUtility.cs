using System.Xml.Serialization;

namespace NotesApp;

public static class SerializationUtility
{
    private static readonly string DataFile = "data.xml";

    public static void SaveAll()
    {
        DataContainer data = new DataContainer
        {
            Tags = ObjectManager.AllTags,
            TagsCategories = ObjectManager.TagsCategories,
            Notes = ObjectManager.AllNotes,
            NotesCategories = ObjectManager.NotesCategories
        };
        Serialize(data, DataFile);
    }

    public static void LoadAll()
    {
        DataContainer data = Deserialize<DataContainer>(DataFile) ?? new DataContainer();


        ObjectManager.init(
            data.Tags,
            data.TagsCategories,
            data.Notes,
            data.NotesCategories
        );
    }

    private static void Serialize<T>(T data, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            Console.WriteLine("Serializing data to " + filePath);
            serializer.Serialize(writer, data);
        }
    }

    private static T? Deserialize<T>(string filePath) where T : class
    {
        if (!File.Exists(filePath)) return null;

        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StreamReader reader = new StreamReader(filePath))
        {
            return (T?)serializer.Deserialize(reader);
        }
    }
}

[Serializable]
public class DataContainer
{
    public List<Tag> Tags { get; set; } = new List<Tag>();
    public List<TagsCategory> TagsCategories { get; set; } = new List<TagsCategory>();
    public List<Note> Notes { get; set; } = new List<Note>();
    public List<NotesCategory> NotesCategories { get; set; } = new List<NotesCategory>();
}