﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using QUANLYVANHOA.Interfaces.HeThong;
using QUANLYVANHOA.Interfaces.DichVu;

public class UserService : IUserService
{
    private readonly INguoiDungRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UserService(INguoiDungRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<(bool IsValid, string Token, string RefreshToken, string Message)> AuthenticateUser(string userName, string password)
    {
        var user = await _userRepository.DangNhap(userName, password);

        if (user == null)
        {
            return (false, null, null, "Invalid username or password.");
        }

        // Lấy danh sách các quyền của người dùng từ cơ sở dữ liệu
        var permissions = CustomAuthorizeAttribute.GetAllUserFunctionsAndPermissions(userName);

        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, user.GhiChu ?? "Can I call you baby ! Can you be my friend ! Can you be my lover up until the very end ! Let me show you love ! Don't pretend ! Stick by my side even when the world is givin'in, YEAH\n" +
                "____                | LÂM NO LOVE |                               ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥\n" +
                "|  |\n" +
                "|  |                     //\\           ______             ______        ♥♥     ♥♥      \n" +
                "|  |                   // __ \\         |  \\\\           ///|  |       ♥♥♥♥   ♥♥♥♥     \n" +
                "|  |                 //  /  \\ \\       |  |\\\\         /// |  |      ♥♥♥♥♥♥ ♥♥♥♥♥♥    \n" +
                "|  |                    / __ \\         |  | \\\\       ///  |  |       ♥♥♥♥♥♥♥♥♥♥♥     \n" +
                "|  |                   / / \\ \\        |  |  \\\\     ///   |  |        ♥♥♥♥♥♥♥♥♥      \n" +
                "|  |                  / /___\\ \\       |  |   \\\\   ///    |  |         ♥♥♥♥♥♥♥       \n" +
                "|  |___________      / /     \\ \\      |  |    \\\\ ///     |  |           ♥♥♥         \n" +
                "|_____________/     /_/       \\_\\     |__|     \\\\//      |__|            ♥          \n"),

                //new Claim(ClaimTypes.Role, user.GhiChu ?? "Can I call you baby ! Can you be my friend ! Can you be my lover up until the very end ! Let me show you love ! Don't pretend ! Stick by my side even when the world is givin'in, YEAH\n" +
                //"____                | LÂM NO LOVE |                               ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥\n" +
                //"|  |\n" +
                //"|  |                    //  \\           ______          ______       ♥♥     ♥♥\n" +
                //"|  |                   // __ \\         |  \\\\           ///|  |      ♥♥♥♥   ♥♥♥♥\n" +
                //"|  |                  // /  \\ \\        |  |\\\\         /// |  |     ♥♥♥♥♥♥ ♥♥♥♥♥♥\n" +
                //"|  |                    / __ \\         |  | \\\\       ///  |  |      ♥♥♥♥♥♥♥♥♥♥♥\n" +
                //"|  |                   / /  \\ \\        |  |  \\\\     ///   |  |       ♥♥♥♥♥♥♥♥♥\n" +
                //"|  |                  / /____\\ \\       |  |   \\\\   ///    |  |        ♥♥♥♥♥♥♥\n" +
                //"|  |___________      / /      \\ \\      |  |    \\\\ ///     |  |          ♥♥♥\n" +
                //"|_____________/     /_/        \\_\\     |__|     \\\\//      |__|           ♥\n"),


                new Claim("NguoiDungID", JsonConvert.SerializeObject(user.NguoiDungID)),
                new Claim("MatKhau", JsonConvert.SerializeObject("IfYouWantToConnectYouNeedToBecomeAProfessionalProgrammer")),
                new Claim("FunctionsAndPermissions", JsonConvert.SerializeObject(permissions)) // Lưu các quyền của từng chức năng vào JWT
            }),
            Expires = DateTime.UtcNow.AddSeconds(double.Parse(jwtSettings["ExpirySeconds"])),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        // Tạo Refresh Token
        var refreshToken = GenerateRefreshToken();
        //var refreshTokenExpiry = DateTime.UtcNow.AddSeconds(5); // Refresh token có thời hạn giây
        var refreshTokenExpiry = DateTime.UtcNow.AddDays(7); // Refresh token có thời hạn 7 ngày
        // Gọi stored procedure để lưu session mới
        await _userRepository.TaoPhienDangNhap(user.NguoiDungID, refreshToken, refreshTokenExpiry);
        return (true, token, refreshToken, "Login successful.");
    }

    public async Task<(string Token, string RefreshToken)> RefreshToken(string refreshToken)
    {
        // Lấy session của người dùng dựa trên refresh token
        var session = await _userRepository.LayPhienDangNhapTheoRefreshToken(refreshToken);

        // Kiểm tra xem session có tồn tại và refresh token có hết hạn hay không
        if (session == null || session.ExpiryDate <= DateTime.UtcNow || session.IsRevoked)
        {
            return (null, null); // Refresh token không hợp lệ hoặc đã hết hạn
        }

        // Lấy thông tin người dùng từ database
        var user = await _userRepository.LayTheoID(session.NguoiDungID);
        if (user == null)
        {
            return (null, null); // Người dùng không tồn tại
        }

        // Lấy các quyền của người dùng từ hệ thống
        var permissions = CustomAuthorizeAttribute.GetAllUserFunctionsAndPermissions(user.TenNguoiDung);

        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

        // Tạo lại JWT token (Access Token)
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.TenNguoiDung),
                new Claim(ClaimTypes.Role, user.GhiChu ?? "Can I call you baby ! Can you be my friend ! Can you be my lover up until the very end ! Let me show you love ! Don't pretend ! Stick by my side even when the world is givin'in, YEAH\n" +
                "____                | LÂM NO LOVE |                               ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥\n" +
                "|  |\n" +
                "|  |                     //\\           ______             ______        ♥♥     ♥♥      \n" +
                "|  |                   // __ \\         |  \\\\           ///|  |       ♥♥♥♥   ♥♥♥♥     \n" +
                "|  |                 //  /  \\ \\       |  |\\\\         /// |  |      ♥♥♥♥♥♥ ♥♥♥♥♥♥    \n" +
                "|  |                    / __ \\         |  | \\\\       ///  |  |       ♥♥♥♥♥♥♥♥♥♥♥     \n" +
                "|  |                   / / \\ \\        |  |  \\\\     ///   |  |        ♥♥♥♥♥♥♥♥♥      \n" +
                "|  |                  / /___\\ \\       |  |   \\\\   ///    |  |         ♥♥♥♥♥♥♥       \n" +
                "|  |___________      / /     \\ \\      |  |    \\\\ ///     |  |           ♥♥♥         \n" +
                "|_____________/     /_/       \\_\\     |__|     \\\\//      |__|            ♥          \n"),

                //new Claim(ClaimTypes.Role, user.GhiChu ?? "Can I call you baby ! Can you be my friend ! Can you be my lover up until the very end ! Let me show you love ! Don't pretend ! Stick by my side even when the world is givin'in, YEAH\n" +
                //"____                | LÂM NO LOVE |                               ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥\n" +
                //"|  |\n" +
                //"|  |                    //  \\           ______          ______       ♥♥     ♥♥\n" +
                //"|  |                   // __ \\         |  \\\\           ///|  |      ♥♥♥♥   ♥♥♥♥\n" +
                //"|  |                  // /  \\ \\        |  |\\\\         /// |  |     ♥♥♥♥♥♥ ♥♥♥♥♥♥\n" +
                //"|  |                    / __ \\         |  | \\\\       ///  |  |      ♥♥♥♥♥♥♥♥♥♥♥\n" +
                //"|  |                   / /  \\ \\        |  |  \\\\     ///   |  |       ♥♥♥♥♥♥♥♥♥\n" +
                //"|  |                  / /____\\ \\       |  |   \\\\   ///    |  |        ♥♥♥♥♥♥♥\n" +
                //"|  |___________      / /      \\ \\      |  |    \\\\ ///     |  |          ♥♥♥\n" +
                //"|_____________/     /_/        \\_\\     |__|     \\\\//      |__|           ♥\n"),


                new Claim("NguoiDungID", JsonConvert.SerializeObject(user.NguoiDungID)),
                new Claim("MatKhau", JsonConvert.SerializeObject("IfYouWantToConnectYouNeedToBecomeAProfessionalProgrammer")),
                new Claim("FunctionsAndPermissions", JsonConvert.SerializeObject(permissions)) // Lưu các quyền của từng chức năng vào JWT
            }),
            Expires = DateTime.UtcNow.AddSeconds(double.Parse(jwtSettings["ExpirySeconds"])),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var newToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        // Tạo refresh token mới
        var newRefreshToken = GenerateRefreshToken();

        // Cập nhật refresh token và thời gian hết hạn mới vào cơ sở dữ liệu
        await _userRepository.CapNhatRefreshToken(session.PhienDangNhapID, newRefreshToken, DateTime.UtcNow.AddDays(7));

        return (newToken, newRefreshToken); // Trả về access token và refresh token mới
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }


    public int? GetUserIdFromToken(string token)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out SecurityToken validatedToken);

            var userIdClaim = principal.FindFirst("NguoiDungID");
            if (userIdClaim != null)
            {
                return int.Parse(userIdClaim.Value);
            }
        }
        catch
        {
            // Token validation failed
            return null;
        }

        return null;
    }
}
