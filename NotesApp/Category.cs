namespace NotesApp;

public abstract class Category<T>
{
    public string Guid { get;  set; }
    public string Title { get;  set; }
    public string? Description  { get;  set; }
    public List<T> Items { get;  set; }

    protected Category(string title, string description = "")
    {
        Guid = System.Guid.NewGuid().ToString();
        Title = title;
        Description = description;
        Items = new List<T>();
    }

    protected Category()
    {
        Title = string.Empty;
        Description = string.Empty;
    }

    protected Category(Category<T> category)
    {
        Guid = category.Guid;
        Title = category.Title;
        Description = category.Description;
        Items = category.Items;
    }

    public override string ToString()
    {
        return "Title: " + Title + "; Description: " + Description;
    }
    public abstract int GetPriority();
    
    public virtual void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Object in category cannot be null");
        }
        Items.Add(item);
    }

    public virtual void Remove(T item)
    {
        Items.Remove(item);
    }

    public virtual List<T> GetItems() => Items;

    public virtual void DeleteCategory()
    {
        Items.Clear();
    }
}