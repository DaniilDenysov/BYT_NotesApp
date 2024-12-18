namespace NotesApp;

public class NoteTag
{
    public Note note { get; set; }
    public Tag tag { get; set; }
    public DateTime addedTime {get; set;}

    public NoteTag(Note note, Tag tag)
    {
        if(note == default || tag == default)  
            throw new ArgumentNullException("One of the arguments is null");
        this.note = note;
        this.tag = tag;
        addedTime = DateTime.Now;
    }
}
