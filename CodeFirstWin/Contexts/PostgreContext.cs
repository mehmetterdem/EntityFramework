using CodeFirstWin.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstWin.Contexts
{
    public class PostgreContext:DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Stok> Stoklar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"server=127.0.0.1;Database=Market;userid=postgres;password=kvc261115151121");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Stok>()
                .Property(p => p.StokAdi)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("stookAdi");
            modelBuilder.Entity<Stok>()
                .Property(p => p.Aciklama)
                .HasMaxLength(100);
        }
        public override int SaveChanges()
        {
            var entities = ChangeTracker
                .Entries()
                .Where(p => p.State == EntityState.Added || p.State == EntityState.Modified);
            foreach (var item in entities)
            {
                if (item.State==EntityState.Added)
                {
                    item.Property("CreateDate").CurrentValue = DateTime.Now;
                }
                if (item.State==EntityState.Modified)
                {
                    item.Property("UpdateDate").CurrentValue=DateTime.Now;
                }
            }


            return base.SaveChanges();
        }
    }
}

