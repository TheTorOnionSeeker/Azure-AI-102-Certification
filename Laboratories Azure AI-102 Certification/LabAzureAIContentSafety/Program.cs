using System;
using System.Linq.Expressions;
using Azure;
using Azure.AI.ContentSafety;

string endpoint = "https://lab-content-safety-guilledev.cognitiveservices.azure.com/";
string key = "BGjyydbr7Vt9uLdtoq5D6Muonwf3ZRgNSavsKenfXfCECv44gYq1JQQJ99BBACYeBjFXJ3w3AAAHACOGbDyU";

ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));

string userText = "Ya dejalo, idiota!";
var request = new AnalyzeTextOptions(userText);
Response<AnalyzeTextResult> response;
response = client.AnalyzeText(request);

Console.WriteLine("\nAnalyse text succeeded:");
Console.WriteLine("Hate severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Hate)?.Severity ?? 0);
Console.WriteLine("SelfHarm severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.SelfHarm)?.Severity ?? 0);
Console.WriteLine("Sexual severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Sexual)?.Severity ?? 0);
Console.WriteLine("Violence severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Violence)?.Severity ?? 0);


/* while (userText.ToLower() != "quit")
{
    Console.WriteLine("Enter some text ('quit' to stop)");
    userText = Console.ReadLine();
    if (userText.ToLower() != "quit")
    {
        var request = new AnalyzeTextOptions(userText);
        try
        {
            response = client.AnalyzeText(request);
        }
        catch (RequestFailedException ex)
        {
            Console.WriteLine("Analyse text failed.\nStatus code: {0}, Error code: {1}, Error message: {2}", ex.Status, ex.ErrorCode, ex.Message);
        }
        Console.WriteLine("\nAnalyse text succeeded:");
        Console.WriteLine("Hate severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Hate)?.Severity ?? 0);
        Console.WriteLine("SelfHarm severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.SelfHarm)?.Severity ?? 0);
        Console.WriteLine("Sexual severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Sexual)?.Severity ?? 0);
        Console.WriteLine("Violence severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Violence)?.Severity ?? 0);
    }

} */