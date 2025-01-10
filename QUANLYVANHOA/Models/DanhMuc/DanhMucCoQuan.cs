using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Org.BouncyCastle.Utilities.IO.Pem;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.DanhMuc
{
    public class DanhMucCoQuan
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

        public int Cap { get; set; }
        public List<DanhMucCoQuan> Children { get; set; } = new List<DanhMucCoQuan>(); // Child nodes
    }

    public class DanhMucCoQuanInsertModel
    {
        [JsonPropertyName("TenCoQuan")]
        public string TenCoQuan { get; set; }

        [JsonPropertyName("MaCoQuan")]
        public string MaCoQuan { get; set; }

        [JsonPropertyName("CoQuanChaID")]
        public int CoQuanChaID { get; set; }

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
    }



    public class DanhMucCoQuanUpdateModel
    {
        [JsonPropertyName("TenCoQuan")]
        public string TenCoQuan { get; set; }

        [JsonPropertyName("MaCoQuan")]
        public string MaCoQuan { get; set; }

        [JsonPropertyName("CoQuanChaID")]
        public int CoQuanChaID { get; set; }

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
    }

}