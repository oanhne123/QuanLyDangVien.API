using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyDangVien.Api.Models; // Đổi namespace cho khớp dự án của bạn
using QuanLyDangVien.API.Data;
using QuanLyDangVien.API.DTOs;

namespace QuanLyDangVien.API.Controllers
{
    [Route("api/banghidangphi")]
    [ApiController]
    public class BanGhiDangPhiController : BaseController<BanGhiDangPhi>
    {
        public BanGhiDangPhiController(AppDbContext context) : base(context) { }

        // ========================================================
        // HÀM 1: LƯU ĐẶC THÙ (Xóa cũ -> Thêm mới)
        // ========================================================
        [HttpPost("luu-thang")]
        public async Task<ActionResult<ApiResponse<bool>>> LuuDangPhiThang([FromBody] List<BanGhiDangPhi> danhSach)
        {
            if (danhSach == null || !danhSach.Any())
                return BadRequest(ApiResponse<bool>.Fail("Không có dữ liệu để lưu."));

            var first = danhSach.First();

            try
            {
                // 1. Tìm và xóa dữ liệu cũ của Tháng/Năm/Chi Bộ đó
                var oldData = await _dbSet.Where(x =>
                    x.Thang == first.Thang &&
                    x.Nam == first.Nam &&
                    x.NguoiLap == first.NguoiLap).ToListAsync();

                if (oldData.Any())
                {
                    _dbSet.RemoveRange(oldData);
                }

                // 2. Lưu danh sách mới
                await _dbSet.AddRangeAsync(danhSach);
                await _context.SaveChangesAsync();

                return Ok(ApiResponse<bool>.Ok(true, $"Đã lưu thành công Đảng phí tháng {first.Thang}/{first.Nam}!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.Fail($"Lỗi khi lưu: {ex.Message}"));
            }
        }

        // ========================================================
        // HÀM 2: LỌC DỮ LIỆU RIÊNG CHO LỚP XEM
        // ========================================================
        [HttpGet("xem-theo-lop")]
        public async Task<ActionResult<ApiResponse<List<BanGhiDangPhi>>>> GetTheoLop(int thang, int nam, string tenLop)
        {
            try
            {
                var data = await _dbSet
                    .Where(x => x.Thang == thang && x.Nam == nam && x.TenLop.ToLower() == tenLop.ToLower())
                    .ToListAsync();

                return Ok(ApiResponse<List<BanGhiDangPhi>>.Ok(data, "Tải dữ liệu thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<BanGhiDangPhi>>.Fail($"Lỗi: {ex.Message}"));
            }
        }
    }
}