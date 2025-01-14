using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Interfaces.DanhMuc
{
    public interface IDanhMucCoQuanRepository
    {
        Task<IEnumerable<DanhMucCoQuan>> DanhMucCoQuanGetAll(string tenCoQuan);
    }
}
