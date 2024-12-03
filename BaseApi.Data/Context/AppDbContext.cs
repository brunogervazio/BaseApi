using BaseApi.Domain.Entities;
using BaseApi.Domain.Entities.Base;
using BaseApi.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public AppDbContext(DbContextOptions options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                    ((BaseEntity)entity.Entity).CreatedAt = now;

                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
