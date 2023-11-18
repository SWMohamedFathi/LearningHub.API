using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningHub.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Stdcourse> Stdcourses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=C##WEB ;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##WEB")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CATEGORYID");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roledid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEDID");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Roled)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Roledid)
                    .HasConstraintName("ROLEID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STUDENTID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Roledid)
                    .HasName("SYS_C008316");

                entity.ToTable("ROLE");

                entity.Property(e => e.Roledid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEDID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Stdcourse>(entity =>
            {
                entity.ToTable("STDCOURSE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Dateofregister)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFREGISTER");

                entity.Property(e => e.Markofstd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARKOFSTD");

                entity.Property(e => e.Stdid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STDID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Stdcourses)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_COURSEID");

                entity.HasOne(d => d.Std)
                    .WithMany(p => p.Stdcourses)
                    .HasForeignKey(d => d.Stdid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STDID");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
