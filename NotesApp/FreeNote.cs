namespace NotesApp;

public class FreeNote : Note
{
    public override List<string> GetFiles()
    {
        return base.GetFiles().GetRange(0,1);
    }
}