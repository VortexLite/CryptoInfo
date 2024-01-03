using CryptoInfo.Models;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace CryptoInfo.ViewModels
{
    public class MarketViewModel : BaseViewModel
    {
        private ObservableCollection<MarketData> _data = new ObservableCollection<MarketData>();
        public ObservableCollection<MarketData> Data
        {
            get => _data;
            set => SetField(ref _data, value);
        }

        public async Task GetData(string namecoin)
        {
            string apiUrl = $"https://api.coincap.io/v2/assets/{namecoin}/markets";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            var content = new StringContent("", null, "text/plain");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(jsonResponse);

            var MarketDataList = json["data"]
                .Take(10)
                .Select(token => new MarketData()
                {
                    _exchangeId = token["exchangeId"].ToString(),
                    _baseId = token["baseId"].ToString(),
                    _quoteId = token["quoteId"].ToString(),
                    _baseSymbol = token["baseSymbol"].ToString(),
                    _volumeUsd24Hr = token["volumeUsd24Hr"].ToString(),
                    _priceUsd = token["priceUsd"].ToString(),
                    _volumePercent = token["volumePercent"].ToString()
                })
                .ToList();
            Data = new ObservableCollection<MarketData>(MarketDataList);
        }
    }
}
