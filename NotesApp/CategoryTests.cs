using Xunit;
using NotesApp;

[Collection("SequentialTests")]
public class CategoryTests
{
    [Fact]
    public void TagsCategoryConstructor()
    {
        TagsCategory category = new TagsCategory();
        TagsCategory category2 = new TagsCategory("Tag", "Desc");
        Assert.True(category.Title == "");
        Assert.True(category.Description == "");
        Assert.True(category2.Title == "Tag");
        Assert.True(category2.Description == "Desc");
    }

    [Fact]
    public void TagsCategoryGet()
    {
        TagsCategory category = new TagsCategory("Tag", "Desc");
        Assert.True(category.Title == "Tag");
        Assert.True(category.Description == "Desc");
    }

    [Fact]
    public void TagsCategorySet()
    {
        TagsCategory category = new TagsCategory();
        category.Title = "Tag";
        category.Description = "Desc";
        category.Guid = "t";
        category.Items.Add(null);
        Assert.True(category.Title == "Tag");
        Assert.True(category.Description == "Desc");
        Assert.True(category.Guid == "t");
        Assert.True(category.Items.Count == 1);
    }

    [Fact]
    public void TagsCategoryListAdd() {
        TagsCategory category = new TagsCategory();
        category.Add(new Tag("First"));
        category.Add(new Tag("Second"));
        Assert.True(category.Items[0].Name == "First");
        Assert.True(category.Items[1].Name == "Second");
    }

    [Fact]
    public void TagsCategoryListRemove() {  
        TagsCategory categories = new TagsCategory();
        Tag tag = new Tag("Tag to test");
        categories.Add(tag);
        categories.Remove(tag);
        Assert.DoesNotContain(tag, categories.Items);
    }

    [Fact]
    public void TagsCategoryToString() {
        TagsCategory category = new TagsCategory("Tag", "Desc");
        Assert.True(category.ToString() == "Title: Tag; Description: Desc");
    }

    [Fact]
    public void TagCategoryDispose()
    {
        ObjectManager.Instance.ClearAll();
        TagsCategory category = new TagsCategory();
        category.Dispose();
        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.Empty(objects);
    }

    [Fact]
    public void NotesCategoryConstructor()
    {
        NotesCategory category = new NotesCategory();
        NotesCategory category2 = new NotesCategory("Note", "Desc");
        Assert.True(category.Title == "");
        Assert.True(category.Description == "");
        Assert.True(category2.Title == "Note");
        Assert.True(category2.Description == "Desc");
    }

    [Fact]
    public void NotesCategoryGet()
    {
        NotesCategory category = new NotesCategory("Note", "Desc");
        Assert.True(category.Title == "Note");
        Assert.True(category.Description == "Desc");
    }

    [Fact]
    public void NotesCategorySet()
    {
        NotesCategory category = new NotesCategory();
        category.Title = "Note";
        category.Description = "Desc";
        category.Guid = "n";
        category.Items.Add(null);
        Assert.True(category.Title == "Note");
        Assert.True(category.Description == "Desc");
        Assert.True(category.Guid == "n");
        Assert.True(category.Items.Count == 1);
    }

    [Fact]
    public void NotesCategoryListAdd()
    {
        NotesCategory category = new NotesCategory();
        category.Add(new Note("First"));
        category.Add(new Note("Second"));
        Assert.True(category.Items[0].Title == "First");
        Assert.True(category.Items[1].Title == "Second");
    }

    [Fact]
    public void NotesCategoryListRemove()
    {
        NotesCategory categories = new NotesCategory();
        Note note = new Note("Note to test");
        categories.Add(note);
        categories.Remove(note);
        Assert.DoesNotContain(note, categories.Items);
    }

    [Fact]
    public void NotesCategoryToString()
    {
        NotesCategory category = new NotesCategory("Note", "Desc");
        Assert.True(category.ToString() == "Title: Note; Description: Desc");
    }

    [Fact]
    public void NotesCategoryEquals() 
    {
        NotesCategory category1 = new NotesCategory("Title", "Desc");
        NotesCategory category2 = new NotesCategory(category1);
        Assert.True(category1 ==category2);   
    }

    [Fact]
    public void NotesCategoryNotEquals()
    {
        NotesCategory category1 = new NotesCategory();
        NotesCategory category2 = new NotesCategory();
        Assert.True(category1 != category2);
    }

    [Fact]
    public void NotesCategoryDispose()
    {
        ObjectManager.Instance.ClearAll();
        NotesCategory category = new NotesCategory();
        category.Dispose();
        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.Empty(objects);
    }
}