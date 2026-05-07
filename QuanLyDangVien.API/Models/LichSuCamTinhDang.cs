using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDangVien.API.Models
{
    public class LichSuCamTinhDang
    {
        [Key]
        public int Id { get; set; }

        public int? IdHoSo { get; set; }


        [StringLength(50)]
        public string? LoaiSuKien { get; set; } = string.Empty; // "CongNhan" hoặc "DuaRa"

        public DateTime? NgayThucHien { get; set; }

        [StringLength(50)]
        public string? SoQuyetDinh { get; set; }

        [StringLength(500)]
        public string? LyDo { get; set; }
    }
}