using QUANLYVANHOA.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Repositories
{
    public class DanhMucLoaiDiTichRepository : IDanhMucLoaiDiTichRepository
    {
        private readonly string _connectionString;

        public DanhMucLoaiDiTichRepository(IConfiguration configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }

        public async Task<(IEnumerable<DanhMucLoaiDiTich>, int)> GetAll(string name, int pageNumber, int pageSize)
        {
            var loaiDiTichList = new List<DanhMucLoaiDiTich>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("LDT_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenLoaiDiTich", name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            loaiDiTichList.Add(new DanhMucLoaiDiTich
                            {
                                LoaiDiTichID = reader.GetInt32(reader.GetOrdinal("LoaiDiTichID")),
                                LoaiDiTichChaID = reader.GetInt32(reader.GetOrdinal("LoaiDiTichChaID")),
                                TenLoaiDiTich = reader.GetString(reader.GetOrdinal("TenLoaiDiTich")),
                                MaLoaiDiTich = reader.GetString(reader.GetOrdinal("MaLoaiDiTich")),
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

            return (loaiDiTichList, totalRecords);
        }

        public async Task<DanhMucLoaiDiTich> GetByID(int id)
        {
            DanhMucLoaiDiTich loaiDiTich = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("LDT_GetByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoaiDiTichID", id);
                    await connection.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            loaiDiTich = new DanhMucLoaiDiTich
                            {
                                LoaiDiTichID = reader.GetInt32(reader.GetOrdinal("LoaiDiTichID")),
                                LoaiDiTichChaID = reader.GetInt32(reader.GetOrdinal("LoaiDiTichChaID")),
                                TenLoaiDiTich = reader.GetString(reader.GetOrdinal("TenLoaiDiTich")),
                                MaLoaiDiTich = reader.GetString(reader.GetOrdinal("MaLoaiDiTich")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                GhiChu = reader.GetString(reader.GetOrdinal("GhiChu")),
                                Loai = reader.GetInt32(reader.GetOrdinal("Loai"))
                            };
                        }
                    }
                }
            }

            return loaiDiTich;
        }

        public async Task<int> Insert(DanhMucLoaiDiTichModelInsert loaiDiTich)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("LDT_Insert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenLoaiDiTich", loaiDiTich.TenLoaiDiTich);
                    cmd.Parameters.AddWithValue("@GhiChu", loaiDiTich.GhiChu);
                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Update(DanhMucLoaiDiTichModelUpdate loaiDiTich)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("LDT_Update", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoaiDiTichID", loaiDiTich.LoaiDiTichID);
                    cmd.Parameters.AddWithValue("@TenLoaiDiTich", loaiDiTich.TenLoaiDiTich);
                    cmd.Parameters.AddWithValue("@GhiChu", loaiDiTich.GhiChu);
                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("LDT_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoaiDiTichID", id);

                    await connection.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
