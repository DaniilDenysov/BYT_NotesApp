using NotesApp;
using Xunit;

public class NoteTagTests
{
    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenNoteIsNull()
    {

        Tag tag = new Tag("Tag1");


        var exception = Assert.Throws<ArgumentNullException>(() => new NoteTag(null, tag));
        Assert.Equal("One of the arguments is null", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenTagIsNull()
    {

        Note note = new Note("Note1");


        var exception = Assert.Throws<ArgumentNullException>(() => new NoteTag(note, null));
        Assert.Equal("One of the arguments is null", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenTagAlreadyExistsForNote()
    {

        Note note = new Note("Note1");
        Tag tag = new Tag("Tag1");


        note.AddTag(tag);


        var exception = Assert.Throws<ArgumentException>(() => new NoteTag(note, tag));
        Assert.Equal("Such tag already exists", exception.Message); 
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenNoteAlreadyExistsForTag()
    {

        Note note = new Note("Note1");
        Tag tag = new Tag("Tag1");


        tag.AddNoteTag(note);


        var exception = Assert.Throws<ArgumentException>(() => new NoteTag(note, tag));
        Assert.Equal("Such note already exists", exception.Message); 
    }

    [Fact]
    public void Constructor_ShouldCreateNoteTagSuccessfully_WhenValidInputs()
    {

        Note note = new Note("Note1");
        Tag tag = new Tag("Tag1");


        NoteTag noteTag = new NoteTag(note, tag);

        Assert.Equal(note, noteTag.note); 
        Assert.Equal(tag, noteTag.tag);
        Assert.Contains(noteTag, note.tags);  
        Assert.Contains(noteTag, tag.NoteTags); 
    }
}