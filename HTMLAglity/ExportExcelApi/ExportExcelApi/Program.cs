#region Using packages and namespaces

using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using ExportExcelApi.Model;
using System.Runtime.InteropServices.Marshalling;

#endregion

#region Building The Web API

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

#endregion

#region Validation

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#endregion

app.MapPost("/export", ([FromBody] List<Person> people) => 
{
    using var workbook = new XLWorkbook();
    var worksheet = workbook.Worksheets.Add("People");


    // Header
    worksheet.Cell(1, 1).Value = "Id";
    worksheet.Cell(1, 2).Value = "FirstName";
    worksheet.Cell(1, 3).Value = "LastName";
    worksheet.Cell(1, 4).Value = "City";
    worksheet.Cell(1, 5).Value = "PohoneNumber";
    worksheet.Cell(1, 6).Value = "Gender";

    // Data
    for(int i = 0; i<people.Count; i++)
    {
        worksheet.Cell(i + 2, 1).Value = people[i].Id;
        worksheet.Cell(i + 2, 2).Value = people[i].FirstName;
        worksheet.Cell(i + 2, 3).Value = people[i].LastName;
        worksheet.Cell(i + 2, 4).Value = people[i].City;
        worksheet.Cell(i + 2, 5).Value = people[i].PhoneNumber;
        worksheet.Cell(i + 2, 6).Value = people[i].Gender;
    }

    using var stream = new MemoryStream();
    workbook.SaveAs(stream);
    stream.Position = 0;

    return Results.File(
        fileContents: stream.ToArray(),
        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        fileDownloadName: "Export.xlsx"
    );
});

app.Run();
