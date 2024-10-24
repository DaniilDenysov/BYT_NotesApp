namespace NotesApp;

public class Note : IReversible<Note>
{
    public string Guid { get; private set; }
    public DateTime LastModificationDate { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string Title { get; private set; }
    public string? Content { get; private set; }

    public Note(string title, string content = "", string guid = "")
    {
        Guid = guid == "" ? System.Guid.NewGuid().ToString() : guid;
        LastModificationDate = DateTime.Now;
        CreationDate = DateTime.Now;
        Title = title;
        Content = content;
    }

    public Note(Note note)
    {
        Guid = note.Guid;
        LastModificationDate = note.LastModificationDate;
        CreationDate = note.CreationDate;
        Title = note.Title;
        Content = note.Content;
    }
    
    
    public Note Clone()
    {
        return new Note(this);
    }
}