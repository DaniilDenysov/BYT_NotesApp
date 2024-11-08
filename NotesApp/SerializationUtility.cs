using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using NotesApp;

public static class SerializationUtility
{
    private static readonly string DataFile = "C:\\Users\\Aleks\\source\\repos\\BYT_NotesApp\\NotesApp\\data.xml";

    public static void SaveAll()
    {
        DataContainer data = new DataContainer
        {
            Objects = ObjectManager.getAllData().ToList()  
        };
        Serialize(data, DataFile);
    }

    public static void LoadAll()
    {
        DataContainer data = Deserialize<DataContainer>(DataFile) ?? new DataContainer();

        if (data.Objects.Count == 0)
        {
            Console.WriteLine("No objects loaded from the XML file.");
        }
        else
        {
            Console.WriteLine($"Loaded {data.Objects.Count} objects.");
            ObjectManager.init(data.Objects);
        }

        Console.WriteLine("Deserialization completed.");
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

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (T?)serializer.Deserialize(reader);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Deserialization error: " + ex.Message);
            return null;
        }
    }

}



[Serializable]
[XmlInclude(typeof(Tag))]
[XmlInclude(typeof(TagsCategory))]
[XmlInclude(typeof(Note))]
[XmlInclude(typeof(NotesCategory))]
public class DataContainer
{
    [XmlArray("Objects")]
    [XmlArrayItem("Object")]
    public List<Object> Objects { get; set; } = new List<Object>();
}
