using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.DanhMuc
{
    public class DanhMucChiTieu
    {
        [JsonPropertyName("ChiTieuID")]
        public int ChiTieuID { get; set; }

        [JsonPropertyName("MaChiTieu")]
        public string MaChiTieu { get; set; }

        [JsonPropertyName("TenChiTieu")]
        public string TenChiTieu { get; set; }

        [JsonPropertyName("ChiTieuChaID")]
        public int ChiTieuChaID { get; set; }

        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("LoaiMauPhieuID")]
        public int LoaiMauPhieuID { get; set; }
        public List<DanhMucChiTieu>? Children { get; set; } = new List<DanhMucChiTieu>();
    }

    public class DanhMucChiTieuInsertModel
    {
        [JsonPropertyName("MaChiTieu")]
        public string MaChiTieu { get; set; }

        [JsonPropertyName("TenChiTieu")]
        public string TenChiTieu { get; set; }

        [JsonPropertyName("ChiTieuChaID")]
        public int? ChiTieuChaID { get; set; }

        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }

        [JsonPropertyName("LoaiMauPhieuID")]
        public int LoaiMauPhieuID { get; set; }

        [JsonPropertyName("TenChiTieuCha")]
        public string TenChiTieuCha { get; set; }


    }

    public class DanhMucChiTieuInsertChidrenModel
    {
        [JsonPropertyName("MaChiTieu")]
        public string MaChiTieu { get; set; }

        [JsonPropertyName("TenChiTieu")]
        public string TenChiTieu { get; set; }

        [JsonPropertyName("ChiTieuChaID")]
        public int? ChiTieuChaID { get; set; }

        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }
    }

    public class DanhMucChiTieuUpdateModel
    {
        [JsonPropertyName("ChiTieuID")]
        public int ChiTieuID { get; set; }

        [JsonPropertyName("ChiTieuChaID")]
        public int? ChiTieuChaID { get; set; }

        [JsonPropertyName("MaChiTieu")]
        public string MaChiTieu { get; set; }

        [JsonPropertyName("TenChiTieu")]
        public string TenChiTieu { get; set; }

        [JsonPropertyName("LoaiMauPhieuID")]
        public int LoaiMauPhieuID { get; set; }

        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }

        [JsonPropertyName("TenChiTieuCha")]
        public string TenChiTieuCha { get; set; }
    }
}
