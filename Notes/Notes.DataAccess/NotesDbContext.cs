using Microsoft.EntityFrameworkCore;
using Notes.CryptoService;
using Notes.Domain.Enums;
using Notes.Domain.Models;

namespace Notes.DataAccess
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //validation using fluent Api

            modelBuilder.Entity<Note>()
                .Property(n => n.Text)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Note>()
                .Property(n => n.Priority)
                .IsRequired();

            modelBuilder.Entity<Note>()
                .Property(n => n.Tag)
                .IsRequired();

            // relations

            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId);

            // User

            modelBuilder.Entity<User>()
              .Property(x => x.FirstName)
              .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(30)
                .IsRequired();

            // Seed

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Elena",
                    LastName = "Simoska",
                    UserName = "ElenaS",
                    Age = 38,
                    Password = StringHasher.Hash("elena123"),
                    Notes = new List<Note>()
                });


            modelBuilder.Entity<Note>()
                .HasData(new Note
                {
                    Id = 1,
                    Text = "Study More",
                    Priority = Priority.High,
                    Tag = Tag.Work,
                    UserId = 1,

                });

        }


    }
}
