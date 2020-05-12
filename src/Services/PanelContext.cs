using System.Data;
using System;
using System.Xml;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using panel_builder_app_web.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

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
            modelBuilder.Entity<Panel>().HasQueryFilter(d=>d.DeletedAt == null);
            modelBuilder.UseSerialColumns();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateDeletedAt();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges(){
            UpdateDeletedAt();
            return base.SaveChanges();
        }

        private void UpdateDeletedAt()
        {
            ChangeTracker.DetectChanges();
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["CreatedAt"] = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues["UpdatedAt"] = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        entry.CurrentValues["DeletedAt"] = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}