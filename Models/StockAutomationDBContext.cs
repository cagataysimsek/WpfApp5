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
        public DbSet<MaterialHistory> MaterialHistories { get; set; }
        public DbSet<Recipt> Recipts { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2IT11V6\\WINCCPLUSMIG2014;Initial Catalog=StockAutomationDB;Integrated Security=True");
        }
    }
}
