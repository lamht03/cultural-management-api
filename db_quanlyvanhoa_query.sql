EXEC v1_HeThong_CanBo_GetListPaging @TenCanBoOrTenNguoiDung = '', @CoQuanID =null, @PageNumber = 1, @PageSize =20;
EXEC v1_HeThong_CanBo_GetByID @CanBoID = 14
EXEC v1_HeThong_CanBo_Add 
    @TenCanBo = N'Hà Tùng Lâm', 
    @CoQuanID = 1, 
    @TenNguoiDung = N'hatunglam',
    @DanhSachNhomPhanQuyenID = '1' -- Assign to groups 2, 3, and 5
update HT_CanBo set TrangThai = 1 where CanBoID = 24
select * FROM HT_CanBo
select * FROM HT_NguoiDung
set IDENTITY_INSERT HT_NguoiDung ON
INSERT HT_NguoiDung (NguoiDungID,TenNguoiDung,MatKhau,GhiChu,CanBoID) VALUES (1,'admin','admin',N'Tài khoản của Administrator', 1)
set IDENTITY_INSERT HT_NguoiDung OFF



set IDENTITY_INSERT HT_NhomNguoiDung ON
INSERT HT_NhomNguoiDung (NhomNguoiDungID,NguoiDungID,NhomPhanQuyenID) VALUES (1,1,1)
set IDENTITY_INSERT HT_NhomNguoiDung OFF

select * FROM HT_NhomNguoiDung
SELECT * FROM HT_NhomChucNang

delete HT_NhomNguoiDung where NhomNguoiDungID = 55

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
-- EXEC v1_HeThong_CanBo_Delete @CanBoID = 23;

-- select * from HT_ChucNang
-- EXEC NhomPhanQuyen_GetAllUsersInAuthorizationGroup @NhomPhanQuyenID =1

update HT_CanBo set Email = 'txtlamhi@gmail.com' where CanBoID = 24

select * FROM HT_NguoiDung