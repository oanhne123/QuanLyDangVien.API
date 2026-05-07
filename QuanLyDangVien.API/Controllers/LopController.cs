using Microsoft.AspNetCore.Mvc;
using QuanLyDangVien.API.Data;
using QuanLyDangVien.API.Models;

namespace QuanLyDangVien.API.Controllers
{
    [Route("api/lop")]
    [ApiController]
    public class LopController : BaseController<Lop>
    {
        public LopController(AppDbContext context) : base(context) { }
    }
}