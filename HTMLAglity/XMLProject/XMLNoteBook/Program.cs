#region nameSpaces

using XMLNoteBook.Model;
using XMLNoteBook.View;

#endregion

#region NoteBook

var XmlPath = "notes.xml";

var notes = XmlHelper.Load<NotesCollection>(XmlPath);

var newNote = new Note
{
    Id = notes.Notes.Any() ? notes.Notes.Max(n => n.Id) + 1 : 1,
    CreatedAt = DateTime.Now,
    Title = "Study XML",
    Content = "Learn XML + C# Serialization/Deserialization.",
    Tags = new List<string> { "XML", "CSharp", "Notes" }
};

notes.Notes.Add(newNote);

XmlHelper.Save(XmlPath, notes);

Console.WriteLine("New note added and saved to XML.");

var loadedNotes = XmlHelper.Load<NotesCollection>(XmlPath);
foreach (var note in loadedNotes.Notes)
    Console.WriteLine($"[{note.Id}] {note.Title} :: {note.CreatedAt}");

#endregion

Console.ReadLine();