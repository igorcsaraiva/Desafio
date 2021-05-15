using Desafio.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Data
{
    public sealed class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasKey(x => x.Id);
            modelBuilder.Entity<PersonalNotes>().HasKey(x => x.Id);

            modelBuilder.Entity<UserInfo>().HasIndex(x => x.UserId).IsUnique();

            modelBuilder.Entity<UserInfo>().Property(x => x.Id).ValueGeneratedNever();
            modelBuilder.Entity<PersonalNotes>().Property(x => x.Id).ValueGeneratedNever();
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<PersonalNotes> PersonalNotes { get; set; }
    }
}
