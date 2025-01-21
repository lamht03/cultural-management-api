using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QUANLYVANHOA.Models.DanhMuc;
using QUANLYVANHOA.Interfaces.DanhMuc;
using QUANLYVANHOA.Core.Enums;

namespace QUANLYVANHOA.Controllers.DanhMuc
{
    [Route("api/v1/DanhMucKyBaoCao")]
    [ApiController]
    public class DanhMucKyBaoCaoController : ControllerBase
    {
        private readonly IDanhMucKyBaoCaoRepository _kyBaoCaoRepository;

        public DanhMucKyBaoCaoController(IDanhMucKyBaoCaoRepository kyBaoCaoRepository)
        {
            _kyBaoCaoRepository = kyBaoCaoRepository;
        }

        [CustomAuthorize(Quyen.Xem, "Quản lý kỳ báo cáo")]
        [HttpGet("DanhSachKyBaoCao")]
        public async Task<IActionResult> GetAll(string? name, int pageNumber = 1, int pageSize = 20)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
            }

            if (pageNumber <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid page number. Page number must be greater than 0." });
            }

            if (pageSize <= 0 || pageSize > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid page size. Page size must be between 1 and 50." });
            }

            var result = await _kyBaoCaoRepository.GetAll(name, pageNumber, pageSize);
            var kyBaoCaoList = result.Item1;
            var totalRecords = result.Item2;
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (kyBaoCaoList.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "No data available" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Get information successfully",
                Data = kyBaoCaoList,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            });
        }

        [CustomAuthorize(Quyen.Xem, "Quản lý kỳ báo cáo")]
        [HttpGet("TimKiemThongTinKyBaoCao")]
        public async Task<IActionResult> GetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid ID. ID must be greater than 0." });
            }

            var kyBaoCao = await _kyBaoCaoRepository.GetByID(id);
            if (kyBaoCao == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            return Ok(new { Status = 1, Message = "Get information successfully", Data = kyBaoCao });
        }

        [HttpPost("ThemMoiKyBaoCao")]
        [CustomAuthorize(Quyen.Them, "Quản lý kỳ báo cáo")]
        public async Task<IActionResult> Insert([FromBody] DanhMucKyBaoCaoModelInsert model)
        {
            var existingKyBaoCaoName = await _kyBaoCaoRepository.GetAll(model.TenKyBaoCao, 1, 20);
            if (existingKyBaoCaoName.Item1.Any())
            {
                return BadRequest(new { Status = 0, Message = "Report period name already exists" });
            }

            if (!string.IsNullOrWhiteSpace(model.TenKyBaoCao))
            {
                model.TenKyBaoCao = model.TenKyBaoCao.Trim();
            }
            if (string.IsNullOrWhiteSpace(model.TenKyBaoCao) || model.TenKyBaoCao.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Invalid TenKyBaoCao. The TenKyBaoCao must be required , and not exceed 50 characters" });
            }

            // Thêm đối tượng vào database

            var newKyBaoCao = new DanhMucKyBaoCaoModelInsert
            {
                TenKyBaoCao = model.TenKyBaoCao,
                TrangThai = model.TrangThai,
                GhiChu = model.GhiChu,
            };

            var result = await _kyBaoCaoRepository.Insert(newKyBaoCao);
            {
                return Ok(new { Status = 1, Message = "Inserted data successfully" });
            }
        }

        [HttpPost("CapNhatKyBaoCao")]
        [CustomAuthorize(Quyen.Sua, "Quản lý kỳ báo cáo")]
        public async Task<IActionResult> Update(DanhMucKyBaoCaoModelUpdate kyBaoCao)
        {
            var existingKyBaoCaoName = await _kyBaoCaoRepository.GetAll(kyBaoCao.TenKyBaoCao, 1, 20);
            if (existingKyBaoCaoName.Item1.Any())
            {
                return BadRequest(new { Status = 0, Message = "Report period name already exists" });
            }

            if (kyBaoCao.KyBaoCaoID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid ID. ID must be greater than 0." });
            }

            var existingKyBaoCao = await _kyBaoCaoRepository.GetByID(kyBaoCao.KyBaoCaoID);
            if (existingKyBaoCao == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            if (string.IsNullOrWhiteSpace(kyBaoCao.TenKyBaoCao) || kyBaoCao.TenKyBaoCao.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Report period name is required and not exceed 50 characters" });
            }

            await _kyBaoCaoRepository.Update(kyBaoCao);
            return Ok(new { Status = 1, Message = "Updated data successfully" });
        }

        [HttpPost("XoaKyBaoCao")]
        [CustomAuthorize(Quyen.Xoa, "Quản lý kỳ báo cáo")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Invalid ID. ID must be greater than 0." });
            }

            var kyBaoCao = await _kyBaoCaoRepository.GetByID(id);
            if (kyBaoCao == null)
            {
                return Ok(new { Status = 0, Message = "ID not found" });
            }

            await _kyBaoCaoRepository.Delete(id);
            return Ok(new { Status = 1, Message = "Deleted data successfully" });
        }
    }
}
