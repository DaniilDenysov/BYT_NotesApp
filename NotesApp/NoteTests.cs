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
}
