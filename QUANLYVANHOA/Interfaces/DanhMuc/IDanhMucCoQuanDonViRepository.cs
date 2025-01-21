using QUANLYVANHOA.Models.DanhMuc;

namespace QUANLYVANHOA.Interfaces.DanhMuc
{
    public interface IDanhMucCoQuanDonViRepository
    {
        Task<(IEnumerable<DanhMucCoQuanDonVi>,int)> DanhMucCoQuanGetAll(string? tenCoQuan);
        Task <DanhMucCoQuanDonVi> DanhMucCoQuanGetByID(int id);
        Task <int> DanhMucCoQuanAdd (DanhMucCoQuanInsertModel model);
        Task <int> DanhMucCoQuanUpdate (DanhMucCoQuanUpdateModel model);
        Task <int> DanhMucCoQuanDelete (int id);

        Task<IEnumerable<DanhMucTinh>>     DMTinhGetAll      ();
        Task<DanhMucTinh>                  DMTinhGetByID     (int id);

        Task<IEnumerable<DanhMucHuyen>>    DMHuyenGetByTinhID(int huyenId);
        Task<DanhMucHuyen>                 DMHuyenGetByID    (int id);

        Task<IEnumerable<DanhMucXa>>       DMXaGetByHuyenID  (int huyenID);
        Task<DanhMucXa>                    DMXaGetByID       (int id);

        Task<IEnumerable<DanhMucCap>>      DMCapGetAll       ();
        Task<DanhMucCap>                   DMCapGetByID      (int id);

        Task<IEnumerable<DanhMucThamQuyen>>DMThamQuyenGetAll ();
        Task<DanhMucThamQuyen>             DMThamQuyenGetByID(int id);
    }
}
