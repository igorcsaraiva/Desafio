using Desafio.Domain.Domain.DomainHistory;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Data
{
    public sealed class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcountHistory>().HasIndex(x => x.UserId);
            modelBuilder.Entity<PersonalNoteHistory>().HasIndex(x => x.UserId);
            modelBuilder.Entity<UserInfoHistory>().HasIndex(x => x.UserId);
        }

        public DbSet<AcountHistory> AcountHistory { get; set; }
        public DbSet<PersonalNoteHistory> PersonalNoteHistory { get; set; }
        public DbSet<UserInfoHistory> UserInfoHistory { get; set; }
    }
}
