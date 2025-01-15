namespace QUANLYVANHOA.Models.HeThong
{
    public class PhienDangNhap
    {
        public int PhienDangNhapID { get; set; }
        public int NguoiDungID { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
