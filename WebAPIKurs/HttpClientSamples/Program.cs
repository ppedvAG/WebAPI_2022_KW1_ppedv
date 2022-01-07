// See https://aka.ms/new-console-template for more information
using System.Net.Http;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");

HttpClient client = new(); //C# 9

#region Sample 1 XML with client.Send(...) 

//Warten bis die WebAPI gestartet und verfügbar ist
Console.WriteLine("--- Starte die Abfrage [Drücke eine Taste]");
Console.ReadKey();

string url = "https://localhost:7174/api/Movie";
//Request wird als Get-Methode verwendet.
HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
//httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
//httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
HttpResponseMessage response = await client.SendAsync(httpRequestMessage);

string xmlString = await response.Content.ReadAsStringAsync(); //Wird aus Body gelesen


Console.WriteLine(xmlString);
#endregion


//Warten bis die WebAPI gestartet und verfügbar ist
Console.WriteLine("--- Weiter zu Beispiel 2 ---- [Drücke eine Taste]");
Console.ReadKey();

#region Beispiel 2
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
HttpResponseMessage response1 = await client.GetAsync(url);
string resultString = await response1.Content.ReadAsStringAsync();
Console.WriteLine(resultString);
#endregion

Console.WriteLine("--- Weiter zu Beispiel 2 ---- [Drücke eine Taste]");
Console.ReadKey();


#region PRoblem mit HttpClient
//client.Dispose(); //Dispose baut das Objekt ab. 
//https://docs.microsoft.com/de-de/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
// IHttpClientFactory wird in Verbindung mit ASP.NET Core verwendet ...... service.AddHttpClient -> ServiceCollection + Hosting-Model 
#endregion




