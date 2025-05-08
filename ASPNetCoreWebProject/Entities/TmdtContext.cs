using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebProject.Entities;

public partial class TmdtContext : DbContext
{
    public TmdtContext()
    {
    }

    public TmdtContext(DbContextOptions<TmdtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }

    public virtual DbSet<ShipmentUnit> ShipmentUnits { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StockIn> StockIns { get; set; }

    public virtual DbSet<StockInDetail> StockInDetails { get; set; }

    public virtual DbSet<StockOut> StockOuts { get; set; }

    public virtual DbSet<StockOutDetail> StockOutDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7ODD7CH\\SQLEXPRESS; Database=TMDT; Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__CART__AB01BF6F35C43966");

            entity.ToTable("CART");

            entity.Property(e => e.CartId)
                .HasMaxLength(100)
                .HasColumnName("CART_ID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");

            entity.HasOne(d => d.Account).WithMany(p => p.Carts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__CART__ACCOUNT_ID__59FA5E80");
        });

        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity.HasKey(e => new { e.CartId, e.ProductId }).HasName("PK__CART_DET__8E2AFE190C82F0F2");

            entity.ToTable("CART_DETAIL");

            entity.Property(e => e.CartId)
                .HasMaxLength(100)
                .HasColumnName("CART_ID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.NumberOfProduct).HasColumnName("NUMBER_OF_PRODUCT");
            entity.Property(e => e.TotalAmount).HasColumnName("TOTAL_AMOUNT");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CART_DETA__CART___5DCAEF64");

            entity.HasOne(d => d.Product).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CART_DETA__PRODU__5CD6CB2B");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__CUSTOMER__05B22F6059946E4A");

            entity.ToTable("CUSTOMER");

            entity.HasIndex(e => e.Username, "UQ__CUSTOMER__B15BE12E47B09A16").IsUnique();

            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.PassWord)
                .HasMaxLength(100)
                .HasColumnName("PASS_WORD");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Account).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CUSTOMER__ACCOUN__4E88ABD4");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("INVOICE_INVOICE_ID_PK");

            entity.ToTable("INVOICE");

            entity.Property(e => e.InvoiceId)
                .HasMaxLength(100)
                .HasColumnName("INVOICE_ID");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATE");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.TotalAmount).HasColumnName("TOTAL_AMOUNT");

            entity.HasOne(d => d.Order).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INVOICE__ORDER_I__00200768");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("ORDERS_ORDER_ID_PK");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("_ADDRESS");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("CITY");
            entity.Property(e => e.OrdrerDate)
                .HasColumnType("datetime")
                .HasColumnName("ORDRER_DATE");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS__ACCOUNT___76969D2E");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__ORDER_DE__6321D5129760A837");

            entity.ToTable("ORDER_DETAIL");

            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Percents).HasColumnName("PERCENTS");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.UnitPrice).HasColumnName("UNIT_PRICE");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDER_DET__ORDER__797309D9");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDER_DET__PRODU__7A672E12");
        });

        modelBuilder.Entity<PersonalInformation>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PERSONAL_INFORMATION_ACCOUNT_ID_PK");

            entity.ToTable("PERSONAL_INFORMATION");

            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("_ADDRESS");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("CITY");
            entity.Property(e => e.DateOfBirth).HasColumnName("DATE_OF_BIRTH");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(11)
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("_TYPE");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRODUCTS_PRODUCT_ID_PK");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("_TYPE");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTS__SUPPLI__571DF1D5");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipmentId).HasName("SHIPMENT_SHIPMENT_ID_PK");

            entity.ToTable("SHIPMENT");

            entity.Property(e => e.ShipmentId)
                .HasMaxLength(100)
                .HasColumnName("SHIPMENT_ID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.TotalFee).HasColumnName("TOTAL_FEE");

            entity.HasOne(d => d.Account).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SHIPMENT__ACCOUN__7D439ABD");
        });

        modelBuilder.Entity<ShipmentDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.StockOutId, e.ShipmentId }).HasName("PK__SHIPMENT__C78FEC58638471F7");

            entity.ToTable("SHIPMENT_DETAIL");

            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.StockOutId)
                .HasMaxLength(100)
                .HasColumnName("STOCK_OUT_ID");
            entity.Property(e => e.ShipmentId)
                .HasMaxLength(100)
                .HasColumnName("SHIPMENT_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("_ADDRESS");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("CITY");
            entity.Property(e => e.DelayReason)
                .HasMaxLength(100)
                .HasColumnName("DELAY_REASON");
            entity.Property(e => e.DeliveredDate)
                .HasColumnType("datetime")
                .HasColumnName("DELIVERED_DATE");
            entity.Property(e => e.Fee).HasColumnName("FEE");
            entity.Property(e => e.ShippedDate)
                .HasColumnType("datetime")
                .HasColumnName("SHIPPED_DATE");
            entity.Property(e => e.Statuss)
                .HasMaxLength(50)
                .HasColumnName("STATUSS");

            entity.HasOne(d => d.Order).WithMany(p => p.ShipmentDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SHIPMENT___ORDER__02FC7413");

            entity.HasOne(d => d.Shipment).WithMany(p => p.ShipmentDetails)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SHIPMENT___SHIPM__04E4BC85");

            entity.HasOne(d => d.StockOut).WithMany(p => p.ShipmentDetails)
                .HasForeignKey(d => d.StockOutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SHIPMENT___STOCK__03F0984C");
        });

        modelBuilder.Entity<ShipmentUnit>(entity =>
        {
            entity.HasKey(e => e.ShipmentUnitId).HasName("SHIPMENT_UNIT_SHIPMENT_UNIT_ID_PK");

            entity.ToTable("SHIPMENT_UNIT");

            entity.Property(e => e.ShipmentUnitId)
                .HasMaxLength(100)
                .HasColumnName("SHIPMENT_UNIT_ID");
            entity.Property(e => e.ShipmentUnitName)
                .HasMaxLength(100)
                .HasColumnName("SHIPMENT_UNIT_NAME");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__SHIPPER__05B22F603D2FEE04");

            entity.ToTable("SHIPPER");

            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.PassWord)
                .HasMaxLength(100)
                .HasColumnName("PASS_WORD");
            entity.Property(e => e.ShipmentUnitId)
                .HasMaxLength(100)
                .HasColumnName("SHIPMENT_UNIT_ID");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Account).WithOne(p => p.Shipper)
                .HasForeignKey<Shipper>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SHIPPER__ACCOUNT__534D60F1");

            entity.HasOne(d => d.ShipmentUnit).WithMany(p => p.Shippers)
                .HasForeignKey(d => d.ShipmentUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SHIPPER__SHIPMEN__5441852A");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.ShopId).HasName("SHOP_SHOP_ID_PK");

            entity.ToTable("SHOP");

            entity.Property(e => e.ShopId)
                .HasMaxLength(100)
                .HasColumnName("SHOP_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("_ADDRESS");
            entity.Property(e => e.Capacity).HasColumnName("CAPACITY");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("CITY");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.ShopId, e.ProductId }).HasName("PK__STOCK__4FD5E4097087127B");

            entity.ToTable("STOCK");

            entity.Property(e => e.ShopId)
                .HasMaxLength(100)
                .HasColumnName("SHOP_ID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

            entity.HasOne(d => d.Product).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOCK__PRODUCT_I__6383C8BA");

            entity.HasOne(d => d.Shop).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOCK__SHOP_ID__628FA481");
        });

        modelBuilder.Entity<StockIn>(entity =>
        {
            entity.HasKey(e => e.StockInId).HasName("STOCK_IN_STOCK_IN_ID_PK");

            entity.ToTable("STOCK_IN");

            entity.Property(e => e.StockInId)
                .HasMaxLength(100)
                .HasColumnName("STOCK_IN_ID");
            entity.Property(e => e.ReceivedDate).HasColumnName("RECEIVED_DATE");
            entity.Property(e => e.ShopId)
                .HasMaxLength(100)
                .HasColumnName("SHOP_ID");
            entity.Property(e => e.SourceShopId)
                .HasMaxLength(100)
                .HasColumnName("SOURCE_SHOP_ID");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_ID");

            entity.HasOne(d => d.Shop).WithMany(p => p.StockInShops)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOCK_IN__SHOP_I__68487DD7");

            entity.HasOne(d => d.SourceShop).WithMany(p => p.StockInSourceShops)
                .HasForeignKey(d => d.SourceShopId)
                .HasConstraintName("FK__STOCK_IN__SOURCE__6754599E");

            entity.HasOne(d => d.Supplier).WithMany(p => p.StockIns)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__STOCK_IN__SUPPLI__66603565");
        });

        modelBuilder.Entity<StockInDetail>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.StockInId }).HasName("PK__STOCK_IN__6F56FD1526716C45");

            entity.ToTable("STOCK_IN_DETAIL", tb => tb.HasTrigger("trg_UpdateQuantity"));

            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.StockInId)
                .HasMaxLength(100)
                .HasColumnName("STOCK_IN_ID");
            entity.Property(e => e.ProductMoney).HasColumnName("PRODUCT_MONEY");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

            entity.HasOne(d => d.Product).WithMany(p => p.StockInDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOCK_IN___PRODU__6B24EA82");

            entity.HasOne(d => d.StockIn).WithMany(p => p.StockInDetails)
                .HasForeignKey(d => d.StockInId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOCK_IN___STOCK__6C190EBB");
        });

        modelBuilder.Entity<StockOut>(entity =>
        {
            entity.HasKey(e => e.StockOutId).HasName("STOCK_OUT_STOCK_OUT_ID_PK");

            entity.ToTable("STOCK_OUT");

            entity.Property(e => e.StockOutId)
                .HasMaxLength(100)
                .HasColumnName("STOCK_OUT_ID");
            entity.Property(e => e.DestShopId)
                .HasMaxLength(100)
                .HasColumnName("DEST_SHOP_ID");
            entity.Property(e => e.IssueDate)
                .HasColumnType("datetime")
                .HasColumnName("ISSUE_DATE");
            entity.Property(e => e.ShopId)
                .HasMaxLength(100)
                .HasColumnName("SHOP_ID");

            entity.HasOne(d => d.DestShop).WithMany(p => p.StockOutDestShops)
                .HasForeignKey(d => d.DestShopId)
                .HasConstraintName("FK__STOCK_OUT__DEST___6EF57B66");

            entity.HasOne(d => d.Shop).WithMany(p => p.StockOutShops)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOCK_OUT__SHOP___6FE99F9F");
        });

        modelBuilder.Entity<StockOutDetail>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.StockOutId }).HasName("PK__STOCK_OU__AF81D690108BD724");

            entity.ToTable("STOCK_OUT_DETAIL");

            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.StockOutId)
                .HasMaxLength(100)
                .HasColumnName("STOCK_OUT_ID");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

            entity.HasOne(d => d.Product).WithMany(p => p.StockOutDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOCK_OUT__PRODU__72C60C4A");

            entity.HasOne(d => d.StockOut).WithMany(p => p.StockOutDetails)
                .HasForeignKey(d => d.StockOutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STOCK_OUT__STOCK__73BA3083");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__SUPPLIER__88565CC19D4C057F");

            entity.ToTable("SUPPLIER");

            entity.Property(e => e.SupplierId)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIl");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(11)
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.SupplierAddress)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_ADDRESS");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
