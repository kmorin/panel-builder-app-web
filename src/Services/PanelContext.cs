using System.Data;
using System;
using System.Xml;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using panel_builder_app_web.Models;
using System.Threading.Tasks;
using System.Linq;

namespace panel_builder_app_web
{
    public partial class PanelContext : DbContext
    {
        public DbSet<Panel> Panels { get; set; }
        public DbSet<Circuit> Circuits { get; set; }

        public PanelContext()
        {
        }

        public PanelContext(DbContextOptions<PanelContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=aspcore;Username=aspcore;Password=secretlocal;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.UseSerialColumns();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var entities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Deleted);

            foreach (var item in entities)
            {
                if (item.Entity is ISoftDelete entity) {
                  item.State = EntityState.Unchanged;
                  entity.DeletedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}