namespace NotesApp;

public class ModifyTag : Command<Tag>
{
    public ModifyTag(Tag newVersion) : base(newVersion)
    {
    }

    public override Tag Revert()
    {
        throw new NotImplementedException();
    }
}