namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopBanGiayDbContext : DbContext
    {
        public ShopBanGiayDbContext()
            : base("name=ShopBanGiay")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Giay> Giays { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<SlideNewProduct> SlideNewProducts { get; set; }
        public virtual DbSet<SlideSearchTrending> SlideSearchTrendings { get; set; }
        public virtual DbSet<SlideTopSeller> SlideTopSellers { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.maKH)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.applyType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.customerId)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.categoryId)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.discountId)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Giay>()
                .Property(e => e.type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.seoTitile)
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .Property(e => e.material)
                .IsUnicode(false);

            modelBuilder.Entity<Giay>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.Giay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SlideNewProduct>()
                .Property(e => e.shoeId)
                .IsUnicode(false);

            modelBuilder.Entity<SlideSearchTrending>()
                .Property(e => e.shoeId)
                .IsUnicode(false);

            modelBuilder.Entity<SlideTopSeller>()
                .Property(e => e.shoeId)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.Giays)
                .WithRequired(e => e.TheLoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.TinTuc)
                .WillCascadeOnDelete(false);
        }
    }
}
