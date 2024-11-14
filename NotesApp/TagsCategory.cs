namespace NotesApp;

public class TagsCategory : Category<Tag>, IDisposable
{
    public TagsCategory(string title, string description = "") : base(title, description)
    {
        ObjectManager.Instance.AddObject(this);
    }

    public TagsCategory() : base(string.Empty) 
    {
        ObjectManager.Instance.AddObject(this);
    }

    public TagsCategory(Category<Tag> category) : base(category)
    {
        ObjectManager.Instance.AddObject(this);
    }

    public override int GetPriority()
    {
        return 1;
    }
    
    public void Dispose()
    {
        ObjectManager.Instance.RemoveObj(this);
        GC.SuppressFinalize(this);
    }

    ~TagsCategory()
    {
        ObjectManager.Instance.RemoveObj(this);
    }
}