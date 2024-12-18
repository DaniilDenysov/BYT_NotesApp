namespace NotesApp;

public class Templates : Category<TemplateNote>, IDisposable
{
    public string templateName { get; set; }
    public List<TemplateNote> templateNotes { get; set; } =  new List<TemplateNote>();

    public Templates()
	{
        ObjectManager.Instance.AddObject(this);
    }

    public void add(Templates templates)
    {
        if (templates == null)
        {
            throw new ArgumentNullException(nameof(templates));
        }
        ObjectManager.Instance.AddObject(templates);
    }

    public void Remove(Templates templates)
    {
        foreach (var templateNote in templates.templateNotes)
        {
            templateNote.Dispose();
        }
        ObjectManager.Instance.RemoveObj(templates);
        GC.SuppressFinalize(templates);
    }

    public override int GetPriority()
    {
        return 1; 
    }

    public void Dispose()
    {   
        foreach (var templateNote in templateNotes)
        {
            templateNote.Dispose();
        }
        ObjectManager.Instance.RemoveObj(this);
        GC.SuppressFinalize(this);
    }

    ~Templates()
    {
        ObjectManager.Instance.RemoveObj(this);
    }
}
