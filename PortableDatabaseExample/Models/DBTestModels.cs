using System;
using System.Data.Entity;
namespace PortableDatabaseExample.Models
{
    public class SqlCETestModel : DbContext
    {
        public SqlCETestModel()
            : base("SQL_CE_Connection")
        {

        }

        public DbSet<Purchase> Purchases { get; set; }
    }

    public class SQLiteTestModel : DbContext
    {
        public SQLiteTestModel()
            : base("SQLite_Connection")
        {

        }

        public DbSet<Purchase> Purchases { get; set; }
    }

    public class Purchase
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}