using NotesApp;
using Xunit;

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
    public void TagSet() {
        Tag tag1 = new Tag();   
        tag1.Name = "Test";
        tag1.Description = "Desc";
        tag1.Guid = "t";
        Assert.True(tag1.Name == "Test");
        Assert.True(tag1.Description == "Desc");
        Assert.True(tag1.Guid == "t");
    }

    [Fact]
    public void TagDispose() {
        Thread.Sleep(10);
        ObjectManager.Instance.ClearAll();
        Tag tag1 = new Tag();
        tag1.Dispose();
        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.Empty(objects);
    }

    [Fact]
    public void TagGet()
    {
        Tag tag = new Tag();
        tag.Name = "Test";
        tag.Description = "Desc";
        tag.Guid = "t";
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
    public void TagNotEquals() {
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
}