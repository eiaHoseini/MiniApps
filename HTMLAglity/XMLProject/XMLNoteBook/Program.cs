#region nameSpaces

using XMLNoteBook.Model;
using XMLNoteBook.View;
using ClosedXML.Excel;

#endregion

//TODO: Update this project to a CRUD App
#region NoteBook

//// Paths
//var xmlLocalPath = "notes.xml";
//var xmlDesktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "XMLsProjects", "notes.xml");
//Directory.CreateDirectory(Path.GetDirectoryName(xmlDesktopPath));

//var notes = XmlHelper.Load<NotesCollection>(xmlLocalPath);

//var newNote = new Note
//{
//    Id = notes.Notes.Any() ? notes.Notes.Max(n => n.Id) + 1 : 1,
//    CreatedAt = DateTime.Now,
//    Title = "Study XML",
//    Content = "Learn XML + C# Serialization/Deserialization.",
//    Tags = new List<string> { "XML", "CSharp", "Notes" }
//};

//notes.Notes.Add(newNote);

//// Save to both locations
//XmlHelper.Save(xmlLocalPath, notes);
//XmlHelper.Save(xmlDesktopPath, notes);

//Console.WriteLine("Notes saved in both Local and Desktop/XMLsProjects folder.");

//var loadedNotes = XmlHelper.Load<NotesCollection>(xmlLocalPath);
//foreach (var note in loadedNotes.Notes)
//    Console.WriteLine($"[{note.Id}] {note.Title} :: {note.CreatedAt.TimeOfDay}");

#endregion

#region Excel Exercises

// Just For learn the ClosedXML.excel Package
var people = new List<Person>
{
    new Person { FirstName = "John", LastName = "Doe", Age = 30, City = "New York" },
    new Person { FirstName = "Jane", LastName = "Smith", Age = 25, City = "Los Angeles" },
    new Person { FirstName = "Sam", LastName = "Brown", Age = 28, City = "Chicago" }
};

using (var workbook = new XLWorkbook())
{
    // Create a worksheet
    var worksheet = workbook.Worksheets.Add("People");

    // Add headers
    worksheet.Cell(1, 1).Value = "First Name";
    worksheet.Cell(1, 2).Value = "Last Name";
    worksheet.Cell(1, 3).Value = "Age";
    worksheet.Cell(1, 4).Value = "City";

    // Format headers
    var headerRange = worksheet.Range(1, 1, 1, 3);
    headerRange.Style.Font.Bold = true;
    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

    // Add data
    for (int i = 0; i < people.Count; i++)
    {
        var person = people[i];
        worksheet.Cell(i + 2, 1).Value = person.FirstName;
        worksheet.Cell(i + 2, 2).Value = person.LastName;
        worksheet.Cell(i + 2, 3).Value = person.Age;
        worksheet.Cell(i + 2, 4).Value = person.City;
    }

    // Save the workbook
    var excelPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "People.xlsx");
    workbook.SaveAs(excelPath);
    Console.WriteLine($"Excel file saved to: {excelPath}");
}

#endregion

Console.ReadLine();