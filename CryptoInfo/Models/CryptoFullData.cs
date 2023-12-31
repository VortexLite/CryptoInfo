using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoInfo.ViewModels;

namespace CryptoInfo.Models
{
    internal class CryptoFullData
    {
        public decimal _MaxSupply { get; set; }
        public decimal _VWAP24Hr { get; set; }
        public CryptoData cryptodata { get; set; }
    } 
}
