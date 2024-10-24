namespace NotesApp;

public interface IReversible<T>
{
    public T Clone();
}