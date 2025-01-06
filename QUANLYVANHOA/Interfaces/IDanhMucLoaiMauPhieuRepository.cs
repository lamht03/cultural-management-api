using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Interfaces
{
    public interface IDanhMucLoaiMauPhieuRepository
    {
        Task<(IEnumerable<DanhMucLoaiMauPhieu>, int)> GetAll(string? name, int pageNumber, int pageSize);
        Task<DanhMucLoaiMauPhieu> GetByID(int id);
        Task<int> Insert(DanhMucLoaiMauPhieuModelInsert obj);
        Task<int> Update(DanhMucLoaiMauPhieuModelUpdate obj);
        Task<int> Delete(int id);
    }
}
