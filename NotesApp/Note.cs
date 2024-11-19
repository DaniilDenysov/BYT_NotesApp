using System;
using System.IO;
namespace NotesApp;

public class Note : IDisposable, ICloneable
{
    public string Guid { get;  set; }
    public uint Priority { get;  set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastModificationDate { get; set; }

/*    private DateTime _creationDate;
    private DateTime _lastModificationDate;

    public DateTime CreationDate
    {
        get => _creationDate;
        set
        {
            if (value > _lastModificationDate)
            {
                throw new InvalidOperationException("CreationDate cannot be later than LastModificationDate.");
            }
            _creationDate = value;
        }
    }

    public DateTime LastModificationDate
    {
        get => _lastModificationDate;
        set
        {
            if (value < _creationDate)
            {
                throw new InvalidOperationException("LastModificationDate cannot be earlier than CreationDate.");
            }
            _lastModificationDate = value;
        }
    }*/
    public string Title { get;  set; }
    public string? Content { get;  set; }

    public Note(string title, string content = "", string guid = "")
    {
        Guid = guid == "" ? System.Guid.NewGuid().ToString() : guid;
        CreationDate = DateTime.Now;
        LastModificationDate = CreationDate;
        Title = title;
        Content = content;
        Priority = 0;
        ObjectManager.Instance.AddObject(this);
    }

    public Note()
    {
        Guid = System.Guid.NewGuid().ToString();
        CreationDate = DateTime.Now;
        //LastModificationDate = DateTime.Now;
        Title = string.Empty;
        Content = string.Empty;
        Priority = 0;
    }

    public Note(Note note)
    {
        Guid = note.Guid;
        LastModificationDate = note.LastModificationDate;
        CreationDate = note.CreationDate;
        Title = note.Title;
        Content = note.Content;
        ObjectManager.Instance.AddObject(this);
    }
    
    public override string ToString()
    {
        return "Title: " + Title + "; Content: " + Content;
    }

    public void Dispose()
    {
        ObjectManager.Instance.RemoveObj(this);
        GC.SuppressFinalize(this);
    }
    
    public static bool operator== (Note left, Note right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        return left.Guid == right.Guid &&
               left.Title == right.Title &&
               left.Content == right.Content && 
               left.CreationDate == right.CreationDate &&
               left.LastModificationDate == right.LastModificationDate &&
               left.Priority == right.Priority;
    }
    
    public static bool operator!= (Note left, Note right)
    {
        return !(left == right);
    }

    ~Note()
    {
        ObjectManager.Instance.RemoveObj(this);
    }

    public ICloneable Clone()
    {
        throw new NotImplementedException();
    }

    public void Clone(ICloneable cloneable)
    {
        throw new NotImplementedException();
    }
}