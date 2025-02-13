using Microsoft.AspNetCore.Mvc;
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
    [Route("api/v1/DanhMucLoaiDiTich")]
    [ApiController]
    public class DanhMucLoaiDiTichController : ControllerBase
    {
        private readonly IDanhMucLoaiDiTichRepository _loaiDiTichRepository;

        public DanhMucLoaiDiTichController(IDanhMucLoaiDiTichRepository loaiDiTichRepository)
        {
            _loaiDiTichRepository = loaiDiTichRepository;
        }

        [HttpGet("DanhSachLoaiDiTich")]
        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyLoaiDiTich)]
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

            var result = await _loaiDiTichRepository.GetAll(name, pageNumber, pageSize);
            var loaiDiTichList = result.Item1;
            var totalRecords = result.Item2;
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (!loaiDiTichList.Any())
            {
                return Ok(new
                {
                    Status = 0,
                    Message = "No data available",
                    Data = loaiDiTichList
                });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Get information successfully",
                Data = loaiDiTichList,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            });
        }

        [HttpGet("TimKiemLoaiDiTichTheoID")]
        [CustomAuthorize(QuyenEnums.Xem, ChucNangEnums.QuanLyLoaiDiTich)]
        public async Task<IActionResult> GetByID(int id)
        {
            var loaiDiTich = await _loaiDiTichRepository.GetByID(id);
            if (loaiDiTich == null)
            {
                return Ok(new { Status = 0, Message = "Id not found" });
            }
            return Ok(new { Status = 1, Message = "Get information successfully", Data = loaiDiTich });
        }

        [HttpPost("ThemMoiLoaiDiTich")]
        [CustomAuthorize(QuyenEnums.Them, ChucNangEnums.QuanLyLoaiDiTich)]
        public async Task<IActionResult> Insert([FromBody] DanhMucLoaiDiTichModelInsert model)
        {
            var existingLoaiDiTichName = await _loaiDiTichRepository.GetAll(model.TenLoaiDiTich, 1, 20);
            if (existingLoaiDiTichName.Item1.Any())
            {
                return Ok(new { Status = 0, Message = "Data already exists" });
            }

            if (!string.IsNullOrWhiteSpace(model.TenLoaiDiTich))
            {
                model.TenLoaiDiTich = model.TenLoaiDiTich.Trim();
            }

            // Validate input data
            if (string.IsNullOrWhiteSpace(model.TenLoaiDiTich) || model.TenLoaiDiTich.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid TenLoaiDiTich. Must not be empty and not exceed 50 characters." });
            }

            int ghiChuAsInt;
            if (!int.TryParse(model.GhiChu, out ghiChuAsInt) || ghiChuAsInt < 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid GhiChu. Must be a valid integer greater than or equal to 0." });
            }

            // Create a new DanhMucLoaiDiTich object
            var newLoaiDiTich = new DanhMucLoaiDiTichModelInsert
            {
                TenLoaiDiTich = model.TenLoaiDiTich.Trim(),
                GhiChu = ghiChuAsInt.ToString()
            };

            // Insert the object into the database
            var result = await _loaiDiTichRepository.Insert(newLoaiDiTich);
            if (result > 0)
            {
                return Ok(new { Status = 1, Message = "Inserted data successfully" });
            }
            return StatusCode(500, new { Status = 0, Message = "Insertion failed" });
        }

        [HttpPost("CapNhatThongTinLoaiDiTich")]
        [CustomAuthorize(QuyenEnums.Sua, ChucNangEnums.QuanLyLoaiDiTich)]
        public async Task<IActionResult> Update([FromBody] DanhMucLoaiDiTichModelUpdate model)
        {
            var existingLoaiDiTichName = await _loaiDiTichRepository.GetAll(model.TenLoaiDiTich, 1, 20);
            if (existingLoaiDiTichName.Item1.Any())
            {
                return Ok(new { Status = 0, Message = "Data already exists" });
            }

            if (!string.IsNullOrWhiteSpace(model.TenLoaiDiTich))
            {
                model.TenLoaiDiTich = model.TenLoaiDiTich.Trim();
            }

            var existingLoaiDiTich = await _loaiDiTichRepository.GetByID(model.LoaiDiTichID);
            if (existingLoaiDiTich == null) return Ok(new { Status = 0, Message = "ID not found" });

            if (string.IsNullOrWhiteSpace(model.TenLoaiDiTich) || model.TenLoaiDiTich.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Invalid TenLoaiDiTich. Must not be empty and not exceed 50 characters." });
            }

            int ghiChuAsInt;
            if (!int.TryParse(model.GhiChu, out ghiChuAsInt) || ghiChuAsInt < 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid GhiChu. Must be a valid integer greater than or equal to 0." });
            }


            var result = await _loaiDiTichRepository.Update(model);
            if (result > 0)
            {
                return Ok(new { Status = 1, Message = "Updated data successfully" });
            }
            return StatusCode(500, new { Status = 0, Message = "Update failed" });
        }

        [HttpPost("XoaLoaiDiTich")]
        [CustomAuthorize(QuyenEnums.Xoa, ChucNangEnums.QuanLyLoaiDiTich)]
        public async Task<IActionResult> Delete(int id)
        {
            var existingLoaiDiTich = await _loaiDiTichRepository.GetByID(id);
            if (existingLoaiDiTich == null) return Ok(new { Status = 0, Message = "ID not found" });

            var result = await _loaiDiTichRepository.Delete(id);
            if (result > 0)
            {
                return Ok(new { Status = 1, Message = "Deleted data successfully" });
            }
            return StatusCode(500, new { Status = 0, Message = "Deletion failed" });
        }
    }
}
