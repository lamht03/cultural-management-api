using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Interfaces
{
    public interface IDanhMucDonViTinhRepository
    {
        Task<(IEnumerable<DanhMucDonViTinh>, int)> GetAll(string? name, int pageNumber, int pageSize);
        Task<DanhMucDonViTinh> GetByID(int id);
        Task<int> Insert(DanhMucDonViTinhModelInsert obj);
        Task<int> Update(DanhMucDonViTinhModelUpdate obj);
        Task<int> Delete(int id);

    }
}
