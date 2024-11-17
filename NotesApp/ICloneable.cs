namespace NotesApp;

public interface ICloneable
{
    /// <summary>
    /// Copies object values to new object
    /// </summary>
    /// <returns>New object but with same values</returns>
    ICloneable Clone();
    
    /// <summary>
    /// Copies values of the passed object to current object
    /// </summary>
    /// <param name="cloneable">To copy from</param>
    void Clone(ICloneable cloneable);
}