using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.HeThong
{
    public class ChucNang
    {
        [JsonPropertyName("ChucNangID")]
        public int ChucNangID { get; set; }

        [JsonPropertyName("TenChucNang")]
        public string TenChucNang { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }

    public class ChucNangInsertModel
    {
        [JsonPropertyName("TenChucNang")]
        public string TenChucNang { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }

    public class ChucNangUpdateModel
    {
        [JsonPropertyName("ChucNangID")]
        public int ChucNangID { get; set; }

        [JsonPropertyName("TenChucNang")]
        public string TenChucNang { get; set; }

        [JsonPropertyName("MoTa")]
        public string MoTa { get; set; }
    }
}
