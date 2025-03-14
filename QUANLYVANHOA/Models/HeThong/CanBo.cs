using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.HeThong
{
    public class CanBo
    {
        [JsonPropertyName("CanBoID")]
        public int CanBoID { get; set; }

        [JsonPropertyName("TenCanBo")]
        public string TenCanBo { get; set; }

        [JsonPropertyName("NgaySinh")]
        public DateTime? NgaySinh { get; set; }

        [JsonPropertyName("GioiTinh")]
        public int? GioiTinh { get; set; }

        [JsonPropertyName("DiaChi")]
        public string? DiaChi { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("DienThoai")]
        public string? DienThoai { get; set; }

        [JsonPropertyName("TrangThai")]
        public int TrangThai { get; set; }

        [JsonPropertyName("CoQuanID")]
        public int CoQuanID { get; set; }

        [JsonPropertyName("TenNguoiDung")]

        public string TenNguoiDung { get; set; }

        [JsonPropertyName("DanhSachNhomPhanQuyenID")]
        public List<int>? DanhSachNhomPhanQuyenID { get; set; } = new List<int>();

        [JsonPropertyName("NguoiDungID")]
        public int NguoiDungID { get; set; }

        [JsonPropertyName("TenCoQuan")]
        public string TenCoQuan { get; set; }
    }


    public class CanBoAddModel
    {
        [JsonPropertyName("TenCanBo")]
        public string TenCanBo { get; set; }
        [JsonPropertyName("NgaySinh")]
        public DateTime? NgaySinh { get; set; }
        [JsonPropertyName("GioiTinh")]
        public int? GioiTinh { get; set; }
        [JsonPropertyName("DiaChi")]
        public string? DiaChi { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("DienThoai")]
        public string? DienThoai { get; set; }
        [JsonPropertyName("TrangThai")]
        public int TrangThai { get; set; }
        [JsonPropertyName("CoQuanID")]
        public int CoQuanID { get; set; }
        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }
        [JsonPropertyName("DanhSachNhomPhanQuyenID")]
        public List<int>? DanhSachNhomPhanQuyenID { get; set; } = new List<int>();
    }



    public class CanBoUpdateModel
    {
        [JsonPropertyName("CanBoID")]
        public int CanBoID { get; set; }
        [JsonPropertyName("TenCanBo")]
        public string TenCanBo { get; set; }
        [JsonPropertyName("NgaySinh")]
        public DateTime? NgaySinh { get; set; }
        [JsonPropertyName("GioiTinh")]
        public int? GioiTinh { get; set; }
        [JsonPropertyName("DiaChi")]
        public string? DiaChi { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("DienThoai")]
        public string? DienThoai { get; set; }
        [JsonPropertyName("TrangThai")]
        public int TrangThai { get; set; }
        [JsonPropertyName("CoQuanID")]
        public int CoQuanID { get; set; }
        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }
        [JsonPropertyName("DanhSachNhomPhanQuyenID")]
        public List<int>? DanhSachNhomPhanQuyenID { get; set; } = new List<int>();
    }
}
