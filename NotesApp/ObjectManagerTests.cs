using NotesApp;
using Xunit;

public class ObjectManagerTests
{

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
        Assert.True(objects[2] as Note == note2);
        Assert.True(objects[3] as Tag == tag1);
        Assert.True(objects[4] as Tag == tag2);
        Assert.True(objects[5] as TagsCategory == tagsCategory);
        Assert.True(objects[6] as NotesCategory == notesCategory);
    }

    [Fact]
    public void ObjectManager_DeleteObject()
    {
        ObjectManager.Instance.ClearAll();
        Note note1 = new Note("First note");
        Note note2 = new Note("Second note");
        Tag tag1 = new Tag("First tag");
        Tag tag2 = new Tag("Second tag");
        TagsCategory tagsCategory = new TagsCategory("The great tags category");
        NotesCategory notesCategory = new NotesCategory("The great notes category");

        tag2.Dispose();
        tagsCategory.Dispose();
        note1.Dispose();

        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();

        Assert.False(objects.Contains(tag2));
        Assert.False(objects.Contains(tagsCategory));
        Assert.False(objects.Contains(note1));
    }
}
