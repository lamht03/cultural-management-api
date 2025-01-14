using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.HeThong
{
    public class HeThongNhomPhanQuyen
    {
        [JsonPropertyName("NhomPhanQuyenID")]
        public int NhomPhanQuyenID { get; set; }

        [JsonPropertyName("TenNhomPhanQuyen")]
        public string TenNhomPhanQuyen { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }
    public class NhomNguoiDungInsertModel
    {
        [JsonPropertyName("TenNhomNguoiDung")]
        public string TenNhomNguoiDung { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }
    public class NhomPhanQuyenUpdateModel
    {
        [JsonPropertyName("NhomPhanQuyenID")]
        public int NhomPhanQuyenID { get; set; }

        [JsonPropertyName("TenNhomPhanQuyen")]
        public string TenNhomPhanQuyen { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }
}
