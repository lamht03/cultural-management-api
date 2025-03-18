using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.HeThong
{
    public class NhomChucNang
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

        [JsonPropertyName("Xem")]
        public bool Xem { get; set; }

        [JsonPropertyName("Them")]
        public bool Them { get; set; }

        [JsonPropertyName("Sua")]
        public bool Sua { get; set; }

        [JsonPropertyName("Xoa")]
        public bool Xoa { get; set; }
    }

    public class NhomChucNangDeleteModel
    {
        [JsonPropertyName("ChucNangID")]
        public int ChucNangID { get; set; }

        [JsonPropertyName("NhomPhanQuyenID")]
        public int NhomPhanQuyenID { get; set; }
    }
}
