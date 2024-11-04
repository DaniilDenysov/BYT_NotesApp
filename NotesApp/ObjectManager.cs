namespace NotesApp;
public static class ObjectManager
{
    private static List<Tag> allTags = new List<Tag>();
    private static List<TagsCategory> tagsCategories = new List<TagsCategory>();
    private static List<Note> allNotes = new List<Note>();
    private static List<NotesCategory> notesCategories = new List<NotesCategory>();

    public static List<Tag> AllTags { get => allTags; }
    public static List<TagsCategory> TagsCategories { get => tagsCategories; }
    public static List<Note> AllNotes { get => allNotes; }
    public static List<NotesCategory> NotesCategories { get => notesCategories; }

    public static void init(List<Tag> tags, List<TagsCategory> tc, List<Note> notes, List<NotesCategory> nc)
    {
        allTags = tags;
        tagsCategories = tc;
        allNotes = notes;
        notesCategories = nc;
    }

    public static void addObject<T> (T t)
    {
        if(t is Tag tag)
        {
            allTags.Add(tag);
        } else if (t is TagsCategory category) 
        { 
            tagsCategories.Add(category);
        } else if(t is Note note)
        {
            allNotes.Add(note); 
        } else if(t is NotesCategory notesCat)
        {
            notesCategories.Add(notesCat);  
        } else
        {
            throw new Exception("Something went very wrong");
        }
    }

    public static void removeObj<T>(T t)
    {
        if (t is Tag tag)
        {
            allTags.Remove(tag);
        }
        else if (t is TagsCategory category)
        {
            tagsCategories.Remove(category);
        }
        else if (t is Note note)
        {
            allNotes.Remove(note);
        }
        else if (t is NotesCategory notesCat)
        {
            notesCategories.Remove(notesCat);
        }
        else
        {
            throw new Exception("Something went very wrong");
        }
    }

}
