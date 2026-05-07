namespace QuanLyDangVien.API.Models
{
    public class Lop
    {
        public int Id { get; set; }
        public string TenLop { get; set; } = string.Empty;
        public string? KhoaHoc { get; set; }

        public string? ChiBo { get; set;}
    }
}