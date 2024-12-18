using NotesApp;

public class TrashBin
{
    public static TrashBin Instance;
    public Dictionary<string, Note> scrapped = new Dictionary<string, Note>();

    public void Add(Note note)
    {
        if (scrapped.TryAdd(note.Guid,note))
        {
            note.CurrentStatus = Note.Status.Deleted;
        }
    }

    public void Remove(string guid)
    {
        if (scrapped.TryGetValue(guid,out Note note))
        {
            note.CurrentStatus = Note.Status.Accessible;
            scrapped.Remove(guid);
        }
    }

    public bool Exists(string guid)
    {
        return scrapped.ContainsKey(guid);
    }

    //will scrap everything
    public void Update()
    {
        var keys = new List<string>(scrapped.Keys);
        
        foreach (var key in keys)
        {
            if (scrapped.TryGetValue(key,out Note note))
            {
                note.Dispose();
                scrapped.Remove(key);
            }
        }
    }

    public TrashBin()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}