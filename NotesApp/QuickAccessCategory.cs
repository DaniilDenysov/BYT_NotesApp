namespace NotesApp;

public class QuickAccessCategory : Category<Note>
{
    public QuickAccessCategory(string title, string description = "") : base(title, description)
    {
    }

    public QuickAccessCategory(Category<Note> category) : base(category)
    {
    }

    public override int GetPriority()
    {
        return 0;
    }

    public override Category<Note> Clone()
    {
        return new QuickAccessCategory(this);
    }
}