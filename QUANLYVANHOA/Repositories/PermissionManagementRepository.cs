using QUANLYVANHOA.Interfaces;
using QUANLYVANHOA.Models.HeThong;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYVANHOA.Repositories
{
    public class PermissionManagementRepository : IPermissionManagementRepository
    {
        private readonly string _connectionString;

        public PermissionManagementRepository (IConfiguration _configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }

        #region Repository of Function
        public async Task<(IEnumerable<HeThongChucNang>, int)> GetAllFunction(string? functionName, int pageNumber, int pageSize)
        {
            var functionList = new List<HeThongChucNang>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("FMS_GetListPaging", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionName", functionName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            functionList.Add(new HeThongChucNang
                            {
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                TenChucNang = reader.GetString(reader.GetOrdinal("FunctionName")),
                                MoTa = reader.GetString(reader.GetOrdinal("Description"))
                            });
                        }

                        await reader.NextResultAsync(); // Di chuyển đến kết quả thứ hai
                        if (await reader.ReadAsync())
                        {
                            totalRecords = reader.GetInt32(reader.GetOrdinal("TotalRecords"));
                        }
                    }
                }
            }

            return (functionList, totalRecords);
        }

        public async Task<HeThongChucNang> GetFunctionByID(int functionId)
        {
            HeThongChucNang function = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FMS_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionID", functionId);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            function = new HeThongChucNang
                            {
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                TenChucNang = reader.GetString(reader.GetOrdinal("FunctionName")),
                                MoTa = reader.GetString(reader.GetOrdinal("Description"))
                            };
                        }
                    }
                }
            }

            return function;
        }

        public async Task<int> CreateFunction(HeThongChucNangInsertModel function)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FMS_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionName", function.TenChucNang);
                    command.Parameters.AddWithValue("@Description", function.MoTa);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateFunction(HeThongChucNangUpdateModel function)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FMS_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionID", function.ChucNangID);
                    command.Parameters.AddWithValue("@FunctionName", function.TenChucNang);
                    command.Parameters.AddWithValue("@Description", function.MoTa);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteFunction(int functionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FMS_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionID", functionId);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion

        #region Repository of Group
        public async Task<(IEnumerable<HeThongNhomPhanQuyen>, int)> GetAllGroup(string? groupName, int pageNumber, int pageSize)
        {
            var groupList = new List<HeThongNhomPhanQuyen>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("GMS_GetListPaging", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupName", groupName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            groupList.Add(new HeThongNhomPhanQuyen
                            {
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                TenNhomPhanQuyen = reader.GetString(reader.GetOrdinal("GroupName")),
                                MoTa = reader.GetString(reader.GetOrdinal("Description"))
                            });
                        }

                        await reader.NextResultAsync(); // Di chuyển đến kết quả thứ hai
                        if (await reader.ReadAsync())
                        {
                            totalRecords = reader.GetInt32(reader.GetOrdinal("TotalRecords"));
                        }
                    }
                }
            }

            return (groupList, totalRecords);
        }

        public async Task<HeThongNhomPhanQuyen> GetGroupByID(int groupID)
        {
            HeThongNhomPhanQuyen group = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GMS_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", groupID);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            group = new HeThongNhomPhanQuyen
                            {
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                TenNhomPhanQuyen = reader.GetString(reader.GetOrdinal("GroupName")),
                                MoTa = reader.GetString(reader.GetOrdinal("Description"))
                            };
                        }
                    }
                }
            }

            return group;
        }

        public async Task<int> CreateGroup(SysGroupInsertModel group)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GMS_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupName", group.GroupName);
                    command.Parameters.AddWithValue("@Description", group.Description);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateGroup(NhomPhanQuyenUpdateModel group)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GMS_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", group.NhomPhanQuyenID);
                    command.Parameters.AddWithValue("@GroupName", group.TenNhomPhanQuyen);
                    command.Parameters.AddWithValue("@Description", group.MoTa);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteGroup(int groupID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GMS_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", groupID);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion

        #region Repository of Function In Group
        public async Task<IEnumerable<HeThongNhomChucNang>> GetAllFunctionInGroup()
        {
            var functionInGroupList = new List<HeThongNhomChucNang>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("FIG_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            functionInGroupList.Add(new HeThongNhomChucNang
                            {
                                NhomChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionInGroupID")),
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                Quyen = reader.GetInt32(reader.GetOrdinal("Permission"))
                            });
                        }
                    }
                }
            }

            return functionInGroupList;
        }

        public async Task<IEnumerable<HeThongNhomChucNang>> GetFunctionInGroupByGroupID(int groupID)
        {
            var functionInGroupList = new List<HeThongNhomChucNang>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("FIG_GetByGroupID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", groupID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            functionInGroupList.Add(new HeThongNhomChucNang
                            {
                                NhomChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionInGroupID")),
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                Quyen = reader.GetInt32(reader.GetOrdinal("Permission"))
                            });
                        }
                    }
                }
            }

            return functionInGroupList;
        }

        public async Task<IEnumerable<HeThongNhomChucNang>> GetFunctionInGroupByFunctionID(int functionID)
        {
            var functionInGroupList = new List<HeThongNhomChucNang>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("FIG_GetByFunctionID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionID", functionID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            functionInGroupList.Add(new HeThongNhomChucNang
                            {
                                NhomChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionInGroupID")),
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                Quyen = reader.GetInt32(reader.GetOrdinal("Permission"))
                            });
                        }
                    }
                }
            }

            return functionInGroupList;
        }

        public async Task<HeThongNhomChucNang> GetFunctionInGroupByID(int functionInGroupID)
        {
            HeThongNhomChucNang functionInGroup = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("FIG_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionInGroupID", functionInGroupID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            functionInGroup = new HeThongNhomChucNang
                            {
                                NhomChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionInGroupID")),
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                Quyen = reader.GetInt32(reader.GetOrdinal("Permission"))
                            };
                        }
                    }
                }
            }

            return functionInGroup;
        }

        public async Task<int> AddFunctionIntoGroup(NhomChucNangInsertModel functionInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FIG_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionID", functionInGroup.ChucNangID);
                    command.Parameters.AddWithValue("@GroupID", functionInGroup.GroupID);
                    command.Parameters.AddWithValue("@Permission", functionInGroup.Quyen);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateFunctionInGroup(SysFunctionInGroupUpdateModel functionInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FIG_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionInGroupID", functionInGroup.FunctionInGroupID);
                    command.Parameters.AddWithValue("@FunctionID", functionInGroup.FunctionID);
                    command.Parameters.AddWithValue("@GroupID", functionInGroup.GroupID);
                    command.Parameters.AddWithValue("@Permission", functionInGroup.Permission);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteFunctionFromGroup(int functionInGroupID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FIG_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionInGroupID", functionInGroupID);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion

        #region Repository of User In Group
        public async Task<IEnumerable<HeThongNhomNguoiDung>> GetAllUserInGroup()
        {
            var userInGroupList = new List<HeThongNhomNguoiDung>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            userInGroupList.Add(new HeThongNhomNguoiDung
                            {
                                NhomNguoiDungID = reader.GetInt32(reader.GetOrdinal("UserInGroupID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                NhomPhanQuyen = reader.GetInt32(reader.GetOrdinal("GroupID"))
                            });
                        }
                    }
                }
            }

            return userInGroupList;
        }

        public async Task<IEnumerable<HeThongNhomNguoiDung>> GetUserInGroupByGroupID(int groupID)
        {
            var userInGroupList = new List<HeThongNhomNguoiDung>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_GetByGroupID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", groupID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            userInGroupList.Add(new HeThongNhomNguoiDung
                            {
                                NhomNguoiDungID = reader.GetInt32(reader.GetOrdinal("UserInGroupID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                NhomPhanQuyen = reader.GetInt32(reader.GetOrdinal("GroupID"))
                            });
                        }
                    }
                }
            }

            return userInGroupList;
        }

        public async Task<IEnumerable<HeThongNhomNguoiDung>> GetUserInGroupByUserID(int userID)
        {
            var userInGroupList = new List<HeThongNhomNguoiDung>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_GetByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            userInGroupList.Add(new HeThongNhomNguoiDung
                            {
                                NhomNguoiDungID = reader.GetInt32(reader.GetOrdinal("UserInGroupID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                NhomPhanQuyen = reader.GetInt32(reader.GetOrdinal("GroupID"))
                            });
                        }
                    }
                }
            }

            return userInGroupList;
        }

        public async Task<HeThongNhomNguoiDung> GetUserInGroupByID(int userInGroupID)
        {
            HeThongNhomNguoiDung userInGroup = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserInGroupID", userInGroupID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            userInGroup = new HeThongNhomNguoiDung
                            {
                                NhomNguoiDungID = reader.GetInt32(reader.GetOrdinal("UserInGroupID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                NhomPhanQuyen = reader.GetInt32(reader.GetOrdinal("GroupID"))
                            };
                        }
                    }
                }
            }

            return userInGroup;
        }

        public async Task<int> InsertUserInGroup(ThemNguoiDungVaoNhomPhanQuyenModel userInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userInGroup.NguoiDungID);
                    command.Parameters.AddWithValue("@GroupID", userInGroup.NhomPhanQuyenID);
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateUserInGroup(XoaNguoiDungKhoiNhomPhanQuyenModel userInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserInGroupID", userInGroup.UserInGroupID);
                    command.Parameters.AddWithValue("@UserID", userInGroup.NguoiDungID);
                    command.Parameters.AddWithValue("@GroupID", userInGroup.NhomPhanQuyenID);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteUserInGroup(int userInGroupID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserInGroupID", userInGroupID);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion
    }
}
