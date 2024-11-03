using System;
using System.IO;
namespace NotesApp;

public class Note : IReversible<Note>, IDisposable
{
    public string Guid { get; private set; }
    public uint Priority { get; private set; }
    public DateTime LastModificationDate { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string Title { get; private set; }
    public string? Content { get; private set; }

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