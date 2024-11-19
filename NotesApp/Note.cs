using System;
using System.IO;
namespace NotesApp;

public class Note : IDisposable, ICloneable
{
    public string Guid { get;  set; }
    public uint Priority { get;  set; }

    private DateTime creationDate;

    public DateTime GetCreationDate()
    {
        return creationDate;
    }

    public void SetCreationDate(DateTime value)
    {
        creationDate = value;
    }

    public DateTime LastModificationDate { get; set; }
    public string Title { get;  set; }
    public string? Content { get;  set; }

    public Note(string title, string content = "", string guid = "")
    {
        Guid = guid == "" ? System.Guid.NewGuid().ToString() : guid;
        SetCreationDate(DateTime.Now);
        LastModificationDate = DateTime.Now;
        Title = title;
        Content = content;
        Priority = 0;
        ObjectManager.Instance.AddObject(this);
    }

    public Note()
    {
        Guid = System.Guid.NewGuid().ToString();
        SetCreationDate(DateTime.Now);
        LastModificationDate = DateTime.Now;
        Title = string.Empty;
        Content = string.Empty;
        Priority = 0;
    }

    public Note(Note note)
    {
        Guid = note.Guid;
        LastModificationDate = note.LastModificationDate;
        SetCreationDate(note.GetCreationDate());
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

        DateTime leftTimeNormalized = new DateTime(left.GetCreationDate().Ticks - (left.GetCreationDate().Ticks % TimeSpan.TicksPerSecond));
        DateTime rightTimeNormalized= new DateTime(right.GetCreationDate().Ticks - (right.GetCreationDate().Ticks % TimeSpan.TicksPerSecond));

        return left.Guid == right.Guid &&
               left.Title == right.Title &&
               left.Content == right.Content && 
               leftTimeNormalized == rightTimeNormalized &&
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