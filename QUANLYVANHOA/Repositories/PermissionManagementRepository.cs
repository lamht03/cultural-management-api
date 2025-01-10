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
        public async Task<(IEnumerable<SysFunction>, int)> GetAllFunction(string? functionName, int pageNumber, int pageSize)
        {
            var functionList = new List<SysFunction>();
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
                            functionList.Add(new SysFunction
                            {
                                FunctionID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                FunctionName = reader.GetString(reader.GetOrdinal("FunctionName")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
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

        public async Task<SysFunction> GetFunctionByID(int functionId)
        {
            SysFunction function = null;

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
                            function = new SysFunction
                            {
                                FunctionID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                FunctionName = reader.GetString(reader.GetOrdinal("FunctionName")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
                            };
                        }
                    }
                }
            }

            return function;
        }

        public async Task<int> CreateFunction(SysFunctionInsertModel function)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FMS_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionName", function.FunctionName);
                    command.Parameters.AddWithValue("@Description", function.Description);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateFunction(SysFunctionUpdateModel function)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FMS_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionID", function.FunctionID);
                    command.Parameters.AddWithValue("@FunctionName", function.FunctionName);
                    command.Parameters.AddWithValue("@Description", function.Description);

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
        public async Task<(IEnumerable<SysGroup>, int)> GetAllGroup(string? groupName, int pageNumber, int pageSize)
        {
            var groupList = new List<SysGroup>();
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
                            groupList.Add(new SysGroup
                            {
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                GroupName = reader.GetString(reader.GetOrdinal("GroupName")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
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

        public async Task<SysGroup> GetGroupByID(int groupID)
        {
            SysGroup group = null;

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
                            group = new SysGroup
                            {
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                GroupName = reader.GetString(reader.GetOrdinal("GroupName")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
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

        public async Task<int> UpdateGroup(SysGroupUpdateModel group)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GMS_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", group.GroupID);
                    command.Parameters.AddWithValue("@GroupName", group.GroupName);
                    command.Parameters.AddWithValue("@Description", group.Description);

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
        public async Task<IEnumerable<SysFunctionInGroup>> GetAllFunctionInGroup()
        {
            var functionInGroupList = new List<SysFunctionInGroup>();

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
                            functionInGroupList.Add(new SysFunctionInGroup
                            {
                                FunctionInGroupID = reader.GetInt32(reader.GetOrdinal("FunctionInGroupID")),
                                FunctionID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                Permission = reader.GetInt32(reader.GetOrdinal("Permission"))
                            });
                        }
                    }
                }
            }

            return functionInGroupList;
        }

        public async Task<IEnumerable<SysFunctionInGroup>> GetFunctionInGroupByGroupID(int groupID)
        {
            var functionInGroupList = new List<SysFunctionInGroup>();

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
                            functionInGroupList.Add(new SysFunctionInGroup
                            {
                                FunctionInGroupID = reader.GetInt32(reader.GetOrdinal("FunctionInGroupID")),
                                FunctionID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                Permission = reader.GetInt32(reader.GetOrdinal("Permission"))
                            });
                        }
                    }
                }
            }

            return functionInGroupList;
        }

        public async Task<IEnumerable<SysFunctionInGroup>> GetFunctionInGroupByFunctionID(int functionID)
        {
            var functionInGroupList = new List<SysFunctionInGroup>();

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
                            functionInGroupList.Add(new SysFunctionInGroup
                            {
                                FunctionInGroupID = reader.GetInt32(reader.GetOrdinal("FunctionInGroupID")),
                                FunctionID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                Permission = reader.GetInt32(reader.GetOrdinal("Permission"))
                            });
                        }
                    }
                }
            }

            return functionInGroupList;
        }

        public async Task<SysFunctionInGroup> GetFunctionInGroupByID(int functionInGroupID)
        {
            SysFunctionInGroup functionInGroup = null;

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
                            functionInGroup = new SysFunctionInGroup
                            {
                                FunctionInGroupID = reader.GetInt32(reader.GetOrdinal("FunctionInGroupID")),
                                FunctionID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                                Permission = reader.GetInt32(reader.GetOrdinal("Permission"))
                            };
                        }
                    }
                }
            }

            return functionInGroup;
        }

        public async Task<int> InsertFunctionInGroup(SysFunctionInGroupInsertModel functionInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("FIG_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FunctionID", functionInGroup.FunctionID);
                    command.Parameters.AddWithValue("@GroupID", functionInGroup.GroupID);
                    command.Parameters.AddWithValue("@Permission", functionInGroup.Permission);

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

        public async Task<int> DeleteFunctionInGroup(int functionInGroupID)
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
        public async Task<IEnumerable<SysUserInGroup>> GetAllUserInGroup()
        {
            var userInGroupList = new List<SysUserInGroup>();

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
                            userInGroupList.Add(new SysUserInGroup
                            {
                                UserInGroupID = reader.GetInt32(reader.GetOrdinal("UserInGroupID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"))
                            });
                        }
                    }
                }
            }

            return userInGroupList;
        }

        public async Task<IEnumerable<SysUserInGroup>> GetUserInGroupByGroupID(int groupID)
        {
            var userInGroupList = new List<SysUserInGroup>();

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
                            userInGroupList.Add(new SysUserInGroup
                            {
                                UserInGroupID = reader.GetInt32(reader.GetOrdinal("UserInGroupID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"))
                            });
                        }
                    }
                }
            }

            return userInGroupList;
        }

        public async Task<IEnumerable<SysUserInGroup>> GetUserInGroupByUserID(int userID)
        {
            var userInGroupList = new List<SysUserInGroup>();

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
                            userInGroupList.Add(new SysUserInGroup
                            {
                                UserInGroupID = reader.GetInt32(reader.GetOrdinal("UserInGroupID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"))
                            });
                        }
                    }
                }
            }

            return userInGroupList;
        }

        public async Task<SysUserInGroup> GetUserInGroupByID(int userInGroupID)
        {
            SysUserInGroup userInGroup = null;

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
                            userInGroup = new SysUserInGroup
                            {
                                UserInGroupID = reader.GetInt32(reader.GetOrdinal("UserInGroupID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"))
                            };
                        }
                    }
                }
            }

            return userInGroup;
        }

        public async Task<int> InsertUserInGroup(SysUserInGroupCreateModel userInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userInGroup.UserID);
                    command.Parameters.AddWithValue("@GroupID", userInGroup.GroupID);
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateUserInGroup(SysUserInGroupUpdateModel userInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("UIG_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserInGroupID", userInGroup.UserInGroupID);
                    command.Parameters.AddWithValue("@UserID", userInGroup.UserID);
                    command.Parameters.AddWithValue("@GroupID", userInGroup.GroupID);

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
