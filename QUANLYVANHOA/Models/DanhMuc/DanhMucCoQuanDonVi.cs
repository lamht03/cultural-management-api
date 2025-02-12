using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Org.BouncyCastle.Utilities.IO.Pem;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.DanhMuc
{
    public class DanhMucCoQuanDonVi
    {
        [JsonPropertyName("CoQuanID")]
        public int CoQuanID { get; set; }

        [JsonPropertyName("TenCoQuan")]
        public string TenCoQuan { get; set; }

        [JsonPropertyName("MaCoQuan")]
        public string MaCoQuan { get; set; }

        [JsonPropertyName("CoQuanChaID")]
        public int? CoQuanChaID { get; set; }

        [JsonPropertyName("CapID")]
        public int CapID { get; set; }

        [JsonPropertyName("ThamQuyenID")]
        public int? ThamQuyenID { get; set; }

        [JsonPropertyName("TinhID")]
        public int TinhID { get; set; }

        [JsonPropertyName("HuyenID")]
        public int HuyenID { get; set; }

        [JsonPropertyName("XaID")]
        public int? XaID { get; set; }

        [JsonPropertyName("CQCoHieuLuc")]
        public bool? CQCoHieuLuc { get; set; }

        [JsonPropertyName("CQCapUBND")]
        public bool? CQCapUBND { get; set; }

        [JsonPropertyName("CQCapThanhTra")]
        public bool? CQCapThanhTra { get; set; }

        [JsonPropertyName("CQThuocHeThongPM")]
        public bool? CQThuocHeThongPM { get; set; }

        [JsonPropertyName("QTCanBoTiepDan")]
        public bool? QTCanBoTiepDan { get; set; }

        [JsonPropertyName("QTVanThuTiepNhanDon")]
        public bool? QTVanThuTiepNhanDon { get; set; }

        [JsonPropertyName("QTTiepCongDanVaXuLyDonPhucTap")]
        public bool? QTTiepCongDanVaXuLyDonPhucTap { get; set; }

        [JsonPropertyName("QTGiaiQuyetPhucTap")]
        public bool? QTGiaiQuyetPhucTap { get; set; }

        [JsonPropertyName("Cap")]
        public int Cap { get; set; }
        public List<DanhMucCoQuanDonVi> Children { get; set; } = new List<DanhMucCoQuanDonVi>(); // Child nodes
    }

    public class DanhMucCoQuanInsertModel
    {
        [JsonPropertyName("TenCoQuan")]
        public string TenCoQuan { get; set; }

        [JsonPropertyName("MaCoQuan")]
        public string MaCoQuan { get; set; }

        [JsonPropertyName("CoQuanChaID")]
        public int? CoQuanChaID { get; set; }

        [JsonPropertyName("CapID")]
        public int CapID { get; set; }

        [JsonPropertyName("ThamQuyenID")]
        public int ThamQuyenID { get; set; }

        [JsonPropertyName("TinhID")]
        public int TinhID { get; set; }

        [JsonPropertyName("HuyenID")]
        public int HuyenID { get; set; }

        [JsonPropertyName("XaID")]
        public int XaID { get; set; }

        [JsonPropertyName("CQCoHieuLuc")]
        public bool? CQCoHieuLuc { get; set; }

        [JsonPropertyName("CQCapUBND")]
        public bool? CQCapUBND { get; set; }

        [JsonPropertyName("CQCapThanhTra")]
        public bool? CQCapThanhTra { get; set; }

        [JsonPropertyName("CQThuocHeThongPM")]
        public bool? CQThuocHeThongPM { get; set; }

        [JsonPropertyName("QTCanBoTiepDan")]
        public bool? QTCanBoTiepDan { get; set; }

        [JsonPropertyName("QTVanThuTiepNhanDon")]
        public bool? QTVanThuTiepNhanDon { get; set; }

        [JsonPropertyName("QTTiepCongDanVaXuLyDonPhucTap")]
        public bool? QTTiepCongDanVaXuLyDonPhucTap { get; set; }

        [JsonPropertyName("QTGiaiQuyetPhucTap")]
        public bool? QTGiaiQuyetPhucTap { get; set; }

        [JsonPropertyName("TenCoQuanCha")]
        public string? TenCoQuanCha { get; set; }
    }



    public class DanhMucCoQuanUpdateModel
    {
        [JsonPropertyName("CoQuanID")]
        public  int CoQuanID { get; set; }

        [JsonPropertyName("TenCoQuan")]
        public string TenCoQuan { get; set; }

        [JsonPropertyName("MaCoQuan")]
        public string MaCoQuan { get; set; }

        [JsonPropertyName("CoQuanChaID")]
        public int? CoQuanChaID { get; set; }

        [JsonPropertyName("CapID")]
        public int CapID { get; set; }

        [JsonPropertyName("ThamQuyenID")]
        public int ThamQuyenID { get; set; }

        [JsonPropertyName("TinhID")]
        public int TinhID { get; set; }

        [JsonPropertyName("HuyenID")]
        public int HuyenID { get; set; }

        [JsonPropertyName("XaID")]
        public int XaID { get; set; }

        [JsonPropertyName("CQCoHieuLuc")]
        public bool? CQCoHieuLuc { get; set; }

        [JsonPropertyName("CQCapUBND")]
        public bool? CQCapUBND { get; set; }

        [JsonPropertyName("CQCapThanhTra")]
        public bool? CQCapThanhTra { get; set; }

        [JsonPropertyName("CQThuocHeThongPM")]
        public bool? CQThuocHeThongPM { get; set; }

        [JsonPropertyName("QTCanBoTiepDan")]
        public bool? QTCanBoTiepDan { get; set; }

        [JsonPropertyName("QTVanThuTiepNhanDon")]
        public bool? QTVanThuTiepNhanDon { get; set; }

        [JsonPropertyName("QTTiepCongDanVaXuLyDonPhucTap")]
        public bool? QTTiepCongDanVaXuLyDonPhucTap { get; set; }

        [JsonPropertyName("QTGiaiQuyetPhucTap")]
        public bool? QTGiaiQuyetPhucTap { get; set; }

        [JsonPropertyName("TenCoQuanCha")]
        public string? TenCoQuanCha { get; set; }

    }



    public class DanhMucTinh
    {
        [JsonPropertyName("TinhID")]
        public int TinhID { get; set; }

        [JsonPropertyName("TenTinh")]
        public string TenTinh { get; set; }

        [JsonPropertyName("TenDayDu")]
        public string TenDayDu { get; set; }

        [JsonPropertyName("MappingCode")]
        public string MappingCode { get; set; }

        [JsonPropertyName("LoaiDiaDanh")]
        public int LoaiDiaDanh { get; set; }
    }

    public class DanhMucHuyen
    {
        [JsonPropertyName("HuyenID")]
        public int HuyenID { get; set; }

        [JsonPropertyName("TinhID")]
        public int TinhID { get; set; }

        [JsonPropertyName("TenHuyen")]
        public string TenHuyen { get; set; }

        [JsonPropertyName("TenDayDu")]
        public string TenDayDu { get; set; }

        [JsonPropertyName("MappingCode")]
        public string MappingCode { get; set; }

        [JsonPropertyName("LoaiDiaDanh")]
        public int LoaiDiaDanh { get; set; }
    }

    public class DanhMucXa
    {
        [JsonPropertyName("XaID")]
        public int XaID { get; set; }

        [JsonPropertyName("HuyenID")]
        public int HuyenID { get; set; }

        [JsonPropertyName("TenXa")]
        public string TenXa { get; set; }

        [JsonPropertyName("TenDayDu")]
        public string TenDayDu { get; set; }

        [JsonPropertyName("MappingCode")]
        public string MappingCode { get; set; }

        [JsonPropertyName("LoaiDiaDanh")]
        public int LoaiDiaDanh { get; set; }
    }

    public class DanhMucCap
    {
        [JsonPropertyName("CapID")]
        public int CapID { get; set; }

        [JsonPropertyName("TenCap")]
        public string TenCap { get; set; }

        [JsonPropertyName("ThuTu")]
        public int ThuTu { get; set; }
    }

    public class DanhMucThamQuyen
    {
        [JsonPropertyName("ThamQuyenID")]
        public int ThamQuyenID { get; set; }

        [JsonPropertyName("TenThamQuyen")]
        public string TenThamQuyen { get; set; }

        [JsonPropertyName("MaThamQuyen")]
        public string MaThamQuyen { get; set; }
        
        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }
    }

}