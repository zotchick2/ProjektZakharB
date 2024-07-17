using System;

namespace ProjektZakharB.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public int TypeID { get; set; }
        public int CurrencyID { get; set; }
        public decimal Kwota { get; set; }
        public string Kategoria { get; set; }
        public DateTime DataTransakcji { get; set; }
        public string Opis { get; set; }

        public Account Account { get; set; }
        public TypeIncomeExpense TypeIncomeExpense { get; set; }
        public CurrencyRate CurrencyRate { get; set; }
    }
}
