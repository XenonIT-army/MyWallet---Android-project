using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SqlliteApp.Standard.Entities;
using SqlliteApp.Standard.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SqlliteApp.Standard.Context
{
    public partial class MobileContext : DbContext
    {
        public DbSet<Payment> Payment { get; set; }

        //public DbSet<PurchaseHistory> PurchaseHistory { get; set; }
        public MobileContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabaseService>().GetDatabasePath();
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Payment>()
            //    .HasKey(e => new { e.Id ,e.Balance,e.Name,e.Percent});

            //modelBuilder.Entity<Payment>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Payment>()
            //    .Property(e => e.Balance)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Payment>()
            //    .Property(e => e.Percent)
            //    .IsUnicode(false);


        }
    }
}
