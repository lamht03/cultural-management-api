EXEC v1_HeThong_CanBo_GetListPaging @TenCanBoOrTenNguoiDung = '', @CoQuanID =null, @PageNumber = 1, @PageSize =20;
EXEC v1_HeThong_CanBo_GetByID @CanBoID = 14
EXEC v1_HeThong_CanBo_Add 
    @TenCanBo = N'xxxxxx', 
    @CoQuanID = 1, 
    @TenNguoiDung = N'xxxxxxxxx',
    @MatKhau = N'123456',
    @DanhSachNhomPhanQuyenID = '1,2' -- Assign to groups 2, 3, and 5


select * FROM HT_NguoiDung
select * FROM HT_NhomNguoiDung

-- delete  HT_CanBo WHERE CanBoID =13
-- delete  HT_NhomNguoiDung WHERE NguoiDungID =13


-- EXEC v1_HeThong_CanBo_GetByEmail @Email = "admin@example.com"

-- EXEC v1_HeThong_CanBo_Update
--     @CanBoID = 14,
--     @TenCanBo = N'Nguyễn Văn A',
--     @Email = 'nguyenvana@email.com',
--     @NguoiDungID = 2,
--     @DanhSachNhomPhanQuyenID = NULL; -- Không thay đổi nhóm phân quyền

-- EXEC v1_HeThong_CanBo_Update
--     @CanBoID = 14,
--     @TenCanBo = N'Nguyễn Văn A',
--     @Email = 'nguyenvana@email.com',
--     @CoQuanID = 10,
--     @TrangThai = 1,
--     @DanhSachNhomPhanQuyenID = NULL; -- Không thay đổi nhóm phân quyền

-- EXEC v1_HeThong_CanBo_Update
--     @CanBoID = 14,
--     @TenCanBo = N'Nguyễn Văn X',
--     @Email = 'nguyenvana@email.com',
--     @CoQuanID = 12,
--     @TrangThai = 1,
--     @DanhSachNhomPhanQuyenID = ''; -- Xóa hết nhóm phân quyền
EXEC v1_HeThong_CanBo_Delete @CanBoID = 15;