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

/*Note parentNote = new Note("Parent");
Note childNote1 = new Note("child1");
Note childNote2 = new Note("child2");

parentNote.AddChild(childNote1);
childNote2.SetParent(parentNote);


parentNote.DisplayHierarchy();

childNote1.RemoveParent();

parentNote.DisplayHierarchy();*/

TagsCategory t1 = new TagsCategory("Parent");
Tag t2 = new Tag("Child1");
Tag t3 = new Tag("Child2");

t1.AddTag(t2);
t3.AddCategory(t1);


List<Tag> tags = t1._tags;
List<TagsCategory> tc1 = t2.Categories;
List<TagsCategory> tc2 = t3.Categories;

Console.WriteLine(tags[0]);
Console.WriteLine(tags[1]);
Console.WriteLine(tc1[0]);
Console.WriteLine(tc2[0]);