using CryptoInfo.ViewModels;
using Newtonsoft.Json;

namespace CryptoInfo.Models
{
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

        public string _ImageSource { get; set; }

        [JsonProperty("data")]
        public List<CryptoData> Data { get; set; }
    }
}
