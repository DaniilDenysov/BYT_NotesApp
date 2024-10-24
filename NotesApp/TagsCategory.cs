namespace NotesApp;

public class TagsCategory : Category<Tag>
{
    public TagsCategory(string title, string description = "") : base(title, description)
    {
    }

    public TagsCategory(Category<Tag> category) : base(category)
    {
    }

    public override int GetPriority()
    {
        return 1;
    }

    public override Category<Tag> Clone()
    {
        return new TagsCategory(this);
    }
}