namespace NotesApp;
using System;
using System.ComponentModel;

public class TemplateNote : Note , IDisposable
{
	public Templates template { get; set; }

	public TemplateNote(Note note, Templates template) : base(note)
    {
		this.template = template;
        template.templateNotes.Add(this);
    }
	
	public void add (TemplateNote templateNote)
	{ 
		if(templateNote == null)
		{
            throw new ArgumentNullException(nameof(templateNote));
        }

		ObjectManager.Instance.AddObject(templateNote);
    }

	public void remove(TemplateNote templateNote)
	{
        if (templateNote == null)
        {
            throw new ArgumentNullException(nameof(templateNote));
        }

        template.templateNotes.Remove(templateNote);
        ObjectManager.Instance.RemoveObj(templateNote);
    }

	public Note CreateNoteFromTemplate()
	{
		Note note = new Note(this.Title, this.Content);
		return note;
	}

    ~TemplateNote()
    {
		template.templateNotes.Remove(this);
        ObjectManager.Instance.RemoveObj(this);
    }
}
