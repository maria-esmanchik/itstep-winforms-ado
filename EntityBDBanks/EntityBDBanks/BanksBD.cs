using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EntityBDBanks
{   
    public class BankDBUSD
    {
        public int Id { get; set; }
        public double Sell { get; set; }
        public double Buy { get; set; }      
    }

    public class BankDBEUR
    {
        public int Id { get; set; }
        public double Sell { get; set; }
        public double Buy { get; set; }       
    }

    public class BankDBRUR
    {
        public int Id { get; set; }
        public double Sell { get; set; }
        public double Buy { get; set; }

    }

    public class BankDB
    {
        public int Id { get; set; }
        //public DateTime Date { get; set; }
        //public DateTime Time { get; set; }
        public ICollection<BankDBUSD> BankDBUSDs { get; set; }
        public ICollection<BankDBEUR> BankDBEURs { get; set; }
        public ICollection<BankDBRUR> BankDBRURs { get; set; }
        public BankDB()
        {
            BankDBUSDs = new List<BankDBUSD>();
            BankDBEURs = new List<BankDBEUR>();
            BankDBRURs = new List<BankDBRUR>();
        }
    }

    public class BanksContext : DbContext
    {
        public BanksContext() : base("DbCource") { }

        public DbSet<BankDB> BanksDBID { get; set; }
        public DbSet<BankDBUSD> BankDBUSD { get; set; }
        public DbSet<BankDBEUR> BanksDBEUR { get; set; }
        public DbSet<BankDBRUR> BanksDBRUR { get; set; }
    }
} 
