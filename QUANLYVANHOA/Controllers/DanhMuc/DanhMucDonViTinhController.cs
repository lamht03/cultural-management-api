﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;
using QUANLYVANHOA.Models.DanhMuc;
using QUANLYVANHOA.Interfaces.DanhMuc;
using QUANLYVANHOA.Core.Enums;

namespace QUANLYVANHOA.Controllers.DanhMuc
{
    [Route("api/v1/DanhMucDonViTinh")]
    [ApiController]
    public class DanhMucDonViTinhController : ControllerBase
    {
        private readonly IDanhMucDonViTinhRepository _donViTinhRepository;

        public DanhMucDonViTinhController(IDanhMucDonViTinhRepository donViTinhRepository)
        {
            _donViTinhRepository = donViTinhRepository;
        }

        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyDonViTinh)]
        [HttpGet("DanhSachDonViTinh")]
        public async Task<IActionResult> GetAll(string? name, int pageNumber = 1, int pageSize = 20)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
            }
            // Validate pageNumber and pageSize
            if (pageNumber <= 0)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Invalid page number. Page number must be greater than 0."
                });
            }

            if (pageSize <= 0 || pageSize > 50)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Invalid page size. Page size must be between 1 and 50."
                });
            }

            var result = await _donViTinhRepository.GetAll(name, pageNumber, pageSize);
            var donViTinhList = result.Item1;
            var totalRecords = result.Item2;
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (!donViTinhList.Any())
            {
                return Ok(new
                {
                    Status = 0,
                    Message = "No data available",
                    Data = donViTinhList
                });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Get information successfully",
                Data = donViTinhList,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            });
        }

        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyDonViTinh)]
        [HttpGet("TimKiemDonViTinhTheoID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var donViTinh = await _donViTinhRepository.GetByID(id);
            if (donViTinh == null)
            {
                return Ok(new { Status = 0, Message = "Id not found" });
            }
            return Ok(new { Status = 1, Message = "Get information successfully", Data = donViTinh });
        }

        [CustomAuthorize(QuyenEnums.Them, ChucNangEnums.QuanLyDonViTinh)]
        [HttpPost("ThemMoiDonViTinh")]
        public async Task<IActionResult> Insert([FromBody] DanhMucDonViTinhModelInsert model)
        {
            var existingTenDonViTinh = await _donViTinhRepository.GetAll(model.TenDonViTinh, 1, 20);
            if (existingTenDonViTinh.Item1.Any())
            {
                return BadRequest(new { Status = 0, Message = "TenDonViTinh already exists" });
            }

            if (!string.IsNullOrWhiteSpace(model.TenDonViTinh))
            {
                model.TenDonViTinh = model.TenDonViTinh.Trim();
            }
            // Validate input data
            if (string.IsNullOrWhiteSpace(model.TenDonViTinh) || model.TenDonViTinh.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid TenDonViTinh. Must not be empty and not exceed 50 characters." });
            }

            if (string.IsNullOrWhiteSpace(model.MaDonViTinh) || model.MaDonViTinh.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid MaDonViTinh. Must not be empty and not exceed 50 characters." });
            }

            if (model.GhiChu.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Invalid GhiChu. Must not exceed 50 characters." });
            }

            // Create a new DanhMucDonViTinh object
            var newDonViTinh = new DanhMucDonViTinhModelInsert
            {
                TenDonViTinh = model.TenDonViTinh.Trim(),
                MaDonViTinh = model.MaDonViTinh.Trim(),
                GhiChu = model.GhiChu?.Trim(),
                TrangThai = model.TrangThai
            };

            // Insert the object into the database
            var result = await _donViTinhRepository.Insert(newDonViTinh);
            if (result > 0)
            {
                return Ok(new { Status = 1, Message = "Inserted data successfully" });
            }
            return StatusCode(500, new { Status = 0, Message = "Insertion failed" });
        }

        [CustomAuthorize(QuyenEnums.Sua, ChucNangEnums.QuanLyDonViTinh)] 
        [HttpPost("CapNhatDonViTinh")] 
        public async Task<IActionResult> Update([FromBody] DanhMucDonViTinhModelUpdate model)
        {
            var existingTenDonViTinh = await _donViTinhRepository.GetAll(model.TenDonViTinh, 1, 20);
            if (existingTenDonViTinh.Item1.Any() && existingTenDonViTinh.Item1.First().DonViTinhID != model.DonViTinhID)
            {
                return BadRequest(new { Status = 0, Message = "TenDonViTinh already exists" });
            }

            var existingDonViTinh = await _donViTinhRepository.GetByID(model.DonViTinhID);
            if (existingDonViTinh == null) return Ok(new { Status = 0, Message = "ID not found" });

            if (!string.IsNullOrWhiteSpace(model.TenDonViTinh))
            {
                model.TenDonViTinh = model.TenDonViTinh.Trim();
            }


            if (string.IsNullOrWhiteSpace(model.TenDonViTinh) || model.TenDonViTinh.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Invalid TenDonViTinh. Must not be empty and not exceed 100 characters." });
            }

            if (string.IsNullOrWhiteSpace(model.MaDonViTinh) || model.MaDonViTinh.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid MaDonViTinh. Must not be empty and not exceed 50 characters." });
            }

            if (model.GhiChu.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Invalid GhiChu. Must not exceed 50 characters." });
            }

            var result = await _donViTinhRepository.Update(model);
            if (result > 0)
            {
                return Ok(new { Status = 1, Message = "Updated data successfully" });
            }
            return StatusCode(500, new { Status = 0, Message = "Update failed" });
        }

        [CustomAuthorize(QuyenEnums.Xoa, ChucNangEnums.QuanLyDonViTinh)]
        [HttpPost("XoaDonViTinh")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingDonViTinh = await _donViTinhRepository.GetByID(id);
            if (existingDonViTinh == null) return Ok(new { Status = 0, Message = "ID not found" });

            var result = await _donViTinhRepository.Delete(id);
            if (result > 0)
            {
                return Ok(new { Status = 1, Message = "Deleted data successfully" });
            }
            return StatusCode(500, new { Status = 0, Message = "Deletion failed" });
        }
    }
}
