using Microsoft.EntityFrameworkCore;


namespace Models
{
    public class StockAutomationDBContext:DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Defination> Definations { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StockAutomationDB;Integrated Security=True");
        }
    }
}
