using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QUANLYVANHOA.Models.DanhMuc;
using QUANLYVANHOA.Interfaces.DanhMuc;
using QUANLYVANHOA.Core.Enums;
using System.Data.SqlClient;
namespace QUANLYVANHOA.Controllers.DanhMuc
{
    [Route("api/v1/DanhMucCoQuanDonVi/")]
    [ApiController]
    public class DanhMucCoQuanDonViController : ControllerBase
    {
        private readonly IDanhMucCoQuanDonViRepository _coQuanRepository;
        private readonly IDanhMucLoaiMauPhieuRepository _loaiMauPhieuRepository;

        public DanhMucCoQuanDonViController(IDanhMucCoQuanDonViRepository coQuanRepository)
        {
            _coQuanRepository = coQuanRepository;
        }

        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("DanhSachCoQuan")]
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

            var result = await _coQuanRepository.DanhMucCoQuanGetAll(name/*, pageNumber, pageSize*/);
            var coQuanList = result.Item1;
            //var totalRecords = result.Item2;
            //var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (coQuanList.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "Không có dữ liệu cơ quan !" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Lấy dữ liệu cơ quan thành công !",
                Data = coQuanList,
                //PageNumber = pageNumber,
                //PageSize = pageSize,
                //TotalPages = totalPages,
                //TotalRecords = totalRecords
            });
        }


        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("TimCoQuanTheoID")]
        public async Task<IActionResult> DanhMucCoQuanGetByID (int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = "ID phải lớn hơn 0"
                });
            }

            var coQuan = await _coQuanRepository.DanhMucCoQuanGetByID(id);
            if (coQuan == null) 
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID" });
            }

            return Ok(new { Status = 1, Message = "Lấy dữ liệu cơ quan thành công !", Data = coQuan });

        }


        [CustomAuthorize(Quyen.Sua, "Quản lý cơ quan đơn vị")]
        [HttpPost("ThemMoiCoQuan")]
        public async Task<IActionResult> DanhMucCoQuanAdd([FromBody] DanhMucCoQuanInsertModel model)
        {
            var existingCoQuan = await _coQuanRepository.DanhMucCoQuanGetAll(model.TenCoQuan);
            if (existingCoQuan.Item1.Any())
            {
                return BadRequest(new { Status = 0, Message = "Tên cơ quan đã tồn tại !" });
            }

            if (!string.IsNullOrWhiteSpace(model.TenCoQuan)) 
            {
                model.TenCoQuan = model.TenCoQuan.Trim();
            }
            if (string.IsNullOrWhiteSpace(model.TenCoQuan) || model.TenCoQuan.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Tên cơ quan không được vượt quá 100 kí tự" });
            }

            if (!string.IsNullOrWhiteSpace(model.MaCoQuan))
            {
                model.MaCoQuan = model.MaCoQuan.Trim();
            }
            if (string.IsNullOrWhiteSpace(model.MaCoQuan) || model.MaCoQuan.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Tên cơ quan không được vượt quá 100 kí tự" });
            }

            if (model.CoQuanChaID.HasValue)
            {
                var existingCoQuanCha = await _coQuanRepository.DanhMucCoQuanGetByID(model.CoQuanChaID.Value);
                if (existingCoQuanCha == null || model.CoQuanChaID <= 0)
                {
                    return BadRequest(new { Status = 0, Message = "Cơ quan cha ID không tồn tại trong cơ sở dữ liệu danh mục chỉ tiêu !" });
                }
            }

            var existingCap = _coQuanRepository.DMCapGetByID(model.CapID);
            if (existingCap == null || model.CapID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Cấp ID không tồn tại trong cơ sở dữ liệu !" });
            }

            var existingThamQuyen = _coQuanRepository.DMThamQuyenGetByID(model.ThamQuyenID);
            if (existingThamQuyen == null || model.ThamQuyenID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Thẩm Quyền ID không tồn tại trong cơ sở dữ liệu !" });
            }

            var existingTinh = _coQuanRepository.DMTinhGetByID(model.TinhID);
            if (existingTinh == null || model.TinhID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Tỉnh ID không tồn tại trong cơ sở dữ liệu !" });
            }

            var existingHuyen = _coQuanRepository.DMHuyenGetByID(model.HuyenID);
            if (existingHuyen == null || model.HuyenID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Huyện ID không tồn tại trong cơ sở dữ liệu !" });
            }

            var existingXa = _coQuanRepository.DMXaGetByID(model.XaID);
            if (existingXa == null || model.XaID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Xã ID không tồn tại trong cơ sở dữ liệu !" });
            }


            await _coQuanRepository.DanhMucCoQuanAdd(model);
            return Ok(new {Status = 1, Message = "Thêm dữ liệu thành công !"});
        }



        [CustomAuthorize(Quyen.Sua, "Quản lý cơ quan đơn vị")]
        [HttpPost("CapNhatDuLieuCoQuan")]
        public async Task<IActionResult> DanhMucCoQuanUpdate([FromBody] DanhMucCoQuanUpdateModel model)
        {
            var existingCoQuan = await _coQuanRepository.DanhMucCoQuanGetByID(model.CoQuanID);
            if (existingCoQuan == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID của cơ quan cần cập nhật dữ liệu !" });
            }

            if (!string.IsNullOrWhiteSpace(model.TenCoQuan))
            {
                model.TenCoQuan = model.TenCoQuan.Trim();
            }

            var existingCoQuan2 = await _coQuanRepository.DanhMucCoQuanGetAll(model.TenCoQuan);
            if (existingCoQuan2.Item1.Any())
            {
                return BadRequest(new { Status = 0, Message = "Tên cơ quan đã tồn tại !" });
            }

            if (!string.IsNullOrWhiteSpace(model.TenCoQuan))
            {
                model.TenCoQuan = model.TenCoQuan.Trim();
            }
            if (string.IsNullOrWhiteSpace(model.TenCoQuan) || model.TenCoQuan.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Tên cơ quan không được vượt quá 100 kí tự" });
            }

            if (!string.IsNullOrWhiteSpace(model.MaCoQuan))
            {
                model.MaCoQuan = model.MaCoQuan.Trim();
            }
            if (string.IsNullOrWhiteSpace(model.MaCoQuan) || model.MaCoQuan.Length > 100)
            {
                return BadRequest(new { Status = 0, Message = "Tên cơ quan không được vượt quá 100 kí tự" });
            }

            if (model.CoQuanChaID.HasValue)
            {
                var existingCoQuanCha = await _coQuanRepository.DanhMucCoQuanGetByID(model.CoQuanChaID.Value);
                if (existingCoQuanCha == null || model.CoQuanChaID <= 0)
                {
                    return BadRequest(new { Status = 0, Message = "Cơ quan cha ID không tồn tại trong cơ sở dữ liệu danh mục chỉ tiêu !" });
                }
            }

            var existingCap = _coQuanRepository.DMCapGetByID(model.CapID);
            if (existingCap == null || model.CapID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Cấp ID không tồn tại trong cơ sở dữ liệu !" });
            }

            var existingThamQuyen = _coQuanRepository.DMThamQuyenGetByID(model.ThamQuyenID);
            if (existingThamQuyen == null || model.ThamQuyenID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Thẩm Quyền ID không tồn tại trong cơ sở dữ liệu !" });
            }

            var existingTinh = _coQuanRepository.DMTinhGetByID(model.TinhID);
            if (existingTinh == null || model.TinhID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Tỉnh ID không tồn tại trong cơ sở dữ liệu !" });
            }

            var existingHuyen = _coQuanRepository.DMHuyenGetByID(model.HuyenID);
            if (existingHuyen == null || model.HuyenID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Huyện ID không tồn tại trong cơ sở dữ liệu !" });
            }

            var existingXa = _coQuanRepository.DMXaGetByID(model.XaID);
            if (existingXa == null || model.XaID <= 0)
            {
                return BadRequest(new { Status = 0, Message = "Xã ID không tồn tại trong cơ sở dữ liệu !" });
            }



            await _coQuanRepository.DanhMucCoQuanUpdate(model);
            return Ok(new { Status = 1, Message = "Cập nhật dữ liệu thành công !" });
        }


        [CustomAuthorize(Quyen.Xoa, "Quản lý cơ quan đơn vị")]
        [HttpPost("XoaDanhMucCoQuan")]
        public async Task<IActionResult> DanhMucCoQuanDelete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Status = 0, Message = "ID phải lớn hơn 0 !" });
            }

            var coQuan = await _coQuanRepository.DanhMucCoQuanGetByID(id);
            if (coQuan == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID của cơ quan !" });
            }

            await _coQuanRepository.DanhMucCoQuanDelete(id);
            return Ok(new { Status = 1, Message = "Xóa dữ liệu thành công !" });
        }

        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("DanhSachTinh")]
        public async Task<IActionResult> DMTinhGetAll(/*string? name*//*, int pageNumber = 1, int pageSize = 100*/)
        {
            //if (!string.IsNullOrWhiteSpace(name))
            //{
            //    name = name.Trim();
            //}

            //if (pageNumber <= 0)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page number. Page number must be greater than 0." });
            //}

            //if (pageSize <= 0 || pageSize > 100)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page size. Page size must be between 1 and 100." });
            //}

            var result = await _coQuanRepository.DMTinhGetAll(/*name*//*, pageNumber, pageSize*/);
            var danhMucTinhList = result/*.Item1*/;
            //var totalRecords = result.Item2;
            //var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (danhMucTinhList.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "Không có dữ liệu danh mục Tỉnh !" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Lấy dữ liệu danh mục Tỉnh thành công !",
                Data = danhMucTinhList,
                //PageNumber = pageNumber,
                //PageSize = pageSize,
                //TotalPages = totalPages,
                //TotalRecords = totalRecords
            });
        }


        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("TimTinhTheoID")]
        public async Task<IActionResult> DanhMucTinhGetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Tỉnh ID phải lớn hơn 0 !"
                });
            }

            var danhMucTinh = await _coQuanRepository.DMTinhGetByID(id);
            if (danhMucTinh == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID của Tỉnh !" });
            }

            return Ok(new { Status = 1, Message = "Lấy dữ liệu danh mục tỉnh thành công !", Data = danhMucTinh });

        }


        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("DanhSachHuyenTheoTinhID")]
        public async Task<IActionResult> DMHuyenGetByTinhID(int tinhId/*string? name*//*, int pageNumber = 1, int pageSize = 100*/)
        {
            //if (!string.IsNullOrWhiteSpace(name))
            //{
            //    name = name.Trim();
            //}

            //if (pageNumber <= 0)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page number. Page number must be greater than 0." });
            //}

            //if (pageSize <= 0 || pageSize > 100)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page size. Page size must be between 1 and 100." });
   
         //}

            var result = await _coQuanRepository.DMHuyenGetByTinhID(tinhId/*name*//*, pageNumber, pageSize*/);
            var danhMucHuyenList = result/*.Item1*/;
            //var totalRecords = result.Item2;
            //var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (danhMucHuyenList.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "Không có dữ liệu danh mục Huyện !" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Lấy dữ liệu danh mục Huyện thành công !",
                Data = danhMucHuyenList,
                //PageNumber = pageNumber,
                //PageSize = pageSize,
                //TotalPages = totalPages,
                //TotalRecords = totalRecords
            });
        }

        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("TimHuyenTheoID")]
        public async Task<IActionResult> DanhMucHuyenGetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Huyện ID phải lớn hơn 0 !"
                });
            }

            var danhMucHuyen = await _coQuanRepository.DMHuyenGetByID(id);
            if (danhMucHuyen == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID của Huyện !" });
            }

            return Ok(new { Status = 1, Message = "Lấy dữ liệu danh mục Huyện thành công !", Data = danhMucHuyen });

        }

        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("DanhSachXaTheoHuyenID")]
        public async Task<IActionResult> DMXaGetByHuyenID(int id/*string? name*//*, int pageNumber = 1, int pageSize = 100*/)
        {
            //if (!string.IsNullOrWhiteSpace(name))
            //{
            //    name = name.Trim();
            //}

            //if (pageNumber <= 0)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page number. Page number must be greater than 0." });
            //}

            //if (pageSize <= 0 || pageSize > 100)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page size. Page size must be between 1 and 100." });
            //}

            var result = await _coQuanRepository.DMXaGetByHuyenID(id /*name*//*, pageNumber, pageSize*/);
            var danhMucXaList = result/*.Item1*/;
            //var totalRecords = result.Item2;
            //var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (danhMucXaList.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "Không có dữ liệu danh mục Xã !" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Lấy dữ liệu danh mục Xã thành công !",
                Data = danhMucXaList,
                //PageNumber = pageNumber,
                //PageSize = pageSize,
                //TotalPages = totalPages,
                //TotalRecords = totalRecords
            });
        }


        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("TimXaTheoID")]
        public async Task<IActionResult> DanhMucXaGetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Xã ID phải lớn hơn 0 !"
                });
            }

            var danhMucXa = await _coQuanRepository.DMXaGetByID(id);
            if (danhMucXa == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID của Xã !" });
            }

            return Ok(new { Status = 1, Message = "Lấy dữ liệu danh mục Xã thành công !", Data = danhMucXa });

        }

        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("DanhSachCap")]
        public async Task<IActionResult> DMCapGetAll(/*string? name*//*, int pageNumber = 1, int pageSize = 100*/)
        {
            //if (!string.IsNullOrWhiteSpace(name))
            //{
            //    name = name.Trim();
            //}

            //if (pageNumber <= 0)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page number. Page number must be greater than 0." });
            //}

            //if (pageSize <= 0 || pageSize > 100)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page size. Page size must be between 1 and 100." });
            //}

            var result = await _coQuanRepository.DMCapGetAll(/*name*//*, pageNumber, pageSize*/);
            var danhMucCapList = result/*.Item1*/;
            //var totalRecords = result.Item2;
            //var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (danhMucCapList.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "Không có dữ liệu danh mục Cấp !" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Lấy dữ liệu danh mục Cấp thành công !",
                Data = danhMucCapList,
                //PageNumber = pageNumber,
                //PageSize = pageSize,
                //TotalPages = totalPages,
                //TotalRecords = totalRecords
            });
        }


        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("TimDanhMucCapTheoID")]
        public async Task<IActionResult> DanhMucCapGetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Cấp cơ quan ID phải lớn hơn 0 !"
                });
            }

            var danhMucCap = await _coQuanRepository.DMCapGetByID(id);
            if (danhMucCap == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID của Cấp cơ quan !" });
            }

            return Ok(new { Status = 1, Message = "Lấy dữ liệu danh mục Cấp cơ quan thành công !", Data = danhMucCap });

        }

        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("DanhSachThamQuyen")]
        public async Task<IActionResult> DMThamQuyenGetAll(/*string? name*//*, int pageNumber = 1, int pageSize = 100*/)
        {
            //if (!string.IsNullOrWhiteSpace(name))
            //{
            //    name = name.Trim();
            //}

            //if (pageNumber <= 0)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page number. Page number must be greater than 0." });
            //}

            //if (pageSize <= 0 || pageSize > 100)
            //{
            //    return BadRequest(new { Status = 0, Message = "Invalid page size. Page size must be between 1 and 100." });
            //}

            var result = await _coQuanRepository.DMThamQuyenGetAll(/*name*//*, pageNumber, pageSize*/);
            var danhMucThamQuyenList = result/*.Item1*/;
            //var totalRecords = result.Item2;
            //var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (danhMucThamQuyenList.Count() == 0)
            {
                return Ok(new { Status = 0, Message = "Không có dữ liệu danh mục Thẩm Quyền đơn vị !" });
            }

            return Ok(new
            {
                Status = 1,
                Message = "Lấy dữ liệu danh mục Thẩm Quyền thành công !",
                Data = danhMucThamQuyenList,
                //PageNumber = pageNumber,
                //PageSize = pageSize,
                //TotalPages = totalPages,
                //TotalRecords = totalRecords
            });
        }


        [CustomAuthorize(Quyen.Xem, "Quản lý cơ quan đơn vị")]
        [HttpGet("TimDanhMucThamQuyenTheoID")]
        public async Task<IActionResult> DanhMucThamQuyenGetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    Status = 0,
                    Message = "Thẩm quyền ID phải lớn hơn 0 !"
                });
            }

            var danhMucThamQuyen = await _coQuanRepository.DMThamQuyenGetByID(id);
            if (danhMucThamQuyen == null)
            {
                return Ok(new { Status = 0, Message = "Không tìm thấy ID của Thẩm Quyền cơ quan !" });
            }

            return Ok(new { Status = 1, Message = "Lấy dữ liệu danh mục Thẩm Quyền cơ quan thành công !", Data = danhMucThamQuyen });

        }


    }
}
