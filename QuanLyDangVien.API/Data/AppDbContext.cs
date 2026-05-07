using Microsoft.EntityFrameworkCore;
using QuanLyDangVien.Api.Models;
using QuanLyDangVien.API.Models;
using System.Reflection.Emit;

namespace QuanLyDangVien.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DanToc> tbDanToc { get; set; }
        public DbSet<Lop> tbLop { get; set; }
        public DbSet<DangVien> tbDangVien { get; set; }

        public DbSet<HoSoCamTinhDang> tbHoSoCamTinhDang { get; set; }
        public DbSet<LichSuCamTinhDang> tbLichSuCamTinhDang { get; set; }

        public DbSet<TaiKhoan> tbTaiKhoan { get; set; }
        public DbSet<BanGhiDangPhi> tbBanGhiDangPhi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ép EF Core sử dụng đúng tên bảng trong SQL Server
            modelBuilder.Entity<DanToc>().ToTable("tbDanToc");
            modelBuilder.Entity<Lop>().ToTable("tbLop");
            modelBuilder.Entity<DangVien>().ToTable("tbDangVien");
            modelBuilder.Entity<HoSoCamTinhDang>().ToTable("tbHoSoCamTinhDang");
            modelBuilder.Entity<LichSuCamTinhDang>().ToTable("tbLichSuCamTinhDang");
            modelBuilder.Entity<TaiKhoan>().ToTable("TaiKhoan");
            modelBuilder.Entity<BanGhiDangPhi>().ToTable("BanGhiDangPhi");




        }
    }
}