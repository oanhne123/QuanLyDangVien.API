using Microsoft.AspNetCore.Mvc;
using QuanLyDangVien.API.Data;
using QuanLyDangVien.API.Models;

namespace QuanLyDangVien.API.Controllers
{
    [Route("api/dantoc")]
    [ApiController]
    public class DanTocController : BaseController<DanToc>
    {
        public DanTocController(AppDbContext context) : base(context) { }
    }
}