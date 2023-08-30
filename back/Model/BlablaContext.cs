using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace back.Model;

public partial class BlablaContext : DbContext
{
    public BlablaContext()
    {
    }

    public BlablaContext(DbContextOptions<BlablaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Community> Communities { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0018D\\SQLEXPRESS;Initial Catalog=Blabla;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cargo__3214EC272D599576");

            entity.ToTable("Cargo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CommunityNavigation).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.Community)
                .HasConstraintName("FK__Cargo__Community__3B75D760");
        });

        modelBuilder.Entity<Community>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Communit__3214EC279E12F2E1");

            entity.ToTable("Community");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Criacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Descrip)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Foto)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Likes__3214EC2712B300D3");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.PersonNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.Person)
                .HasConstraintName("FK__Likes__Person__46E78A0C");

            entity.HasOne(d => d.PostNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.Post)
                .HasConstraintName("FK__Likes__Post__47DBAE45");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Member__3214EC276ACF27A4");

            entity.ToTable("Member");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.CargoNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.Cargo)
                .HasConstraintName("FK__Member__Cargo__3E52440B");

            entity.HasOne(d => d.CommunityNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.Community)
                .HasConstraintName("FK__Member__Communit__403A8C7D");

            entity.HasOne(d => d.PersonNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.Person)
                .HasConstraintName("FK__Member__Person__3F466844");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC2724FEE74F");

            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Foto)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NickName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.WordPass)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC2787D687A7");

            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CommunityId).HasColumnName("Community_id");
            entity.Property(e => e.Descrip)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Foto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PersonId).HasColumnName("Person_id");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Community).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("FK__Post__Community___4316F928");

            entity.HasOne(d => d.Person).WithMany(p => p.Posts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Post__Person_id__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
