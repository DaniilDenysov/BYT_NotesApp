// See https://aka.ms/new-console-template for more information
using NotesApp;

Console.WriteLine("Hello, World!");
SerializationUtility.LoadAll();

IReadOnlyList<Object> list = ObjectManager.getAllData();
Note n3 = new Note("nvm", "I should disappear");

Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
n3.Dispose();
Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
SerializationUtility.SaveAll();
Console.Read();