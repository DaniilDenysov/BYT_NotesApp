using System;
using System.IO;
namespace NotesApp;

public class Note : IReversible<Note>, IDisposable
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
        ObjectManager.addObject(this);
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
        ObjectManager.addObject(this);
    }
    
    
    public Note Clone()
    {
        return new Note(this);
    }

    public override string ToString()
    {
        return "Title: " + Title + "; Content: " + Content;
    }

    public void Dispose()
    {
        ObjectManager.removeObj(this);
        GC.SuppressFinalize(this);
    }

}