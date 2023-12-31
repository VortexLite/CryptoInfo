using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class CryptoData
{
    [JsonProperty("rank")]
    public string _TopCrypto { get; set; }

    [JsonProperty("id")]
    public string _NameCoin { get; set; }

    [JsonProperty("symbol")]
    public string _Symbol { get; set; }

    [JsonProperty("priceUsd")]
    public string _Price { get; set; }

    [JsonProperty("marketCapUsd")]
    public string _MarketCap { get; set; }

    [JsonProperty("volumeUsd24Hr")]
    public string _Volume24H { get; set; }

    [JsonProperty("supply")]
    public string _Supply { get; set; }

    [JsonProperty("changePercent24Hr")]
    public string _24H { get; set; }

    [JsonProperty("maxSupply")]
    public string _MaxSupply { get; set; }

    [JsonProperty("vwap24Hr")]
    public string _VWAP24Hr { get; set; }

    [JsonProperty("data")]
    public List<CryptoData> Data { get; set; }
}

class Program
{
    static async Task Main()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string jsonResponse = await response.Content.ReadAsStringAsync();

        JObject json = JObject.Parse(jsonResponse);

        var cryptoDataList = json["data"]
            .Take(10)
            .Select(token => new CryptoData
            {
                _TopCrypto = token["rank"].ToString(),
                _NameCoin = token["id"].ToString(),
                _Symbol = token["symbol"].ToString(),
                _Price = token["priceUsd"].ToString(),
                _MarketCap = token["marketCapUsd"].ToString(),
                _Volume24H = token["volumeUsd24Hr"].ToString(),
                _Supply = token["supply"].ToString(),
                _24H = token["changePercent24Hr"].ToString(),
                _MaxSupply = token["maxSupply"].ToString(),
                _VWAP24Hr = token["vwap24Hr"].ToString()
            })
            .ToList();

        foreach (var crypto in cryptoDataList)
        {
            Console.WriteLine($"Name: {crypto._NameCoin}, Rank: {crypto._TopCrypto}, Price: {crypto._Price}");
            Console.WriteLine($"Max Supply: {crypto._MaxSupply}, VWAP 24Hr: {crypto._VWAP24Hr}");
        }
    }
}