using System;

namespace ProjektZakharB.Models
{
    public class BudgetPlan
    {
        public int BudgetID { get; set; }
        public int UserID { get; set; }
        public int CurrencyID { get; set; }
        public decimal MaksymalnaKwotaBudzetu { get; set; }
        public string Kategoria { get; set; }
        public DateTime MiesiacIRokPlanowania { get; set; }

        public User User { get; set; }
        public CurrencyRate CurrencyRate { get; set; }
    }
}
