using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BairesDev.Exam.Infraestructure.Entity;

namespace BairesDev.Exam.Infraestructure.Models
{
    public partial class ActiveDBContext : DbContext
    {
        public ActiveDBContext()
        {
        }

        public ActiveDBContext(DbContextOptions<ActiveDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ActiveDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("PersonVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
