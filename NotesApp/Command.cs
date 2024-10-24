namespace NotesApp;

public abstract class Command<T> where T : IReversible<T>
{
    public T lastVersion { get; private set; }
    public T newVersion { get; private set; }
    
    
    protected Command(T newVersion)
    {
        lastVersion = newVersion.Clone();
        this.newVersion = newVersion;
    }

    public abstract T Revert();
}