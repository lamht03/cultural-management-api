using Azure.Core.Serialization;
using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Core.DTO
{
    public class ChucNangTrongNhomPhanQuyenDTO
    {
        [JsonPropertyName("ChucNangID")]
        public int ChucNangID { get; set; }

        [JsonPropertyName("TenChucNang")]
        public string TenChucNang { get; set; }

        [JsonPropertyName("NhomPhanQuyenID")]
        public int NhomPhanQuyenID { get; set; }

        [JsonPropertyName("NhomChucNangID")]
        public int NhomChucNangID { get; set; }


        [JsonPropertyName("TenNhomPhanQuyen")]
        public string TenNhomPhanQuyen { get; set; }

        [JsonPropertyName("Quyen")]
        public int Quyen { get; set; }

        [JsonPropertyName("Xem")]
        public bool Xem { get; set; }

        [JsonPropertyName("Them")]
        public bool Them { get; set; }

        [JsonPropertyName("Sua")]
        public bool Sua { get; set; }

        [JsonPropertyName("Xoa")]
        public bool Xoa { get; set; }
    }

    public class NhomChucNangUpdateDTO
    {
        [JsonPropertyName("NhomChucNangID")]
        public int NhomChucNangID { get; set; }

        [JsonPropertyName("Xem")]
        public bool Xem { get; set; }

        [JsonPropertyName("Them")]
        public bool Them { get; set; }

        [JsonPropertyName("Sua")]
        public bool Sua { get; set; }

        [JsonPropertyName("Xoa")]
        public bool Xoa { get; set; }
    }
}
