using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models
{
    public class DanhMucDiTichXepHang
    {
        [JsonPropertyName("DiTichXepHangID")]
        public int DiTichXepHangID { get; set; }

        [JsonPropertyName("DiTichXepHangChaID")]
        public int DiTichXepHangChaID { get; set; }

        [JsonPropertyName("TenDiTich")]
        public string TenDiTich { get; set; }

        [JsonPropertyName("MaDiTich")]
        public string MaDiTich { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }

        [JsonPropertyName("Loai")]
        public int Loai { get; set; }
    }

    public class DanhMucDiTichXepHangModelInsert
    {
        [JsonPropertyName("TenDiTich")]
        public string TenDiTich { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }

    public class DanhMucDiTichXepHangModelUpdate
    {
        [JsonPropertyName("DiTichXepHangID")]
        public int DiTichXepHangID { get; set; }

        [JsonPropertyName("TenDiTich")]
        public string TenDiTich { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }

}
