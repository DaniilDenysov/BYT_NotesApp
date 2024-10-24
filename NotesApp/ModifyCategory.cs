namespace NotesApp;

public class ModifyCategory : Command<Category<Note>>
{
    public ModifyCategory(Category<Note> newVersion) : base(newVersion)
    {
    }

    public override Category<Note> Revert()
    {
        throw new NotImplementedException();
    }
}