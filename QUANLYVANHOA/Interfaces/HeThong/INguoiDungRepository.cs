using System.Collections.Generic;
using System.Threading.Tasks;
using QUANLYVANHOA.Models.HeThong;

namespace QUANLYVANHOA.Interfaces.HeThong
{
    public interface INguoiDungRepository
    {
        Task<(IEnumerable<NguoiDung>, int)> LayDanhSachPhanTrang(string? userName, int pageNumber, int pageSize);
        Task<NguoiDung> LayTheoID(int userId);
        Task<NguoiDung> LayTheoEmail(string email);

        Task<int> TaoNguoiDungMoi(NguoiDungInsertModel user);
        Task<int> SuaThongTinNguoiDung(NguoiDungUpdateModel user);
        Task<int> XoaThongTinNguoiDung(int userId);
        Task<NguoiDung> DangNhap(string userName, string password);
        Task<int> DangKyTaiKhoan(RegisterModel model);

        Task TaoPhienDangNhap(int userId, string refreshToken, DateTime expiryDate);
        Task<PhienDangNhap> LayPhienDangNhapTheoRefreshToken(string refreshToken);
        Task CapNhatRefreshToken(int sessionId, string newRefreshToken, DateTime newExpiryDate);
        Task VoHieuHoaPhienDangNhap(int sessionId);
        Task VoHieuHoaTatCaPhienDangNhapCuaNguoiDung(int userId);
        Task XoaTatCaPhienDangNhapCuaNguoiDung(int userId);

    }
}