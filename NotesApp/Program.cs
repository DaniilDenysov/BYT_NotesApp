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

Note parentNote = new Note("Parent");
Note childNote1 = new Note("child1");
Note childNote2 = new Note("child2");

parentNote.AddChild(childNote1);
childNote2.SetParent(parentNote);


parentNote.DisplayHierarchy();

childNote1.RemoveParent();

parentNote.DisplayHierarchy();