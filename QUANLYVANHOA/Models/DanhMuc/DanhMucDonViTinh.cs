using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.DanhMuc
{
    public class DanhMucDonViTinh
    {
        [JsonPropertyName("DonViTinhID")]
        public int DonViTinhID { get; set; }

        [JsonPropertyName("TenDonViTinh")]
        public string TenDonViTinh { get; set; }

        [JsonPropertyName("MaDonViTinh")]
        public string MaDonViTinh { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }

    public class DanhMucDonViTinhModelInsert
    {
        [JsonPropertyName("TenDonViTinh")]
        public string TenDonViTinh { get; set; }

        [JsonPropertyName("MaDonViTinh")]
        public string MaDonViTinh { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }

    public class DanhMucDonViTinhModelUpdate
    {
        [JsonPropertyName("DonViTinhID")]
        public int DonViTinhID { get; set; }

        [JsonPropertyName("TenDonViTinh")]
        public string TenDonViTinh { get; set; }

        [JsonPropertyName("MaDonViTinh")]
        public string MaDonViTinh { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }
}
