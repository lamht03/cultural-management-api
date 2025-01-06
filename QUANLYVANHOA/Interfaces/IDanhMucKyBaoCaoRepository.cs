using QUANLYVANHOA.Models.DanhMuc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QUANLYVANHOA.Interfaces
{
    public interface IDanhMucKyBaoCaoRepository
    {
        Task<(IEnumerable<DanhMucKyBaoCao>, int)> GetAll(string? name, int pageNumber, int pageSize);
        Task<DanhMucKyBaoCao> GetByID(int id);
        Task<int> Insert(DanhMucKyBaoCaoModelInsert obj);
        Task<int> Update(DanhMucKyBaoCaoModelUpdate obj);
        Task<int> Delete(int id);
    }
}
