using NotesApp;
using Xunit;

[Collection("SequentialTests")]
public class SerializationTests
{
    [Fact]
    public void Serialization_Deserialization_Note_Test()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml");
        
       
        
        if (File.Exists(path))
        {
           File.Delete(path);
        }
        Note serializedNote = new Note("Hello","World",Guid.NewGuid().ToString());
        SerializationUtility.Serialize(serializedNote,path);
        Assert.True(File.Exists(path));
        Note deserializedNote = SerializationUtility.Deserialize<Note>(path);

       

        DateTime LeftCreate = new DateTime(serializedNote.GetCreationDate().Ticks - (serializedNote.GetCreationDate().Ticks % TimeSpan.TicksPerSecond), serializedNote.GetCreationDate().Kind);
        DateTime RightCreate = new DateTime(deserializedNote.GetCreationDate().Ticks - (deserializedNote.GetCreationDate().Ticks % TimeSpan.TicksPerSecond), deserializedNote.GetCreationDate().Kind);
        DateTime LeftMod = new DateTime(serializedNote.GetLastModificationDate().Ticks - (serializedNote.GetLastModificationDate().Ticks % TimeSpan.TicksPerSecond), serializedNote.GetLastModificationDate().Kind);
        DateTime RightMod = new DateTime(deserializedNote.GetLastModificationDate().Ticks - (deserializedNote.GetLastModificationDate().Ticks % TimeSpan.TicksPerSecond), deserializedNote.GetLastModificationDate().Kind);


        Assert.True(deserializedNote != null);
        Assert.Equal(serializedNote.Guid,deserializedNote.Guid);
        Assert.Equal(LeftMod, RightMod);
        Assert.Equal(LeftCreate, RightCreate);
        Assert.Equal(serializedNote.Content, deserializedNote.Content);
        Assert.Equal(serializedNote.Priority ,deserializedNote.Priority);
        Assert.Equal(serializedNote.Title, deserializedNote.Title);
    }

/*    [Fact]
    public void Serialization_Deserialization_Tag_Test()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml");
        
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        
        Tag serializedTag = new Tag("SampleTag", "A sample tag for testing", Guid.NewGuid().ToString());
        SerializationUtility.Serialize(serializedTag, path);
        Assert.True(File.Exists(path));
        Tag deserializedTag = SerializationUtility.Deserialize<Tag>(path);
        Assert.NotNull(deserializedTag);
        Assert.Equal(serializedTag.Guid, deserializedTag.Guid);
        Assert.Equal(serializedTag.Name, deserializedTag.Name);
        Assert.Equal(serializedTag.Description, deserializedTag.Description);
    }*/

    [Fact]
    public void Serialization_Deserialization_NotesCategory_Test()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml");
        
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        Note serializedNote1 = new Note("Note1","Hello",Guid.NewGuid().ToString());
        Note serializedNote2 = new Note("Note2","World",Guid.NewGuid().ToString());
        NotesCategory serializedNotesCategory = new NotesCategory("Category1","First");
        serializedNotesCategory.Add(serializedNote1);
        serializedNotesCategory.Add(serializedNote2);
        SerializationUtility.Serialize(serializedNotesCategory,path);
        Assert.True(File.Exists(path));
        NotesCategory deserializedNotesCategory = SerializationUtility.Deserialize<NotesCategory>(path);



        Assert.Equal(serializedNotesCategory.Guid,deserializedNotesCategory.Guid);
        Assert.Equal(serializedNotesCategory.Title,deserializedNotesCategory.Title);
        Assert.Equal(serializedNotesCategory.Description,deserializedNotesCategory.Description);
        Assert.Equal(serializedNotesCategory.Items.Count,deserializedNotesCategory.Items.Count);

        for (int i = 0; i < Math.Max(serializedNotesCategory.Items.Count,deserializedNotesCategory.Items.Count); i++)
        {
            Assert.True(serializedNotesCategory.Items[i] == deserializedNotesCategory.Items[i]);
        }
    }
    
   /* [Fact]
    public void Serialization_Deserialization_TagsCategory_Test()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tags_test.xml");
        
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        
        Tag tag1 = new Tag("Tag1", "Description1", Guid.NewGuid().ToString());
        Tag tag2 = new Tag("Tag2", "Description2", Guid.NewGuid().ToString());
        
        TagsCategory serializedTagsCategory = new TagsCategory("Category1", "First tag category");
        serializedTagsCategory.Add(tag1);
        serializedTagsCategory.Add(tag2);

        SerializationUtility.Serialize(serializedTagsCategory, path);
        Assert.True(File.Exists(path));
        
        TagsCategory deserializedTagsCategory = SerializationUtility.Deserialize<TagsCategory>(path);
        
        Assert.Equal(serializedTagsCategory.Guid, deserializedTagsCategory.Guid);
        Assert.Equal(serializedTagsCategory.Title, deserializedTagsCategory.Title);
        Assert.Equal(serializedTagsCategory.Description, deserializedTagsCategory.Description);
        Assert.Equal(serializedTagsCategory.Items.Count, deserializedTagsCategory.Items.Count);
        
        for (int i = 0; i < Math.Max(serializedTagsCategory.Items.Count,deserializedTagsCategory.Items.Count); i++)
        {
            Assert.True(serializedTagsCategory.Items[i] == deserializedTagsCategory.Items[i]);
        }
    }*/


    
    [Fact]
    public void SaveAll_LoadAll_Test()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml");

        if (File.Exists(path))
        {
            File.Delete(path);
        }
        ObjectManager.Instance.ClearAll();
        Note serializedNote1 = new Note("Note1","Hello",Guid.NewGuid().ToString());
        Note serializedNote2 = new Note("Note2","World",Guid.NewGuid().ToString());
        SerializationUtility.SaveAll(path);

        SerializationUtility.LoadAll(path);

        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.Equal(objects.Count, 2);
        Assert.True(objects[0] as Note == serializedNote1);
        Assert.True(objects[1] as Note == serializedNote2);
    }

   
}