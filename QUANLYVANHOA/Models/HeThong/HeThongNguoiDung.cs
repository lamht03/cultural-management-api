﻿using System.Text.Json.Serialization;

namespace QUANLYVANHOA.Models.HeThong
{
    public class HeThongNguoiDung
    {
        [JsonPropertyName("NguoiDungID")]
        public int NguoiDungID { get; set; }

        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }

        [JsonPropertyName("TenDayDu")]
        public string? TenDayDu { get; set; }// alow null

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("MatKhau")]
        public string MatKhau { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }

    }

    public class LoginModel
    {
        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }
        [JsonPropertyName("MatKhau")]
        public string MatKhau { get; set; }
    }
    public class HeThongNguoiDungInsertModel
    {
        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }

        [JsonPropertyName("TenDayDu")]
        public string? TenDayDu{ get; set; }// alow null

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("MatKhau")]
        public string MatKhau { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }

    }

    public class SysUserUpdateModel
    {
        [JsonPropertyName("NguoiDungID")]
        public int NguoiDungID { get; set; }

        [JsonPropertyName("Ten")]
        public string TenNguoiDung { get; set; }

        [JsonPropertyName("TenDayDu")]
        public string? TenDayDu { get; set; }// alow null

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("MatKhau")]
        public string MatKhau { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }

    }


    public class RegisterModel
    {

        [JsonPropertyName("TenDayDu")]
        public string TenDayDu { get; set; }

        [JsonPropertyName("TenNguoiDung")]
        public string TenNguoiDung { get; set; }

        [JsonPropertyName("MatKhau")]
        public string MatKhau { get; set; }

        [JsonPropertyName("XacNhanMatKhau")]
        public string XacNhanMatKhau { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("TrangThai")]
        public bool TrangThai { get; set; }

        [JsonPropertyName("GhiChu")]
        public string? GhiChu { get; set; }
    }

    public class UpdateRefreshTokenModel
    {
        [JsonPropertyName("NguoiDungID")]
        public int NguoiDungID { get; set; }

        [JsonPropertyName("RefreshToken")]
        public string? RefreshToken { get; set; }

        [JsonPropertyName("RefreshTokenExpiryTime")]
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }

}
