using Microsoft.AspNetCore.Mvc;
using QUANLYVANHOA.Core.Enums;
using QUANLYVANHOA.Interfaces.DanhMuc;
using QUANLYVANHOA.Interfaces.HeThong;
using QUANLYVANHOA.Models.HeThong;
using System.Text.RegularExpressions;

namespace QUANLYVANHOA.Controllers.HeThong
{
    [Route("api/v1/HeThongCanBo/")]
    [ApiController]
    public class HeThongCanBoController : ControllerBase
    {
        private readonly ICanBoRepository _canBoRepository;
        private readonly IDanhMucCoQuanDonViRepository _coQuanRepository;
        private readonly IPhanQuyenRepository _phanQuyenRepository;


        public HeThongCanBoController(ICanBoRepository canBoRepository , IDanhMucCoQuanDonViRepository coQuanRepository, IPhanQuyenRepository phanQuyenRepository)
        {
            _canBoRepository = canBoRepository;
            _coQuanRepository = coQuanRepository;
            _phanQuyenRepository = phanQuyenRepository;
        }
        [CustomAuthorize(QuyenEnums.Xem /*| Quyen.Them |Quyen.Sua | Quyen.Xoa*/, ChucNangEnums.QuanLyNguoiDung)]
        [HttpGet("DanhSachCanBo")]
        public async Task<IActionResult> GetListPaging(string? TenCanBoOrTenNguoiDung,int? CoQuanID,  int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrWhiteSpace(TenCanBoOrTenNguoiDung))
            {
                TenCanBoOrTenNguoiDung = TenCanBoOrTenNguoiDung.Trim();
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


            var (canBoList, totalRecords) = await _canBoRepository.CanBoGetListPaging(TenCanBoOrTenNguoiDung, CoQuanID, pageNumber, pageSize);
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (!canBoList.Any())
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "No data available",
                    Data = canBoList
                });
            }

            return Ok(new
            {
                Data = canBoList,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            });
        }



        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyNguoiDung)]
        [HttpGet("LayCanBoTheoID")]
        public async Task<IActionResult> GetByID(int staffId)
        {
            var officer = await _canBoRepository.CanBoGetByID(staffId);
            if (officer == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Id not found",
                    Data = officer
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Get information successfully",
                Data = officer
            });
        }


        [CustomAuthorize(QuyenEnums.Them, ChucNangEnums.QuanLyNguoiDung)]
        [HttpPost("ThemMoiCanBo")]
        public async Task<IActionResult> CanBoAdd([FromBody] CanBoAddModel model)
        {
            if (string.IsNullOrWhiteSpace(model.TenCanBo))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên Cán Bộ không được bỏ trống !."
                });
            }

            model.TenCanBo = model.TenCanBo.Trim();
            var existingCanBoName = await _canBoRepository.CanBoGetByName(model.TenCanBo);
            if (existingCanBoName != null)
            {
                return BadRequest(new Response { Status = 0, Message = "Tên cán bộ đã tồn tại vui lòng chọn tên cán bộ khác !" });
            }

            //model.MatKhau = "123456";
            
            //if (string.IsNullOrWhiteSpace(model.MatKhau) || model.MatKhau.Contains(" "))
            //{
            //    return BadRequest(new Response
            //    {
            //        Status = 0,
            //        Message = "Mật khẩu là bắt buộc và không được chứa khoảng trắng !"
            //    });
            //}

            if (model.TenCanBo.Length > 100)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên Cán Bộ không vượt quá 100 kí tự !."
                });
            }

            //if (model.MatKhau.Length > 100)
            //{
            //    return BadRequest(new Response
            //    {
            //        Status = 0,
            //        Message = "Mật khẩu không được vượt quá 100 kí tự."
            //    });
            //}

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Email yêu cầu bắt buộc !."
                });
            }

            // Validate email format
            if (!IsValidEmail(model.Email))
            {
                return BadRequest(new Response { Status = 0, Message = "Email không hợp lệ !." });
            }

            // Kiểm tra email đã tồn tại trong hệ thống bằng GetByEmailAsync
            var existingStaff = await _canBoRepository.CanBoGetByEmail(model.Email);
            if (existingStaff != null)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Email đã tồn tại vui lòng nhập Email khác !."
                });
            }

            var exitingCoQuan = await _coQuanRepository.DanhMucCoQuanGetByID(model.CoQuanID);
            if (exitingCoQuan == null)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Cơ Quan không tồn tại !."
                });
            }

            if (model.TrangThai <0 || model.TrangThai >2)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Trạng thái chỉ có giá trị là 0 : Nghỉ hưu | 1: Đang làm | 2: Chuyển công tác | 3: Nghỉ việc  !."
                });
            }

            if (model.GioiTinh < 0 || model.GioiTinh > 2)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Giới Tính chỉ có giá trị là 0 : Nữ | 1: Nam | 2: Khác !."
                });
            }


            List<int> invalidIds = new List<int>();
            if (model.DanhSachNhomPhanQuyenID != null)
            { 
                foreach (var id in model.DanhSachNhomPhanQuyenID)
                {
                    var nhomPhanQuyen = await _phanQuyenRepository.GetGroupByID(id);
                    if (nhomPhanQuyen == null)
                    {
                        invalidIds.Add(id);
                    }
                }
            }
            // If there are invalid IDs, return an error response
            if (invalidIds.Any())
            {
                return BadRequest($"Invalid NhomPhanQuyenID: {string.Join(", ", invalidIds)}");
            }


            int rowsAffected = await _canBoRepository.CanBoAdd(model);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while creating the user."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Thêm cán bộ thành công !."
            });
        }


        [CustomAuthorize(QuyenEnums.Sua, ChucNangEnums.QuanLyNguoiDung)]
        [HttpPost("SuaThongTinCanBo")]
        public async Task<IActionResult> CanBoUpdate([FromBody] CanBoUpdateModel model)
        {
            var existingUser = await _canBoRepository.CanBoGetByID(model.CanBoID);
            if (existingUser == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "User not found."
                });
            }


            if (string.IsNullOrWhiteSpace(model.TenCanBo))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên Cán Bộ không được bỏ trống !."
                });
            }

            model.TenCanBo = model.TenCanBo.Trim();
            var existingCanBoName = await _canBoRepository.CanBoGetByName(model.TenCanBo);
            if (existingCanBoName != null)
            {
                return BadRequest(new Response { Status = 0, Message = "Tên cán bộ đã tồn tại vui lòng chọn tên cán bộ khác !" });
            }

            if (model.TenCanBo.Length > 100)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên Cán Bộ không vượt quá 100 kí tự !."
                });
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Email yêu cầu bắt buộc !."
                });
            }

            // Validate email format
            if (!IsValidEmail(model.Email))
            {
                return BadRequest(new Response { Status = 0, Message = "Invalid email format." });
            }

            // Kiểm tra email đã tồn tại trong hệ thống bằng GetByEmailAsync
            var existingStaff = await _canBoRepository.CanBoGetByEmail(model.Email);
            if (existingStaff != null)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Email đã tồn tại vui lòng nhập Email khác !."
                });
            }

            var exitingCoQuan = await _coQuanRepository.DanhMucCoQuanGetByID(model.CoQuanID);
            if (exitingCoQuan == null)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Cơ Quan không tồn tại !."
                });
            }

            if (model.TrangThai < 0 || model.TrangThai > 2)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Trạng thái chỉ có giá trị là 0 : Nghỉ hưu | 1: Đang làm | 2: Chuyển công tác | 3: Nghỉ việc  !."
                });
            }

            if (model.GioiTinh < 0 || model.GioiTinh > 2)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Giới Tính chỉ có giá trị là 0 : Nữ | 1: Nam | 2: Khác !."
                });
            }

            List<int> invalidIds = new List<int>();
            if (model.DanhSachNhomPhanQuyenID != null)
            {
                foreach (var id in model.DanhSachNhomPhanQuyenID)
                {
                    var nhomPhanQuyen = await _phanQuyenRepository.GetGroupByID(id);
                    if (nhomPhanQuyen == null)
                    {
                        invalidIds.Add(id);
                    }
                }
            }
            // If there are invalid IDs, return an error response
            if (invalidIds.Any())
            {
                return BadRequest($"Invalid NhomPhanQuyenID: {string.Join(", ", invalidIds)}");
            }


            int rowsAffected = await _canBoRepository.CanBoUpdate(model);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while updating the user."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Thêm cán bộ thành công !."
            });
        }


        [CustomAuthorize(QuyenEnums.Xoa, ChucNangEnums.QuanLyNguoiDung)]
        [HttpPost("XoaThongTinCanBo")]
        public async Task<IActionResult> Delete(int canBoId)
        {
            var existingUser = await _canBoRepository.CanBoGetByID(canBoId);
            if (existingUser == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy người dùng !."
                });
            }

            int rowsAffected = await _canBoRepository.CanBoDelete(canBoId);
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
                Message = "Xóa người dùng thành công !."
            });
        }



        // Helper method to validate email format using regex
        private bool IsValidEmail(string email)
        {
            // Biểu thức chính quy phức tạp
            var emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            // Kiểm tra xem email có khớp với biểu thức chính quy hay không
            return Regex.IsMatch(email, emailRegex);
        }
    }
}
