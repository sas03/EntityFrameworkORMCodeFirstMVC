using EntityFrameworkMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;

namespace EntityFrameworkMVC.Repositories
{
    public class SavingContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<SavingAccount> SavingAccount { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=Savings;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }
    }
}
