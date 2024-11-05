// See https://aka.ms/new-console-template for more information
using NotesApp;

Console.WriteLine("Hello, World!");
SerializationUtility.LoadAll();
//Note n = new Note("Numero uno", "Hi there");
//Note n2 = new Note("Numero dwa", "Hi there2");
List<Note> list = ObjectManager.AllNotes;

using (var n3 = new Note("Nvm", "i should disappear"))
{
    for (int i = 0; i < 1; i++)
    {
        foreach (var item in list) Console.WriteLine(item);
    }
}
Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
SerializationUtility.SaveAll();