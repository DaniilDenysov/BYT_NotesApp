using Xunit;

namespace NotesApp;

public class NotesCategory : Category<Note>, IDisposable
{
    public NotesCategory(string title, string description = "") : base(title, description)
    {
        ObjectManager.AddObject(this);
    }

    public NotesCategory(Category<Note> category) : base(category)
    {
        ObjectManager.AddObject(this);
    }

    public NotesCategory()
        : base(string.Empty, string.Empty) 
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
        ObjectManager.RemoveObj(this);
    }
}