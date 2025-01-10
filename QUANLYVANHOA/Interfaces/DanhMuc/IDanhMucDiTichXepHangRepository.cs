using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Interfaces.DanhMuc
{
    public interface IDanhMucDiTichXepHangRepository
    {
        Task<(IEnumerable<DanhMucDiTichXepHang>, int)> GetAll(string? name, int pageNumber, int pageSize);
        Task<DanhMucDiTichXepHang> GetByID(int id);
        Task<int> Insert(DanhMucDiTichXepHangModelInsert obj);
        Task<int> Update(DanhMucDiTichXepHangModelUpdate obj);
        Task<int> Delete(int id);
    }
}
