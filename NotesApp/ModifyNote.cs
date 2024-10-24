namespace NotesApp;

public class ModifyNote : Command<Note>
{
    public ModifyNote(Note newVersion) : base(newVersion)
    {
    }

    public override Note Revert()
    {
        throw new NotImplementedException();
    }
}