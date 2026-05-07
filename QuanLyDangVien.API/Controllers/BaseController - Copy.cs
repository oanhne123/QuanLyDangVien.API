using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuanLyDangVien.Api.Models;
using QuanLyDangVien.API.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuanLyDangVien.Api.Controllers
{
    // 1. Dùng Record đẻ hứng dữ liệu cực gọn (Thay thế cho các class DTO rườm rà)
    public record LoginRequest(string Username, string Password);

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            // 2. Tìm User trong Database
            var user = _db.tbTaiKhoan.FirstOrDefault(u => u.Username == req.Username && u.Password == req.Password);

            if (user == null) return Unauthorized("Sai tài khoản hoặc mật khẩu!");

            // 3. Tạo Token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username), // Lưu Username để Blazor gọi ra
                new Claim("FullName", user.HoTen)          // Lưu thêm tên thật
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7), // Cho phép login 7 ngày cho khỏe
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // Trả về đúng 1 chuỗi Token (không cần class LoginResponse)
            return Ok(new { Token = tokenString });
        }
    }
}