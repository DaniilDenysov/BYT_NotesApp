namespace NotesApp;

public class PremiumNote : Note
{
    public DateTime expirationDate {  get; set; }
    
    public PremiumNote(Note note, DateTime expirationDate) : base(note)
    {
        this.expirationDate = expirationDate;
    }

}