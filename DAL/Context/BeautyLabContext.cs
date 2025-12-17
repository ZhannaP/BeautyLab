using DAL.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Context
{
    public partial class BeautyLabContext : DbContext
    {
        public BeautyLabContext(DbContextOptions<BeautyLabContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<MasterService> MasterServices { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<User> Users { get; set; }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                modelBuilder.Entity<Appointment>().ToTable("Appointment");
                entity.HasKey(e => e.AppointmentId);

                entity.Property(e => e.Status)
                      .HasMaxLength(20)
                      .IsUnicode(false);

                entity.HasOne(a => a.Client)
                      .WithMany()
                      .HasForeignKey(a => a.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Master)
                      .WithMany()
                      .HasForeignKey(a => a.MasterId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Service)
                      .WithMany()
                      .HasForeignKey(a => a.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                modelBuilder.Entity<Client>().ToTable("Client");
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.Notes)
                      .HasMaxLength(200)
                      .IsUnicode(false);

                entity.HasOne(c => c.User)
                      .WithMany()
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Master>(entity =>
            {
                modelBuilder.Entity<Master>().ToTable("Master");
                entity.HasKey(e => e.MasterId);

                entity.Property(e => e.Specialization)
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.HasOne(m => m.User)
                      .WithMany()
                      .HasForeignKey(m => m.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<MasterService>(entity =>
            {
                modelBuilder.Entity<MasterService>().ToTable("MasterService");
                entity.HasKey(e => e.MasterServiceId);

                entity.HasOne(ms => ms.Master)
                      .WithMany()
                      .HasForeignKey(ms => ms.MasterId);

                entity.HasOne(ms => ms.Service)
                      .WithMany()
                      .HasForeignKey(ms => ms.ServiceId);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                modelBuilder.Entity<Payment>().ToTable("Payment");
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.Method)
                      .HasMaxLength(20)
                      .IsUnicode(false);

                entity.Property(e => e.Status)
                      .HasMaxLength(20)
                      .IsUnicode(false);

                entity.HasOne(p => p.Appointment)
                      .WithMany()
                      .HasForeignKey(p => p.AppointmentId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                modelBuilder.Entity<Role>().ToTable("Role");
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleName)
                      .HasMaxLength(20)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                modelBuilder.Entity<Service>().ToTable("Service");
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.Description)
                      .HasMaxLength(200)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                modelBuilder.Entity<User>().ToTable("User");
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.FirstName)
                      .HasMaxLength(30)
                      .IsUnicode(false);

                entity.Property(e => e.LastName)
                      .HasMaxLength(30)
                      .IsUnicode(false);

                entity.Property(e => e.Phone)
                      .HasMaxLength(20)
                      .IsUnicode(false);

                entity.Property(e => e.Email)
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.Password)
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.HasOne(u => u.Role)
                      .WithMany()
                      .HasForeignKey(u => u.RoleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }
    }
}
