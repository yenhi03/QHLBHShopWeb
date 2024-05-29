using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Design> Designs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierInv> SupplierInvs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NHINGUYENHO\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.BuildingNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("building_number");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.EmailCus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email_cus");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("postcode");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_customer_user");
            });

            modelBuilder.Entity<Design>(entity =>
            {
                entity.HasKey(e => e.DesignsId)
                    .HasName("PK__design__3213E83FCB52DC7E");

                entity.ToTable("designs");

                entity.Property(e => e.DesignsId).HasColumnName("designs_id");

                entity.Property(e => e.Finish)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("finish");

                entity.Property(e => e.Gems)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("gems");

                entity.Property(e => e.Material)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("material");

                entity.Property(e => e.ProductsId).HasColumnName("products_id");

                entity.Property(e => e.Purity).HasColumnName("purity");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.Designs)
                    .HasForeignKey(d => d.ProductsId)
                    .HasConstraintName("fk_design");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Position)
                    .HasMaxLength(255)
                    .HasColumnName("position");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("salary");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_user");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrdersId)
                    .HasName("PK__customer__3213E83F7231B4CE");

                entity.ToTable("orders");

                entity.Property(e => e.OrdersId).HasColumnName("orders_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("month");

                entity.Property(e => e.OrdersDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orders_date");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductsId).HasColumnName("products_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customer_inv_customer");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customer_inv_products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductsId)
                    .HasName("PK__stock__3213E83FF377EFCD");

                entity.ToTable("products");

                entity.Property(e => e.ProductsId).HasColumnName("products_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("item");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_products_category");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Material)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("material");
            });

            modelBuilder.Entity<SupplierInv>(entity =>
            {
                entity.ToTable("supplier_inv");

                entity.Property(e => e.SupplierInvId).HasColumnName("supplier_inv_id");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductsId).HasColumnName("products_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.TransactionStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_stamp");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.SupplierInvs)
                    .HasForeignKey(d => d.ProductsId)
                    .HasConstraintName("FK_supplier_inv_stock");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierInvs)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_supplier_inv_supplier");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "UQ__user__A9D1053406E7F427")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
