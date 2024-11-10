// See https://aka.ms/new-console-template for more information
using NotesApp;

string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.xml");
SerializationUtility.LoadAll(path);

IReadOnlyList<Object> list = ObjectManager.GetAllData();
Note n3 = new Note("nvm", "I should disappear");

Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
n3.Dispose();
Console.WriteLine();
foreach (var item in list) Console.WriteLine(item);
SerializationUtility.SaveAll(path);
Console.Read();