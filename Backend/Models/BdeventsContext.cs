using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class BdeventsContext : DbContext
{
    public BdeventsContext()
    {
    }

    public BdeventsContext(DbContextOptions<BdeventsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiEvent> ApiEvents { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Eventlog> Eventlogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<ApiEvent>(entity =>
        {
            entity.HasKey(e => e.ApiEventId).HasName("PRIMARY");

            entity.ToTable("api_events");

            entity.HasIndex(e => e.EventId, "EventID");

            entity.Property(e => e.ApiEventId).HasColumnName("API_EventID");
            entity.Property(e => e.AdditionalInformation).HasColumnType("text");
            entity.Property(e => e.EventId).HasColumnName("EventID");

            entity.HasOne(d => d.Event).WithMany(p => p.ApiEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("api_events_ibfk_1");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity.ToTable("events");

            entity.HasIndex(e => e.UserId, "UserID");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Events)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_ibfk_1");
        });

        modelBuilder.Entity<Eventlog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PRIMARY");

            entity.ToTable("eventlog");

            entity.HasIndex(e => e.EventId, "EventID");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.ActivityType).HasColumnType("enum('Creation','Update','Deletion')");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Event).WithMany(p => p.Eventlogs)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventlog_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DateRegistered)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
