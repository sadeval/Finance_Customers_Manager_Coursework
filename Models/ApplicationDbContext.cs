using FMS_PNP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerTransaction> CustomerTransactions { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Настройка сущностей

        // Administrator
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.ToTable("Administrator");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.FullName)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("FullName");

            entity.Property(e => e.Login)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnName("Login");

            entity.Property(e => e.PasswordHash)
                  .IsRequired()
                  .HasMaxLength(256)
                  .HasColumnName("PasswordHash");

            // Индексы
            entity.HasIndex(e => e.Login)
                  .IsUnique();

            // Связи
            entity.HasMany(e => e.Transactions)
                  .WithOne(t => t.Administrator)
                  .HasForeignKey(t => t.AdministratorId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Product
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.NameOfProduct)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("NameOfProduct"); // Сопоставляем с существующим столбцом

            entity.Property(e => e.Category)
                  .HasMaxLength(50)
                  .HasColumnName("Category");

            entity.Property(e => e.Textile)
                  .HasMaxLength(50)
                  .HasColumnName("Textile");

            entity.Property(e => e.Season)
                  .HasMaxLength(50)
                  .HasColumnName("Season");

            entity.Property(e => e.Color)
                  .HasMaxLength(50)
                  .HasColumnName("Color");

            entity.Property(e => e.Size)
                  .IsRequired()
                  .HasColumnName("Size");

            entity.Property(e => e.Quantity)
                  .IsRequired()
                  .HasColumnName("Quantity");

            entity.Property(e => e.Price)
                  .HasColumnType("decimal(18,2)")
                  .HasColumnName("Price");

            // Индексы
            entity.HasIndex(e => e.NameOfProduct)
                  .IsUnique();

            // Связи
            entity.HasMany(e => e.Transactions)
                  .WithOne(t => t.Product)
                  .HasForeignKey(t => t.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Transaction
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transactions"); 

            entity.HasKey(e => e.TransactionID);

            entity.Property(e => e.FullName)
                  .HasMaxLength(100)
                  .HasColumnName("FullName");

            entity.Property(e => e.NameOfProduct)
                  .HasMaxLength(100)
                  .HasColumnName("NameOfProduct");

            entity.Property(e => e.Category)
                  .HasMaxLength(50)
                  .HasColumnName("Category");

            entity.Property(e => e.ReturnOfGoods)
                  .IsRequired()
                  .HasColumnName("ReturnOfGoods");

            entity.Property(e => e.Summ)
                  .HasColumnType("decimal(18,2)")
                  .HasDefaultValue(0)
                  .HasColumnName("Summ");

            entity.Property(e => e.Date)
                  .IsRequired()
                  .HasColumnName("Date");

            // Индексы
            entity.HasIndex(e => e.Date);

            // Связи
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.Transactions)
                  .HasForeignKey(t => t.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Administrator)
                  .WithMany(a => a.Transactions)
                  .HasForeignKey(t => t.AdministratorId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Customer)
                  .WithMany(c => c.Transactions)
                  .HasForeignKey(t => t.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Customer
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers"); 

            entity.HasKey(e => e.Id);

            entity.Property(e => e.FullName)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("FullName");

            entity.Property(e => e.Mobile)
                  .HasMaxLength(20)
                  .HasColumnName("Mobile");

            entity.Property(e => e.Email)
                  .HasMaxLength(100)
                  .HasColumnName("Email");

            entity.Property(e => e.Address)
                  .HasMaxLength(200)
                  .HasColumnName("Address");

            // Индексы
            entity.HasIndex(e => e.Email)
                  .IsUnique();

            // Связи
            entity.HasMany(e => e.Transactions)
                  .WithOne(t => t.Customer)
                  .HasForeignKey(t => t.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.CustomerTransactions)
                  .WithOne(ct => ct.Customer)
                  .HasForeignKey(ct => ct.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // CustomerTransaction
        modelBuilder.Entity<CustomerTransaction>(entity =>
        {
            entity.ToTable("CustomerTransactions"); 

            entity.HasKey(e => e.Id);

            entity.Property(e => e.FullName)
                  .HasMaxLength(100)
                  .HasColumnName("FullName");

            entity.Property(e => e.Amount)
                  .HasColumnType("decimal(18,2)")
                  .HasColumnName("Amount");

            entity.Property(e => e.Date)
                  .IsRequired()
                  .HasColumnName("Date");

            // Связи
            entity.HasOne(e => e.Customer)
                  .WithMany(c => c.CustomerTransactions)
                  .HasForeignKey(ct => ct.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
