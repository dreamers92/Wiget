using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AcmeWidget.Models
{
    public partial class FormRegistrationsContext : DbContext
    {
        public FormRegistrationsContext()
        {
        }

        public FormRegistrationsContext(DbContextOptions<FormRegistrationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.ToTable("Applicant");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength(true);

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("comments");

                entity.Property(e => e.DateModified).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
