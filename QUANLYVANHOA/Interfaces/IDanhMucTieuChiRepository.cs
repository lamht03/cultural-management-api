using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Interfaces
{
    public interface IDanhMucTieuChiRepository
    {
        public Task<(IEnumerable<DanhMucTieuChi>, int)> GetAll(string? name/*, int pageNumber, int pageSize*/);
        public Task<DanhMucTieuChi> GetByID(int id);
        public Task<int> Insert(DanhMucTieuChiModelInsert obj);
        public Task<int> Update(DanhMucTieuChiModelUpdate obj);
        public Task<int> Delete(int id);

    }
}
