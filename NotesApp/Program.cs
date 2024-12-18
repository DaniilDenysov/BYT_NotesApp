// See https://aka.ms/new-console-template for more information
using NotesApp;
using Xunit;

/*string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.xml");
SerializationUtility.LoadAll(path);

IReadOnlyList<Object> list = ObjectManager.Instance.GetAllData();
Note n3 = new Note("nvm", "I should disappear");

Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
n3.Dispose();
Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
SerializationUtility.SaveAll(path);
Console.Read();*/

/*Note parentNote = new Note("Parent N");
Note childNote1 = new Note("child1 N");
Note childNote2 = new Note("child2 N");

NotesCategory parentCategory = new NotesCategory("Parents C");
NotesCategory childCategory = new NotesCategory("Children C");

parentCategory.Add(parentNote);
childCategory.Add(childNote1);
childCategory.Add(childNote2);


Console.WriteLine("Parent Category");
foreach (Note note in parentCategory.Items)
{
    Console.WriteLine(note.Title);
}
Console.WriteLine();

Console.WriteLine("Child Category");
foreach (Note note in childCategory.Items)
{
    Console.WriteLine(note.Title);
}

Console.WriteLine();

childCategory.Remove(childNote1);

Console.WriteLine();*/

Tag tag = new Tag("Tag1");


var exception = Assert.Throws<ArgumentNullException>(() => new NoteTag(null, tag));
Assert.Equal("One of the arguments is null", exception.ParamName);