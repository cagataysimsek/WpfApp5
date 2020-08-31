using Microsoft.EntityFrameworkCore;
using Models.Migrations;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2IT11V6\\WINCCPLUSMIG2014;Initial Catalog=StockAutomationDB;Integrated Security=True");
        }
    }
}
