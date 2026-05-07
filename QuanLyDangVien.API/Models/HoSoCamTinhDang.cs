using System.ComponentModel.DataAnnotations;

namespace QuanLyDangVien.API.Models
{
    public class HoSoCamTinhDang
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; } = string.Empty;

        public DateTime? NgaySinh { get; set; }

        public int? IdLop { get; set; }

        [StringLength(10)]
        public string? GioiTinh { get; set; }

        public int? IdDanToc { get; set; }

        [StringLength(50)]
        public string TrangThaiHienTai { get; set; } = "Đang theo dõi";

        public string? ChiBo { get; set; }  
    }
}