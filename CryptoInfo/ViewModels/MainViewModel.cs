using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using CryptoInfo.Models;
using Newtonsoft.Json.Linq;

namespace CryptoInfo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            InitializeAsync();
        }

        private ObservableCollection<CryptoData> _data = new ObservableCollection<CryptoData>();
        public ObservableCollection<CryptoData> Data
        {
            get => _data;
            set => SetField(ref _data, value);
        }

        private ObservableCollection<CryptoData> _searchResults = new ObservableCollection<CryptoData>();
        public ObservableCollection<CryptoData> SearchResults
        {
            get => _searchResults;
            set => SetField(ref _searchResults, value);
        }

        public void PerformSearch(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                SearchResults = new ObservableCollection<CryptoData>(Data);
            }
            else
            {
                SearchResults = new ObservableCollection<CryptoData>(
                    Data.Where(item =>
                        item._NameCoin.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        item._Symbol.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    )
                );
            }
        }

        public string GetImagePath(string nameCoin)
        {
            string directoryPath = "Images/Coin/";
            string fileName = $"{nameCoin}.png";

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath, fileName);

            if (File.Exists(filePath))
            {
                return filePath;
            }
            else
            {
                return "Images/Coin/undefiend.png";
            }
        }

        private async void InitializeAsync()
        {
            await GetData();
        }

        public async Task GetData()
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
                    _VWAP24Hr = token["vwap24Hr"].ToString(),

                    _ImageSource = GetImagePath(token["id"].ToString())
                })
                .ToList();
            Data = new ObservableCollection<CryptoData>(cryptoDataList);

            PerformSearch(string.Empty);
        }
    }
}
