namespace NotesApp;

public class VersionControlPipelineManager
{
    public static VersionControlPipelineManager Instance;

    private Stack<ICloneable> currentStack = new Stack<ICloneable>();
    private Stack<ICloneable> undoStack = new Stack<ICloneable>();
    private Stack<ICloneable> redoStack = new Stack<ICloneable>();
    
    public VersionControlPipelineManager()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public void Add(ICloneable cloneable)
    {
        currentStack.Push(cloneable);
        undoStack.Push(cloneable.Clone());
        redoStack.Clear();
    }
    
    public void Undo()
    {
        if (undoStack.Count > 1  && currentStack.Count > 1)
        {
            if (currentStack.Pop().GetType() != redoStack.Pop().GetType()) throw new InvalidOperationException("Types doesn't match!");
            var currentUndo = undoStack.Peek();
            redoStack.Push(currentUndo);
            var current = currentStack.Peek();
            current.Clone(currentUndo);
        }
        throw new InvalidOperationException("Undo stack is empty!");
    }
    
    public void Redo()
    {
        if (redoStack.Count > 0 && currentStack.Count > 0)
        {
            if (currentStack.Pop().GetType() != redoStack.Pop().GetType()) throw new InvalidOperationException("Types doesn't match!");
            var currentRedo = redoStack.Pop();
            undoStack.Push(currentRedo);
            var current = currentStack.Peek();
            current.Clone(currentRedo);
        }
        throw new InvalidOperationException("Redo stack is empty!");
    }
}