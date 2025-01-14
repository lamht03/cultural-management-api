using System.Collections.Generic;
using System.Threading.Tasks;
using QUANLYVANHOA.Models.HeThong;

namespace QUANLYVANHOA.Interfaces.HeThong
{
    public interface IHeThongNguoiDungRepository
    {
        Task<(IEnumerable<HeThongNguoiDung>, int)> LayDanhSachPhanTrang(string? userName, int pageNumber, int pageSize);
        Task<HeThongNguoiDung> LayTheoID(int userId);
        Task<HeThongNguoiDung> LayTheoEmail(string email);

        Task<int> TaoNguoiDungMoi(HeThongNguoiDungInsertModel user);
        Task<int> SuaThongTinNguoiDung(SysUserUpdateModel user);
        Task<int> XoaThongTinNguoiDung(int userId);
        Task<HeThongNguoiDung> DangNhap(string userName, string password);
        Task<int> DangKyTaiKhoan(RegisterModel model);

        Task TaoPhienDangNhap(int userId, string refreshToken, DateTime expiryDate);
        Task<HeThongPhienDangNhap> LayPhienDangNhapTheoRefreshToken(string refreshToken);
        Task CapNhatRefreshToken(int sessionId, string newRefreshToken, DateTime newExpiryDate);
        Task VoHieuHoaPhienDangNhap(int sessionId);
        Task VoHieuHoaTatCaPhienDangNhapCuaNguoiDung(int userId);
        Task XoaTatCaPhienDangNhapCuaNguoiDung(int userId);

    }
}