using Microsoft.EntityFrameworkCore;

namespace ProjektZakharB.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TypeIncomeExpense> TypesIncomesExpenses { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BudgetPlan> BudgetPlans { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурации и ограничения могут быть добавлены здесь
        }
    }
}
