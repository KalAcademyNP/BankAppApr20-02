using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppApr20_02
{
    public class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankContext()
        {

        }
        public BankContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Initial Catalog=BankApr2002;Connect Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e =>
            {
                e.ToTable("Accounts");
                e.HasKey(a => a.AccountNumber);
                e.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();

                e.Property(a => a.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                e.Property(a => a.AccountName)
                    .IsRequired()
                    .HasMaxLength(150);

            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable("Transactions");
                e.HasKey(t => t.Id);
                e.Property(t => t.Id)
                    .ValueGeneratedOnAdd();

            });
        }

    }
}
