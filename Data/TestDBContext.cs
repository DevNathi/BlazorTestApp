using BlazorTestApp.Models;
using BlazorTestApp.Pages;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestApp.Data
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User configuration
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.U_Id);

            modelBuilder.Entity<UserModel>()
                .Property(u => u.U_Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Branch)
                .WithMany(b => b.Users)
                .HasForeignKey(u => u.U_BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Warehouse)
                .WithMany(w => w.Users)
                .HasForeignKey(u => u.U_WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Warehouse configuration
            modelBuilder.Entity<Warehouse>()
                .HasKey(w => w.W_Id);

            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.Branch)
                .WithMany(b => b.Warehouses)
                .HasForeignKey(w => w.W_BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Branch configuration
            modelBuilder.Entity<Branch>()
                .HasKey(b => b.B_Id);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Users)
                .WithOne(u => u.Branch)
                .HasForeignKey(u => u.U_BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Warehouses)
                .WithOne(w => w.Branch)
                .HasForeignKey(w => w.W_BranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
