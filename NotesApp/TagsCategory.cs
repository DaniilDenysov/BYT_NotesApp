namespace NotesApp;

public class TagsCategory : Category<Tag>, IDisposable
{
    public TagsCategory(string title, string description = "") : base(title, description)
    {
        ObjectManager.AddObject(this);
    }

    public TagsCategory() : base(string.Empty) 
    {
        ObjectManager.AddObject(this);
    }

    public TagsCategory(Category<Tag> category) : base(category)
    {
        ObjectManager.AddObject(this);
    }

    public override int GetPriority()
    {
        return 1;
    }
    
    public void Dispose()
    {
        ObjectManager.RemoveObj(this);
        GC.SuppressFinalize(this);
    }

    ~TagsCategory()
    {
        ObjectManager.RemoveObj(this);
    }
}