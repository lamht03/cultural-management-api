using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.HeThong
{
    public class HeThongChucNang
    {
        [JsonPropertyName("ChucNangID")]
        public int ChucNangID { get; set; }

        [JsonPropertyName("TenChucNang")]
        public string TenChucNang { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }

    public class HeThongChucNangInsertModel
    {
        [JsonPropertyName("TenChucNang")]
        public string TenChucNang { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }

    public class HeThongChucNangUpdateModel
    {
        [JsonPropertyName("ChucNangID")]
        public int ChucNangID { get; set; }

        [JsonPropertyName("TenChucNang")]
        public string TenChucNang { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }
}
