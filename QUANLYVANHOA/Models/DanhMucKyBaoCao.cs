using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models
{
    public class DanhMucKyBaoCao
    {
        [JsonPropertyName("KyBaoCaoID")]
        public int KyBaoCaoID { get; set; }


        [JsonPropertyName("KyBaoCaoChaID")]
        public  int KyBaoCaoChaID { get; set; }


        [JsonPropertyName("TenKyBaoCao")]
        public string TenKyBaoCao { get; set; }


        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get;     set; }


        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }


        [JsonPropertyName("LoaiKyBaoCao")]
        public int LoaiKyBaoCao { get; set; }
    }

    public class DanhMucKyBaoCaoModelInsert
    {
        [JsonPropertyName("TenKyBaoCao")]
        public string TenKyBaoCao { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }

    public class DanhMucKyBaoCaoModelUpdate
    {
        [JsonPropertyName("KyBaoCaoID")]
        public int KyBaoCaoID { get; set; }

        [JsonPropertyName("TenKyBaoCao")]
        public string TenKyBaoCao { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string GhiChu { get; set; }
    }
}
