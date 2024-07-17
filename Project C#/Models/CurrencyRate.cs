using System;

namespace ProjektZakharB.Models
{
    public class CurrencyRate
    {
        public int CurrencyID { get; set; }
        public string Currency { get; set; }
        public decimal KursDoUSD { get; set; }
        public DateTime DataAktualizacjiKursu { get; set; }
    }
}
