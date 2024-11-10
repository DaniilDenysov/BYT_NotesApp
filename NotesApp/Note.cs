using System;
using System.IO;
namespace NotesApp;

public class Note : IDisposable
{
    public string Guid { get;  set; }
    public uint Priority { get;  set; }
    public DateTime LastModificationDate { get;  set; }
    public DateTime CreationDate { get;  set; }
    public string Title { get;  set; }
    public string? Content { get;  set; }

    public Note(string title, string content = "", string guid = "")
    {
        Guid = guid == "" ? System.Guid.NewGuid().ToString() : guid;
        LastModificationDate = DateTime.Now;
        CreationDate = DateTime.Now;
        Title = title;
        Content = content;
        Priority = 0;
        ObjectManager.AddObject(this);
    }

    public Note()
    {
        Guid = System.Guid.NewGuid().ToString();
        LastModificationDate = DateTime.Now;
        CreationDate = DateTime.Now;
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
        ObjectManager.AddObject(this);
    }
    
    public override string ToString()
    {
        return "Title: " + Title + "; Content: " + Content;
    }

    public void Dispose()
    {
        ObjectManager.RemoveObj(this);
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
        ObjectManager.RemoveObj(this);
    }
}