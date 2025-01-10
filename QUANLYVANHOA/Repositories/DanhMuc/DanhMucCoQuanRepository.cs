//using Microsoft.Data.SqlClient;
//using QUANLYVANHOA.Interfaces.DanhMuc;
//using QUANLYVANHOA.Models.DanhMuc;
//using System.Data;
//namespace QUANLYVANHOA.Repositories.DanhMuc
//{
//    public class DanhMucCoQuanRepository : IDanhMucCoQuanRepository
//    {
//        private readonly string _connectionString;
        
//        public DanhMucCoQuanRepository(string connectionString)
//        {
//            _connectionString = new Connection().GetConnectionString();
//        }


//        public async Task<IEnumerable<DanhMucCoQuan>> DanhMucCoQuanGetAll (string tenCoQuan)
//        {
//            var result = new List<DanhMucCoQuan>();

//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            {
//                await connection.OpenAsync();

//                using (SqlCommand command = new SqlCommand("DMCoQuanGetAll", connection))
//                {
//                    command.CommandType = CommandType.StoredProcedure;

//                    // Add parameters
//                    command.Parameters.AddWithValue("@TenCoQuan", (object)tenCoQuan ?? DBNull.Value);

//                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
//                    {
//                        while (await reader.ReadAsync())
//                        {
//                            result.Add(new DanhMucCoQuan
//                            {
//                                CoQuanID = reader.GetInt32(0),
//                                TenCoQuan = reader.GetString(1),
//                                MaCoQuan = reader.GetString(2),
//                                CoQuanChaID = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
//                                Cap = reader.GetInt32(4)
//                            });
//                        }
//                    }
//                }
//            }

//            return result;
//       }
//    }
//}

