namespace NotesApp;

public class NoteTag
{
    public Note note { get; set; }
    public Tag tag { get; set; }
    public DateTime addedTime {get; set;}

    public NoteTag(Note note, Tag tag)
    {
        addedTime = DateTime.Now;
    }
}
