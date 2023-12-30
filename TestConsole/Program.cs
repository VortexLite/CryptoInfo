var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets");
var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();
Console.WriteLine(await response.Content.ReadAsStringAsync());




Console.ReadLine();