namespace QuanLyDangVien.API.Models
{
    public class DangVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string? QueQuan { get; set; }
        public int? IdDanToc { get; set; }
        public int? IdLop { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgayVaoDang { get; set; }
        public DateTime? NgayChinhThuc { get; set; }

        // Các cột mã số, quyết định (kiểu String)
        public string? SoTheDang { get; set; }
        public string? CT_DB { get; set; }
        public string? CB_HSPT { get; set; }
        public string? SoQDKetNap { get; set; }
        public string? SoQDCDCT { get; set; }
         public string? ChiBo   { get; set; }   
    }
}