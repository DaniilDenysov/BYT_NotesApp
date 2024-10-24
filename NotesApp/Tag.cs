namespace NotesApp;

public class Tag : IReversible<Tag>
{
    public string Guid { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public Tag(string name, string description = "", string guid = "")
    {
        Guid = guid == "" ? System.Guid.NewGuid().ToString() : guid;
        Name = name;
        Description = description;
    }

    public Tag(Tag tag)
    {
        Guid = tag.Guid;
        Name = tag.Name;
        Description = tag.Description;
    }
    
    public Tag Clone()
    {
        return new Tag(this);
    }
}