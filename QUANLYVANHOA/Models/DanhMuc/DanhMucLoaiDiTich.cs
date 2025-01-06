using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.DanhMuc
{
    public class DanhMucLoaiDiTich
    {
        [JsonPropertyName("LoaiDiTichID")]
        public int LoaiDiTichID { get; set; }

        [JsonPropertyName("LoaiDiTichChaID")]
        public int LoaiDiTichChaID { get; set; }

        [JsonPropertyName("TenLoaiDiTich")]
        public string TenLoaiDiTich { get; set; }

        [JsonPropertyName("MaLoaiDiTich")]
        public string MaLoaiDiTich { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }

        [JsonPropertyName("Loai")]
        public int Loai { get; set; }
    }

    public class DanhMucLoaiDiTichModelInsert
    {
        [JsonPropertyName("TenLoaiDiTich")]
        public string TenLoaiDiTich { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }

    public class DanhMucLoaiDiTichModelUpdate
    {
        [JsonPropertyName("LoaiDiTichID")]
        public int LoaiDiTichID { get; set; }

        [JsonPropertyName("TenLoaiDiTich")]
        public string TenLoaiDiTich { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }
}
