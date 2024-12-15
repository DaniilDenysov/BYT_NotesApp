namespace NotesApp;

public class NotesCategory : Category<Note>, IDisposable
{
    public override void Add(Note item)
    {
        base.Add(item);
        item.Category = this;
    }

    public override void Remove(Note item)
    {
        base.Remove(item);
        item.Category = default;
    }

    public override void DeleteCategory()
    {
        foreach(var v in Items)
            v.Dispose();
        this.Dispose();
    }


    public NotesCategory(string title, string description = "") : base(title, description)
    {
        ObjectManager.Instance.AddObject(this);
    }

    public NotesCategory(Category<Note> category) : base(category)
    {
        ObjectManager.Instance.AddObject(this);
    }

    public NotesCategory()
        : base(string.Empty, string.Empty) 
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

    public static bool operator== (NotesCategory left, NotesCategory right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        int i = 0;
        for (;i<left.Items.Count && i < right.Items.Count;i++)
        {
            if (left.Items[i] != right.Items[i])
            {
                return false;
            }
        }

        if (i < left.Items.Count || i < right.Items.Count) return false;
        
        return left.Guid == right.Guid &&
               left.Title == right.Title &&
               left.Description == right.Description;
    }
    
    public static bool operator!= (NotesCategory left, NotesCategory right)
    {
        return !(left == right);
    }
    
    ~NotesCategory()
    {
        ObjectManager.Instance.RemoveObj(this);
    }
}