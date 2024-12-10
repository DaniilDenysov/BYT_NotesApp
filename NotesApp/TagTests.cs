using NotesApp;
using Xunit;

[Collection("SequentialTests")]
public class TagTests
{
    [Fact]
    public void TestTagConstructor()
    {
        Tag tag1 = new Tag();
        Tag tag2 = new Tag("Tag to test", "Teest", "t");
        Tag tag3 = new Tag();

        Assert.True(tag2.Name == "Tag to test");
        Assert.True(tag2.Description == "Teest");
        Assert.True(tag2.Guid == "t");
        Assert.NotEqual(tag1, tag3);
    }

    [Fact]
    public void TagSet()
    {
        Tag tag1 = new Tag();
        tag1.Name = "Test";
        tag1.Description = "Desc";
        tag1.Guid = "t";
        Assert.True(tag1.Name == "Test");
        Assert.True(tag1.Description == "Desc");
        Assert.True(tag1.Guid == "t");
    }

    [Fact]
    public void TagGet()
    {
        Tag tag = new Tag("Test", "Desc", "t");
        Assert.True(tag.Name == "Test");
        Assert.True(tag.Description == "Desc");
        Assert.True(tag.Guid == "t");
    }

    [Fact]
    public void TagEqualsCheck()
    {
        Tag tag1 = new Tag("Tag to test", "Teest", "t");
        Tag tag2 = new Tag("Tag to test", "Teest", "t");
        Assert.True(tag1 == tag2);
    }

    [Fact]
    public void TagNotEquals()
    {
        Tag tag1 = new Tag();
        Tag tag2 = new Tag("Tag to test", "Teest", "t");
        Assert.True(tag1 != tag2);
    }

    [Fact]
    public void TagClone()
    {
        Tag tag = new Tag("Name", "Desc", "Guid");
        Tag clone = tag.Clone();
        Assert.True(tag == clone);
    }

    [Fact]
    public void TagToString()
    {
        Tag tag = new Tag("Name", "Desc");
        Assert.True(tag.ToString() == "Name: Name; Description: Desc");
    }

    [Fact]
    public void TagDispose()
    {
        ObjectManager.Instance.ClearAll();
        Tag tag = new Tag();
        tag.Dispose();
        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.Empty(objects);
    }

    [Fact]
    public void CategoryAdded()
    {
        TagsCategory category = new TagsCategory();
        Tag t = new Tag();

        t.AddCategory(category);

        Assert.Contains(category, t.Categories);
    }

    [Fact]
    public void AddCategory_ShouldThrow_WhenCategoryIsNull()
    {
        var tag = new Tag();

        Assert.Throws<ArgumentNullException>(() => tag.AddCategory(null));
    }

    [Fact]
    public void AddCategory_ShouldThrow_WhenCategoryAlreadyAdded()
    {
        var tag = new Tag();
        var category = new TagsCategory();

        tag.AddCategory(category);

        Assert.Throws<InvalidOperationException>(() => tag.AddCategory(category));
    }

    [Fact]
    public void RemoveCategory_ShouldRemoveCategoryFromTag()
    {
        var tag = new Tag();
        var category = new TagsCategory();

        tag.AddCategory(category);
        tag.RemoveCategory(category);

        Assert.DoesNotContain(category, tag.Categories);
        Assert.DoesNotContain(tag, category._tags);
    }

    [Fact]
    public void RemoveCategory_ShouldThrow_WhenCategoryIsNull()
    {
        var tag = new Tag();

        Assert.Throws<ArgumentNullException>(() => tag.RemoveCategory(null));
    }

    [Fact]
    public void RemoveCategory_ShouldThrow_WhenCategoryNotInTag()
    {
        var tag = new Tag();
        var category = new TagsCategory();

        Assert.Throws<InvalidOperationException>(() => tag.RemoveCategory(category));
    }
}