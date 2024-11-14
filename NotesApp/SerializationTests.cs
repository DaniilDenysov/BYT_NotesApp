using NotesApp;
using Xunit;


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
        Assert.True(deserializedNote != null);
        Assert.Equal(serializedNote.Guid,deserializedNote.Guid);
        Assert.Equal(serializedNote.LastModificationDate, deserializedNote.LastModificationDate);
        Assert.Equal(serializedNote.CreationDate, deserializedNote.CreationDate);
        Assert.Equal(serializedNote.Content, deserializedNote.Content);
        Assert.Equal(serializedNote.Priority ,deserializedNote.Priority);
        Assert.Equal(serializedNote.Title, deserializedNote.Title);
    }

    [Fact]
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
    }

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
    
    [Fact]
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
    }


    
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

    [Fact]
    public void ObjectManager_CreateNote_CreateTag_CreateCategories()
    {
        ObjectManager.Instance.ClearAll();
        Note note1 = new Note("First note");
        Note note2 = new Note("Second note");
        Tag tag1 = new Tag("First tag");
        Tag tag2 = new Tag("Second tag");
        TagsCategory tagsCategory = new TagsCategory("The great tags category");
        NotesCategory notesCategory = new NotesCategory("The great notes category");


        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();

        Assert.True(objects[0] as Note == note1);
        Assert.True(objects[1] as Note == note2);
        Assert.True(objects[2] as Tag == tag1);
        Assert.True(objects[3] as Tag == tag2);
        Assert.True(objects[4] as TagsCategory == tagsCategory);
        Assert.True(objects[5] as NotesCategory == notesCategory);
    }
}