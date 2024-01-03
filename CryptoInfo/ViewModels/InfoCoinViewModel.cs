using CryptoInfo.Models;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;

namespace CryptoInfo.ViewModels
{
    public class InfoCoinViewModel : BaseViewModel
    {
        public InfoCoinViewModel()
        {
            GetData("bitcoin");
        }

        private ObservableCollection<CryptoData> _data = new ObservableCollection<CryptoData>();
        public ObservableCollection<CryptoData> Data
        {
            get => _data;
            set => SetField(ref _data, value);
        }

        public string GetImagePath(string nameCoin)
        {
            string directoryPath = "Images/FullSizeCoin/";
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

        public async Task GetData(string coinName)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.coincap.io/v2/assets/{coinName}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(jsonResponse);

            var token = json["data"];

            Data = new ObservableCollection<CryptoData>
            {
                new CryptoData
                {
                    _TopCrypto = token["rank"].ToString(),
                    _NameCoin = token["id"].ToString().ToUpper(),
                    _Symbol = token["symbol"].ToString().ToUpper(),
                    _Price = token["priceUsd"].ToString(),
                    _MarketCap = token["marketCapUsd"].ToString(),
                    _Volume24H = token["volumeUsd24Hr"].ToString(),
                    _Supply = token["supply"].ToString(),
                    _24H = token["changePercent24Hr"].ToString(),
                    _MaxSupply = token["maxSupply"].ToString(),
                    _VWAP24Hr = token["vwap24Hr"].ToString(),

                    _ImageSource = GetImagePath(token["id"].ToString())
                }
            };
        }
    }
}
