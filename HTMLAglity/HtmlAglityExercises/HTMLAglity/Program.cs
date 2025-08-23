#region namespace

#region Using HTML Agility Pack

// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using System.Xml.Linq;

#endregion

#region Using Excel

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using HTMLAglity.Excell;

#endregion

#endregion

#region HTML Agility Pack Exeresices & Learning

//var web = new HtmlWeb();

#region Step 1: Get the HTML Before the Parsing

//// initialize the HAP HTTP client
//var web = new HtmlWeb();

//// connect to target page
//var document = web.Load("https://www.scrapingcourse.com/ecommerce/");

//// print the raw HTML as a string 
////Console.WriteLine(document.DocumentNode.OuterHtml);

//// scraping logic...

#endregion

#region Step 2: Extract a Single Element

//// retrieve the "<title>" element
//var titleElement = document.DocumentNode.SelectSingleNode("//title");
//Console.WriteLine(titleElement);

//// extract the inner text from it and print it
//var title = HtmlEntity.DeEntitize(titleElement.InnerText);
//Console.WriteLine(title);

#endregion

#region step 3: Extract Multiple Elements

//// get the first HTML product nodes
//var firstProductElement = document.DocumentNode.SelectSingleNode("//li[contains(@class, 'product')]");

//// data extraction logic
//var nameOfProduct = HtmlEntity.DeEntitize(firstProductElement.SelectSingleNode(".//h2").InnerText);
//var imageOfProduct = HtmlEntity.DeEntitize(firstProductElement.SelectSingleNode(".//img").Attributes["src"].Value);
//var priceOfProduct = HtmlEntity.DeEntitize(firstProductElement.SelectSingleNode(".//span").InnerText);

//// print the scraped data
//Console.WriteLine($"{{ Name = {nameOfProduct}, Image = {imageOfProduct}, Price = {priceOfProduct} }}");

#endregion

#region Step 4: Extract All Matching Elements from a Page

//// get the list of HTML product nodes
//var productHTMLElements = document.DocumentNode.SelectNodes("//li[contains(@class, 'product')]");

//// iterate over the list of product HTML elements
//foreach (var productHTMLElement in productHTMLElements)
//{
//    // data extraction logic
//    var name = HtmlEntity.DeEntitize(productHTMLElement.SelectSingleNode(".//h2").InnerText);
//    var image = HtmlEntity.DeEntitize(productHTMLElement.SelectSingleNode(".//img").Attributes["src"].Value);
//    var price = HtmlEntity.DeEntitize(productHTMLElement.SelectSingleNode(".//span").InnerText);

//    // print the scraped data
//    Console.WriteLine($"{{ Name = {name}, Image = {image}, Price = {price} }}");
//}

#endregion

#region Exercise 1

//var document = web.Load("https://books.toscrape.com");

//var bookElements = document.DocumentNode.SelectNodes("//li[contains(@class, 'col-xs-6')]");

//var mehdiBook = document.DocumentNode.SelectNodes("//li[contains(@class, 'col-xs-6')]").ElementAt(6);
//// instead of this way, you can click on that image and copy the XPath from the browser's developer tools

//var mehdiBookName = HtmlEntity.DeEntitize(mehdiBook.SelectSingleNode(".//h3").InnerText);
//var mehdiBookImage = HtmlEntity.DeEntitize(mehdiBook.SelectSingleNode(".//img").Attributes["src"].Value);
//var mehdiBookPrice = HtmlEntity.DeEntitize(mehdiBook.SelectSingleNode(".//p[contains(@class, 'price_color')]").InnerText);

//Console.WriteLine($"{{ Name = {mehdiBookName}, Image = {mehdiBookImage}, Price = {mehdiBookPrice} }}\n");
//Console.WriteLine("=====================================================================================\n");

//foreach (var bookElement in bookElements)
//{
//    var Bname = HtmlEntity.DeEntitize(bookElement.SelectSingleNode(".//h3").InnerText);
//    var image = HtmlEntity.DeEntitize(bookElement.SelectSingleNode(".//img").Attributes["src"].Value);
//    var price = HtmlEntity.DeEntitize(bookElement.SelectSingleNode(".//p[contains(@class, 'price_color')]").InnerText);
//    Console.WriteLine($"{{ Name = {Bname}, Image = {image}, Price = {price} }}\n\n");
//}

#endregion

#region Exercise 2

//var document = web.Load("https://quera.org/profile");
//Console.WriteLine(document.DocumentNode.OuterHtml);

////var profileElement = document.DocumentNode.SelectNodes("//*[@id=\"cv-maker\"]/div/div[3]/div/div[1]/div[2]/form[2]");
////var name = HtmlEntity.DeEntitize(profileElement.SelectSingleNode("//*[@id=\"cv-maker\"]/div/div[3]/div/div[1]/div[2]/form[2]/div[1]/div[1]/div/input").InnerText);

#endregion

#endregion

#region Excel Exercises & Learning

#region Learning XML Serialization and Deserialization

#region XML Serialization

var students = new List<Student>
{
    new Student { Id = 1, StudentNumber = 1001, FirstName = "Ali", LastName = "Rezaei" ,City = "Tehran", Gender = "Mail", PhoneNumber = "0912" },
    new Student { Id = 2, StudentNumber = 1002, FirstName = "Sara", LastName = "Mohammadi", City = "Yazd" }
};

XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));

using (FileStream fs = new FileStream("students.xml", FileMode.Create))
{
    serializer.Serialize(fs, students);
}
// If you want save the XML in a special root use this following code:
// using (FileStream fs = new FileStream(@"C:\Data\students.xml", FileMode.Create))

Console.WriteLine("XML Created Successfully!");

#endregion

#region XML Deserialization

using (FileStream fs = new FileStream("students.xml", FileMode.Open))
{
    List<Student> loadedStudents = (List<Student>)serializer.Deserialize(fs);

    foreach (var s in loadedStudents)
    {
        Console.WriteLine($"Id: {s.Id}, Name: {s.FirstName} {s.LastName}, City {s.City}, Gender: {s?.Gender}, PhoneNumber = {s?.PhoneNumber}");
    }
}

#endregion

#endregion

#endregion

Console.ReadKey();