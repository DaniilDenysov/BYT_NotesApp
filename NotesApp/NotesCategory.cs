namespace NotesApp;

public class NotesCategory : Category<Note>
{
    public NotesCategory(string title, string description = "") : base(title, description)
    {
    }

    public NotesCategory(Category<Note> category) : base(category)
    {
    }

    public override int GetPriority()
    {
        return 1;
    }

    public override Category<Note> Clone()
    {
        return new NotesCategory(this);
    }
}