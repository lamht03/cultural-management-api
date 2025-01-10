using System.Collections.Generic;
using System.Threading.Tasks;
using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Interfaces.DanhMuc
{
    public interface IDanhMucChiTieuRepository
    {
        Task<(IEnumerable<DanhMucChiTieu>, int)> GetAll(string? name/*, int pageNumber, int pageSize*/);
        Task<DanhMucChiTieu> GetByID(int id);
        Task<IEnumerable<DanhMucChiTieu>> GetByLoaiMauPhieuID(int loaiMauPhieuID);
        Task<int> Insert(DanhMucChiTieuInsertModel chiTieu);
        Task<int> InsertChildren(DanhMucChiTieuInsertChidrenModel chiTieuModelInsertChidren);
        Task<int> Update(DanhMucChiTieuUpdateModel chiTieu);
        Task<int> Delete(int id);
    }
}
