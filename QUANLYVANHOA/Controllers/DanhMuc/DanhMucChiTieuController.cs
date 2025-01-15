﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QUANLYVANHOA.Models.DanhMuc;
using QUANLYVANHOA.Interfaces.DanhMuc;

namespace QUANLYVANHOA.Controllers.DanhMuc
{

    [Route("api/v1/DanhMucChiTieu/")]
    [CustomAuthorize(1, "Quản lý chỉ tiêu")]
    [ApiController]
    public class DanhMucChiTieuController : ControllerBase
    {
        private readonly IDanhMucChiTieuRepository _chiTieuRepository;
        private readonly IDanhMucLoaiMauPhieuRepository _loaiMauPhieuRepository;

        public DanhMucChiTieuController(IDanhMucChiTieuRepository chiTieuRepository, IDanhMucLoaiMauPhieuRepository loaiMauPhieuRepository)
        {
            _chiTieuRepository = chiTieuRepository;
            _loaiMauPhieuRepository = loaiMauPhieuRepository;
        }

        [CustomAuthorize(1, "Quản lý chỉ tiêu")]
        [HttpGet("DanhSachChiTieu")]
        public async Task<IActionResult> GetAll(string? name/*, int pageNumber = 1, int pageSize = 100*/)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
            }

            //if (pageNumber <= 0)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page number. Page number must be greater than 0." });
            //}

            //if (pageSize <= 0 || pageSize > 100)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page size. Page size must be between 1 and 100." });
            //}

            var result = await _chiTieuRepository.GetAll(name/*, pageNumber, pageSize*/);
            var chiTieuList = result.Item1;
            //var totalRecords = result.Item2;
            //var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (chiTieuList.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "No data available" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Get information successfully",
                Data = chiTieuList,
                //PageNumber = pageNumber,
                //PageSize = pageSize,
                //TotalPages = totalPages,
                //TotalRecords = totalRecords
            });
        }

        [CustomAuthorize(1, "Quản lý chỉ tiêu")]
        [HttpGet("TimChiTieuTheoID")]
        public async Task<IActionResult> GetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid ID. ID must be greater than 0." });
            }

            var chiTieu = await _chiTieuRepository.GetByID(id);
            if (chiTieu == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = chiTieu });
        }

        [HttpGet("TimChiTieuTheoLoaiMauPhieuID")]
        [CustomAuthorize(2, "Quản lý chỉ tiêu")]
        public async Task<IActionResult> GetByLoaiMauPhieuID(int loaiMauPhieuID)
        {
            if (loaiMauPhieuID <= 0)
            {
                return BadRequest("Invalid LoaiMauPhieuID.");
            }

            try
            {
                var chiTieuHierarchy = await _chiTieuRepository.GetByLoaiMauPhieuID(loaiMauPhieuID);

                if (chiTieuHierarchy == null)
                {
                    return NotFound($"No ChiTieu found for LoaiMauPhieuID: {loaiMauPhieuID}");
                }

                return Ok(chiTieuHierarchy);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [CustomAuthorize(2, "Quản lý chỉ tiêu")]
        [HttpPost("ThemMoiChiTieu")]
        public async Task<IActionResult> Insert([FromBody] DanhMucChiTieuInsertModel chiTieu)
        {
            var existingChiTieu = await _chiTieuRepository.GetAll(chiTieu.TenChiTieu);
            if (existingChiTieu.Item1.Any())
            {
                return BadRequest(new { Status = 0, Message = "TenChiTieu already exists" });
            }

            if (!string.IsNullOrWhiteSpace(chiTieu.TenChiTieu))
            {
                chiTieu.TenChiTieu = chiTieu.TenChiTieu.Trim();
            }
            if (string.IsNullOrWhiteSpace(chiTieu.TenChiTieu) || chiTieu.TenChiTieu.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid TenChiTieu. The TenChiTieu must be required and not exceed 50 characters" });
            }

            if (string.IsNullOrWhiteSpace(chiTieu.MaChiTieu) || chiTieu.MaChiTieu.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid MaChiTieu. The MaChiTieu must be required and not exceed 50 characters" });
            }

            if (chiTieu.ChiTieuChaID.HasValue)
            {
                var existingChiTieuCha = await _chiTieuRepository.GetByID(chiTieu.ChiTieuChaID.Value);
                if (existingChiTieuCha == null || chiTieu.ChiTieuChaID <= 0)
                {
                    return BadRequest(new { Status = 0, Message = "ChiTieuChaId not found or cannot set to 0. The ChiTieuChaId must set to 'NULL' or greater than 0" });
                }
            }

            if (chiTieu.GhiChu.Length > 300)
            {
                return BadRequest(new { Status = 0, Message = "Invalid GhiChu. The GhiChu must not exceed 300 characters" });
            }

            var existingLoaiMauPhieu = await _loaiMauPhieuRepository.GetByID(chiTieu.LoaiMauPhieuID);
            if (existingLoaiMauPhieu == null)
            {
                return Ok(new { Status = 0, Message = "LoaiMauPhieu does not exist" });
            }
            if (chiTieu.LoaiMauPhieuID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid LoaiMauPhieuID. It must be greater than 0." });
            }

            await _chiTieuRepository.Insert(chiTieu);
            return Ok(new { Status = 1, Message = "Inserted data successfully" });
        }

        [HttpPost("ThemChiTieuCon")]
        [CustomAuthorize(2, "Quản lý chỉ tiêu")]
        public async Task<IActionResult> InsertChiTieuCon([FromBody] DanhMucChiTieuInsertChidrenModel chiTieuModelInsertChidren)
        {
            var existingChiTieu = await _chiTieuRepository.GetAll(chiTieuModelInsertChidren.TenChiTieu);
            if (existingChiTieu.Item1.Any())
            {
                return BadRequest(new { Status = 0, Message = "TenChiTieu already exists" });
            }

            if (!string.IsNullOrWhiteSpace(chiTieuModelInsertChidren.TenChiTieu))
            {
                chiTieuModelInsertChidren.TenChiTieu = chiTieuModelInsertChidren.TenChiTieu.Trim();
            }
            if (string.IsNullOrWhiteSpace(chiTieuModelInsertChidren.TenChiTieu) || chiTieuModelInsertChidren.TenChiTieu.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Invalid TenChiTieu. The TenChiTieu must be required and not exceed 50 characters" });
            }

            if (string.IsNullOrWhiteSpace(chiTieuModelInsertChidren.MaChiTieu) || chiTieuModelInsertChidren.MaChiTieu.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Invalid MaChiTieu. The MaChiTieu must be required and not exceed 50 characters" });
            }

            if (chiTieuModelInsertChidren.ChiTieuChaID.HasValue)
            {
                var existingChiTieuCha = await _chiTieuRepository.GetByID(chiTieuModelInsertChidren.ChiTieuChaID.Value);
                if (existingChiTieuCha == null || chiTieuModelInsertChidren.ChiTieuChaID <= 0)
                {
                    return BadRequest(new { Status = 0, Message = "ChiTieuChaId not found or cannot set to 0. The ChiTieuChaId must set to 'NULL' or greater than 0" });
                }
            }

            if (chiTieuModelInsertChidren.GhiChu.Length > 300)
            {
                return BadRequest(new { Status = 0, Message = "Invalid GhiChu. The GhiChu must not exceed 300 characters" });
            }
            try
            {
                await _chiTieuRepository.InsertChildren(chiTieuModelInsertChidren);
                return Ok(new { Status = 1, Message = "Inserted successfully." });
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [CustomAuthorize(4, "Quản lý chỉ tiêu")]
        [HttpPost("CapNhatThongTinChiTieu")]
        public async Task<IActionResult> Update(DanhMucChiTieuUpdateModel chiTieu)
        {
            if (!string.IsNullOrWhiteSpace(chiTieu.TenChiTieu))
            {
                chiTieu.TenChiTieu = chiTieu.TenChiTieu.Trim();
            }

            if (chiTieu.ChiTieuID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid ID. ID must be greater than 0." });
            }

            if (chiTieu.ChiTieuChaID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "ChiTieuChaID cannot set to 0. The ChiTieuChaId must set to 'NULL' or greater than 0" });
            }

            var existingChiTieu = await _chiTieuRepository.GetByID(chiTieu.ChiTieuID);
            if (existingChiTieu == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            if (string.IsNullOrWhiteSpace(chiTieu.TenChiTieu) || chiTieu.TenChiTieu.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid TenChiTieu. The TenChiTieu must be required and not exceed 50 characters" });
            }

            if (string.IsNullOrWhiteSpace(chiTieu.MaChiTieu) || chiTieu.MaChiTieu.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid MaChiTieu. The MaChiTieu must be required and not exceed 50 characters" });
            }

            if (chiTieu.GhiChu.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Invalid GhiChu. The GhiChu must not exceed 100 characters" });
            }

            var existingLoaiMauPhieu = await _loaiMauPhieuRepository.GetByID(chiTieu.LoaiMauPhieuID);
            if (existingLoaiMauPhieu == null)
            {
                return Ok(new { Status = 0, Message = "LoaiMauPhieu does not exist" });
            }
            if (chiTieu.LoaiMauPhieuID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid LoaiMauPhieuID. It must be greater than 0." });
            }


            await _chiTieuRepository.Update(chiTieu);
            return Ok(new { Status = 1, Message = "Updated data successfully" });
        }

        [CustomAuthorize(8, "Quản lý chỉ tiêu")]
        [HttpPost("XoaChiTieu")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid ID. ID must be greater than 0." });
            }

            var chiTieu = await _chiTieuRepository.GetByID(id);
            if (chiTieu == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            await _chiTieuRepository.Delete(id);
            return Ok(new { Status = 1, Message = "Deleted data successfully" });
        }
    }
}
