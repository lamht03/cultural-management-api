﻿using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Interfaces.DanhMuc
{
    public interface IDanhMucLoaiMauPhieuRepository
    {
        Task<(IEnumerable<DanhMucLoaiMauPhieu>, int)> GetAll(string? name,string? note, int pageNumber, int pageSize);
        Task<DanhMucLoaiMauPhieu> GetByID(int id);
        Task<int> Insert(DanhMucLoaiMauPhieuModelInsert obj);
        Task<int> Update(DanhMucLoaiMauPhieuModelUpdate obj);
        Task<int> Delete(int id);
    }
}
