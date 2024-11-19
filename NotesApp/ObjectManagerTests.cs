using NotesApp;
using Xunit;

[Collection("SequentialTests")]
public class ObjectManagerTests
{
    [Fact]
    public void ObjectManagerCreateNote()
    {
        ObjectManager.Instance.ClearAll();
        Note note1 = new Note("First note");
        Note note2 = new Note("Second note");

        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();

        Assert.True(objects[0] as Note == note1);
        Assert.True(objects[1] as Note == note2);
    }

    [Fact]
    public void ObjectManagerCreateTag()
    {
        ObjectManager.Instance.ClearAll();
        Tag tag1 = new Tag("First tag");
        Tag tag2 = new Tag("Second tag");

        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.True(objects[0] as Tag == tag1);
        Assert.True(objects[1] as Tag == tag2);
    }

    [Fact]
    public void ObjectManagerCreateTagsCategory() {
        ObjectManager.Instance.ClearAll();
        TagsCategory tagsCategory1 = new TagsCategory("The great tags category1");
        TagsCategory tagsCategory2 = new TagsCategory("The great tags category2");

        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.True(objects[0] as TagsCategory == tagsCategory1);
        Assert.True(objects[1] as TagsCategory == tagsCategory2);
    }

    [Fact]
    public void ObjectManagerCreateNoteCategory()
    {
        ObjectManager.Instance.ClearAll();
        NotesCategory notesCategory1 = new NotesCategory("The great notes category1");
        NotesCategory notesCategory2 = new NotesCategory("The great notes category2");

        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.True(objects[0] as NotesCategory == notesCategory1);
        Assert.True(objects[1] as NotesCategory == notesCategory2);
    }

    [Fact]
    public void ObjectManager_CreateAllObj()
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
