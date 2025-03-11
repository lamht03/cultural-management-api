using Microsoft.Data.SqlClient;
using System.Data;
using QUANLYVANHOA.Utilities;
using QUANLYVANHOA.Models.HeThong;
using QUANLYVANHOA.Interfaces.HeThong;
using Dapper;

namespace QUANLYVANHOA.Repositories.HeThong
{
    public class HeThongNguoiDungRepository : INguoiDungRepository
    {
        private readonly string _connectionString;

        public HeThongNguoiDungRepository(IConfiguration configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }

        public async Task<(IEnumerable<NguoiDung>, int)> LayDanhSachPhanTrang(string? TenNguoiDung, int pageNumber, int pageSize)
        {
            var userList = new List<NguoiDung>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NguoiDung_GetListPaging", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenNguoiDung", TenNguoiDung ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // Đọc dữ liệu người dùng
                        while (await reader.ReadAsync())
                        {
                            userList.Add(new NguoiDung
                            {
                                NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                                TenNguoiDung = reader.GetString(reader.GetOrdinal("TenNguoiDung")),
                                //TenDayDu = !reader.IsDBNull(reader.GetOrdinal("TenDayDu")) ? reader.GetString(reader.GetOrdinal("TenDayDu")) : null,
                                //Email = reader.GetString(reader.GetOrdinal("Email")),
                                //MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                                //TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                GhiChu = !reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? reader.GetString(reader.GetOrdinal("GhiChu")) : null,
                            });
                        }

                        // Đọc tổng số bản ghi từ truy vấn riêng biệt
                        await reader.NextResultAsync(); // Di chuyển đến kết quả thứ hai
                        if (await reader.ReadAsync())
                        {
                            totalRecords = reader.GetInt32(reader.GetOrdinal("TotalRecords"));
                        }
                    }
                }
            }

            return (userList, totalRecords);
        }


        public async Task<NguoiDung> LayTheoID(int NguoiDungID)
        {
            NguoiDung user = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("NguoiDung_GetByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NguoiDungID", NguoiDungID);
                    await connection.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new NguoiDung
                            {
                                NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                                TenNguoiDung = reader.GetString(reader.GetOrdinal("TenNguoiDung")),
                                //TenDayDu = !reader.IsDBNull(reader.GetOrdinal("TenDayDu")) ? reader.GetString(reader.GetOrdinal("TenDayDu")) : null,
                                //Email = reader.GetString(reader.GetOrdinal("Email")),
                                MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                                //TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                //GhiChu = !reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? reader.GetString(reader.GetOrdinal("GhiChu")) : null
                            };
                        }
                    }
                }
            }

            return user;
        }



        //public async Task<int> TaoNguoiDungMoi(NguoiDungInsertModel user)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        using (var cmd = new SqlCommand("NguoiDung_Create", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@TenNguoiDung", user.TenNguoiDung);
        //            cmd.Parameters.AddWithValue("@TenDayDu", user.TenDayDu);
        //            cmd.Parameters.AddWithValue("@Email", user.Email);
        //            cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
        //            cmd.Parameters.AddWithValue("@TrangThai", user.TrangThai);
        //            cmd.Parameters.AddWithValue("@GhiChu", user.GhiChu);
        //            await connection.OpenAsync();
        //            return await cmd.ExecuteNonQueryAsync();
        //        }
        //    }
        //}

        //public async Task<int> DangKyTaiKhoan(RegisterModel user)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        using (var cmd = new SqlCommand("NguoiDung_Create", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@TenNguoiDung", user.TenNguoiDung);
        //            cmd.Parameters.AddWithValue("@TenDayDu", user.TenDayDu);
        //            cmd.Parameters.AddWithValue("@Email", user.Email);
        //            cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
        //            cmd.Parameters.AddWithValue("@TrangThai", user.TrangThai);
        //            cmd.Parameters.AddWithValue("@GhiChu", user.GhiChu);
        //            await connection.OpenAsync();
        //            return await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task<int> SuaThongTinNguoiDung(NguoiDungUpdateModel user)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        using (var cmd = new SqlCommand("NguoiDung_Update", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@NguoiDungID", user.NguoiDungID);
        //            cmd.Parameters.AddWithValue("@TenNguoiDung", user.TenNguoiDung);
        //            cmd.Parameters.AddWithValue("@TenDayDu", user.TenDayDu);
        //            cmd.Parameters.AddWithValue("@Email", user.Email);
        //            cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
        //            cmd.Parameters.AddWithValue("@TrangThai", user.TrangThai);
        //            cmd.Parameters.AddWithValue("@GhiChu", user.GhiChu);
        //            await connection.OpenAsync();
        //            return await cmd.ExecuteNonQueryAsync();
        //        }
        //    }
        //}


        public async Task<int> XoaThongTinNguoiDung(int NguoiDungID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("NguoiDung_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NguoiDungID", NguoiDungID);
                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> ResetPassword(int NguoiDungID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ResetPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NguoiDungID", NguoiDungID);

                    return await command.ExecuteNonQueryAsync(); 
                }
            }
        }

        public async Task<string> ResetPasswordByEmail(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ResetPasswordByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);

                    // Thêm tham số OUTPUT để lấy mật khẩu mới từ SQL Server
                    var outputParam = new SqlParameter("@NewPassword", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);

                    await command.ExecuteNonQueryAsync();

                    return outputParam.Value.ToString();
                }
            }
        }



        public async Task<int> ChangePassword(int userId, string oldPassword, string newPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ChangePassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NguoiDungID", userId);
                    command.Parameters.AddWithValue("@OldPassword", oldPassword);
                    command.Parameters.AddWithValue("@NewPassword", newPassword);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task<NguoiDung> DangNhap(string TenNguoiDung, string MatKhau)
        {
            NguoiDung user = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("VerifyLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenNguoiDung", TenNguoiDung);
                    command.Parameters.AddWithValue("@MatKhau", MatKhau);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new NguoiDung
                            {
                                NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                                TenNguoiDung = reader.GetString(reader.GetOrdinal("TenNguoiDung")),
                            };
                        }
                    }
                }
            }

            return user;
        }

        // 1. Lưu session mới vào cơ sở dữ liệu
        public async Task TaoPhienDangNhap(int NguoiDungID, string refreshToken, DateTime expiryDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("PhienDangNhap_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NguoiDungID", NguoiDungID);
                    command.Parameters.AddWithValue("@RefreshToken", refreshToken);
                    command.Parameters.AddWithValue("@ExpiryDate", expiryDate);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // 2. Lấy session theo refresh token
        public async Task<PhienDangNhap> LayPhienDangNhapTheoRefreshToken(string refreshToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("PhienDangNhap_GetByRefreshToken", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RefreshToken", refreshToken);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new PhienDangNhap
                            {
                                PhienDangNhapID = reader.GetInt32(reader.GetOrdinal("PhienDangNhapID")),
                                NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                                RefreshToken = reader.GetString(reader.GetOrdinal("RefreshToken")),
                                ExpiryDate = reader.GetDateTime(reader.GetOrdinal("ExpiryDate")),
                                IsRevoked = reader.GetBoolean(reader.GetOrdinal("IsRevoked")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        // 3. Cập nhật refresh token cho session
        public async Task CapNhatRefreshToken(int sessionId, string newRefreshToken, DateTime newExpiryDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("PhienDangNhap_UpdateRefreshToken", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PhienDangNhapID", sessionId);
                    command.Parameters.AddWithValue("@NewRefreshToken", newRefreshToken);
                    command.Parameters.AddWithValue("@NewExpiryDate", newExpiryDate);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // 4. Thu hồi session
        public async Task VoHieuHoaPhienDangNhap(int sessionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("PhienDangNhap_Revoke", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SessionID", sessionId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // 5. Thu hồi tất cả session của người dùng
        public async Task VoHieuHoaTatCaPhienDangNhapCuaNguoiDung(int NguoiDungID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("PhienDangNhap_RevokeAllSessionsOfUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NguoiDungID", NguoiDungID);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // 6. Xóa tất cả session của người dùng
        public async Task XoaTatCaPhienDangNhapCuaNguoiDung(int NguoiDungID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("PhienDangNhap_DeleteAllSessionsOfUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NguoiDungID", NguoiDungID);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


    }
}
