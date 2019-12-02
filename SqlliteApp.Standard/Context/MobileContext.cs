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

        public DbSet<PurchaseHistory> History { get; set; }
        public MobileContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabaseService>().GetDatabasePath();
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite($"Filename={dbPath}");
        }

       
    }
}
