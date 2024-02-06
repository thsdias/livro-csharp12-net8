/*
    Important:
    One of the limitations with console apps is that you can only use the await keyword inside methods that are marked as async, 
    but C# 7 and earlier do not allow the Main method to be marked as async! Luckily, a new feature introduced in C# 7.1 was support for async in Main.
*/

using System.Net.Http;

HttpClient client = new();
HttpResponseMessage response = await client.GetAsync("http://www.apple.com/");

WriteLine("Apple's home page has {0:N0} bytes.", response.Content.Headers.ContentLength);