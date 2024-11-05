namespace NotesApp;

public class Tag : IReversible<Tag>, IDisposable
{
    public string Guid { get;  set; }
    public string Name { get;  set; }
    public string? Description { get;  set; }

    public Tag(string name, string description = "", string guid = "")
    {
        Guid = guid == "" ? System.Guid.NewGuid().ToString() : guid;
        Name = name;
        Description = description;

        ObjectManager.addObject(this);
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
        ObjectManager.addObject(this);
    }
    
    public Tag Clone()
    {
        return new Tag(this);
    }

    public void Dispose()
    {
        ObjectManager.removeObj(this);
        GC.SuppressFinalize(this);
    }
}