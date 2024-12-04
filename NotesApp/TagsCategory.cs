namespace NotesApp;

public class TagsCategory : Category<Tag>, IDisposable
{

    public List<Tag> _tags { get; set; }

    public void AddTag(Tag tag)
    {
        if (tag == null)
            throw new ArgumentNullException(nameof(tag));
        if (tag.Categories.Contains(this))
            throw new InvalidOperationException("This category already exists");
        if(_tags.Contains(tag))
            throw new InvalidOperationException("This tag already exists");
        _tags.Add(tag);
        tag.Categories.Add(this);
    }

    public void RemoveTag(Tag tag)
    {
        if (tag == null)
            throw new ArgumentNullException(nameof(tag));
        if (!tag.Categories.Contains(this))
            throw new InvalidOperationException("This category does not exists");
        if (!_tags.Contains(tag))
            throw new InvalidOperationException("This tag does not exists");
        tag.Categories.Remove(this);
        _tags.Remove(tag);
    }

    public TagsCategory(string title, string description = "") : base(title, description)
    {
        _tags = new List<Tag>();   
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