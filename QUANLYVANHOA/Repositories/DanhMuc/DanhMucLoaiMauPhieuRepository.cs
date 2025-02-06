using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using QUANLYVANHOA.Models.DanhMuc;
using QUANLYVANHOA.Interfaces.DanhMuc;

namespace QUANLYVANHOA.Repositories.DanhMuc
{
    public class DanhMucLoaiMauPhieuRepository : IDanhMucLoaiMauPhieuRepository
    {
        private readonly string _connectionString;

        public DanhMucLoaiMauPhieuRepository(IConfiguration configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }

        public async Task<(IEnumerable<DanhMucLoaiMauPhieu>, int)> GetAll(string name,string? note ,int pageNumber, int pageSize)
        {
            var loaiMauPhieuList = new List<DanhMucLoaiMauPhieu>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("LMP_GetListPaging", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenLoaiMauPhieu", name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@GhiChu",note ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            loaiMauPhieuList.Add(new DanhMucLoaiMauPhieu
                            {
                                LoaiMauPhieuID = reader.GetInt32(reader.GetOrdinal("LoaiMauPhieuID")),
                                TenLoaiMauPhieu = reader.GetString(reader.GetOrdinal("TenLoaiMauPhieu")),
                                MaLoaiMauPhieu = reader.GetString(reader.GetOrdinal("MaLoaiMauPhieu")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                GhiChu = reader.GetString(reader.GetOrdinal("GhiChu")),
                                Loai = reader.GetInt32(reader.GetOrdinal("Loai"))
                            });
                        }

                        await reader.NextResultAsync();
                        if (await reader.ReadAsync())
                        {
                            totalRecords = reader.GetInt32(reader.GetOrdinal("TotalRecords"));
                        }
                    }
                }
            }

            return (loaiMauPhieuList, totalRecords);
        }

        public async Task<DanhMucLoaiMauPhieu> GetByID(int id)
        {
            DanhMucLoaiMauPhieu loaiMauPhieu = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("LMP_GetByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoaiMauPhieuID", id);
                    await connection.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            loaiMauPhieu = new DanhMucLoaiMauPhieu
                            {
                                LoaiMauPhieuID = reader.GetInt32(reader.GetOrdinal("LoaiMauPhieuID")),
                                TenLoaiMauPhieu = reader.GetString(reader.GetOrdinal("TenLoaiMauPhieu")),
                                MaLoaiMauPhieu = reader.GetString(reader.GetOrdinal("MaLoaiMauPhieu")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                GhiChu = reader.GetString(reader.GetOrdinal("GhiChu")),
                                Loai = reader.GetInt32(reader.GetOrdinal("Loai"))
                            };
                        }
                    }
                }
            }

            return loaiMauPhieu;
        }

        public async Task<int> Insert(DanhMucLoaiMauPhieuModelInsert loaiMauPhieu)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("LMP_Insert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenLoaiMauPhieu", loaiMauPhieu.TenLoaiMauPhieu);
                    cmd.Parameters.AddWithValue("@MaLoaiMauPhieu", loaiMauPhieu.MaLoaiMauPhieu);
                    cmd.Parameters.AddWithValue("@GhiChu", loaiMauPhieu.GhiChu);
                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Update(DanhMucLoaiMauPhieuModelUpdate loaiMauPhieu)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("LMP_Update", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoaiMauPhieuID", loaiMauPhieu.LoaiMauPhieuID);
                    cmd.Parameters.AddWithValue("@TenLoaiMauPhieu", loaiMauPhieu.TenLoaiMauPhieu);
                    cmd.Parameters.AddWithValue("@MaLoaiMauPhieu", loaiMauPhieu.MaLoaiMauPhieu);
                    cmd.Parameters.AddWithValue("@GhiChu", loaiMauPhieu.GhiChu);
                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("LMP_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoaiMauPhieuID", id);

                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
