using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using QUANLYVANHOA.Models.DanhMuc;
using QUANLYVANHOA.Interfaces.DanhMuc;

namespace QUANLYVANHOA.Repositories.DanhMuc
{
    public class DanhMucDiTichXepHangRepository : IDanhMucDiTichXepHangRepository
    {
        private readonly string _connectionString;

        public DanhMucDiTichXepHangRepository(IConfiguration configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }

        public async Task<(IEnumerable<DanhMucDiTichXepHang>, int)> GetAll(string name, int pageNumber, int pageSize)
        {
            var ditichList = new List<DanhMucDiTichXepHang>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Lấy dữ liệu phân trang
                using (var command = new SqlCommand("DTXH_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenDiTich", name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ditichList.Add(new DanhMucDiTichXepHang
                            {
                                DiTichXepHangID = reader.GetInt32(reader.GetOrdinal("DiTichXepHangID")),
                                TenDiTich = reader.GetString(reader.GetOrdinal("TenDiTich")),
                                MaDiTich = reader.GetString(reader.GetOrdinal("MaDiTich")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                GhiChu = reader.GetString(reader.GetOrdinal("GhiChu")),
                                Loai = reader.GetInt32(reader.GetOrdinal("Loai"))
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

            return (ditichList, totalRecords);
        }

        public async Task<DanhMucDiTichXepHang> GetByID(int id)
        {
            DanhMucDiTichXepHang ditichXepHang = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DTXH_GetByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiTichXepHangID", id);
                    await connection.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            ditichXepHang = new DanhMucDiTichXepHang
                            {
                                DiTichXepHangID = reader.GetInt32(reader.GetOrdinal("DiTichXepHangID")),
                                DiTichXepHangChaID = reader.GetInt32(reader.GetOrdinal("DiTichXepHangChaID")),
                                TenDiTich = reader.GetString(reader.GetOrdinal("TenDiTich")),
                                MaDiTich = reader.GetString(reader.GetOrdinal("MaDiTich")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                GhiChu = reader.GetString(reader.GetOrdinal("GhiChu")),
                                Loai = reader.GetInt32(reader.GetOrdinal("Loai"))
                            };
                        }
                    }
                }
            }
            return ditichXepHang;
        }

        public async Task<int> Insert(DanhMucDiTichXepHangModelInsert diTichXepHang)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DTXH_Insert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDiTich", diTichXepHang.TenDiTich);
                    cmd.Parameters.AddWithValue("@GhiChu", diTichXepHang.GhiChu);
                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Update(DanhMucDiTichXepHangModelUpdate diTichXepHang)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DTXH_Update", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiTichXepHangID", diTichXepHang.DiTichXepHangID);
                    cmd.Parameters.AddWithValue("@TenDiTich", diTichXepHang.TenDiTich);
                    cmd.Parameters.AddWithValue("@GhiChu", diTichXepHang.GhiChu);
                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DTXH_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiTichXepHangID", id);

                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
