namespace NotesApp;

public class Tag : IDisposable
{
    public string Guid { get;  set; }
    public string Name { get;  set; }
    public string? Description { get;  set; }

    public Tag(string name, string description = "", string guid = "")
    {
        Guid = guid == "" ? System.Guid.NewGuid().ToString() : guid;
        Name = name;
        Description = description;

        ObjectManager.Instance.AddObject(this);
    }

    public Tag()
    {
        Guid = System.Guid.NewGuid().ToString();
        Name = string.Empty;
        Description = string.Empty;
    }

    public Tag(Tag tag)
    {
        Guid = tag.Guid;
        Name = tag.Name;
        Description = tag.Description;
        ObjectManager.Instance.AddObject(this);
    }
    
    public Tag Clone()
    {
        return new Tag(this);
    }

    public void Dispose()
    {
        ObjectManager.Instance.RemoveObj(this);
        GC.SuppressFinalize(this);
    }

    public static bool operator== (Tag left, Tag right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        
        return left.Guid == right.Guid &&
               left.Description == right.Description &&
               left.Name == right.Name;
    }
    
    public static bool operator!= (Tag left, Tag right)
    {
        return !(left == right);
    }
    
    ~Tag()
    {
        ObjectManager.Instance.RemoveObj(this);
    }
}