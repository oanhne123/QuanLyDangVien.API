using Microsoft.AspNetCore.Mvc;
using QuanLyDangVien.API.Data;
using QuanLyDangVien.API.Models;

namespace QuanLyDangVien.API.Controllers
{
    [Route("api/hosocamtinhdang")]
    [ApiController]
    public class HoSoCamTinhDangController : BaseController<HoSoCamTinhDang>
    {
        public HoSoCamTinhDangController(AppDbContext context) : base(context) { }
    }
}