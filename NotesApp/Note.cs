using System;
using System.IO;
namespace NotesApp;

public class Note : IDisposable, ICloneable
{
    public string Guid { get;  set; }
    public uint Priority { get;  set; }

    public string Title { get; set; }
    public string? Content { get; set; }
    public Note parent;
    public List<Note> children;

    private DateTime creationDate;
    private DateTime lastModificationDate;

    public void AddParent(Note note)
    {
        if(parent == null)
        {
            parent = note;
            note.ChildAftetParent(this);
            lastModificationDate = DateTime.Now;
        }
        else
        {
            throw new InvalidOperationException("Delete previous parent first");
        }
    }

    private void ChildAftetParent(Note note)
    {
        if (!children.Contains(note))
        {
            children.Add(note);
        }
    }

    public void AddChild(Note note)
    {
        note.AddParent(this);
    }


    public Note getParent()
    {
        return parent;
    }

    public List<Note> getChildren()
    {
        return children;
    }


    public DateTime GetCreationDate()
    {
        return creationDate;
    }

    public void SetCreationDate(DateTime value)
    {   
        if(creationDate == default)
        {
            creationDate = value;
        } 
        else if(value < DateTime.Now){
            throw new InvalidOperationException("Creation Date can't be earlier than today");
        } else
        creationDate = value;
    }

    public DateTime GetLastModificationDate()
    {
        return lastModificationDate;
    }

    public void SetLastModificationDate(DateTime value)
    {
        if(value < creationDate && creationDate != default)
        {
            throw new InvalidOperationException("Modification cannot be earlier than creation date");
        } else if (value < lastModificationDate && lastModificationDate != default)
        {
            throw new InvalidOperationException("Modification cannot be earlier than previous modification");
        } else

        lastModificationDate = value;
    }

    public Note(string title, string content = "", string guid = "")
    {
        Guid = guid == "" ? System.Guid.NewGuid().ToString() : guid;
        SetCreationDate(DateTime.Now);
        SetLastModificationDate(DateTime.Now);
        Title = title;
        Content = content;
        Priority = 0;
        ObjectManager.Instance.AddObject(this);
        children = new List<Note>();
    }

    public Note()
    {
        Guid = System.Guid.NewGuid().ToString();
        SetCreationDate(DateTime.Now);
        SetLastModificationDate(DateTime.Now);
        Title = string.Empty;
        Content = string.Empty;
        Priority = 0;
        children = new List<Note>();
    }

    public Note(Note note)
    {
        Guid = note.Guid;
        SetLastModificationDate(note.GetLastModificationDate());
        SetCreationDate(note.GetCreationDate());
        Title = note.Title;
        Content = note.Content;
        ObjectManager.Instance.AddObject(this);
        children = new List<Note>();
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

        DateTime leftTimeCreate = new DateTime(left.creationDate.Ticks - (left.creationDate.Ticks % TimeSpan.TicksPerSecond), left.creationDate.Kind);
        DateTime rightTimeCreate = new DateTime(right.creationDate.Ticks - (right.creationDate.Ticks % TimeSpan.TicksPerSecond), right.creationDate.Kind);
        DateTime leftTimeMod = new DateTime(left.lastModificationDate.Ticks - (left.lastModificationDate.Ticks % TimeSpan.TicksPerSecond), left.lastModificationDate.Kind);
        DateTime RightTimeMod = new DateTime(right.lastModificationDate.Ticks - (right.lastModificationDate.Ticks % TimeSpan.TicksPerSecond), right.lastModificationDate.Kind);


        return left.Guid == right.Guid &&
               left.Title == right.Title &&
               left.Content == right.Content && 
               leftTimeCreate == rightTimeCreate &&
               leftTimeMod == RightTimeMod &&
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