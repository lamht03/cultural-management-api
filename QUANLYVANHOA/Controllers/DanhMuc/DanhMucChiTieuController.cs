using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QUANLYVANHOA.Models.DanhMuc;
using QUANLYVANHOA.Interfaces.DanhMuc;
using QUANLYVANHOA.Core.Enums;

namespace QUANLYVANHOA.Controllers.DanhMuc
{

    [Route("api/v1/DanhMucChiTieu/")]
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

        [CustomAuthorize(Quyen.Xem, "Quản lý chỉ tiêu")]
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
                return Ok(new { Status = 0, Message = "Không có dữ liệu !" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Lấy thông tin thành công !",
                Data = chiTieuList,
                //PageNumber = pageNumber,
                //PageSize = pageSize,
                //TotalPages = totalPages,
                //TotalRecords = totalRecords
            });
        }

        [CustomAuthorize(Quyen.Xem, "Quản lý chỉ tiêu")]
        [HttpGet("TimChiTieuTheoID")]
        public async Task<IActionResult> GetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Status = 0, Message = "ID phải lớn hơn 0 !" });
            }

            var chiTieu = await _chiTieuRepository.GetByID(id);
            if (chiTieu == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID !" });
            }

            return Ok(new { Status = 1, Message = "Lấy dữ liệu thành công !", Data = chiTieu });
        }

        [HttpGet("TimChiTieuTheoLoaiMauPhieuID")]
        [CustomAuthorize(Quyen.Xem, "Quản lý chỉ tiêu")]
        public async Task<IActionResult> GetByLoaiMauPhieuID(int loaiMauPhieuID)
        {
            if (loaiMauPhieuID <= 0)
            {
                return BadRequest("Loại mẫu phiếu ID phải lớn hơn 0 !");
            }

            try
            {
                var chiTieuHierarchy = await _chiTieuRepository.GetByLoaiMauPhieuID(loaiMauPhieuID);

                if (chiTieuHierarchy == null)
                {
                    return NotFound($"Không chỉ tiêu nào có LoaiMauPhieuID = {loaiMauPhieuID}");
                }

                return Ok(chiTieuHierarchy);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [CustomAuthorize(Quyen.Them, "Quản lý chỉ tiêu")]
        [HttpPost("ThemMoiChiTieu")]
        public async Task<IActionResult> Insert([FromBody] DanhMucChiTieuInsertModel chiTieu)
        {
            var existingChiTieu = await _chiTieuRepository.GetAll(chiTieu.TenChiTieu);
            if (existingChiTieu.Item1.Any())
            {
                return BadRequest(new { Status = 0, Message = "Tên chỉ tiêu đã tồn tại" });
            }

            if (!string.IsNullOrWhiteSpace(chiTieu.TenChiTieu))
            {
                chiTieu.TenChiTieu = chiTieu.TenChiTieu.Trim();
            }
            if (string.IsNullOrWhiteSpace(chiTieu.TenChiTieu) || chiTieu.TenChiTieu.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Tên chỉ tiêu phải ít hơn 50 kí tự !" });
            }

            if (!string.IsNullOrWhiteSpace(chiTieu.MaChiTieu))
            {
                chiTieu.MaChiTieu = chiTieu.MaChiTieu.Trim();
            }
            if (string.IsNullOrWhiteSpace(chiTieu.MaChiTieu) || chiTieu.MaChiTieu.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Mã chỉ tiêu không quá 50 kí tự !" });
            }

            if (chiTieu.ChiTieuChaID.HasValue)
            {
                var existingChiTieuCha = await _chiTieuRepository.GetByID(chiTieu.ChiTieuChaID.Value);
                if (existingChiTieuCha == null || chiTieu.ChiTieuChaID <= 0)
                {
                    return BadRequest(new { Status = 0, Message = "Chỉ tiêu cha ID không tồn tại trong cơ sở dữ liệu danh mục chỉ tiêu !" });
                }
            }

            if (chiTieu.GhiChu.Length > 300)
            {
                return BadRequest(new { Status = 0, Message = "Ghi chú không được vượt quá 300 kí tự !" });
            }

            var existingLoaiMauPhieu = await _loaiMauPhieuRepository.GetByID(chiTieu.LoaiMauPhieuID);
            if (existingLoaiMauPhieu == null)
            {
                return Ok(new { Status = 0, Message = "Loại Mẫu Phiếu ID không tồn tại !" });
            }
            if (chiTieu.LoaiMauPhieuID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Loai Mẫu Phiếu ID phải lớn hơn 0 !" });
            }

            await _chiTieuRepository.Insert(chiTieu);
            return Ok(new { Status = 1, Message = "Thêm dữ liệu thành công !" });
        }

        //[HttpPost("ThemChiTieuCon")]
        //[CustomAuthorize(Quyen.Them, "Quản lý chỉ tiêu")]
        //public async Task<IActionResult> InsertChiTieuCon([FromBody] DanhMucChiTieuInsertChidrenModel chiTieuModelInsertChidren)
        //{
        //    var existingChiTieu = await _chiTieuRepository.GetAll(chiTieuModelInsertChidren.TenChiTieu);
        //    if (existingChiTieu.Item1.Any())
        //    {
        //        return BadRequest(new { Status = 0, Message = "Tên chỉ tiêu đã tồn tại !" });
        //    }

        //    if (!string.IsNullOrWhiteSpace(chiTieuModelInsertChidren.TenChiTieu))
        //    {
        //        chiTieuModelInsertChidren.TenChiTieu = chiTieuModelInsertChidren.TenChiTieu.Trim();
        //    }
        //    if (string.IsNullOrWhiteSpace(chiTieuModelInsertChidren.TenChiTieu) || chiTieuModelInsertChidren.TenChiTieu.Length > 100)
        //    {
        //        return BadRequest(new { Status = 0, Message = "Tên chỉ tiêu không được vượt quá 100 kí tự !" });
        //    }

        //    if (string.IsNullOrWhiteSpace(chiTieuModelInsertChidren.MaChiTieu) || chiTieuModelInsertChidren.MaChiTieu.Length > 100)
        //    {
        //        return BadRequest(new { Status = 0, Message = "Mã chỉ tiêu không được vượt quá 100 kí tự !" });
        //    }

        //    if (chiTieuModelInsertChidren.ChiTieuChaID.HasValue)
        //    {
        //        var existingChiTieuCha = await _chiTieuRepository.GetByID(chiTieuModelInsertChidren.ChiTieuChaID.Value);
        //        if (existingChiTieuCha == null || chiTieuModelInsertChidren.ChiTieuChaID <= 0)
        //        {
        //            return BadRequest(new { Status = 0, Message = "Chỉ tiêu cha không tồn tại hoặc chỉ tiêu cha gán sai giá trị. Chỉ tiêu cha phải lớn hơn không và tồn tại trong cơ sở dữ liệu chỉ tiêu !" });
        //        }
        //    }

        //    if (chiTieuModelInsertChidren.GhiChu.Length > 300)
        //    {
        //        return BadRequest(new { Status = 0, Message = "Ghi chú không được vượt quá 300 kí tự !" });
        //    }
        //    try
        //    {
        //        await _chiTieuRepository.InsertChildren(chiTieuModelInsertChidren);
        //        return Ok(new { Status = 1, Message = "Inserted successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log lỗi nếu cần
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}


        [CustomAuthorize(Quyen.Sua, "Quản lý chỉ tiêu")]
        [HttpPost("CapNhatThongTinChiTieu")]
        public async Task<IActionResult> Update(DanhMucChiTieuUpdateModel chiTieu)
        {
            if (!string.IsNullOrWhiteSpace(chiTieu.TenChiTieu))
            {
                chiTieu.TenChiTieu = chiTieu.TenChiTieu.Trim();
            }

            if (chiTieu.ChiTieuID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "ID phải lớn hơn 0" });
            }

            if (chiTieu.ChiTieuChaID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Chỉ tiêu cha ID chỉ nhận giá trị lớn hơn 0 hoặc NULL !" });
            }

            var existingChiTieu = await _chiTieuRepository.GetByID(chiTieu.ChiTieuID);
            if (existingChiTieu == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID !" });
            }

            if (string.IsNullOrWhiteSpace(chiTieu.TenChiTieu) || chiTieu.TenChiTieu.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Tên chỉ tiêu không được vượt quá 50 kí tự !" });
            }

            if (string.IsNullOrWhiteSpace(chiTieu.MaChiTieu) || chiTieu.MaChiTieu.Length > 50)
            {
                return BadRequest(new { Status = 0, Message = "Mã chỉ tiêu không được vượt quá 50 kí tự !" });
            }

            if (chiTieu.GhiChu.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Ghi chú không được vượt quá 100 kí tự !" });
            }

            var existingLoaiMauPhieu = await _loaiMauPhieuRepository.GetByID(chiTieu.LoaiMauPhieuID);
            if (existingLoaiMauPhieu == null)
            {
                return Ok(new { Status = 0, Message = "Loại mẫu phiếu ID không tồn tại" });
            }
            if (chiTieu.LoaiMauPhieuID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Loại mẫu phiếu ID phải lớn hơn 0." });
            }


            await _chiTieuRepository.Update(chiTieu);
            return Ok(new { Status = 1, Message = "Cập nhật dữ liệu thành công !" });
        }

        [CustomAuthorize(Quyen.Xoa, "Quản lý chỉ tiêu")]
        [HttpPost("XoaChiTieu")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Status = 0, Message = "ID phải lớn hơn 0 !" });
            }

            var chiTieu = await _chiTieuRepository.GetByID(id);
            if (chiTieu == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID" });
            }

            await _chiTieuRepository.Delete(id);
            return Ok(new { Status = 1, Message = "Xóa dữ liệu thành công !" });
        }
    }
}
