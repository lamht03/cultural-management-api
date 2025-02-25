using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QUANLYVANHOA.Core.Enums;
using QUANLYVANHOA.Interfaces.DichVu;
using QUANLYVANHOA.Interfaces.HeThong;
using QUANLYVANHOA.Models;
using QUANLYVANHOA.Models.HeThong;
using QUANLYVANHOA.Repositories;
using QUANLYVANHOA.Services;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QUANLYVANHOA.Controllers.HeThong
{
    [Route("api/v1/HeThongNguoiDung/")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungRepository _userRepository;
        private readonly IPhanQuyenRepository _permissionManagementRepository;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly ICanBoRepository _canBoRepository;

        public NguoiDungController(INguoiDungRepository userRepository, IPhanQuyenRepository userInGroupRepository, IUserService userService, IEmailService emailService, ICanBoRepository canBoRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
            _permissionManagementRepository = userInGroupRepository;
            _emailService = emailService;
            _canBoRepository = canBoRepository;
        }

        [CustomAuthorize(QuyenEnums.Xem /*| Quyen.Them |Quyen.Sua | Quyen.Xoa*/, ChucNangEnums.QuanLyNguoiDung)]
        [HttpGet("DanhSachNguoiDung")]
        public async Task<IActionResult> GetAll(string? userName, int pageNumber = 1, int pageSize = 20)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                userName = userName.Trim();
            }

            if (pageNumber <= 0)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Invalid page number. Page number must be greater than 0."
                });
            }

            if (pageSize <= 0 || pageSize > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Invalid page size. Page size must be between 1 and 50."
                });
            }

            var (users, totalRecords) = await _userRepository.LayDanhSachPhanTrang(userName, pageNumber, pageSize);
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (!users.Any())
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "No data available",
                    Data = users
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Get information successfully",
                Data = users,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            });
        }


        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyNguoiDung)]
        [HttpGet("TimKiemNguoiDungTheoID")]
        public async Task<IActionResult> GetByID(int userId)
        {
            var user = await _userRepository.LayTheoID(userId);
            if (user == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Id not found",
                    Data = user
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Get information successfully",
                Data = user
            });
        }


        //[CustomAuthorize(Quyen.Them, "Quản lý người dùng")]
        //[HttpPost("ThemTaiKhoanNguoiDung")]
        //public async Task<IActionResult> Create([FromBody] NguoiDungInsertModel user)
        //{
        //    if (string.IsNullOrWhiteSpace(user.TenNguoiDung))
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Invalid username. The username username is required."
        //        });
        //    }

        //    var existingUserName = await _userRepository.LayDanhSachPhanTrang(user.TenNguoiDung, 1, 20);
        //    if (existingUserName.Item1.Any())
        //    {
        //        return BadRequest(new Response { Status = 0, Message = "Username already exists. Please choose a different username." });
        //    }

        //    if (string.IsNullOrWhiteSpace(user.MatKhau) || user.MatKhau.Contains(" "))
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Invalid password. The password must not contain spaces and password is required."
        //        });
        //    }

        //    if (user.TenNguoiDung.Length > 50)
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Username cannot exceed 20 characters."
        //        });
        //    }

        //    if (user.MatKhau.Length > 100)
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Password cannot exceed 64 characters."
        //        });
        //    }

        //    if (string.IsNullOrWhiteSpace(user.Email))
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Email is required."
        //        });
        //    }

        //    if (user.GhiChu.Length > 100)
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Note cannot exceed 100 characters."
        //        });
        //    }

        //    int rowsAffected = await _userRepository.TaoNguoiDungMoi(user);
        //    if (rowsAffected == 0)
        //    {
        //        return StatusCode(500, new Response
        //        {
        //            Status = 0,
        //            Message = "An error occurred while creating the user."
        //        });
        //    }

        //    return Ok(new Response
        //    {
        //        Status = 1,
        //        Message = "User added successfully."
        //    });
        //}


        //[CustomAuthorize(Quyen.Sua, "Quản lý người dùng")]
        //[HttpPost("CapNhatThongTinTaiKhoanNguoiDung")]
        //public async Task<IActionResult> Update([FromBody] NguoiDungUpdateModel user)
        //{

        //    var existingUser = await _userRepository.LayTheoID(user.NguoiDungID);
        //    if (existingUser == null)
        //    {
        //        return Ok(new Response
        //        {
        //            Status = 0,
        //            Message = "User not found."
        //        });
        //    }

        //    if (existingUser.TenNguoiDung != user.TenNguoiDung)
        //    {
        //        var existingUserName = await _userRepository.LayDanhSachPhanTrang(user.TenNguoiDung, 1, 20);
        //        if (existingUserName.Item1.Any())
        //        {
        //            return BadRequest(new Response { Status = 0, Message = "Username already exists. Please choose a different username." });
        //        }
        //    }


        //    if (user.TenNguoiDung.Contains(" ") || user.TenNguoiDung.Length > 50)
        //    {
        //        return BadRequest(new Response { Status = 0, Message = "Invalid password. Password must not contain spaces and must be less than 100 characters." });
        //    }

        //    if (user.MatKhau.Contains(" ") || user.MatKhau.Length > 100)
        //    {
        //        return BadRequest(new Response { Status = 0, Message = "Invalid password. Password must not contain spaces and must be less than 100 characters." });
        //    }

        //    if (string.IsNullOrWhiteSpace(user.TenNguoiDung) || user.TenNguoiDung.Contains(" "))
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Invalid username. The username must not contain spaces and username is required."
        //        });
        //    }

        //    if (string.IsNullOrWhiteSpace(user.MatKhau) || user.MatKhau.Contains(" "))
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Invalid password. The password must not contain spaces and password is required."
        //        });
        //    }

        //    if (user.TenNguoiDung.Length > 50)
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Username cannot exceed 20 characters."
        //        });
        //    }

        //    if (user.MatKhau.Length > 100)
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Password cannot exceed 64 characters."
        //        });
        //    }

        //    // Validation for other fields
        //    if (string.IsNullOrWhiteSpace(user.Email))
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Email is required."
        //        });
        //    }

        //    if (user.GhiChu.Length > 100)
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 0,
        //            Message = "Note cannot exceed 100 characters."
        //        });
        //    }

        //    int rowsAffected = await _userRepository.SuaThongTinNguoiDung(user);
        //    if (rowsAffected == 0)
        //    {
        //        return StatusCode(500, new Response
        //        {
        //            Status = 0,
        //            Message = "An error occurred while creating the user."
        //        });
        //    }

        //    return Ok(new Response
        //    {
        //        Status = 1,
        //        Message = "User updated successfully."
        //    });
        //}


        [CustomAuthorize(QuyenEnums.Xoa, ChucNangEnums.QuanLyNguoiDung)]
        [HttpPost("XoaTaiKhoanNguoiDung")]
        public async Task<IActionResult> Delete(int userId)
        {
            var existingUser = await _userRepository.LayTheoID(userId);
            if (existingUser == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "User not found."
                });
            }

            int rowsAffected = await _userRepository.XoaThongTinNguoiDung(userId);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while deleting the user."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "User deleted successfully."
            });
        }

        [CustomAuthorize(QuyenEnums.Sua, ChucNangEnums.QuanLyNguoiDung)]
        [HttpPost("DatLaiMatKhau")]
        public async Task<IActionResult> ResetPassword(int userId)
        {
            var existingUser = await _userRepository.LayTheoID(userId);
            if (existingUser == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "User not found."
                });
            }

            var rowsAffected = await _userRepository.ResetPassword(userId);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while deleting the user."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "User has successfully reset password! !."
            });
        }

        [HttpPost("DoiMatKhau")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var existingUser = await _userRepository.LayTheoID(model.NguoiDungID);
            if (existingUser == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "User not found."
                });
            }

            if (string.IsNullOrWhiteSpace(model.MatKhauCu) || string.IsNullOrWhiteSpace(model.MatKhauMoi) || string.IsNullOrWhiteSpace(model.XacNhanMatKhauMoi))
            {
                return BadRequest(new { Status = 0, Message = "Mật khẩu cũ, mật khẩu mới, xác nhận mật khẩu mới là bắt buộc !." });
            }

            if (model.MatKhauMoi.Length < 6)
            {
                return BadRequest(new { Status = 0, Message = "Mật khẩu mới phải có ít nhất 6 kí tự !." });
            }
            if (model.MatKhauMoi.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Mật khẩu mới không được vượt quá 100 kí tự !." });
            }

            if (model.MatKhauCu == model.MatKhauMoi)
            {
                return BadRequest(new { Status = 0, Message = "Mật khẩu mới phải khác mật khẩu cũ !." });
            }

            if (model.MatKhauMoi.Contains(" "))
            {
                return BadRequest(new { Status = 0, Message = "Mật khẩu mới không được chứa khoảng trắng." });
            }

            if(existingUser.MatKhau != model.MatKhauCu)
            {
                return BadRequest(new { Status = 0, Message = "Bạn đã nhập sai mật khẩu cũ!." });
            }

            if (model.MatKhauMoi != model.XacNhanMatKhauMoi)
            {
                return BadRequest("Mật khẩu mới và xác nhận mật khẩu mới không khớp với nhau !.");
            }

            int result = await _userRepository.ChangePassword(model.NguoiDungID, model.MatKhauCu, model.MatKhauMoi);
            return Ok(new { Status = 1, Message = "Mật khẩu thay đổi thành công !." });
        }


        [HttpPost("QuenMatKhau")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest(new { Status = 0, Message = "Email không được để trống!" });
            }

            var existingUser = await _canBoRepository.CanBoGetByEmail(email);
            if (existingUser == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy tài khoản với email này!"
                });
            }
            string newPassword = await _userRepository.ResetPasswordByEmail(email);
            // Gửi email
            await _emailService.SendEmailAsync(email, "Reset Password", $"Mật khẩu mới của bạn là: {newPassword}");

            return Ok(new { Status = 1, Message = "Mật khẩu mới đã được gửi đến email của bạn!" });
        }




        [HttpPost("DangNhap")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Check if the model is null
            if (model == null)
            {
                return BadRequest(new Response { Status = 0, Message = "Invalid request. Login data is missing." });
            }

            // Check for null or empty username and password
            if (string.IsNullOrEmpty(model.TenNguoiDung) || string.IsNullOrEmpty(model.MatKhau))
            {
                return BadRequest(new Response { Status = 0, Message = "Username and password are required." });
            }

            // Check for spaces within username
            if (model.TenNguoiDung.Contains(" "))
            {
                return BadRequest(new Response { Status = 0, Message = "Username cannot contain spaces." });
            }

            // Check for leading or trailing spaces in password
            if (model.MatKhau.Contains(" "))
            {
                return BadRequest(new Response { Status = 0, Message = "Invalid username or password" });
            }

            // Authenticate user
            var (isValid, token, refreshToken, message) = await _userService.AuthenticateUser(model.TenNguoiDung, model.MatKhau);

            if (!isValid)
            {
                return Unauthorized(new Response { Status = 0, Message = message });
            }

            // Return token if authentication is successful
            return Ok(new
            {
                Status = 1,
                Message = message,
                Token = token,
                RefreshToken = refreshToken
            });
        }



        [HttpPost("LamMoiToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest model)
        {
            if (string.IsNullOrEmpty(model.RefreshToken))
            {
                return BadRequest(new { message = "Refresh token is required." });
            }

            try
            {
                var (newToken, newRefreshToken) = await _userService.RefreshToken(model.RefreshToken);

                if (newToken == null || newRefreshToken == null)
                {
                    return Unauthorized(new Response { Status = 0, Message = "Invalid or expired refresh token." });
                }

                return Ok(new ResponseRefreshToken
                {
                    Status = 1,
                    Data = newToken,
                    Message = "Token refreshed successfully.",
                    RefreshToken = newRefreshToken
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while refreshing the token.", error = ex.Message });
            }
        }


        [HttpPost("DangXuat")]
        public async Task<IActionResult> Logout([FromBody] RefreshTokenRequest model)
        {
            if (string.IsNullOrEmpty(model.RefreshToken))
            {
                return BadRequest(new { message = "Refresh token is required." });
            }

            try
            {
                // Lấy session từ refresh token
                var session = await _userRepository.LayPhienDangNhapTheoRefreshToken(model.RefreshToken);

                if (session == null)
                {
                    return Unauthorized(new { message = "Invalid refresh token." });
                }

                // Vô hiệu hóa session (revoking session)
                await _userRepository.VoHieuHoaPhienDangNhap(session.PhienDangNhapID);

                return Ok(new { message = "Logout successful. Refresh token has been revoked." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while logging out.", error = ex.Message });
            }
        }

    }
}
