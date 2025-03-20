using QUANLYVANHOA.Models.HeThong;
using System.Data;
using Microsoft.Data.SqlClient;
using QUANLYVANHOA.Core.DTO;
using QUANLYVANHOA.Core.Enums;
using QUANLYVANHOA.Interfaces.HeThong;

namespace QUANLYVANHOA.Repositories.HeThong
{
    public class PhanQuyenRepository : IPhanQuyenRepository
    {
        private readonly string _connectionString;

        public PhanQuyenRepository (IConfiguration _configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }

        #region Repository of Function
        public async Task<(IEnumerable<ChucNang>, int)> GetAllFunction(string? functionName, int pageNumber, int pageSize)
        {
            var functionList = new List<ChucNang>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("ChucNang_GetListPaging", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenChucNang", functionName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            functionList.Add(new ChucNang
                            {
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("ChucNangID")),
                                TenChucNang = reader.GetString(reader.GetOrdinal("TenChucNang")),
                                MoTa = reader.GetString(reader.GetOrdinal("MoTa"))
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

        public async Task<ChucNang> GetFunctionByID(int functionId)
        {
            ChucNang function = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("ChucNang_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChucNangID", functionId);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            function = new ChucNang
                            {
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("ChucNangID")),
                                TenChucNang = reader.GetString(reader.GetOrdinal("TenChucNang")),
                                MoTa = reader.GetString(reader.GetOrdinal("MoTa"))
                            };
                        }
                    }
                }
            }

            return function;
        }

        public async Task<int> CreateFunction(ChucNangInsertModel function)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("ChucNang_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenChucNang", function.TenChucNang);
                    command.Parameters.AddWithValue("@MoTa", function.MoTa);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateFunction(ChucNangUpdateModel function)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("ChucNang_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChucNangID", function.ChucNangID);
                    command.Parameters.AddWithValue("@TenChucNang", function.TenChucNang);
                    command.Parameters.AddWithValue("@MoTa", function.MoTa);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteFunction(int functionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("ChucNang_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChucNangID", functionId);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion

        #region Repository of Group
        public async Task<IEnumerable<NguoiDungTrongNhomPhanQuyenDTO>> GetAllUsersInAuthorizationGroup(int nhomPhanQuyenID)
        {
            var userInGroupList = new List<NguoiDungTrongNhomPhanQuyenDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NhomPhanQuyen_GetAllUsersInAuthorizationGroup", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NhomPhanQuyenID",nhomPhanQuyenID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            userInGroupList.Add(new NguoiDungTrongNhomPhanQuyenDTO
                            {
                                NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                                CanBoID = reader.GetInt32(reader.GetOrdinal("CanBoID")),
                                CoQuanID = reader.GetInt32(reader.GetOrdinal("CoQuanID")),
                                TenNguoiDung = reader.GetString(reader.GetOrdinal("TenNguoiDung")),
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID")),
                                TenNhomPhanQuyen = reader.GetString(reader.GetOrdinal("TenNhomPhanQuyen"))
                            });
                        }
                    }
                }
            }

            return userInGroupList;
        }

        public async Task<IEnumerable<ChucNangTrongNhomPhanQuyenDTO>> GetAllFunctionsAndPermissionsInAuthorizationGroup(int nhomPhanQuyenID)
        {
            var functionInGroupList = new List<ChucNangTrongNhomPhanQuyenDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NhomChucNang_GetAllFunctionsAndPermissionsInAuthorizationGroup", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NhomPhanQuyenID", nhomPhanQuyenID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            functionInGroupList.Add(new ChucNangTrongNhomPhanQuyenDTO
                            {
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("ChucNangID")),
                                TenChucNang = reader.GetString(reader.GetOrdinal("TenChucNang")),
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID")),
                                TenNhomPhanQuyen = reader.GetString(reader.GetOrdinal("TenNhomPhanQuyen")),
                                NhomChucNangID = reader.GetInt32(reader.GetOrdinal("NhomChucNangID")),
                                Quyen = reader.GetInt32(reader.GetOrdinal("Quyen")),
                                Xem = (reader.GetInt32(reader.GetOrdinal("Quyen")) & (int)QuyenEnums.Xem) == (int)QuyenEnums.Xem,
                                Them = (reader.GetInt32(reader.GetOrdinal("Quyen")) & (int)QuyenEnums.Them) == (int)QuyenEnums.Them,
                                Sua = (reader.GetInt32(reader.GetOrdinal("Quyen")) & (int)QuyenEnums.Sua) == (int)QuyenEnums.Sua,
                                Xoa = (reader.GetInt32(reader.GetOrdinal("Quyen")) & (int)QuyenEnums.Xoa) == (int)QuyenEnums.Xoa,
                            });
                        }
                    }
                }
            }

            return functionInGroupList;
        }

        public async Task<(IEnumerable<NhomPhanQuyen>, int)> GetAllGroup(string? tenNhomPhanQuyen, int? CanBoId, int pageNumber, int pageSize)
        {
            var groupList = new List<NhomPhanQuyen>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NhomPhanQuyen_GetListPaging", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenNhomPhanQuyen", tenNhomPhanQuyen ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CanBoID", CanBoId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            groupList.Add(new NhomPhanQuyen
                            {
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID")),
                                TenNhomPhanQuyen = reader.GetString(reader.GetOrdinal("TenNhomPhanQuyen")),
                                MoTa = reader.GetString(reader.GetOrdinal("MoTa"))
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

        public async Task<NhomPhanQuyen> GetGroupByID(int NhomPhanQuyenID)
        {
            NhomPhanQuyen group = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("NhomPhanQuyen_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NhomPhanQuyenID", NhomPhanQuyenID);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            group = new NhomPhanQuyen
                            {
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID")),
                                TenNhomPhanQuyen = reader.GetString(reader.GetOrdinal("TenNhomPhanQuyen")),
                                MoTa = reader.GetString(reader.GetOrdinal("MoTa"))
                            };
                        }
                    }
                }
            }

            return group;
        }

        public async Task<int> CreateGroup(NhomPhanQuyenInsertModel group)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("NhomPhanQuyen_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenNhomPhanQuyen", group.TenNhomPhanQuyen);
                    command.Parameters.AddWithValue("@MoTa", group.MoTa);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateGroup(NhomPhanQuyenUpdateModel group)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("NhomPhanQuyen_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NhomPhanQuyenID", group.NhomPhanQuyenID);
                    command.Parameters.AddWithValue("@TenNhomPhanQuyen", group.TenNhomPhanQuyen);
                    command.Parameters.AddWithValue("@MoTa", group.MoTa);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteGroup(int NhomPhanQuyenID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("NhomPhanQuyen_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NhomPhanQuyenID", NhomPhanQuyenID);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion

        #region Repository of Function In Group

        //public async Task<IEnumerable<NhomChucNang>> GetFunctionInGroupByNhomPhanQuyenID(int NhomPhanQuyenID)
        //{
        //    var functionInGroupList = new List<NhomChucNang>();

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();

        //        using (var command = new SqlCommand("NhomChucNang_GetByNhomPhanQuyenID", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@NhomPhanQuyenID", NhomPhanQuyenID);

        //            using (var reader = await command.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    functionInGroupList.Add(new NhomChucNang
        //                    {
        //                        NhomChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionInNhomPhanQuyenID")),
        //                        ChucNangID = reader.GetInt32(reader.GetOrdinal("FunctionID")),
        //                        NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID")),
        //                        Quyen = reader.GetInt32(reader.GetOrdinal("Permission"))
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return functionInGroupList;
        //}

        public async Task<IEnumerable<NhomChucNang>> GetFunctionInGroupByFunctionID(int functionID)
        {
            var functionInGroupList = new List<NhomChucNang>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NhomChucNang_GetFunctionInGroupByFunctionID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChucNangID", functionID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            functionInGroupList.Add(new NhomChucNang
                            {
                                NhomChucNangID = reader.GetInt32(reader.GetOrdinal("NhomChucNangID")),
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("ChucNangID")),
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID")),
                                Quyen = reader.GetInt32(reader.GetOrdinal("Quyen"))
                            });
                        }
                    }
                }
            }
            return functionInGroupList;
        }

        public async Task<NhomChucNang> GetFunctionInGroupByID(int functionInNhomPhanQuyenID)
        {
            NhomChucNang functionInGroup = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NhomChucNang_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NhomChucNangID", functionInNhomPhanQuyenID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            functionInGroup = new NhomChucNang
                            {
                                NhomChucNangID = reader.GetInt32(reader.GetOrdinal("NhomChucNangID")),
                                ChucNangID = reader.GetInt32(reader.GetOrdinal("ChucNangID")),
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID")),
                                Quyen = reader.GetInt32(reader.GetOrdinal("Quyen"))
                            };
                        }
                    }
                }
            }

            return functionInGroup;
        }

        public async Task<int> AddFunctionToGroup(int nhomPhanQuyenID, int chucNangID, int quyen)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("NhomChucNang_AddFunctionToAuthorizationGroup", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChucNangID", chucNangID);
                    command.Parameters.AddWithValue("@NhomPhanQuyenID", nhomPhanQuyenID);
                    command.Parameters.AddWithValue("@Quyen", quyen);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateFunctionPermissionsInGroup(int nhomChucNangID, int quyen)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("NhomChucNang_UpdateFunctionalAccessPermissions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NhomChucNangID", nhomChucNangID);
                    command.Parameters.AddWithValue("@Quyen", quyen);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }




        public async Task<int> DeleteFunctionFromGroup(NhomChucNangDeleteModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("NhomChucNang_DeleteFunctionInAuthorizationGroup", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChucNangID", model.ChucNangID);
                    command.Parameters.AddWithValue("@NhomPhanQuyenID", model.NhomPhanQuyenID);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion

        #region Repository of User In Group

        public async Task<IEnumerable<NhomNguoiDung>> GetUserInGroupByUserID(int NguoiDungID)
        {
            var userInGroupList = new List<NhomNguoiDung>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NhomNguoiDung_GetUserInAuthorizationGroupByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NguoiDungID", NguoiDungID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            userInGroupList.Add(new NhomNguoiDung
                            {
                                NhomNguoiDungID = reader.GetInt32(reader.GetOrdinal("NhomNguoiDungID")),
                                NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                                NhomPhanQuyenID = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID"))
                            });
                        }
                    }
                }
            }

            return userInGroupList;
        }

        //public async Task<NhomNguoiDung> GetUserInGroupByID(int userInNhomPhanQuyenID)
        //{
        //    NhomNguoiDung userInGroup = null;

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();

        //        using (var command = new SqlCommand("NhomNguoiDung_GetByID", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@UserInNhomPhanQuyenID", userInNhomPhanQuyenID);

        //            using (var reader = await command.ExecuteReaderAsync())
        //            {
        //                if (await reader.ReadAsync())
        //                {
        //                    userInGroup = new NhomNguoiDung
        //                    {
        //                        NhomNguoiDungID = reader.GetInt32(reader.GetOrdinal("UserInNhomPhanQuyenID")),
        //                        NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
        //                        NhomPhanQuyen = reader.GetInt32(reader.GetOrdinal("NhomPhanQuyenID"))
        //                    };
        //                }
        //            }
        //        }
        //    }

        //    return userInGroup;
        //}

        public async Task<int> InsertUserInGroup(ThemNguoiDungVaoNhomPhanQuyenModel userInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NhomNguoiDung_AddUserToAuthorizationGroup", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NguoiDungID", userInGroup.NguoiDungID);
                    command.Parameters.AddWithValue("@NhomPhanQuyenID", userInGroup.NhomPhanQuyenID);
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteUserInGroup(XoaNguoiDungKhoiNhomPhanQuyenModel userInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NhomNguoiDung_DeleteUserInAuthorizationGroup", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NguoiDungID", userInGroup.NguoiDungID);
                    command.Parameters.AddWithValue("@NhomPhanQuyenID", userInGroup.NhomPhanQuyenID);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion
    }
}
