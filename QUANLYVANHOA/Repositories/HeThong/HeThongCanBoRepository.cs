using QUANLYVANHOA.Models.HeThong;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using QUANLYVANHOA.Interfaces.HeThong;

public class HeThongCanBoRepository : ICanBoRepository
{
    private readonly string _connectionString;

    public HeThongCanBoRepository(IConfiguration configuration)
    {
        _connectionString = new Connection().GetConnectionString();
    }

    public async Task<(IEnumerable<CanBo>, int)> CanBoGetListPaging(string? TenCanBo, int? CoQuanID, int pageNumber, int pageSize)
    {
        var canBoList = new List<CanBo>();
        int totalRecords = 0;

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var command = new SqlCommand("v1_HeThong_CanBo_GetListPaging", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số vào Stored Procedure
                command.Parameters.Add(new SqlParameter("@TenCanBoOrTenNguoiDung", SqlDbType.NVarChar, 255) { Value = (object)TenCanBo ?? DBNull.Value });
                command.Parameters.Add(new SqlParameter("@PageNumber", SqlDbType.Int) { Value = pageNumber });
                command.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int) { Value = pageSize });
                command.Parameters.Add(new SqlParameter("@CoQuanID", SqlDbType.Int) { Value = (object)CoQuanID ?? DBNull.Value });

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var canBo = new CanBo
                        {
                            CanBoID = reader.GetInt32(reader.GetOrdinal("CanBoID")),
                            TenCanBo = reader.GetString(reader.GetOrdinal("TenCanBo")),
                            NgaySinh = reader.IsDBNull(reader.GetOrdinal("NgaySinh")) ? null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                            GioiTinh = reader.IsDBNull(reader.GetOrdinal("GioiTinh")) ? null : reader.GetInt32(reader.GetOrdinal("GioiTinh")),
                            DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : reader.GetString(reader.GetOrdinal("DiaChi")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            DienThoai = reader.IsDBNull(reader.GetOrdinal("DienThoai")) ? null : reader.GetString(reader.GetOrdinal("DienThoai")),
                            TrangThai = reader.GetInt32(reader.GetOrdinal("TrangThai")),
                            CoQuanID = reader.GetInt32(reader.GetOrdinal("CoQuanID")),
                            TenNguoiDung = reader.GetString(reader.GetOrdinal("TenNguoiDung")),
                            NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                            DanhSachNhomPhanQuyenID = ParseDanhSach(reader.IsDBNull(reader.GetOrdinal("DanhSachNhomPhanQuyenID")) ? "" : reader.GetString(reader.GetOrdinal("DanhSachNhomPhanQuyenID")))
                        };
                        canBoList.Add(canBo);
                    }

                    // Kiểm tra xem có cột TotalRecords hay không
                    if (await reader.NextResultAsync() && await reader.ReadAsync())
                    {
                        totalRecords = reader.GetInt32(0);
                    }
                }
            }
        }

        return (canBoList, totalRecords);
    }


    public async Task<CanBo> CanBoGetByID(int canBoId)
    {
        CanBo canBo = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("v1_HeThong_CanBo_GetByID", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CanBoID", canBoId);
                await connection.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        canBo = new CanBo
                        {
                            CanBoID = reader.GetInt32(reader.GetOrdinal("CanBoID")),
                            TenCanBo = reader.GetString(reader.GetOrdinal("TenCanBo")),
                            NgaySinh = reader.IsDBNull(reader.GetOrdinal("NgaySinh")) ? null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                            GioiTinh = reader.IsDBNull(reader.GetOrdinal("GioiTinh")) ? null : reader.GetInt32(reader.GetOrdinal("GioiTinh")),
                            DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : reader.GetString(reader.GetOrdinal("DiaChi")),
                            Email =  reader.GetString(reader.GetOrdinal("Email")),
                            DienThoai = reader.IsDBNull(reader.GetOrdinal("DienThoai")) ? null : reader.GetString(reader.GetOrdinal("DienThoai")),
                            TrangThai = reader.GetInt32(reader.GetOrdinal("TrangThai")),
                            CoQuanID = reader.GetInt32(reader.GetOrdinal("CoQuanID")),
                            TenNguoiDung = reader.GetString(reader.GetOrdinal("TenNguoiDung")),
                            NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                            DanhSachNhomPhanQuyenID = ParseDanhSach(reader.IsDBNull(reader.GetOrdinal("DanhSachNhomPhanQuyenID")) ? "" : reader.GetString(reader.GetOrdinal("DanhSachNhomPhanQuyenID")))
                        };
                    }
                }
            }
        }

        return canBo;
    }


    public async Task<int> CanBoAdd(CanBoAddModel model)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand("v1_HeThong_CanBo_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TenCanBo", model.TenCanBo);
                command.Parameters.AddWithValue("@NgaySinh", model.NgaySinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@GioiTinh", model.GioiTinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DiaChi", model.DiaChi ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@DienThoai", model.DienThoai ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TrangThai", model.TrangThai);
                command.Parameters.AddWithValue("@CoQuanID", model.CoQuanID);
                command.Parameters.AddWithValue("@TenNguoiDung", model.TenNguoiDung);
                command.Parameters.AddWithValue("@MatKhau", "123456");

                // Convert List<int> to comma-separated string
                var danhSachNhomPhanQuyenStr = model.DanhSachNhomPhanQuyenID != null && model.DanhSachNhomPhanQuyenID.Any()
                               ? string.Join(",", model.DanhSachNhomPhanQuyenID)
                               : (object)DBNull.Value;
                command.Parameters.AddWithValue("@DanhSachNhomPhanQuyenID", danhSachNhomPhanQuyenStr);
                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
        }
    }


    public async Task<int> CanBoUpdate(CanBoUpdateModel model)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand("v1_HeThong_CanBo_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CanBoID", model.CanBoID);
                command.Parameters.AddWithValue("@TenCanBo", model.TenCanBo);
                command.Parameters.AddWithValue("@NgaySinh", model.NgaySinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@GioiTinh", model.GioiTinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DiaChi", model.DiaChi ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", model.Email); // BẮT BUỘC
                command.Parameters.AddWithValue("@DienThoai", model.DienThoai ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TrangThai", model.TrangThai);
                command.Parameters.AddWithValue("@CoQuanID", model.CoQuanID); // BẮT BUỘC
                command.Parameters.AddWithValue("@TenNguoiDung", model.TenNguoiDung ?? (object)DBNull.Value);

                // Convert List<int> to comma-separated string (nullable handling)
                var danhSachNhomPhanQuyenStr = model.DanhSachNhomPhanQuyenID != null
                                               ? string.Join(",", model.DanhSachNhomPhanQuyenID)
                                               : (object)DBNull.Value;
                command.Parameters.AddWithValue("@DanhSachNhomPhanQuyenID", danhSachNhomPhanQuyenStr);

                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
        }
    }


    public async Task<int> CanBoDelete(int canBoId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("v1_HeThong_CanBo_Delete", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CanBoID", canBoId);
                await connection.OpenAsync();
                return await cmd.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task<NguoiDung> LayTheoEmail(string email)
    {
        NguoiDung user = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("NguoiDung_GetByEmail", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                await connection.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        user = new NguoiDung
                        {
                            NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                            TenNguoiDung = reader.GetString(reader.GetOrdinal("TenNguoiDung")),
                            //MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                            GhiChu = !reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? reader.GetString(reader.GetOrdinal("GhiChu")) : null,
                            CanBoID = reader.GetInt32(reader.GetOrdinal("CanBoID"))
                        };
                    }
                }
            }
        }

        return user;
    }


    public async Task<CanBo> CanBoGetByEmail(string email)
    {
        CanBo canBo = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("v1_HeThong_CanBo_GetByEmail", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                await connection.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        canBo = new CanBo
                        {
                            CanBoID = reader.GetInt32(reader.GetOrdinal("CanBoID")),
                            TenCanBo = reader.GetString(reader.GetOrdinal("TenCanBo")),
                            NgaySinh = reader.IsDBNull(reader.GetOrdinal("NgaySinh")) ? null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                            GioiTinh = reader.IsDBNull(reader.GetOrdinal("GioiTinh")) ? null : reader.GetInt32(reader.GetOrdinal("GioiTinh")),
                            DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : reader.GetString(reader.GetOrdinal("DiaChi")),
                            Email =  reader.GetString(reader.GetOrdinal("Email")),
                            DienThoai = reader.IsDBNull(reader.GetOrdinal("DienThoai")) ? null : reader.GetString(reader.GetOrdinal("DienThoai")),
                            TrangThai = reader.GetInt32(reader.GetOrdinal("TrangThai")),
                            CoQuanID = reader.GetInt32(reader.GetOrdinal("CoQuanID")),
                        };
                    }
                }
            }
        }

        return canBo;
    }


    public async Task<CanBo> CanBoGetByName(string tenCanBo)
    {
        CanBo canBo = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("v1_HeThong_CanBo_GetByName", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenCanBo", tenCanBo);
                await connection.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        canBo = new CanBo
                        {
                            CanBoID = reader.GetInt32(reader.GetOrdinal("CanBoID")),
                            TenCanBo = reader.GetString(reader.GetOrdinal("TenCanBo")),
                            NgaySinh = reader.IsDBNull(reader.GetOrdinal("NgaySinh")) ? null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                            GioiTinh = reader.IsDBNull(reader.GetOrdinal("GioiTinh")) ? null : reader.GetInt32(reader.GetOrdinal("GioiTinh")),
                            DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : reader.GetString(reader.GetOrdinal("DiaChi")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            DienThoai = reader.IsDBNull(reader.GetOrdinal("DienThoai")) ? null : reader.GetString(reader.GetOrdinal("DienThoai")),
                            TrangThai = reader.GetInt32(reader.GetOrdinal("TrangThai")),
                            CoQuanID = reader.GetInt32(reader.GetOrdinal("CoQuanID")),
                            //TenNguoiDung = reader.GetString(reader.GetOrdinal("TenNguoiDung")),
                            //NguoiDungID = reader.GetInt32(reader.GetOrdinal("NguoiDungID")),
                            //DanhSachNhomPhanQuyenID = ParseDanhSach(reader.IsDBNull(reader.GetOrdinal("DanhSachNhomPhanQuyenID")) ? "" : reader.GetString(reader.GetOrdinal("DanhSachNhomPhanQuyenID")))
                        };
                    }
                }
            }
        }

        return canBo;
    }


    private List<int> ParseDanhSach(string? danhSach)
    {
        if (string.IsNullOrWhiteSpace(danhSach))
            return new List<int>();

        try
        {
            return danhSach.Split(',')
                           .Select(s => int.TryParse(s.Trim(), out var num) ? num : (int?)null)
                           .Where(n => n.HasValue)
                           .Select(n => n.Value)
                           .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing: {danhSach} - {ex.Message}");
            return new List<int>();
        }
    }
}
