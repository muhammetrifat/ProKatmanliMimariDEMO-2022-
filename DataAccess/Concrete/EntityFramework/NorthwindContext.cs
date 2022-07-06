using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//projemiz hangi veritabanı ile ilişkili'yi belirteceğimiz yer
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-H56L443\SQLEXPRESS ; Database = NORTHWND ; user id = sa ; password = 1234");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
