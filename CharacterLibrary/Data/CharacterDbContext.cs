using CharacterLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterLibrary.Data
{
    /// <summary>
    /// Entity Framework Core context. The SQLite database lives in a single
    /// file next to the executable (CharacterLibrary.db) so it's easy to back up
    /// or copy between machines.
    /// </summary>
    public class CharacterDbContext : DbContext
    {
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<CharacterTag> CharacterTags => Set<CharacterTag>();

        public string DbPath { get; }

        public CharacterDbContext()
        {
            DbPath = Path.Combine(AppContext.BaseDirectory, "CharacterLibrary.db");
        }

        public CharacterDbContext(string dbPath)
        {
            DbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(e =>
            {
                // Natural unique key: Name
                e.HasIndex(c => c.Name).IsUnique();
            });

            modelBuilder.Entity<Tag>(e =>
            {
                e.HasIndex(t => t.Name).IsUnique();
            });

            modelBuilder.Entity<CharacterTag>(e =>
            {
                e.HasIndex(ct => new { ct.CharacterId, ct.TagId }).IsUnique();

                e.HasOne(ct => ct.Character)
                 .WithMany(c => c.CharacterTags)
                 .HasForeignKey(ct => ct.CharacterId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(ct => ct.Tag)
                 .WithMany(t => t.CharacterTags)
                 .HasForeignKey(ct => ct.TagId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public override int SaveChanges()
        {
            ApplyTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Automatically stamps CreatedAt / ModifiedAt on Character inserts & updates
        /// and CreatedAt on new Tags. UTC is used so backups move cleanly across time zones.
        /// </summary>
        private void ApplyTimestamps()
        {
            var now = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.Entity)
                {
                    case Character ch when entry.State == EntityState.Added:
                        ch.CreatedAt = now;
                        ch.ModifiedAt = now;
                        break;
                    case Character ch when entry.State == EntityState.Modified:
                        ch.ModifiedAt = now;
                        break;
                    case Tag t when entry.State == EntityState.Added:
                        t.CreatedAt = now;
                        break;
                }
            }
        }
    }
}
