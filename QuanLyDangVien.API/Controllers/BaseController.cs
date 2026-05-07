using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyDangVien.API.Data;
using QuanLyDangVien.API.DTOs;

namespace QuanLyDangVien.API.Controllers
{
    // Ràng buộc T : class nghĩa là T có thể là bất kỳ class Model nào (DangVien, Lop, DanToc...)
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseController(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // Tự động nhận diện bảng tương ứng
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<T>>>> GetAll()
        {
            var data = await _dbSet.ToListAsync();
            return Ok(ApiResponse<List<T>>.Ok(data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<T>>> GetById(int id)
        {
            // FindAsync tự động tìm theo khóa chính (Primary Key) của bảng
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return NotFound(ApiResponse<T>.Fail("Không tìm thấy dữ liệu."));

            return Ok(ApiResponse<T>.Ok(entity));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<T>>> Create([FromBody] T entity)
        {
            try
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                return Ok(ApiResponse<T>.Ok(entity, "Thêm mới thành công!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<T>.Fail($"Lỗi khi thêm: {ex.Message}"));
            }
        }




        // Thêm hàm này vào BaseController.cs trong project API
        [HttpPost("bulk")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateRange([FromBody] List<T> entities)
        {
            try
            {
                if (entities == null || !entities.Any())
                    return BadRequest(ApiResponse<bool>.Fail("Danh sách trống, không có gì để lưu."));

                // Entity Framework hỗ trợ hàm AddRange cực nhanh
                await _dbSet.AddRangeAsync(entities);
                await _context.SaveChangesAsync();

                return Ok(ApiResponse<bool>.Ok(true, $"Đã lưu thành công {entities.Count} dòng vào cơ sở dữ liệu!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.Fail($"Lỗi lưu hàng loạt: {ex.Message}"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<T>>> Update(int id, [FromBody] T entity)
        {
            // Tự động kiểm tra ID khớp nhau mà không cần Interface
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                var entityId = (int)idProperty.GetValue(entity)!;
                if (id != entityId) return BadRequest(ApiResponse<T>.Fail("ID không khớp với dữ liệu."));
            }

            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(ApiResponse<T>.Ok(entity, "Cập nhật thành công!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<T>.Fail($"Lỗi khi cập nhật: {ex.Message}"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return NotFound(ApiResponse<bool>.Fail("Không tìm thấy để xóa."));

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return Ok(ApiResponse<bool>.Ok(true, "Xóa thành công!"));
        }
    }
}