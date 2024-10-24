namespace NotesApp;

public class CommandPipeLine<T> where T : IReversible<T>
{
    public static CommandPipeLine<T> Instance;

    public Stack<T> Pipeline = new Stack<T>();
    
    
    public CommandPipeLine()
    {
        if (Instance == null) Instance = this;
    }
}