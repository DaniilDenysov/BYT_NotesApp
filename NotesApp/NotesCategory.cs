namespace NotesApp;

public class NotesCategory : Category<Note>, IDisposable
{
    public NotesCategory(string title, string description = "") : base(title, description)
    {
        ObjectManager.addObject(this);
    }

    public NotesCategory(Category<Note> category) : base(category)
    {
        ObjectManager.addObject(this);
    }

    public override int GetPriority()
    {
        return 1;
    }

    public override Category<Note> Clone()
    {
        return new NotesCategory(this);
    }

    public void Dispose()
    {
        ObjectManager.removeObj(this);
        GC.SuppressFinalize(this);
    }
}