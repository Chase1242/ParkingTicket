using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ParkingTickets.Database.Entities;

namespace ParkingTickets.Database;

public partial class WsuParkingTicketsContext : DbContext
{
    public WsuParkingTicketsContext()
    {
    }

    public WsuParkingTicketsContext(DbContextOptions<WsuParkingTicketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LSI1S54;Initial Catalog=WsuParkingTickets;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Latitude).HasColumnType("decimal(10, 5)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(10, 5)");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Property(e => e.TicketId).ValueGeneratedOnAdd();
            entity.Property(e => e.TicketNumber).HasMaxLength(50);
            entity.Property(e => e.TicketingOfficerName).HasMaxLength(100);
            entity.Property(e => e.ViolationType).HasMaxLength(100);

            entity.HasOne(d => d.Location).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Locations");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
