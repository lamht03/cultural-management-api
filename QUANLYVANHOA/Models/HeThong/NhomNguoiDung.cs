using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.HeThong
{
    public class NhomNguoiDung
    {
        [JsonPropertyName("NhomNguoiDung")]
        public int NhomNguoiDungID { get; set; }

        [JsonPropertyName("NguoiDungID")]
        public int NguoiDungID { get; set; }

        [JsonPropertyName("NhomPhanQuyen")]
        public int NhomPhanQuyen { get; set; }
    }

    public class ThemNguoiDungVaoNhomPhanQuyenModel
    {
        [JsonPropertyName("NguoiDungID")]
        public int NguoiDungID { get; set; }

        [JsonPropertyName("NhomPhanQuyenID")]
        public int NhomPhanQuyenID { get; set; }
    }

    public class XoaNguoiDungKhoiNhomPhanQuyenModel
    {

        [JsonPropertyName("NguoiDungID")]
        public int NguoiDungID { get; set; }

        [JsonPropertyName("NhomNguoiDungID")]
        public int NhomPhanQuyenID { get; set; }
    }
}
