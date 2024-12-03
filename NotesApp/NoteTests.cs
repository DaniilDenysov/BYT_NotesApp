using NotesApp;
using System.Xml.Linq;
using Xunit;

[Collection("SequentialTests")]
public class NoteTests
{
    [Fact]
    public void NoteConstructor()
    {
        Note note1 = new Note();
        Note note2 = new Note("Second note", "Content");
        Note note3 = new Note(note2);

        Assert.True(note1.Title == "");
        Assert.True(note2.Title == "Second note");
        Assert.True(note2.Content == "Content");
        Assert.True(note3.Content == "Content");
    }

    [Fact]
    public void NoteDispose()
    {
        ObjectManager.Instance.ClearAll();
        Note note = new Note(); 
        note.Dispose();
        IReadOnlyList<Object> objects = ObjectManager.Instance.GetAllData();
        Assert.Empty(objects);
    }

    [Fact]
    public void DefaultPriorityCheck()
    {
        Note note = new Note();
        Assert.True(note.Priority == 0);
    }

    [Fact]
    public void NoteToString() 
    {
        Note note1 = new Note("Title", "Content");
        Assert.True(note1.ToString() == "Title: Title; Content: Content");
    }

    [Fact]
    public void NoteEquals()
    {
        Note note1 = new Note("Test", "Testing");
        Note note2 = new Note(note1);
        Assert.True(note1 == note2);
    }


    [Fact]
    public void NoteNotEquals() 
    {
        Note note1 = new Note("Test", "Testing");
        Note note2 = new Note();
        Assert.True(note1 != note2);
    }

    [Fact]
    public void NoteSet()
    {
        Note note = new Note();
        note.Title = "Title";
        note.Content = "Test";
        note.Guid = "t";

        Assert.True(note.Title == "Title");
        Assert.True(note.Content == "Test");
        Assert.True(note.Guid == "t");
    }

    [Fact]
    public void NoteGet()
    {
        Note note = new Note("Title", "Test", "t");
        Assert.True(note.Title == "Title");
        Assert.True(note.Content == "Test");
        Assert.True(note.Guid == "t");
    }

    [Fact]
    public void NoteCreateTime()
    {
        Note note = new Note();

        Assert.Throws<InvalidOperationException>(() =>
        {
            note.SetCreationDate(DateTime.MinValue);
        });
    }

    [Fact]
    public void NoteModTime() 
    {
        Note note = new Note();

        Assert.Throws<InvalidOperationException>(() =>
        {
            note.SetLastModificationDate(DateTime.MinValue);
        });
    }


    [Fact]
    public void AddChild_ShouldAddChildSuccessfully()
    {

        Note parent = new Note("Parent", "Parent content");
        Note child = new Note("Child", "Child content");


        parent.AddChild(child);


        Assert.Contains(child, parent.Children);
        Assert.Equal(parent, child.Parent);
    }

    [Fact]
    public void AddChild_ShouldThrowException_IfChildAlreadyHasParent()
    {

        Note parent1 = new Note("Parent1", "Content");
        Note parent2 = new Note("Parent2", "Content");
        Note child = new Note("Child", "Child content");

        parent1.AddChild(child);


        Assert.Throws<InvalidOperationException>(() => parent2.AddChild(child));
    }

    [Fact]
    public void RemoveChild_ShouldRemoveChildSuccessfully()
    {

        Note parent = new Note("Parent", "Parent content");
        Note child = new Note("Child", "Child content");
        parent.AddChild(child);

        Assert.True(parent.RemoveChild(child));
        Assert.DoesNotContain(child, parent.Children);
        Assert.Null(child.Parent);
    }

    [Fact]
    public void RemoveChild_ShouldReturnFalse_IfChildDoesNotExist()
    {

        Note parent = new Note("Parent", "Parent content");
        Note child = new Note("Child", "Child content");

        Assert.False(parent.RemoveChild(child));
    }

    [Fact]
    public void SetParent_ShouldUpdateParentSuccessfully()
    {

        Note parent = new Note("Parent", "Parent content");
        Note child = new Note("Child", "Child content");


        child.SetParent(parent);


        Assert.Equal(parent, child.Parent);
        Assert.Contains(child, parent.Children);
    }

    [Fact]
    public void SetParent_ShouldRemoveFromPreviousParent()
    {

        Note parent1 = new Note("Parent1", "Parent1 content");
        Note parent2 = new Note("Parent2", "Parent2 content");
        Note child = new Note("Child", "Child content");
        parent1.AddChild(child);


        child.SetParent(parent2);


        Assert.Equal(parent2, child.Parent);
        Assert.Contains(child, parent2.Children);
        Assert.DoesNotContain(child, parent1.Children);
    }

    [Fact]
    public void RemoveParent_ShouldRemoveParentSuccessfully()
    {

        Note parent = new Note("Parent", "Parent content");
        Note child = new Note("Child", "Child content");
        parent.AddChild(child);


        child.RemoveParent();


        Assert.Null(child.Parent);
        Assert.DoesNotContain(child, parent.Children);
    }

    [Fact]
    public void AddChild_ShouldThrowArgumentNullException_IfChildIsNull()
    {

        Note parent = new Note("Parent", "Parent content");


        Assert.Throws<ArgumentNullException>(() => parent.AddChild(null));
    }

}
