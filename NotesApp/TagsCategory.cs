namespace NotesApp;

public class TagsCategory : Category<Tag>, IDisposable
{
    public TagsCategory(string title, string description = "") : base(title, description)
    {
        ObjectManager.addObject(this);
    }

    public TagsCategory() : base(string.Empty) 
    {
        ObjectManager.addObject(this);
    }

    public TagsCategory(Category<Tag> category) : base(category)
    {
        ObjectManager.addObject(this);
    }

    public override int GetPriority()
    {
        return 1;
    }

    public override Category<Tag> Clone()
    {
        return new TagsCategory(this);
    }

    public void Dispose()
    {
        ObjectManager.removeObj(this);
        GC.SuppressFinalize(this);
    }

    ~TagsCategory()
    {
        ObjectManager.removeObj(this);
    }
}