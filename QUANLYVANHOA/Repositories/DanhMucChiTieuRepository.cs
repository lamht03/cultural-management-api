using QUANLYVANHOA.Interfaces;
using QUANLYVANHOA.Models.DanhMuc;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYVANHOA.Repositories
{
    public class DanhMucChiTieuRepository : IDanhMucChiTieuRepository
    {
        private readonly string _connectionString;
        public DanhMucChiTieuRepository(IConfiguration configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }

        public async Task<(IEnumerable<DanhMucChiTieu>, int)> GetAll(string? name/*, int pageNumber, int pageSize*/)
        {
            var chiTieuList = new List<DanhMucChiTieu>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("CT_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 120;
                    command.Parameters.AddWithValue("@TenChiTieu", name ?? (object)DBNull.Value);
                    //command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    //command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var chiTieu = new DanhMucChiTieu
                            {
                                ChiTieuID = reader.GetInt32(reader.GetOrdinal("ChiTieuID")),
                                MaChiTieu = reader["MaChiTieu"].ToString(),
                                TenChiTieu = reader["TenChiTieu"].ToString(),
                                ChiTieuChaID = reader.IsDBNull(reader.GetOrdinal("ChiTieuChaID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ChiTieuChaID")),
                                GhiChu = reader["GhiChu"].ToString(),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                LoaiMauPhieuID = reader.GetInt32(reader.GetOrdinal("LoaiMauPhieuID"))
                            };

                            chiTieuList.Add(chiTieu);
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
            var chiTieuHierarchy = BuildHierarchy(chiTieuList);

            return (chiTieuHierarchy, totalRecords);
        }

        public async Task<DanhMucChiTieu> GetByID(int id)
        {
            DanhMucChiTieu chiTieu = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("CT_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChiTieuID", id);
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            chiTieu = new DanhMucChiTieu
                            {
                                ChiTieuID = reader.GetInt32(reader.GetOrdinal("ChiTieuID")),
                                MaChiTieu = reader["MaChiTieu"].ToString(),
                                TenChiTieu = reader["TenChiTieu"].ToString(),
                                ChiTieuChaID = reader.IsDBNull(reader.GetOrdinal("ChiTieuChaID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ChiTieuChaID")),
                                GhiChu = reader["GhiChu"].ToString(),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                LoaiMauPhieuID = reader.GetInt32(reader.GetOrdinal("LoaiMauPhieuID"))
                            };
                        }
                    }
                }
            }

            return chiTieu;
        }

        public async Task<IEnumerable<DanhMucChiTieu>> GetByLoaiMauPhieuID(int loaiMauPhieuID)
        {
            var chiTieuList = new List<DanhMucChiTieu>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("CT_GetByLoaiMauPhieuID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 120; // Increase Connection Timeout 

                    command.Parameters.AddWithValue("@LoaiMauPhieuID", loaiMauPhieuID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var chiTieu = new DanhMucChiTieu
                            {
                                ChiTieuID = reader.GetInt32(reader.GetOrdinal("ChiTieuID")),
                                MaChiTieu = reader["MaChiTieu"].ToString(),
                                TenChiTieu = reader["TenChiTieu"].ToString(),
                                ChiTieuChaID = reader.IsDBNull(reader.GetOrdinal("ChiTieuChaID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ChiTieuChaID")),
                                GhiChu = reader["GhiChu"].ToString(),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                LoaiMauPhieuID = reader.GetInt32(reader.GetOrdinal("LoaiMauPhieuID"))
                            };

                            chiTieuList.Add(chiTieu);
                        }
                    }
                }

                // After fetching the data, build the hierarchy
                var chiTieuHierarchy = BuildHierarchy(chiTieuList);

                return (chiTieuHierarchy);
            }
        }

        public async Task<int> Insert(DanhMucChiTieuInsertModel chiTieu)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("CT_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaChiTieu", chiTieu.MaChiTieu);
                    command.Parameters.AddWithValue("@TenChiTieu", chiTieu.TenChiTieu);
                    command.Parameters.AddWithValue("@ChiTieuChaID", chiTieu.ChiTieuChaID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@GhiChu", chiTieu.GhiChu ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LoaiMauPhieuID", chiTieu.LoaiMauPhieuID); // Sửa lỗi kiểu dữ liệu

                    await connection.OpenAsync();   
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> InsertChildren(DanhMucChiTieuInsertChidrenModel chiTieuModelInsertChidren)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("CT_InsertChildren", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số vào stored procedure
                    command.Parameters.AddWithValue("@ChiTieuChaID", chiTieuModelInsertChidren.ChiTieuChaID);
                    command.Parameters.AddWithValue("@TenChiTieu", chiTieuModelInsertChidren.TenChiTieu);
                    command.Parameters.AddWithValue("@MaChiTieu", chiTieuModelInsertChidren.MaChiTieu);
                    command.Parameters.AddWithValue("@GhiChu", chiTieuModelInsertChidren.GhiChu);

                    // Thực thi stored procedure
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task<int> Update(DanhMucChiTieuUpdateModel chiTieu)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("CT_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChiTieuID", chiTieu.ChiTieuID);
                    command.Parameters.AddWithValue("@MaChiTieu", chiTieu.MaChiTieu);
                    command.Parameters.AddWithValue("@TenChiTieu", chiTieu.TenChiTieu);
                    command.Parameters.AddWithValue("@ChiTieuChaID", chiTieu.ChiTieuChaID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@GhiChu", chiTieu.GhiChu ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LoaiMauPhieuID", chiTieu.LoaiMauPhieuID); // Sửa lỗi kiểu dữ liệu

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("CT_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChiTieuID", id);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        //private List<DanhMucChiTieu> BuildHierarchy(List<DanhMucChiTieu> chiTieuList)
        //{
        //    var lookup = chiTieuList.ToLookup(c => c.ChiTieuChaID);
        //    var rootItems = lookup[0].ToList();

        //    // Để đảm bảo tất cả các cấp độ của cây đều được bao gồm
        //    foreach (var item in chiTieuList)
        //    {
        //        var parent = chiTieuList.FirstOrDefault(c => c.ChiTieuID == item.ChiTieuChaID);
        //        if (parent != null)
        //        {
        //            parent.Children.Add(item);
        //        }
        //    }

        //    return rootItems;
        //}


        private IEnumerable<DanhMucChiTieu> BuildHierarchy(List<DanhMucChiTieu> chiTieuList)
        {
            var lookup = chiTieuList.ToLookup(ct => ct.ChiTieuChaID); // Tạo lookup từ ChiTieuChaID
            List<DanhMucChiTieu> hierarchy = new List<DanhMucChiTieu>();

            foreach (var chiTieu in chiTieuList.Where(ct => ct.ChiTieuChaID == 0))
            {
                hierarchy.Add(BuildChiTieuWithChildren(chiTieu, lookup));
            }

            return hierarchy;
        }

        private DanhMucChiTieu BuildChiTieuWithChildren(DanhMucChiTieu chiTieu, ILookup<int, DanhMucChiTieu> lookup)
        {
            var children = lookup[chiTieu.ChiTieuID].ToList();

            foreach (var child in children)
            {
                chiTieu.Children.Add(BuildChiTieuWithChildren(child, lookup));
            }

            return chiTieu;
        }

    }
}
