using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace admin.Models
{
    public partial class LockerLuckContext : DbContext
    {
        public LockerLuckContext()
        {
        }

        public LockerLuckContext(DbContextOptions<LockerLuckContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Fav> Favs { get; set; } = null!;
        public virtual DbSet<Get購物車頁面聯集listBy會員Id某會員id查找購物車id子項id商品id賣方id> Get購物車頁面聯集listBy會員Id某會員id查找購物車id子項id商品id賣方ids { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<OrderInfo> OrderInfos { get; set; } = null!;
        public virtual DbSet<OrderOrdering> OrderOrderings { get; set; } = null!;
        public virtual DbSet<Orderdetails訂單資料詳細> Orderdetails訂單資料詳細s { get; set; } = null!;
        public virtual DbSet<Sub> Subs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<View1> View1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration =
                                    new ConfigurationBuilder()
                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
                optionsBuilder.UseSqlServer(
                    configuration.GetConnectionString("LockerLuck")
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.購物車項目id)
                    .HasName("PK_購物車");

                entity.ToTable("Cart");

                entity.Property(e => e.購物車項目id)
                    .HasMaxLength(50)
                    .HasColumnName("購物車項目ID")
                    .HasComment("格式：cart-20220630123015-555555");

                entity.Property(e => e.Is刪除).HasColumnName("is刪除");

                entity.Property(e => e.Is結帳).HasColumnName("is結帳");

                entity.Property(e => e.子項id)
                    .HasMaxLength(50)
                    .HasColumnName("子項ID")
                    .HasComment("格式：sub-20220630123015-555555");

                entity.Property(e => e.會員id)
                    .HasMaxLength(50)
                    .HasColumnName("會員ID");
            });

            modelBuilder.Entity<Fav>(entity =>
            {
                entity.HasKey(e => new { e.商品id, e.會員id })
                    .HasName("PK_收藏清單_1");

                entity.ToTable("Fav");

                entity.Property(e => e.商品id)
                    .HasMaxLength(50)
                    .HasColumnName("商品ID")
                    .HasComment("格式：item-20220630123015-555555");

                entity.Property(e => e.會員id)
                    .HasMaxLength(50)
                    .HasColumnName("會員ID");

                entity.Property(e => e.No)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("no");

                entity.HasOne(d => d.商品)
                    .WithMany(p => p.Favs)
                    .HasForeignKey(d => d.商品id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_收藏清單_商品");

                entity.HasOne(d => d.會員)
                    .WithMany(p => p.Favs)
                    .HasForeignKey(d => d.會員id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_收藏清單_會員");
            });

            modelBuilder.Entity<Get購物車頁面聯集listBy會員Id某會員id查找購物車id子項id商品id賣方id>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Get購物車_頁面_聯集ListBy會員ID：某會員ID>查找購物車ID>子項ID>商品ID>賣方ID");

                entity.Property(e => e.商品id)
                    .HasMaxLength(50)
                    .HasColumnName("商品ID");

                entity.Property(e => e.商品主圖).HasMaxLength(1000);

                entity.Property(e => e.商品名稱).HasMaxLength(50);

                entity.Property(e => e.子項id)
                    .HasMaxLength(50)
                    .HasColumnName("子項ID");

                entity.Property(e => e.子項名稱).HasMaxLength(50);

                entity.Property(e => e.賣方id)
                    .HasMaxLength(50)
                    .HasColumnName("賣方ID");

                entity.Property(e => e.賣方暱稱).HasMaxLength(50);

                entity.Property(e => e.賣方頭像檔名).HasMaxLength(50);

                entity.Property(e => e.購物車項目id)
                    .HasMaxLength(50)
                    .HasColumnName("購物車項目ID");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.商品id)
                    .HasName("PK_商品n");

                entity.ToTable("Item");

                entity.Property(e => e.商品id)
                    .HasMaxLength(50)
                    .HasColumnName("商品ID")
                    .HasComment("格式：item-20220630123015-555555");

                entity.Property(e => e.Is刪除).HasColumnName("is刪除");

                entity.Property(e => e.Is啟用).HasColumnName("is啟用");

                entity.Property(e => e.修改時間).HasColumnType("datetime");

                entity.Property(e => e.創建時間).HasColumnType("datetime");

                entity.Property(e => e.商品主圖)
                    .HasMaxLength(1000)
                    .HasComment("多網址，以,分隔");

                entity.Property(e => e.商品分類)
                    .HasMaxLength(200)
                    .HasComment("（暫定）以,分層");

                entity.Property(e => e.商品參數)
                    .HasMaxLength(1000)
                    .HasComment("（暫定）json，table");

                entity.Property(e => e.商品名稱).HasMaxLength(50);

                entity.Property(e => e.商品地址)
                    .HasMaxLength(200)
                    .HasComment("");

                entity.Property(e => e.商品條件)
                    .HasMaxLength(200)
                    .HasComment("（暫定）以,分層");

                entity.Property(e => e.商品簡述)
                    .HasMaxLength(100)
                    .HasComment("首block內");

                entity.Property(e => e.商品詳述)
                    .HasMaxLength(4000)
                    .HasComment("下方block內");

                entity.Property(e => e.商品郵遞區號).HasComment("3碼");

                entity.Property(e => e.租賃時間下限)
                    .HasMaxLength(10)
                    .HasComment("以 天 為單位，1/7/15/30/90/180/360");

                entity.Property(e => e.聯絡email)
                    .HasMaxLength(100)
                    .HasColumnName("聯絡Email");

                entity.Property(e => e.聯絡line)
                    .HasMaxLength(50)
                    .HasColumnName("聯絡Line");

                entity.Property(e => e.聯絡姓名).HasMaxLength(50);

                entity.Property(e => e.聯絡網址)
                    .HasMaxLength(1000)
                    .HasComment("網址");

                entity.Property(e => e.聯絡電話).HasMaxLength(50);

                entity.Property(e => e.賣方id)
                    .HasMaxLength(50)
                    .HasColumnName("賣方ID")
                    .HasComment("（暫定）會員帳號");
            });

            modelBuilder.Entity<OrderInfo>(entity =>
            {
                entity.HasKey(e => e.訂單id)
                    .HasName("PK_訂單-個資");

                entity.ToTable("Order-Info");

                entity.Property(e => e.訂單id)
                    .HasMaxLength(50)
                    .HasColumnName("訂單ID");

                entity.Property(e => e.下單id)
                    .HasMaxLength(50)
                    .HasColumnName("下單ID");

                entity.Property(e => e.付款id)
                    .HasMaxLength(50)
                    .HasColumnName("付款ID")
                    .HasComment("payment-20220630123015-666666");

                entity.Property(e => e.付款方式).HasMaxLength(50);

                entity.Property(e => e.創建時間).HasColumnType("datetime");

                entity.Property(e => e.折扣代碼).HasMaxLength(50);

                entity.Property(e => e.訂單留言).HasMaxLength(300);
            });

            modelBuilder.Entity<OrderOrdering>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("Order-Ordering");

                entity.Property(e => e.No).HasColumnName("no");

                entity.Property(e => e.Is買方取消).HasColumnName("is買方取消");

                entity.Property(e => e.Is賣方取消).HasColumnName("is賣方取消");

                entity.Property(e => e.停用日期).HasColumnType("datetime");

                entity.Property(e => e.商品id快照)
                    .HasMaxLength(50)
                    .HasColumnName("商品ID快照");

                entity.Property(e => e.商品主圖快照).HasMaxLength(1000);

                entity.Property(e => e.商品名稱快照).HasMaxLength(50);

                entity.Property(e => e.商品地址快照)
                    .HasMaxLength(200)
                    .HasComment("");

                entity.Property(e => e.商品郵遞區號快照).HasComment("3碼");

                entity.Property(e => e.啟用日期).HasColumnType("datetime");

                entity.Property(e => e.子項id快照)
                    .HasMaxLength(50)
                    .HasColumnName("子項ID快照");

                entity.Property(e => e.子項名稱快照).HasMaxLength(50);

                entity.Property(e => e.子項獨立編號).HasComment("舉例：子項(頭等倉)有10格，此處存編號3的格子位置");

                entity.Property(e => e.訂單id)
                    .HasMaxLength(50)
                    .HasColumnName("訂單ID");

                entity.HasOne(d => d.訂單)
                    .WithMany(p => p.OrderOrderings)
                    .HasForeignKey(d => d.訂單id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_訂單-結帳內容_訂單-個資");
            });

            modelBuilder.Entity<Orderdetails訂單資料詳細>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("orderdetails_訂單資料詳細");

                entity.Property(e => e.Is買方取消).HasColumnName("is買方取消");

                entity.Property(e => e.Is賣方取消).HasColumnName("is賣方取消");

                entity.Property(e => e.下單id)
                    .HasMaxLength(50)
                    .HasColumnName("下單ID");

                entity.Property(e => e.付款id)
                    .HasMaxLength(50)
                    .HasColumnName("付款ID");

                entity.Property(e => e.付款方式).HasMaxLength(50);

                entity.Property(e => e.停用日期).HasColumnType("datetime");

                entity.Property(e => e.創建時間).HasColumnType("datetime");

                entity.Property(e => e.商品id快照)
                    .HasMaxLength(50)
                    .HasColumnName("商品ID快照");

                entity.Property(e => e.商品主圖快照).HasMaxLength(1000);

                entity.Property(e => e.商品名稱快照).HasMaxLength(50);

                entity.Property(e => e.商品地址快照).HasMaxLength(200);

                entity.Property(e => e.啟用日期).HasColumnType("datetime");

                entity.Property(e => e.子項名稱快照).HasMaxLength(50);

                entity.Property(e => e.折扣代碼).HasMaxLength(50);

                entity.Property(e => e.訂單id)
                    .HasMaxLength(50)
                    .HasColumnName("訂單ID");

                entity.Property(e => e.訂單留言).HasMaxLength(300);

                entity.Property(e => e.賣方id)
                    .HasMaxLength(50)
                    .HasColumnName("賣方ID");

                entity.Property(e => e.賣方暱稱).HasMaxLength(50);
            });

            modelBuilder.Entity<Sub>(entity =>
            {
                entity.HasKey(e => e.子項id)
                    .HasName("PK_子項");

                entity.ToTable("Sub");

                entity.Property(e => e.子項id)
                    .HasMaxLength(50)
                    .HasColumnName("子項ID")
                    .HasComment("格式：sub-20220630123015-555555");

                entity.Property(e => e.Is刪除).HasColumnName("is刪除");

                entity.Property(e => e.Is啟用).HasColumnName("is啟用");

                entity.Property(e => e.創建時間).HasColumnType("datetime");

                entity.Property(e => e.商品id)
                    .HasMaxLength(50)
                    .HasColumnName("商品ID")
                    .HasComment("格式：item-20220630123015-555555");

                entity.Property(e => e.子項主圖)
                    .HasMaxLength(200)
                    .HasComment("一個網址");

                entity.Property(e => e.子項名稱).HasMaxLength(50);

                entity.Property(e => e.子項簡述).HasMaxLength(50);

                entity.HasOne(d => d.商品)
                    .WithMany(p => p.Subs)
                    .HasForeignKey(d => d.商品id)
                    .HasConstraintName("FK_子項_商品");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.會員id)
                    .HasName("PK_會員");

                entity.Property(e => e.會員id)
                    .HasMaxLength(50)
                    .HasColumnName("會員ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Is刪除).HasColumnName("is刪除");

                entity.Property(e => e.Is啟用).HasColumnName("is啟用");

                entity.Property(e => e.備註).HasMaxLength(1000);

                entity.Property(e => e.地址).HasMaxLength(50);

                entity.Property(e => e.姓名).HasMaxLength(50);

                entity.Property(e => e.帳號權限).HasMaxLength(50);

                entity.Property(e => e.暱稱).HasMaxLength(50);

                entity.Property(e => e.會員密碼).HasMaxLength(100);

                entity.Property(e => e.會員帳號).HasMaxLength(50);

                entity.Property(e => e.註冊時間).HasColumnType("datetime");

                entity.Property(e => e.資料更新時間).HasColumnType("datetime");

                entity.Property(e => e.郵遞區號).HasComment("3碼");

                entity.Property(e => e.電話).HasMaxLength(10);

                entity.Property(e => e.頭像檔名).HasMaxLength(50);
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_1");

                entity.Property(e => e.會員id)
                    .HasMaxLength(50)
                    .HasColumnName("會員ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
