using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Core.DTO
{
    public class NguoiDungTrongNhomPhanQuyenDTO
    {
        [JsonPropertyName("NguoiDungID")]
        public int NguoiDungID { get; set; }

        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }

        [JsonPropertyName("TenDayDu")]
        public string TenDayDu { get; set; }

        [JsonPropertyName("NhomPhanQuyenID")]
        public int NhomPhanQuyenID { get; set; }

        [JsonPropertyName("TenNhomPhanQuyen")]
        public string TenNhomPhanQuyen { get; set; }
    }
}
