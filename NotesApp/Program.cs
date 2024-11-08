// See https://aka.ms/new-console-template for more information
using NotesApp;

Console.WriteLine("Hello, World!");
//SerializationUtility.LoadAll();
Note n = new Note("Numero uno", "Hi there");
Note n2 = new Note("Numero dwa", "Hi there2");
IReadOnlyList<IDisposable> list = ObjectManager.getAllData();
Note n3 = new Note("nvm", "I should disappear");

Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
n3.Dispose();
Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
//SerializationUtility.SaveAll();