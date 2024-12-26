using QUANLYVANHOA.Models;

namespace QUANLYVANHOA.Interfaces
{
    public interface IDanhMucLoaiDiTichRepository
    {
        Task<(IEnumerable<DanhMucLoaiDiTich>, int)> GetAll(string? name, int pageNumber, int pageSize);
        Task<DanhMucLoaiDiTich> GetByID(int id);
        Task<int> Insert(DanhMucLoaiDiTichModelInsert obj);
        Task<int> Update(DanhMucLoaiDiTichModelUpdate obj);
        Task<int> Delete(int id);
    }
}
