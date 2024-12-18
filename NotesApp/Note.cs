using System;
using System.IO;
using System.Xml.Linq;
namespace NotesApp;

public class Note : IDisposable, ICloneable
{
    public string Guid { get;  set; }
    public uint Priority { get;  set; }

    public string Title { get; set; }
    public string? Content { get; set; }
    public Note Parent { get; set; }
    public List<Note> Children { get; set; }

    private DateTime creationDate;
    private DateTime lastModificationDate;

    public NotesCategory Category { get; set; }
    public QuickAccessCategory QuickCategory { get; set; }

    public List<string> files;

    public List<NoteTag> tags { get; set; }

    public Status CurrentStatus = Status.Accessible;
    
    public enum Status
    {
        Accessible,
        Deleted
    }

    public int Age 
    {
        get
        {
            return (DateTime.Now - creationDate).Days / 365;
        }
    }

    public void AddTag(Tag tag)
    {
        tags.Add(new NoteTag(this, tag));
    }

    public virtual List<string> GetFiles()
    {
        return files;
    }
    
    public void RemoveTag(Tag tag)
    {
        NoteTag n = null;
        foreach(NoteTag nt in tags)
        {
            if(nt.tag == tag)
            {
                n = nt;
                break;
            }
        }
        tags.Remove(n);
    }

    public void AttachFile(string file)
    {
        files.Add(file);
    } 

    public void AddChild(Note child)
    {
        if (child == null)
            throw new ArgumentNullException(nameof(child));

        if (child.Parent != null)
            throw new InvalidOperationException("The note already has a parent.");

        child.Parent = this;
        Children.Add(child);
    }


    public bool RemoveChild(Note child)
    {
        if (child == null || !Children.Contains(child))
            return false;

        child.Parent = null;
        return Children.Remove(child);
    }


    public void SetParent(Note parent)
    {
        if (Parent != null)
            Parent.RemoveChild(this);

        parent?.AddChild(this);
    }

    public void RemoveParent()
    {
        Parent?.RemoveChild(this);
    }

    public void DisplayHierarchy(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent * 2) + $"- {Title}: {Content}");
        foreach (var child in Children)
        {
            child.DisplayHierarchy(indent + 1);
        }
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
        Children = new List<Note>();
        Category = default;
    }

    public Note()
    {
        Guid = System.Guid.NewGuid().ToString();
        SetCreationDate(DateTime.Now);
        SetLastModificationDate(DateTime.Now);
        Title = string.Empty;
        Content = string.Empty;
        Priority = 0;
        Children = new List<Note>();
        Category = default;
    }

    public Note(Note note)
    {
        Guid = note.Guid;
        SetLastModificationDate(note.GetLastModificationDate());
        SetCreationDate(note.GetCreationDate());
        Title = note.Title;
        Content = note.Content;
        ObjectManager.Instance.AddObject(this);
        Children = new List<Note>();
        Category = default;
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