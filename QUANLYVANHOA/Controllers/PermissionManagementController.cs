using Microsoft.AspNetCore.Mvc;
using QUANLYVANHOA.Interfaces;
using QUANLYVANHOA.Models.HeThong;

namespace QUANLYVANHOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PermissionManagementController : ControllerBase
    {
        private readonly IPermissionManagementRepository _permissionManagement;

        public PermissionManagementController(IPermissionManagementRepository permissionManagement)
        {
            _permissionManagement = permissionManagement;
        }

        #region Controller of Function
        [HttpGet("GetAllFunction")]
        [CustomAuthorize(1, "ManageAuthorization")]
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

            var (functions, totalRecords) = await _permissionManagement.GetAllFunction(functionName, pageNumber, pageSize);
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (!functions.Any())
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "No data available",
                    Data = functions
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Get information successfully",
                Data = functions,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            });
        }

        [HttpGet("GetFunctionByID")]
        [CustomAuthorize(1, "ManageAuthorization")]
        public async Task<IActionResult> GetFunctionByID(int functionId)
        {
            var function = await _permissionManagement.GetFunctionByID(functionId);
            if (function == null)
            {
                return Ok(new Response
                {   
                    Status = 0,
                    Message = "Id not found",
                    Data = function
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Get information successfully",
                Data = function
            });
        }

        [CustomAuthorize(2, "ManageAuthorization")]
        [HttpPost("CreateFunction")]
        public async Task<IActionResult> CreateFunction([FromBody] HeThongChucNangInsertModel function)
        {

            var existingFunction = await _permissionManagement.GetAllFunction(function.TenChucNang, 1, 20);
            {
                if (existingFunction.Item1.Any())
                {
                    return BadRequest(new Response
                    {
                        Status = 0,
                        Message = "Function name already exists."
                    });
                }
            }

            if (string.IsNullOrWhiteSpace(function.TenChucNang) || function.TenChucNang.Contains(" "))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Invalid function name. The function name must not contain spaces and function name is required."
                });
            }

            if (function.TenChucNang.Length > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Function name cannot exceed 50 characters."
                });
            }

            int rowsAffected = await _permissionManagement.CreateFunction(function);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while creating the function."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Function created successfully."
            });
        }

        [HttpPost("UpdateFunction")]
        [CustomAuthorize(4, "ManageAuthorization")]
        public async Task<IActionResult> UpdateFunction([FromBody] HeThongChucNangUpdateModel function)
        {
            var existingFunction = await _permissionManagement.GetFunctionByID(function.ChucNangID);
            if (existingFunction == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Function not found."
                });
            }


            var existingFunctionName = await _permissionManagement.GetAllFunction(function.TenChucNang, 1, 20);
            {
                if (existingFunctionName.Item1.Any())
                {
                    return BadRequest(new Response
                    {
                        Status = 0,
                        Message = "Function name already exists."
                    });
                }
            }

            if (string.IsNullOrWhiteSpace(function.TenChucNang) || function.TenChucNang.Contains(" "))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Invalid function name. The function name must not contain spaces and function name is required."
                });
            }

            if (function.TenChucNang.Length > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Function name cannot exceed 50 characters."
                });
            }

            int rowsAffected = await _permissionManagement.UpdateFunction(function);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while updating the function."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Function updated successfully."
            });
        }

        [HttpPost("DeleteFunction")]
        [CustomAuthorize(8, "ManageAuthorization")]
        public async Task<IActionResult> DeleteFunction(int functionId)
        {
            var existingFunction = await _permissionManagement.GetFunctionByID(functionId);
            if (existingFunction == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Function not found."
                });
            }

            int rowsAffected = await _permissionManagement.DeleteFunction(functionId);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while deleting the function."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Function deleted successfully."
            });
        }

        #endregion

        #region Controller of Group
        [HttpGet("GetAllGroup")]
        [CustomAuthorize(1, "ManageAuthorization")]
        public async Task<IActionResult> GetAll(string? groupName, int pageNumber = 1, int pageSize = 20)
        {
            if (!string.IsNullOrWhiteSpace(groupName))
            {
                groupName = groupName.Trim();
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

            var (groups, totalRecords) = await _permissionManagement.GetAllGroup(groupName, pageNumber, pageSize);
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (!groups.Any())
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "No data available",
                    Data = groups
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Get information successfully",
                Data = groups,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            });
        }

        [HttpGet("GetGroupByID")]
        [CustomAuthorize(1, "ManageAuthorization")]
        public async Task<IActionResult> GetGroupByID(int groupId)
        {
            var group = await _permissionManagement.GetGroupByID(groupId);
            if (group == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Id not found",
                    Data = group
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Get information successfully",
                Data = group
            });
        }

        [CustomAuthorize(2, "ManageAuthorization")]
        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroup([FromBody] SysGroupInsertModel group)
        {
            if (string.IsNullOrWhiteSpace(group.GroupName) || group.GroupName.Contains(" "))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Invalid group name. The group name must not contain spaces and group name is required."
                });
            }

            if (group.GroupName.Length > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Group name cannot exceed 50 characters."
                });
            }

            int rowsAffected = await _permissionManagement.CreateGroup(group);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while creating the group."
                });
            }

            return CreatedAtAction(nameof(GetGroupByID), new Response
            {
                Status = 1,
                Message = "Group created successfully."
            });
        }

        [HttpPost("UpdateGroup")]
        [CustomAuthorize(4, "ManageAuthorization")]
        public async Task<IActionResult> UpdateGroup([FromBody] NhomPhanQuyenUpdateModel group)
        {
            var existingGroup = await _permissionManagement.GetGroupByID(group.NhomPhanQuyenID);
            if (existingGroup == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Group not found."
                });
            }

            if (string.IsNullOrWhiteSpace(group.TenNhomPhanQuyen) || group.TenNhomPhanQuyen.Contains(" "))
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Invalid group name. The group name must not contain spaces and group name is required."
                });
            }

            if (group.TenNhomPhanQuyen.Length > 50)
            {
                return BadRequest(new Response
                {
                    Status = 0,
                    Message = "Group name cannot exceed 50 characters."
                });
            }

            int rowsAffected = await _permissionManagement.UpdateGroup(group);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while updating the group."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Group updated successfully."
            });
        }

        [HttpPost("DeleteGroup")]
        [CustomAuthorize(8, "ManageAuthorization")]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            var existingGroup = await _permissionManagement.GetGroupByID(groupId);
            if (existingGroup == null)
            {
                return Ok(new Response
                {
                    Status = 0,
                    Message = "Group not found."
                });
            }

            int rowsAffected = await _permissionManagement.DeleteGroup(groupId);
            if (rowsAffected == 0)
            {
                return StatusCode(500, new Response
                {
                    Status = 0,
                    Message = "An error occurred while deleting the group."
                });
            }

            return Ok(new Response
            {
                Status = 1,
                Message = "Group deleted successfully."
            });
        }

        #endregion

        #region Controller of FunctionInGroup
        [CustomAuthorize(1, "ManageAuthorization")]
        [HttpGet("GetAllFunctionInGroup")]
        public async Task<IActionResult> GetAllFunctionInGroup()
        {
            var functionInGroups = await _permissionManagement.GetAllFunctionInGroup();
            if (!functionInGroups.Any())
            {
                return Ok(new { Status = 0, Message = "No data available" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = functionInGroups });
        }

        [CustomAuthorize(1, "ManageAuthorization")]
        [HttpGet("GetFunctionInGroupByID")]
        public async Task<IActionResult> GetFunctionInGroupByID(int id)
        {
            var functionInGroup = await _permissionManagement.GetFunctionInGroupByID(id);
            if (functionInGroup == null)
            {
                return Ok(new { Status = 0, Message = "Id not found" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = functionInGroup });
        }

        [CustomAuthorize(1, "ManageAuthorization")]
        [HttpGet("GetFunctionInGroupByGroupID")]
        public async Task<IActionResult> GetFunctionInGroupByGroupID(int groupId)
        {
            var functionInGroups = await _permissionManagement.GetFunctionInGroupByGroupID(groupId);
            if (!functionInGroups.Any())
            {
                return Ok(new { Status = 0, Message = "No data found for this group" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = functionInGroups });
        }

        [HttpGet("GetByFunctionID")]
        [CustomAuthorize(1, "ManageAuthorization")]
        public async Task<IActionResult> GetByFunctionID(int functionId)
        {
            var functionInGroups = await _permissionManagement.GetFunctionInGroupByFunctionID(functionId);
            if (!functionInGroups.Any())
            {
                return Ok(new { Status = 0, Message = "No data found for this function" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = functionInGroups });
        }

        [HttpPost("InsertFunctionInGroup")]
        [CustomAuthorize(2, "ManageAuthorization")]
        public async Task<IActionResult> InsertFunctionInGroup([FromBody] NhomChucNangInsertModel model)
        {
            if (model.GroupID <= 0 || model.ChucNangID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid data. GroupID and FunctionID must be greater than 0." });
            }

            var newFunctionInGroupID = await _permissionManagement.AddFunctionIntoGroup(model);
            return CreatedAtAction(nameof(GetFunctionInGroupByID), new { id = newFunctionInGroupID }, new { Status = 1, Message = "Inserted data successfully" });
        }

        [HttpPost("UpdateFunctionInGroup")]
        [CustomAuthorize(4, "ManageAuthorization")]
        public async Task<IActionResult> UpdateFunctionInGroup([FromBody] SysFunctionInGroupUpdateModel model)
        {
            var existingFunctionInGroup = await _permissionManagement.GetFunctionInGroupByID(model.FunctionInGroupID);
            if (existingFunctionInGroup == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            await _permissionManagement.UpdateFunctionInGroup(model);
            return Ok(new { Status = 1, Message = "Updated data successfully" });
        }

        [HttpPost("DeleteFunctionInGroup")]
        [CustomAuthorize(8, "ManageAuthorization")]
        public async Task<IActionResult> DeleteFunctionInGroup(int id)
        {
            var existingFunctionInGroup = await _permissionManagement.GetFunctionInGroupByID(id);
            if (existingFunctionInGroup == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            await _permissionManagement.DeleteFunctionFromGroup(id);
            return Ok(new { Status = 1, Message = "Deleted data successfully" });
        }

        #endregion

        #region Controller of UserInGroup
        [HttpGet("GetAllUserInGroup")]
        [CustomAuthorize(1, "ManageAuthorization")]
        public async Task<IActionResult> GetAllUserInGroup()
        {
            var userInGroups = await _permissionManagement.GetAllUserInGroup();
            if (userInGroups.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "No data available" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = userInGroups });
        }

        [HttpGet("GetUserInGroupByID")]
        [CustomAuthorize(1, "ManageAuthorization")]
        public async Task<IActionResult> GetUserInGroupByID(int id)
        {
            var userInGroup = await _permissionManagement.GetUserInGroupByID(id);
            if (userInGroup == null)
            {
                return Ok(new { Status = 0, Message = "Id not found" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = userInGroup });
        }

        [HttpGet("GetUserInGroupByGroupID")]
        [CustomAuthorize(1, "ManageAuthorization")]
        public async Task<IActionResult> GetUserInGroupByGroupID(int groupId)
        {
            var userInGroups = await _permissionManagement.GetUserInGroupByGroupID(groupId);
            if (userInGroups.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "No data found for this group" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = userInGroups });
        }

        [HttpGet("GetUserInGroupByUserID")]
        [CustomAuthorize(1, "ManageAuthorization")]
        public async Task<IActionResult> GetUserInGroupByUserID(int userId)
        {
            var userInGroups = await _permissionManagement.GetUserInGroupByUserID(userId);
            if (userInGroups.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "No data found for this user" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = userInGroups });
        }

        [HttpPost("InsertUserInGroup")]
        [CustomAuthorize(2, "ManageAuthorization")]
        public async Task<IActionResult> InsertUserInGroup([FromBody] ThemNguoiDungVaoNhomPhanQuyenModel model)
        {
            var existingUserInGroup = await _permissionManagement.GetUserInGroupByID(model.NguoiDungID);


            if (model.NguoiDungID <= 0 || model.NhomPhanQuyenID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid data. UserID and GroupID must be greater than 0." });
            }

            var newUserInGroupID = await _permissionManagement.InsertUserInGroup(model);
            return CreatedAtAction(nameof(GetUserInGroupByID), new { id = newUserInGroupID }, new { Status = 1, Message = "Inserted data successfully" });
        }

        [HttpPost("UpdateUserInGroup")]
        [CustomAuthorize(4, "ManageAuthorization")]
        public async Task<IActionResult> UpdateUserInGroup([FromBody] XoaNguoiDungKhoiNhomPhanQuyenModel model)
        {
            var existingUserInGroup = await _permissionManagement.GetUserInGroupByID(model.UserInGroupID);
            if (existingUserInGroup == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            await _permissionManagement.UpdateUserInGroup(model);
            return Ok(new { Status = 1, Message = "Updated data successfully" });
        }

        [HttpPost("DeleteUserInGroup")]
        [CustomAuthorize(8, "ManageAuthorization")]
        public async Task<IActionResult> DeleteUserInGroup(int id)
        {
            var existingUserInGroup = await _permissionManagement.GetUserInGroupByID(id);
            if (existingUserInGroup == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            await _permissionManagement.DeleteUserInGroup(id);
            return Ok(new { Status = 1, Message = "Deleted data successfully" });
        }

        #endregion
    }
}
