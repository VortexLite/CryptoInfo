using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoInfo.ViewModels;

namespace CryptoInfo.Models
{
    public class CryptoData
    {
        public string _TopCrypto { get; set; }
        public string _NameCoin { get; set; }
        public string _Sybmol { get; set; }
        public decimal _Price { get; set; }
        public decimal _MarketCap { get; set; }
        public decimal _Volume24H { get; set; }
        public decimal _Supply { get; set; }
        public decimal _24H { get; set; }
    }
}
