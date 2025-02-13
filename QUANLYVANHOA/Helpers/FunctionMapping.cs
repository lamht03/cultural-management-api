using QUANLYVANHOA.Core.Enums;

namespace QUANLYVANHOA.Helpers
{
    public static class FunctionMapping
    {
        public static readonly Dictionary<string, ChucNangEnums> Map = new()
        {
            { "Quản lý người dùng", ChucNangEnums.QuanLyNguoiDung },
            { "Quản lý di tích xếp hạng", ChucNangEnums.QuanLyDiTichXepHang },
            { "Quản lý đơn vị tính", ChucNangEnums.QuanLyDonViTinh },
            { "Quản lý kỳ báo cáo", ChucNangEnums.QuanLyKyBaoCao },
            { "Quản lý loại di tích", ChucNangEnums.QuanLyLoaiDiTich },
            { "Quản lý loại mẫu phiếu", ChucNangEnums.QuanLyLoaiMauPhieu },
            { "Quản lý tiêu chí", ChucNangEnums.QuanLyTieuChi },
            { "Quản lý chỉ tiêu", ChucNangEnums.QuanLyChiTieu },
            { "Quản lý mẫu phiếu báo cáo", ChucNangEnums.QuanLyMauPhieuBaoCao },
            { "Quản lý ủy quyền", ChucNangEnums.QuanLyUyQuyen },
            { "Quản lý cơ quan đơn vị", ChucNangEnums.QuanLyCoQuanDonVi }
        };
    }
}
