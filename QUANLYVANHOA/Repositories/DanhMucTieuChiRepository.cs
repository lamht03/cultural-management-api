using QUANLYVANHOA.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Repositories
{
    public class DanhMucTieuChiRepository : IDanhMucTieuChiRepository
    {
        private readonly string _connectionString;

        public DanhMucTieuChiRepository(IConfiguration configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }

        public async Task<(IEnumerable<DanhMucTieuChi>, int)> GetAll(string? name/*, int pageNumber, int pageSize*/)
        {
            var tieuChiList = new List<DanhMucTieuChi>();
            int totalRecords = 0;


            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("TC_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 120;
                    command.Parameters.AddWithValue("@TenTieuChi", name ?? (object)DBNull.Value);
                    //command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    //command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tieuChiList.Add(new DanhMucTieuChi
                            {
                                TieuChiID = reader.GetInt32("TieuChiID"),
                                MaTieuChi = reader["MaTieuChi"].ToString(),
                                TenTieuChi = reader["TenTieuChi"].ToString(),
                                TieuChiChaID = reader["TieuChiChaID"] as int?,
                                GhiChu = reader["GhiChu"].ToString(),
                                KieuDuLieuCot = reader["KieuDuLieuCot"] as int?,
                                TrangThai = reader.GetBoolean("TrangThai"),
                                LoaiTieuChi = reader["LoaiTieuChi"] as int?,
                                CapDo = reader["CapDo"] as int?
                            });
                        }

                        //await reader.NextResultAsync();
                        //if (await reader.ReadAsync())
                        //{
                        //    totalRecords = reader.GetInt32(reader.GetOrdinal("TotalRecords"));
                        //}
                    }
                }
            }

            // After fetching the data, build the hierarchy
            var tieuChiHierarchy = BuildHierarchy(tieuChiList);

            return (tieuChiHierarchy, totalRecords);
        }

        public async Task<DanhMucTieuChi> GetByID(int id)
        {
            DanhMucTieuChi tieuChi = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("TC_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TieuChiID", id);
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            tieuChi = new DanhMucTieuChi
                            {
                                TieuChiID = reader.GetInt32("TieuChiID"),
                                MaTieuChi = reader["MaTieuChi"].ToString(),
                                TenTieuChi = reader["TenTieuChi"].ToString(),
                                TieuChiChaID = reader["TieuChiChaID"] as int?,
                                GhiChu = reader["GhiChu"].ToString(),
                                KieuDuLieuCot = reader["KieuDuLieuCot"] as int?,
                                TrangThai = reader.GetBoolean("TrangThai") ,
                                LoaiTieuChi = reader["LoaiTieuChi"] as int?,
                                CapDo = reader["CapDo"] as int?
                            };
                        }
                    }
                }
            }

            return tieuChi;
        }

        public async Task<int> Insert(DanhMucTieuChiModelInsert tieuChi)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("TC_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaTieuChi", tieuChi.MaTieuChi);
                    command.Parameters.AddWithValue("@TenTieuChi", tieuChi.TenTieuChi);
                    command.Parameters.AddWithValue("@TieuChiChaID",tieuChi.TieuChiChaID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KieuDuLieuCot", tieuChi.KieuDuLieuCot ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LoaiTieuChi", tieuChi.LoaiTieuChi ?? (object)DBNull.Value);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Update(DanhMucTieuChiModelUpdate tieuChi)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("TC_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TieuChiID", tieuChi.TieuChiID);
                    command.Parameters.AddWithValue("@MaTieuChi", tieuChi.MaTieuChi);
                    command.Parameters.AddWithValue("@TenTieuChi", tieuChi.TenTieuChi);
                    command.Parameters.AddWithValue("@TieuChiChaID", tieuChi.TieuChiChaID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@GhiChu", tieuChi.GhiChu ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KieuDuLieuCot", tieuChi.KieuDuLieuCot ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LoaiTieuChi", tieuChi.LoaiTieuChi ?? (object)DBNull.Value);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("TC_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TieuChiID", id);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        private List<DanhMucTieuChi> BuildHierarchy(List<DanhMucTieuChi> tieuChiList)
        {
            var lookup = tieuChiList.ToLookup(c => c.TieuChiChaID);
            var rootItems = lookup[null].ToList();

            // Để đảm bảo tất cả các cấp độ của cây đều được bao gồm
            foreach (var item in tieuChiList)
            {
                if (item.TieuChiChaID.HasValue)
                {
                    var parent = tieuChiList.FirstOrDefault(c => c.TieuChiID == item.TieuChiChaID.Value);
                    if (parent != null)
                    {
                        parent.Children.Add(item);
                    }
                }
            }

            return rootItems;
        }

    }
}
