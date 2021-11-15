using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGS.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SGS.Repositories
{
    public class SGSDbContext : DbContext
    {
        public SGSDbContext(DbContextOptions<SGSDbContext> options) : base(options)
        {
        }
        public DbSet<FiscalYear> FiscalYear { get; set; }
        public DbSet<InvoiceHDR> InvoiceHDR { get; set; }
        public DbSet<ItemsDTL> ItemsDTL { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            base.OnConfiguring(dbContextOptionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            var conString = config.GetConnectionString("MyConnection");
            dbContextOptionsBuilder.UseSqlServer(conString);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}