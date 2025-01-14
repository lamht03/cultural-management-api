using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.HeThong
{
    public class HeThongNhomChucNang
    {
        [JsonPropertyName("NhomChucNangID")]
        public int NhomChucNangID { get; set; }

        [JsonPropertyName("ChucNangID")]
        public int ChucNangID { get; set; }

        [JsonPropertyName("NhomPhanQuyenID")]
        public int NhomPhanQuyenID { get; set; }

        [JsonPropertyName("Quyen")]
        public int Quyen { get; set; }
    }

    public class NhomChucNangInsertModel
    {
        [JsonPropertyName("ChucNangID")]
        public int ChucNangID { get; set; }

        [JsonPropertyName("NhomPhanQuyenID")]
        public int NhomPhanQuyenID { get; set; }

        [JsonPropertyName("Quyen")]
        public int Quyen { get; set; }
    }
}
