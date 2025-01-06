using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.DanhMuc
{
    public class DanhMucLoaiMauPhieu
    {
        [JsonPropertyName("LoaiMauPhieuID")]
        public int LoaiMauPhieuID { get; set; }

        [JsonPropertyName("LoaiMauPhieuChaID")]
        public int LoaiMauPhieuChaID { get; set; }

        [JsonPropertyName("TenLoaiMauPhieu")]
        public string TenLoaiMauPhieu { get; set; }

        [JsonPropertyName("MaLoaiMauPhieu")]
        public string MaLoaiMauPhieu { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }

        [JsonPropertyName("Loai")]
        public int Loai { get; set; }
    }

    public class DanhMucLoaiMauPhieuModelInsert
    {
        [JsonPropertyName("TenLoaiMauPhieu")]
        public string TenLoaiMauPhieu { get; set; }

        [JsonPropertyName("MaLoaiMauPhieu")]
        public string MaLoaiMauPhieu { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }

    public class DanhMucLoaiMauPhieuModelUpdate
    {
        [JsonPropertyName("LoaiMauPhieuID")]
        public int LoaiMauPhieuID { get; set; }

        [JsonPropertyName("TenLoaiMauPhieu")]
        public string TenLoaiMauPhieu { get; set; }

        [JsonPropertyName("MaLoaiMauPhieu")]
        public string MaLoaiMauPhieu { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }
}
