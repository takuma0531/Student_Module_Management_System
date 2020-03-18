using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentModuleManagementSystem.DataAccessLayer
{
    public partial class StudentModuleManagementDatabaseContext : DbContext
    {
        public StudentModuleManagementDatabaseContext()
        {
        }

        public StudentModuleManagementDatabaseContext(DbContextOptions<StudentModuleManagementDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentModule> StudentModule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=StudentModuleManagementDatabase;User=sa;Password=tellmewhatyouaredoingrightnow0225howistheweathertodayitissunnytodayhowaboutyou;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasIndex(e => e.ModuleName)
                    .HasName("UQ__Module__EAC9AEC3EB799F79")
                    .IsUnique();

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.FirstName)
                    .HasName("UQ__Student__B31331C9B32586CE")
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentModule>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ModuleId });

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.StudentModule)
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentModule)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
