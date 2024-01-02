using Newtonsoft.Json;

namespace CryptoInfo.Models
{
    public class MarketData
    {
        [JsonProperty("exchangeId")]
        public string _exchangeId { get; set; }

        [JsonProperty("baseId")]
        public string _baseId { get; set; }

        [JsonProperty("quoteId")]
        public string _quoteId { get; set; }

        [JsonProperty("baseSymbol")]
        public string _baseSymbol { get; set; }

        [JsonProperty("quoteSymbol")]
        public string _quoteSymbol { get; set; }

        [JsonProperty("volumeUsd24Hr")]
        public string _volumeUsd24Hr { get; set; }

        [JsonProperty("priceUsd")]
        public string _priceUsd { get; set; }

        [JsonProperty("volumePercent")]
        public string _volumePercent { get; set; }

        [JsonProperty("data")]
        public List<MarketData> Data { get; set; }
    }
}
