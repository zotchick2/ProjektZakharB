
namespace ProjektZakharB.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public int CurrencyID { get; set; }
        public string NazwaKonta { get; set; }
        public decimal Saldo { get; set; }

        public User User { get; set; }
    }
}
