using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDangVien.Api.Models
{
    [Table("BanGhiDangPhi")]
    public class BanGhiDangPhi
    {
        [Key]
        public int Id { get; set; }

        public int Thang { get; set; }
        public int Nam { get; set; }

        // Lưu tên trực tiếp để truy xuất nhanh
        public string HoTenDangVien { get; set; } = "";
        public string TenLop { get; set; } = "";

        // Thêm đối tượng để phân loại (HSPT, CBĐH, CSNV, QDND...)
        public string DoiTuong { get; set; } = "";

        // Dữ liệu tiền bạc
        public int ThuNhap { get; set; }
        public int SoTienPhaiDong { get; set; }
        public int DaThuThangNay { get; set; }
        public int TruyThuThangTruoc { get; set; }

        // Lưu vết người tạo (Tên chi bộ thực hiện lưu)
        public string NguoiLap { get; set; } = "";
        public DateTime NgayLap { get; set; } = DateTime.Now;
    }
}