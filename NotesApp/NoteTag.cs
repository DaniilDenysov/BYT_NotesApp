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
        foreach(NoteTag t in note.tags)
        {
            if (t.tag == tag)
                throw new ArgumentException("Such tag already exists");
        }
        foreach (NoteTag t in tag.NoteTags)
        {
            if (t.note == note)
                throw new ArgumentException("Such note already exists");
        }
        this.note = note;
        this.tag = tag;
        addedTime = DateTime.Now;
    }
}
