#region nameSpaces

using XMLNoteBook.Model;
using XMLNoteBook.View;

#endregion

#region NoteBook

// Paths
var xmlLocalPath = "notes.xml";
var xmlDesktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "XMLsProjects", "notes.xml");
Directory.CreateDirectory(Path.GetDirectoryName(xmlDesktopPath));

var notes = XmlHelper.Load<NotesCollection>(xmlLocalPath);

var newNote = new Note
{
    Id = notes.Notes.Any() ? notes.Notes.Max(n => n.Id) + 1 : 1,
    CreatedAt = DateTime.Now,
    Title = "Study XML",
    Content = "Learn XML + C# Serialization/Deserialization.",
    Tags = new List<string> { "XML", "CSharp", "Notes" }
};

notes.Notes.Add(newNote);

// Save to both locations
XmlHelper.Save(xmlLocalPath, notes);
XmlHelper.Save(xmlDesktopPath, notes);

Console.WriteLine("Notes saved in both Local and Desktop/XMLsProjects folder.");

var loadedNotes = XmlHelper.Load<NotesCollection>(xmlLocalPath);
foreach (var note in loadedNotes.Notes)
    Console.WriteLine($"[{note.Id}] {note.Title} :: {note.CreatedAt.TimeOfDay}");

#endregion

Console.ReadLine();