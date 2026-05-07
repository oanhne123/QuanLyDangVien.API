using Microsoft.AspNetCore.Mvc;
using QuanLyDangVien.API.Data;
using QuanLyDangVien.API.Models;

namespace QuanLyDangVien.API.Controllers
{
    [Route("api/dangvien")] // Cố định đường dẫn thành chữ thường
    [ApiController]
    public class DangVienController : BaseController<DangVien>
    {
        public DangVienController(AppDbContext context) : base(context) { }
    }
}