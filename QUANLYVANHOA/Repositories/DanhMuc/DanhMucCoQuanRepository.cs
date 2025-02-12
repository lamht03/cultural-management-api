using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using QUANLYVANHOA.Interfaces.DanhMuc;
using QUANLYVANHOA.Models.DanhMuc;
using System.Data;
namespace QUANLYVANHOA.Repositories.DanhMuc
{
    public class DanhMucCoQuanRepository : IDanhMucCoQuanDonViRepository
    {
        private readonly string _connectionString;

        public DanhMucCoQuanRepository(IConfiguration configuration)
        {
            _connectionString = new Connection().GetConnectionString();
        }


        public async Task<(IEnumerable<DanhMucCoQuanDonVi>, int)> DanhMucCoQuanGetAll(string? name/*, int pageNumber, int pageSize*/)
        {
            var coQuanList = new List<DanhMucCoQuanDonVi>();
            int totalRecords = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("DMCoQuan_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 120;
                    command.Parameters.AddWithValue("@TenCoQuan", name ?? (object)DBNull.Value);
                    //command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    //command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var danhMucCoQuan = new DanhMucCoQuanDonVi
                            {
                                CoQuanID = reader.GetInt32(reader.GetOrdinal("CoQuanID")),
                                TenCoQuan = reader.GetString(reader.GetOrdinal("TenCoQuan")),
                                MaCoQuan = reader["MaCoQuan"].ToString(),
                                CoQuanChaID = reader.IsDBNull(reader.GetOrdinal("CoQuanChaID")) ? null : reader.GetInt32(reader.GetOrdinal("CoQuanChaID")),
                                //GhiChu = reader.GetString(readerGetOrdinal("GhiChu")),
                                CapID = reader.GetInt32(reader.GetOrdinal("CapID")),
                                ThamQuyenID = reader.IsDBNull(reader.GetOrdinal("ThamQuyenID")) ? null : reader.GetInt32(reader.GetOrdinal("ThamQuyenID")),
                                TinhID = reader.GetInt32(reader.GetOrdinal("TinhID")),
                                HuyenID = reader.GetInt32(reader.GetOrdinal("HuyenID")),
                                XaID = reader.IsDBNull(reader.GetOrdinal("XaID")) ? null : reader.GetInt32(reader.GetOrdinal("XaID")),
                                CQCoHieuLuc = reader.IsDBNull(reader.GetOrdinal("CQCoHieuLuc")) ? null : reader.GetBoolean(reader.GetOrdinal("CQCoHieuLuc")),
                                CQCapUBND = reader.IsDBNull(reader.GetOrdinal("CQCapUBND")) ? null : reader.GetBoolean(reader.GetOrdinal("CQCapUBND")),
                                CQCapThanhTra = reader.IsDBNull(reader.GetOrdinal("CQCapThanhTra")) ? null : reader.GetBoolean(reader.GetOrdinal("CQCapThanhTra")),
                                CQThuocHeThongPM = reader.IsDBNull(reader.GetOrdinal("CQThuocHeThongPM")) ? null : reader.GetBoolean(reader.GetOrdinal("CQThuocHeThongPM")),
                                QTCanBoTiepDan = reader.IsDBNull(reader.GetOrdinal("QTCanBoTiepDan")) ? null : reader.GetBoolean(reader.GetOrdinal("QTCanBoTiepDan")),
                                QTVanThuTiepNhanDon = reader.IsDBNull(reader.GetOrdinal("QTVanThuTiepNhanDon")) ? null : reader.GetBoolean(reader.GetOrdinal("QTVanThuTiepNhanDon")),
                                QTTiepCongDanVaXuLyDonPhucTap = reader.IsDBNull(reader.GetOrdinal("QTTiepCongDanVaXuLyDonPhucTap")) ? null : reader.GetBoolean(reader.GetOrdinal("QTTiepCongDanVaXuLyDonPhucTap")),
                                QTGiaiQuyetPhucTap = reader.IsDBNull(reader.GetOrdinal("QTGiaiQuyetPhucTap")) ? null : reader.GetBoolean(reader.GetOrdinal("QTGiaiQuyetPhucTap")),
                                Cap = reader.GetInt32(reader.GetOrdinal("CapDo"))
                            };

                            coQuanList.Add(danhMucCoQuan);
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
            var coQuanHierarchy = BuildHierarchy(coQuanList);

            return (coQuanHierarchy, totalRecords);
        }

        private IEnumerable<DanhMucCoQuanDonVi> BuildHierarchy(List<DanhMucCoQuanDonVi> coQuanList)
        {
            var lookup = coQuanList.ToLookup(ct => ct.CoQuanChaID ?? 0); // Tạo lookup từ ChiTieuChaID
            List<DanhMucCoQuanDonVi> hierarchy = new List<DanhMucCoQuanDonVi>();

            foreach (var coQuan in coQuanList.Where(ct => (ct.CoQuanChaID ?? 0) == 0))
            {
                hierarchy.Add(BuildCoQuanWithChildren(coQuan, lookup));
            }

            return hierarchy;
        }

        private DanhMucCoQuanDonVi BuildCoQuanWithChildren(DanhMucCoQuanDonVi coQuan, ILookup<int, DanhMucCoQuanDonVi> lookup)
        {
            var children = lookup[coQuan.CoQuanID].ToList();

            foreach (var child in children)
            {
                coQuan.Children.Add(BuildCoQuanWithChildren(child, lookup));
            }

            return coQuan;
        }


        public async Task<DanhMucCoQuanDonVi> DanhMucCoQuanGetByID(int id)
        {
            DanhMucCoQuanDonVi coQuan = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMCoQuan_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CoQuanID", id);
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            coQuan = new DanhMucCoQuanDonVi
                            {
                                CoQuanID = reader.GetInt32(reader.GetOrdinal("CoQuanID")),
                                TenCoQuan = reader.GetString(reader.GetOrdinal("TenCoQuan")),
                                MaCoQuan = reader["MaCoQuan"].ToString(),
                                CoQuanChaID = reader.IsDBNull(reader.GetOrdinal("CoQuanChaID")) ? null : reader.GetInt32(reader.GetOrdinal("CoQuanChaID")),
                                //GhiChu = reader.GetString(readerGetOrdinal("GhiChu")),
                                CapID = reader.GetInt32(reader.GetOrdinal("CapID")),
                                ThamQuyenID = reader.IsDBNull(reader.GetOrdinal("ThamQuyenID")) ? null : reader.GetInt32(reader.GetOrdinal("ThamQuyenID")),
                                TinhID = reader.GetInt32(reader.GetOrdinal("TinhID")),
                                HuyenID = reader.GetInt32(reader.GetOrdinal("HuyenID")),
                                XaID = reader.IsDBNull(reader.GetOrdinal("XaID")) ? null : reader.GetInt32(reader.GetOrdinal("XaID")),
                                CQCoHieuLuc = reader.IsDBNull(reader.GetOrdinal("CQCoHieuLuc")) ? null : reader.GetBoolean(reader.GetOrdinal("CQCoHieuLuc")),
                                CQCapUBND = reader.IsDBNull(reader.GetOrdinal("CQCapUBND")) ? null : reader.GetBoolean(reader.GetOrdinal("CQCapUBND")),
                                CQCapThanhTra = reader.IsDBNull(reader.GetOrdinal("CQCapThanhTra")) ? null : reader.GetBoolean(reader.GetOrdinal("CQCapThanhTra")),
                                CQThuocHeThongPM = reader.IsDBNull(reader.GetOrdinal("CQThuocHeThongPM")) ? null : reader.GetBoolean(reader.GetOrdinal("CQThuocHeThongPM")),
                                QTCanBoTiepDan = reader.IsDBNull(reader.GetOrdinal("QTCanBoTiepDan")) ? null : reader.GetBoolean(reader.GetOrdinal("QTCanBoTiepDan")),
                                QTVanThuTiepNhanDon = reader.IsDBNull(reader.GetOrdinal("QTVanThuTiepNhanDon")) ? null : reader.GetBoolean(reader.GetOrdinal("QTVanThuTiepNhanDon")),
                                QTTiepCongDanVaXuLyDonPhucTap = reader.IsDBNull(reader.GetOrdinal("QTTiepCongDanVaXuLyDonPhucTap")) ? null : reader.GetBoolean(reader.GetOrdinal("QTTiepCongDanVaXuLyDonPhucTap")),
                                QTGiaiQuyetPhucTap = reader.IsDBNull(reader.GetOrdinal("QTGiaiQuyetPhucTap")) ? null : reader.GetBoolean(reader.GetOrdinal("QTGiaiQuyetPhucTap")),
                            };
                        }

                    }
                }
            }
            return coQuan;
        }


        public async Task<int> DanhMucCoQuanAdd(DanhMucCoQuanInsertModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMCoQuan_Add", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaCoQuan", model.MaCoQuan);
                    command.Parameters.AddWithValue("@TenCoQuan", model.TenCoQuan);
                    command.Parameters.AddWithValue("@CoQuanChaID", model.CoQuanChaID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CapID", model.CapID);
                    command.Parameters.AddWithValue("@ThamQuyenID", model.ThamQuyenID);
                    command.Parameters.AddWithValue("@TinhID", model.TinhID);
                    command.Parameters.AddWithValue("@HuyenID", model.HuyenID);
                    command.Parameters.AddWithValue("@XaID", model.XaID);
                    command.Parameters.AddWithValue("@CQCoHieuLuc", model.CQCoHieuLuc ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CQCapUBND", model.CQCapUBND ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CQCapThanhTra", model.CQCapThanhTra ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CQThuocHeThongPM", model.CQThuocHeThongPM ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QTCanBoTiepDan", model.QTCanBoTiepDan ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QTVanThuTiepNhanDon", model.QTVanThuTiepNhanDon ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QTTiepCongDanVaXuLyDonPhucTap", model.QTTiepCongDanVaXuLyDonPhucTap ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QTGiaiQuyetPhucTap", model.QTGiaiQuyetPhucTap ?? (object)DBNull.Value);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }

            }
        }


        public async Task <int> DanhMucCoQuanUpdate (DanhMucCoQuanUpdateModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMCoQuan_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CoQuanID", model.CoQuanID);
                    command.Parameters.AddWithValue("@MaCoQuan", model.MaCoQuan);
                    command.Parameters.AddWithValue("@TenCoQuan", model.TenCoQuan);
                    command.Parameters.AddWithValue("@CoQuanChaID", model.CoQuanChaID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CapID", model.CapID);
                    command.Parameters.AddWithValue("@ThamQuyenID", model.ThamQuyenID);
                    command.Parameters.AddWithValue("@TinhID", model.TinhID);
                    command.Parameters.AddWithValue("@HuyenID", model.HuyenID);
                    command.Parameters.AddWithValue("@XaID", model.XaID);
                    command.Parameters.AddWithValue("@CQCoHieuLuc", model.CQCoHieuLuc ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CQCapUBND", model.CQCapUBND ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CQCapThanhTra", model.CQCapThanhTra ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CQThuocHeThongPM", model.CQThuocHeThongPM ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QTCanBoTiepDan", model.QTCanBoTiepDan ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QTVanThuTiepNhanDon", model.QTVanThuTiepNhanDon ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QTTiepCongDanVaXuLyDonPhucTap", model.QTTiepCongDanVaXuLyDonPhucTap ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QTGiaiQuyetPhucTap", model.QTGiaiQuyetPhucTap ?? (object)DBNull.Value);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DanhMucCoQuanDelete(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMCoQuan_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CoQuanID", id);
                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }



        public async Task<IEnumerable<DanhMucTinh>> DMTinhGetAll()
        {
            var danhMucTinhList = new List<DanhMucTinh>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DMTinh_GetAll",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            danhMucTinhList.Add(new DanhMucTinh
                            {
                                TinhID = reader.GetInt32(reader.GetOrdinal("TinhID")),
                                TenTinh = reader.GetString(reader.GetOrdinal("TenTinh")),
                                TenDayDu = reader.GetString(reader.GetOrdinal("TenDayDu"))
                            });
                        }
                    }

                }

            }
            return danhMucTinhList;
        }


        public async Task<DanhMucTinh> DMTinhGetByID(int id)
        {
            DanhMucTinh danhMucTinh = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMTinh_GetByID",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TinhID", id);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync()) 
                    { 
                        if(await reader.ReadAsync())
                        {
                            danhMucTinh = new DanhMucTinh
                            {
                                TinhID = reader.GetInt32(reader.GetOrdinal("TinhID")),
                                TenTinh = reader.GetString(reader.GetOrdinal("TenTinh")),
                                TenDayDu = reader.GetString(reader.GetOrdinal("TenDayDu"))
                            };
                        }
                    }

                }

            }
            return danhMucTinh;
        }



        public async Task<IEnumerable<DanhMucHuyen>> DMHuyenGetByTinhID(int id)
        {
            var danhMucHuyenList = new List<DanhMucHuyen>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DMHuyen_GetByTinhID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TinhID", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            danhMucHuyenList.Add(new DanhMucHuyen
                            {
                                HuyenID = reader.GetInt32(reader.GetOrdinal("HuyenID")),
                                TinhID = reader.GetInt32(reader.GetOrdinal("TinhID")),
                                TenHuyen = reader.GetString(reader.GetOrdinal("TenHuyen")),
                                TenDayDu = reader.GetString(reader.GetOrdinal("TenDayDu"))
                            });
                        }
                    }

                }

            }
            return danhMucHuyenList;
        }

        public async Task<DanhMucHuyen> DMHuyenGetByID(int id)
        {
            DanhMucHuyen danhMucHuyen = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMHuyen_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@HuyenID", id);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            danhMucHuyen = new DanhMucHuyen
                            {
                                HuyenID = reader.GetInt32(reader.GetOrdinal("HuyenID")),
                                TinhID = reader.GetInt32(reader.GetOrdinal("TinhID")),
                                TenHuyen = reader.GetString(reader.GetOrdinal("TenHuyen")),
                                TenDayDu = reader.GetString(reader.GetOrdinal("TenDayDu"))
                            };
                        }
                    }

                }

            }
            return danhMucHuyen;
        }

        public async Task<IEnumerable<DanhMucXa>> DMXaGetByHuyenID(int id)
        {
            var danhMucXaList = new List<DanhMucXa>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DMXa_GetByHuyenID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@HuyenID", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            danhMucXaList.Add(new DanhMucXa
                            {
                                XaID = reader.GetInt32(reader.GetOrdinal("XaID")),
                                HuyenID = reader.GetInt32(reader.GetOrdinal("HuyenID")),
                                TenXa = reader.GetString(reader.GetOrdinal("TenXa")),
                                TenDayDu = reader.GetString(reader.GetOrdinal("TenDayDu"))
                            });
                        }
                    }

                }

            }
            return danhMucXaList;
        }

        public async Task<DanhMucXa> DMXaGetByID(int id)
        {
            DanhMucXa danhMucXa = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMXa_GetByID",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@XaID", id);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            danhMucXa = new DanhMucXa
                            {
                                XaID = reader.GetInt32(reader.GetOrdinal("XaID")),
                                HuyenID = reader.GetInt32(reader.GetOrdinal("HuyenID")),
                                TenXa = reader.GetString(reader.GetOrdinal("TenXa")),
                                TenDayDu = reader.GetString(reader.GetOrdinal("TenDayDu"))
                            };
                        }
                    }

                }

            }
            return danhMucXa;
        }

        public async Task<IEnumerable<DanhMucCap>> DMCapGetAll()
        {
            var danhMucCapList = new List<DanhMucCap>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DMCap_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            danhMucCapList.Add(new DanhMucCap
                            {
                                CapID = reader.GetInt32(reader.GetOrdinal("CapID")),
                                TenCap = reader.GetString(reader.GetOrdinal("TenCap")),
                                ThuTu = reader.GetInt32(reader.GetOrdinal("ThuTu"))
                            });
                        }
                    }

                }

            }
            return danhMucCapList;
        }

        public async Task<DanhMucCap> DMCapGetByID(int id)
        {
            DanhMucCap danhMucCap = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMCap_GetByID",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CapID", id);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            danhMucCap = new DanhMucCap
                            {
                                CapID = reader.GetInt32(reader.GetOrdinal("CapID")),
                                TenCap = reader.GetString(reader.GetOrdinal("TenCap")),
                                ThuTu = reader.GetInt32(reader.GetOrdinal("ThuTu")),
                            };
                        }
                    }

                }

            }
            return danhMucCap;
        }

        public async Task<IEnumerable<DanhMucThamQuyen>> DMThamQuyenGetAll()
        {
            var danhMucThamQuyenList = new List<DanhMucThamQuyen>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DMThamQuyen_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            danhMucThamQuyenList.Add(new DanhMucThamQuyen
                            {
                                ThamQuyenID = reader.GetInt32(reader.GetOrdinal("ThamQuyenID")),
                                TenThamQuyen = reader.GetString(reader.GetOrdinal("TenThamQuyen"))
                            });
                        }
                    }

                }

            }
            return danhMucThamQuyenList;
        }

        public async Task<DanhMucThamQuyen> DMThamQuyenGetByID(int id)
        {
            DanhMucThamQuyen danhMucThamQuyen = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DMThamQuyen_GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ThamQuyenID", id);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            danhMucThamQuyen = new DanhMucThamQuyen
                            {
                                ThamQuyenID = reader.GetInt32(reader.GetOrdinal("ThamQuyenID")),
                                TenThamQuyen = reader.GetString(reader.GetOrdinal("TenThamQuyen")),
                            };
                        }
                    }

                }

            }
            return danhMucThamQuyen;
        }


    }
}

