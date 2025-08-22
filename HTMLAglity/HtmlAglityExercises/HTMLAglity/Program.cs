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
//Console.WriteLine(document.DocumentNode.OuterHtml);

// scraping logic...

#endregion

#region Step 2: Extract a Single Element

// retrieve the "<title>" element
var titleElement = document.DocumentNode.SelectSingleNode("//title");
Console.WriteLine(titleElement);

// extract the inner text from it and print it
var title = HtmlEntity.DeEntitize(titleElement.InnerText);
Console.WriteLine(title);

#endregion

#region step3: Extract Multiple Elements

// get the first HTML product nodes
var firstProductElement = document.DocumentNode.SelectSingleNode("//li[contains(@class, 'product')]");

// data extraction logic
var nameOfProduct = HtmlEntity.DeEntitize(firstProductElement.SelectSingleNode(".//h2").InnerText);
var imageOfProduct = HtmlEntity.DeEntitize(firstProductElement.SelectSingleNode(".//img").Attributes["src"].Value);
var priceOfProduct = HtmlEntity.DeEntitize(firstProductElement.SelectSingleNode(".//span").InnerText);

// print the scraped data
Console.WriteLine($"{{ Name = {nameOfProduct}, Image = {imageOfProduct}, Price = {priceOfProduct} }}");

#endregion

#region Step 4: Extract All Matching Elements from a Page

// get the list of HTML product nodes
var productHTMLElements = document.DocumentNode.SelectNodes("//li[contains(@class, 'product')]");

// iterate over the list of product HTML elements
foreach (var productHTMLElement in productHTMLElements)
{
    // data extraction logic
    var name = HtmlEntity.DeEntitize(productHTMLElement.SelectSingleNode(".//h2").InnerText);
    var image = HtmlEntity.DeEntitize(productHTMLElement.SelectSingleNode(".//img").Attributes["src"].Value);
    var price = HtmlEntity.DeEntitize(productHTMLElement.SelectSingleNode(".//span").InnerText);

    // print the scraped data
    Console.WriteLine($"{{ Name = {name}, Image = {image}, Price = {price} }}");
}

#endregion

Console.ReadKey();