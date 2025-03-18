using Microsoft.AspNetCore.Mvc;
using QUANLYVANHOA.Core.Enums;
using QUANLYVANHOA.Interfaces.HeThong;
using QUANLYVANHOA.Models.HeThong;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QUANLYVANHOA.Controllers.HeThong
{
    [Route("api/v1/HeThongPhanQuyen/")]
    [ApiController]

    public class PhanQuyenController : ControllerBase
    {
        private readonly IPhanQuyenRepository _permissionManagement;
        private readonly INguoiDungRepository _userRepository;

        public PhanQuyenController(IPhanQuyenRepository permissionManagement, INguoiDungRepository userRepository)
        {
            _permissionManagement = permissionManagement;
            _userRepository = userRepository;
        }

        #region Controller of Function
        [HttpGet("DanhSachChucNang")]
        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> GetAllFunction(string? functionName, int pageNumber = 1, int pageSize = 20)
        {
            if (!string.IsNullOrWhiteSpace(functionName))
            {
                functionName = functionName.Trim();
            }

            if (pageNumber <= 0)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Page number phải lớn hơn 0 !"
                });
            }

            if (pageSize <= 0 || pageSize > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Page size phải nằm trong khoảng từ 1 đến 50 !"
                });
            }

            var (functions, totalRecords) = await _permissionManagement.GetAllFunction(functionName, pageNumber, pageSize);
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (!functions.Any())
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không có dữ liệu !",
                    Data = functions
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Lấy thông tin chức năng thành công !",
                Data = functions,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            });
        }


        [HttpGet("LayChucNangTheoID")]
        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> GetFunctionByID(int functionId)
        {
            var function = await _permissionManagement.GetFunctionByID(functionId);
            if (function == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy chức năng !",
                    Data = function
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Lấy thông tin Chức năng Thành công !",
                Data = function
            });
        }

        [CustomAuthorize(QuyenEnums.Them, ChucNangEnums.QuanLyUyQuyen)]
        [HttpPost("ThemMoiChucNang")]
        public async Task<IActionResult> CreateFunction([FromBody] ChucNangInsertModel function)
        {
            if (!string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                function.TenChucNang = function.TenChucNang.Trim();
            }

            var existingFunction = await _permissionManagement.GetAllFunction(function.TenChucNang, 1, 20);
            {
                if (existingFunction.Item1.Any())
                {
                    return BadRequest(new Response
                    {
                        Status = 0,
                        Message = "Tên chức năng đã tồn tại !"
                    });
                }
            }

            if (string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên chức năng không được để trống !"
                });
            }

            if (function.TenChucNang.Length > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên chức năng không thể vượt quá 50 kí tự !"
                });
            }

            int rowsAffected = await _permissionManagement.CreateFunction(function);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "Có lỗi xảy ra khi thêm mới chức năng !"
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Thêm Chức Năng Thành Công !"
            });
        }

        [HttpPost("CapNhatThongTinChucNang")]
        [CustomAuthorize(QuyenEnums.Sua, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> UpdateFunction([FromBody] ChucNangUpdateModel function)
        {
            if (!string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                function.TenChucNang = function.TenChucNang.Trim();
            }

            var existingFunction = await _permissionManagement.GetFunctionByID(function.ChucNangID);
            if (existingFunction == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID chức năng !"
                });
            }


            var existingFunctionName = await _permissionManagement.GetAllFunction(function.TenChucNang, 1, 20);
            {
                if (existingFunctionName.Item1.Any())
                {
                    return BadRequest(new Response
                    {
                        Status = 0,
                        Message = "Tên Chức nănng đã tồn tại !"
                    });
                }
            }

            if (string.IsNullOrWhiteSpace(function.TenChucNang))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên chức năng không được để trống !"
                });
            }

            if (function.TenChucNang.Length > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên Chức năng không được vượt Quá 50 kí tự !"
                });
            }

            int rowsAffected = await _permissionManagement.UpdateFunction(function);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "Có lỗi xảy ra khi cập nhật thông tin chức năng !"
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Cập nhật thông tin chức năng thành công !"
            });
        }

        [HttpPost("XoaChucNang")]
        [CustomAuthorize(QuyenEnums.Xoa, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> DeleteFunction(int functionId)
        {
            var existingFunction = await _permissionManagement.GetFunctionByID(functionId);
            if (existingFunction == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID chức năng !"
                });
            }

            int rowsAffected = await _permissionManagement.DeleteFunction(functionId);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "Có lỗi xảy ra khi xóa chức năng !"
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Xóa Chức năng thành công !"
            });
        }

        #endregion

        #region Controller of Group
        [HttpGet("DanhSachNhomPhanQuyen")]
        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> GetAll(string? tenNhomPhanQuyen,int? canBoID, int pageNumber = 1, int pageSize = 20)
        {
            if (!string.IsNullOrWhiteSpace(tenNhomPhanQuyen))
            {
                tenNhomPhanQuyen = tenNhomPhanQuyen.Trim();
            }

            if (pageNumber <= 0)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Page number phải lớn hơn 0 !"
                });
            }

            if (pageSize <= 0 || pageSize > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Page size phải trong khoảng từ 0 đến 50"
                });
            }

            var (groups, totalRecords) = await _permissionManagement.GetAllGroup(tenNhomPhanQuyen, canBoID, pageNumber, pageSize);
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (!groups.Any())
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không có dữ liệu Nhóm Phân Quyền !",
                    Data = groups
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Lấy thông tin nhóm phân quyền thành công !",
                Data = groups,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            });
        }

        [HttpGet("LayNhomPhanQuyenTheoID")]
        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> GetGroupByID(int NhomPhanQuyenID)
        {
            var group = await _permissionManagement.GetGroupByID(NhomPhanQuyenID);
            if (group == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID của nhóm phân quyền",
                    Data = group
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Lấy thông tin nhóm phân quyền thành công !",
                Data = group
            });
        }

        [CustomAuthorize(QuyenEnums.Them, ChucNangEnums.QuanLyUyQuyen)]
        [HttpPost("ThemMoiNhomPhanQuyen")]
        public async Task<IActionResult> CreateGroup([FromBody] NhomPhanQuyenInsertModel group)
        {
            if (!string.IsNullOrWhiteSpace(group.TenNhomPhanQuyen))
            {
                group.TenNhomPhanQuyen = group.TenNhomPhanQuyen.Trim();
            }
            var existingAuthorizationGroup = await _permissionManagement.GetAllFunction(group.TenNhomPhanQuyen, 1, 20);
            {
                if (existingAuthorizationGroup.Item1.Any())
                {
                    return BadRequest(new Response
                    {
                        Status = 0,
                        Message = "Tên chức năng đã tồn tại !"
                    });
                }
            }


            if (string.IsNullOrWhiteSpace(group.TenNhomPhanQuyen))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên nhóm phân quyền không được để trống !"
                });
            }

            if (group.TenNhomPhanQuyen.Length > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên nhóm phân quyền không được vượt quá 50 kí tự !"
                });
            }

            int rowsAffected = await _permissionManagement.CreateGroup(group);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "Có lỗi xảy ra khi tạo nhóm phân quyền !"
                });
            }

            return CreatedAtAction(nameof(GetGroupByID), new Response
            {
                Status = 1,
                Message = "Tạo nhóm phân quyền thành công !"
            });
        }

        [HttpPost("CapNhatNhomPhanQuyen")]
        [CustomAuthorize(QuyenEnums.Sua, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> UpdateGroup([FromBody] NhomPhanQuyenUpdateModel group)
        {
            var existingGroup = await _permissionManagement.GetGroupByID(group.NhomPhanQuyenID);
            if (existingGroup == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID nhóm phân quyền cần cập nhật !"
                });
            }

            if (!string.IsNullOrWhiteSpace(group.TenNhomPhanQuyen))
            {
                group.TenNhomPhanQuyen = group.TenNhomPhanQuyen.Trim();
            }

            if (string.IsNullOrWhiteSpace(group.TenNhomPhanQuyen))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên nhóm phân quyền không được để trống !"
                });
            }

            if (group.TenNhomPhanQuyen.Length > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Tên nhóm phân quyền không được vượt quá 50 kí tự !"
                });
            }

            int rowsAffected = await _permissionManagement.UpdateGroup(group);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "Có lỗi xảy ra khi cập nhật nhóm phân quyền !"
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Nhóm phân quyền cập nhật thành công !"
            });
        }

        [HttpPost("XoaNhomPhanQuyen")]
        [CustomAuthorize(QuyenEnums.Xoa, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> DeleteGroup(int NhomPhanQuyenID)
        {
            var existingGroup = await _permissionManagement.GetGroupByID(NhomPhanQuyenID);
            if (existingGroup == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID nhóm phân quyền !"
                });
            }

            int rowsAffected = await _permissionManagement.DeleteGroup(NhomPhanQuyenID);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "Có lỗi xảy ra khi xóa nhóm phân quyền !"
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Xóa nhóm phân quyền thành công !"
            });
        }

        #endregion

        #region Controller of FunctionInGroup
        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyUyQuyen)]
        [HttpGet("LayDanhSachChucNangTrongNhomPhanQuyenTheoNhomPhanQuyenID")]
        public async Task<IActionResult> GetAllFunctionInGroup(int nhomPhanQuyenID)
        {
            var existingGroup = await _permissionManagement.GetGroupByID(nhomPhanQuyenID);
            if (existingGroup == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID nhóm phân quyền"
                });
            }

            var functionInGroups = await _permissionManagement.GetAllFunctionsAndPermissionsInAuthorizationGroup(nhomPhanQuyenID);
            if (!functionInGroups.Any())
            {
                return Ok(new { Status = 0, Message = "Không có chức năng nào trong nhóm phân quyền" });
            }

            return Ok(new { Status = 1, Message = "Lấy danh sách chức năng trong nhóm phân quyền thành công", Data = functionInGroups });
        }


        //[CustomAuthorize(1, "ManageAuthorization")]
        //[HttpGet("GetFunctionInGroupByNhomPhanQuyenID")]
        //public async Task<IActionResult> GetFunctionInGroupByNhomPhanQuyenID(int NhomPhanQuyenID)
        //{
        //    var functionInGroups = await _permissionManagement.GetFunctionInGroupByNhomPhanQuyenID(NhomPhanQuyenID);
        //    if (!functionInGroups.Any())
        //    {
        //        return Ok(new { Status = 0, Message = "No data found for this group" });
        //    }

        //    return Ok(new { Status = 1, Message = "Get information successfully", Data = functionInGroups });
        //}



        [HttpPost("ThemChucNangVaoNhomPhanQuyen")]
        [CustomAuthorize(QuyenEnums.Them, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> InsertFunctionInGroup([FromBody] NhomChucNangInsertModel model)
        {
            var existingFunction = await _permissionManagement.GetFunctionByID(model.ChucNangID);
            if (existingFunction == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID của chức năng muốn thêm vào nhóm phân quyền !"
                });
            }

            var existingAuthorizationGroup = await _permissionManagement.GetGroupByID(model.NhomPhanQuyenID);
            if (existingAuthorizationGroup == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID của Nhóm phân quyền muốn thêm chức năng mới vào !"
                });
            }

            if (model.NhomPhanQuyenID <= 0 || model.ChucNangID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Nhóm phân quyền ID và chức năng ID phải lớn hơn 0 !" });
            }

            var existingFunctionInGroup = await _permissionManagement.GetFunctionInGroupByFunctionID(model.ChucNangID);
            if (existingFunctionInGroup != null && existingFunctionInGroup.First().NhomPhanQuyenID == model.NhomPhanQuyenID)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Chức năng đã có trong nhóm"
                });
            }
            // Chuyển đổi quyền từ boolean sang bitmask
            int quyen = 0;
            if (model.Xem) quyen |= (int)QuyenEnums.Xem;
            if (model.Them) quyen |= (int)QuyenEnums.Them;
            if (model.Sua) quyen |= (int)QuyenEnums.Sua;
            if (model.Xoa) quyen |= (int)QuyenEnums.Xoa;


            var newFunctionInNhomPhanQuyenID = await _permissionManagement.AddFunctionToGroup(model.NhomPhanQuyenID, model.ChucNangID,quyen);
            return Ok(new { Status = 1, Message = "Thêm chức năng vào nhóm phân quyền thành công !" });
        }

        //[HttpPost("CapNhatQuyenTruyCapChucNangTrongNhomPhanQuyen")]
        //[CustomAuthorize(4, ChucNangEnums.QuanLyUyQuyen)]
        //public async Task<IActionResult> UpdateFunctionInGroup([FromBody] SysFunctionInGroupUpdateModel model)
        //{
        //    var existingFunctionInGroup = await _permissionManagement.GetFunctionInGroupByID(model.FunctionInNhomPhanQuyenID);
        //    if (existingFunctionInGroup == null)
        //    {
        //        return Ok(new { Status = 0, Message = "ID not found" });
        //    }

        //    await _permissionManagement.UpdateFunctionInGroup(model);
        //    return Ok(new { Status = 1, Message = "Updated data successfully" });
        //}

        [HttpPost("XoaChucNangKhoiNhomPhanQuyen")]
        [CustomAuthorize(QuyenEnums.Xoa, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> DeleteFunctionInGroup(NhomChucNangDeleteModel model)
        {
            var existingFunctionInGroup = await _permissionManagement.GetFunctionInGroupByFunctionID(model.ChucNangID);
            if (existingFunctionInGroup == null)
            {
                {
                    return Ok(new Response
                    {
                        Status = 0,
                        Message = "Không tìm thấy chức năng trong nhóm phân quyền"
                    });
                }
            }

            await _permissionManagement.DeleteFunctionFromGroup(model);
            return Ok(new { Status = 1, Message = "Xóa chức năng trong nhóm phân quyền thành công" });
        }

        #endregion

        #region Controller of UserInGroup
        [HttpGet("LayDanhSachNguoiDungTrongNhomPhanQuyenTheoNhomPhanQuyenID")]
        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> GetAllUserInGroup(int nhomPhanQuyenID)
        {
            var existingGroup = await _permissionManagement.GetGroupByID(nhomPhanQuyenID);
            if (existingGroup == null)
            {
                return Ok(new
                {
                    Status = 1,
                    Message = "Không tìm thấy nhóm phân quyền"

                });
            }
            var userInGroups = await _permissionManagement.GetAllUsersInAuthorizationGroup(nhomPhanQuyenID);
            if (userInGroups.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "Không có người dùng trong nhóm phân quyền !" });
            }

            return Ok(new { Status = 1, Message = "Lấy danh sách người dùng trong nhóm phân quyền thành công", Data = userInGroups });
        }

        //[HttpGet("GetUserInGroupByID")]
        //[CustomAuthorize(1, ChucNangEnums.QuanLyUyQuyen)]
        //public async Task<IActionResult> GetUserInGroupByID(int id)
        //{
        //    var userInGroup = await _permissionManagement.GetUserInGroupByID(id);
        //    if (userInGroup == null)
        //    {
        //        return Ok(new { Status = 0, Message = "Id not found" });
        //    }

        //    return Ok(new { Status = 1, Message = "Get information successfully", Data = userInGroup });
        //}

        //[HttpGet("GetUserInGroupByNhomPhanQuyenID")]
        //[CustomAuthorize(1, "ManageAuthorization")]
        //public async Task<IActionResult> GetUserInGroupByNhomPhanQuyenID(int NhomPhanQuyenID)
        //{
        //    var userInGroups = await _permissionManagement.GetUserInGroupByNhomPhanQuyenID(NhomPhanQuyenID);
        //    if (userInGroups.Count() == 0)
        //    {
        //        return Ok(new { Status = 0, Message = "No data found for this group" });
        //    }

        //    return Ok(new { Status = 1, Message = "Get information successfully", Data = userInGroups });
        //}

        [HttpPost("ThemNguoiDungVaoNhomPhanQuyen")]
        [CustomAuthorize(QuyenEnums.Them, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> InsertUserInGroup([FromBody] ThemNguoiDungVaoNhomPhanQuyenModel model)
        {
            var existingUser = await _userRepository.LayTheoID(model.NguoiDungID);
            if (existingUser == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID của người dùng muốn thêm vào nhóm phân quyền"
                });
            }

            var existingAuthorizationGroup = await _permissionManagement.GetGroupByID(model.NhomPhanQuyenID);
            if (existingAuthorizationGroup == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Không tìm thấy ID của Nhóm phân quyền muốn thêm người dùng mới vào"
                });
            }

            var exitingUserInGroup = await _permissionManagement.GetUserInGroupByUserID(model.NguoiDungID);

            foreach (var item in exitingUserInGroup)
            {
                if (item.NhomPhanQuyenID == model.NhomPhanQuyenID)
                {
                    return Ok(new { Status = 0, Message = "Người dùng đã được thêm vào nhóm phân quyền này rồi !" });
                }
            }

            if (model.NguoiDungID <= 0 || model.NhomPhanQuyenID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Nhóm phân quyền và người dùng ID không hợp lệ " });
            }

            var newUserInNhomPhanQuyenID = await _permissionManagement.InsertUserInGroup(model);
            return Ok(new { Status = 1, Message = "Thêm người dùng vào trong nhóm phân quyền thành công !" });
        }

        //[HttpPost("UpdateUserInGroup")]
        //[CustomAuthorize(4, "ManageAuthorization")]
        //public async Task<IActionResult> UpdateUserInGroup([FromBody] XoaNguoiDungKhoiNhomPhanQuyenModel model)
        //{
        //    var existingUserInGroup = await _permissionManagement.GetUserInGroupByID(model.UserInNhomPhanQuyenID);
        //    if (existingUserInGroup == null)
        //    {
        //        return Ok(new { Status = 0, Message = "ID not found" });
        //    }

        //    await _permissionManagement.UpdateUserInGroup(model);
        //    return Ok(new { Status = 1, Message = "Updated data successfully" });
        //}

        [HttpPost("XoaNguoiDungKhoiNhomPhanQuyen")]
        [CustomAuthorize(QuyenEnums.Xoa, ChucNangEnums.QuanLyUyQuyen)]
        public async Task<IActionResult> DeleteUserInGroup(XoaNguoiDungKhoiNhomPhanQuyenModel model)
        {
            var existingUserInGroup = await _permissionManagement.GetUserInGroupByUserID(model.NguoiDungID);
            if (existingUserInGroup == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            await _permissionManagement.DeleteUserInGroup(model);
            return Ok(new { Status = 1, Message = "Xóa người dùng khỏi nhóm phân quyền thành công" });
        }

        #endregion
    }
}
