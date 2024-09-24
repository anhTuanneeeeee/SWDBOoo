using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BOs.Models;

public partial class BookroomContext : DbContext
{
    public BookroomContext()
    {
    }

    public BookroomContext(DbContextOptions<BookroomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<SlotBooking> SlotBookings { get; set; }

    public virtual DbSet<TblBooking> TblBookings { get; set; }

    public virtual DbSet<TblBranch> TblBranches { get; set; }

    public virtual DbSet<TblPrice> TblPrices { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblRoom> TblRooms { get; set; }

    public virtual DbSet<TblRoomType> TblRoomTypes { get; set; }

    public virtual DbSet<TblSlot> TblSlots { get; set; }

    public virtual DbSet<TblStatus> TblStatuses { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnection"];
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A382CFC4223");

            entity.ToTable("Payment");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Booking");

            entity.HasOne(d => d.Status).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Status");
        });

        modelBuilder.Entity<SlotBooking>(entity =>
        {
            entity.HasKey(e => e.SlotBookingId).HasName("PK__SlotBook__F7BA697A352815FF");

            entity.ToTable("SlotBooking");

            entity.HasOne(d => d.Booking).WithMany(p => p.SlotBookings)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SlotBooking_Booking");

            entity.HasOne(d => d.Slot).WithMany(p => p.SlotBookings)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SlotBooking_Slot");

            entity.HasOne(d => d.Status).WithMany(p => p.SlotBookings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SlotBooking_Status");
        });

        modelBuilder.Entity<TblBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Tbl_Book__73951AED18B6109A");

            entity.ToTable("Tbl_Booking");

            entity.Property(e => e.BookingDate).HasColumnType("date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Room).WithMany(p => p.TblBookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_Booking_Room");

            entity.HasOne(d => d.User).WithMany(p => p.TblBookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Booking_User");
        });

        modelBuilder.Entity<TblBranch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__tbl_Bran__A1682FC5DCC51851");

            entity.ToTable("Tbl_Branch");

            entity.Property(e => e.BranchName).HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.PriceId).HasColumnName("PriceID");

            entity.HasOne(d => d.Price).WithMany(p => p.TblBranches)
                .HasForeignKey(d => d.PriceId)
                .HasConstraintName("FK_tbl_Branch_Tbl_Price");
        });

        modelBuilder.Entity<TblPrice>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK_Tbl_Pricee");

            entity.ToTable("Tbl_Price");

            entity.Property(e => e.PriceId)
                .ValueGeneratedNever()
                .HasColumnName("PriceID");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__tbl_Role__8AFACE1AE3B96212");

            entity.ToTable("Tbl_Role");

            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<TblRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Tbl_Room__32863939C75A9BA4");

            entity.ToTable("Tbl_Room");

            entity.Property(e => e.IsAvailable).HasDefaultValueSql("((1))");
            entity.Property(e => e.RoomName).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.TblRooms)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Room_Branch");

            entity.HasOne(d => d.RoomType).WithMany(p => p.TblRooms)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK_Room_RoomType");

            entity.HasOne(d => d.Status).WithMany(p => p.TblRooms)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Room_Status");
        });

        modelBuilder.Entity<TblRoomType>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("PK__Tbl_Room__BCC896317F3987E0");

            entity.ToTable("Tbl_RoomType");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblSlot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__Tbl_Slot__0A124AAF25F00DF7");

            entity.ToTable("Tbl_Slot");

            entity.Property(e => e.EndTime).HasMaxLength(20);
            entity.Property(e => e.StartTime).HasMaxLength(20);
        });

        modelBuilder.Entity<TblStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Tbl_Stat__C8EE20635666052C");

            entity.ToTable("Tbl_Status");

            entity.Property(e => e.StatusName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbl_User__1788CC4CBEAE093E");

            entity.ToTable("Tbl_User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreateUser).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(40);
            entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            entity.Property(e => e.UserName).HasMaxLength(30);

            entity.HasOne(d => d.Role).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
