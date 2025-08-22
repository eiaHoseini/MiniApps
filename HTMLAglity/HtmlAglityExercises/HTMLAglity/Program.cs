#region namespace

// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;

#endregion

#region Step 1: Get the HTML Before the Parsing

// initialize the HAP HTTP client
var web = new HtmlWeb();

// connect to target page
var document = web.Load("https://www.scrapingcourse.com/ecommerce/");

// print the raw HTML as a string 
Console.WriteLine(document.DocumentNode.OuterHtml);

// scraping logic...

#endregion

Console.ReadKey();