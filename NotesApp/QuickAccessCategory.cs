namespace NotesApp;

public class QuickAccessCategory : Category<Note>, IDisposable
{
    public override void Add(Note item)
    {
        base.Add(item);
        item.QuickCategory = this;
    }

    public override void Remove(Note item)
    {
        base.Remove(item);
        item.Category = default;
    }

    public override void DeleteCategory()
    {
        foreach (var v in Items)
            v.Dispose();
        this.Dispose();
    }

    public QuickAccessCategory(string title, string description = "") : base(title, description)
    {
        ObjectManager.Instance.AddObject(this);
    }

    public QuickAccessCategory(Category<Note> category) : base(category)
    {
        ObjectManager.Instance.AddObject(this);
    }

    public override int GetPriority()
    {
        return 0;
    }

    public void Dispose()
    {
        ObjectManager.Instance.RemoveObj(this);
        GC.SuppressFinalize(this);
    }

    ~QuickAccessCategory()
    {
        ObjectManager.Instance.RemoveObj(this);
    }
}