using Microsoft.AspNetCore.Mvc;
using QuanLyDangVien.API.Data;
using QuanLyDangVien.API.Models;

namespace QuanLyDangVien.API.Controllers
{
    [Route("api/lichsucamtinhdang")]
    [ApiController]
    public class LichSuCamTinhDangController : BaseController<LichSuCamTinhDang>
    {
        public LichSuCamTinhDangController(AppDbContext context) : base(context) { }
    }
}   