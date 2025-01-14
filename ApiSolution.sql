--Handles Database
    ALTER DATABASE DB_QuanLyVanHoa
    SET SINGLE_USER
    WITH ROLLBACK IMMEDIATE;

    DROP DATABASE DB_QuanLyVanHoa 


    CREATE DATABASE DB_QuanLyVanHoa
    USE DB_QuanLyVanHoa
    GO

--Rename Database
    ALTER DATABASE [QuanLyVanHoa] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    ALTER DATABASE [QuanLyVanHoa] MODIFY NAME = DB_QuanLyVanHoa;

    ALTER DATABASE QuanLyVanHoa
    ALTER DATABASE DB_QuanLyVanHoa SET MULTI_USER;
    GO

--region Địa Giới Hành Chính Database
    CREATE TABLE DM_Tinh
    (
        TinhID INT PRIMARY KEY IDENTITY(1,1), -- Auto-incremented primary key
        TenTinh  NVARCHAR(50) NOT NULL,       -- Name of the province, NOT NULL
        TenDayDu NVARCHAR(100),               -- FullName of the province
        Mappingcode NVARCHAR(50),             -- Mapping code to backup
        LoaiDiaDanh int                       -- Type of geographic area
    )

    -- Insert records into DM_Tinh
        INSERT INTO DM_Tinh VALUES (N'An Giang',N'tỉnh An Giang',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bà Rịa - Vũng Tàu',N'tỉnh Bà Rịa - Vũng Tàu',717,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bạc Liêu',N'tỉnh Bạc Liêu',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bắc Giang',N'tỉnh Bắc Giang',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bắc Kạn',N'tỉnh Bắc Kạn',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bắc Ninh',N'tỉnh Bắc Ninh',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bến Tre',N'tỉnh Bến Tre',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bình Dương',N'tỉnh Bình Dương',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bình Định',N'tỉnh Bình Định',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bình Phước',N'tỉnh Bình Phước',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Bình Thuận',N'tỉnh Bình Thuận',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Cà Mau',N'tỉnh Cà Mau',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Cao Bằng',N'tỉnh Cao Bằng',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Cần Thơ',N'tỉnh Cần Thơ',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Đà Nẵng',N'tỉnh Đắk Lắk',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Đắk Lắk',N'tỉnh Đăk Nông',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Đăk Nông',N'tỉnh Điện Biên',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Điện Biên',N'tỉnh Đồng Nai',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Đồng Nai',N'tỉnh Đồng Tháp',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Đồng Tháp',N'tỉnh Gia Lai',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Gia Lai',N'tỉnh Hà Giang',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hà Giang',N'tỉnh Hà Nam',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hà Nam',N'tỉnh Hà Tĩnh',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hà Nội',N'tỉnh Hải Dương',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hà Tĩnh',N'tỉnh Hậu Giang',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hải Dương',N'tỉnh Hòa Bình',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hải Phòng',N'tỉnh Hưng Yên',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hậu Giang',N'tỉnh Kiên Giang',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hòa Bình',N'tỉnh Kon Tum',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hồ Chí Minh',N'tỉnh Khánh Hòa',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Hưng Yên',N'tỉnh Lai Châu',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Kiên Giang',N'tỉnh Lạng Sơn',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Kon Tum',N'tỉnh Lào Cai',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Khánh Hòa',N'tỉnh Lâm Đồng',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Lai Châu',N'tỉnh Long An',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Lạng Sơn',N'tỉnh Nam Định',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Lào Cai',N'tỉnh Ninh Bình',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Lâm Đồng',N'tỉnh Ninh Thuận',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Long An',N'tỉnh Nghệ An',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Nam Định',N'tỉnh Phú Thọ',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Ninh Bình',N'tỉnh Phú Yên',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Ninh Thuận',N'tỉnh Quảng Bình',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Nghệ An',N'tỉnh Quảng Nam',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Phú Thọ',N'tỉnh Quảng Ninh',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Phú Yên',N'tỉnh Quảng Ngãi',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Quảng Bình',N'tỉnh Quảng Trị',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Quảng Nam',N'tỉnh Sóc Trăng',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Quảng Ninh',N'tỉnh Sơn La',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Quảng Ngãi',N'tỉnh Tây Ninh',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Quảng Trị',N'tỉnh Tiền Giang',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Sóc Trăng',N'tỉnh Tuyên Quang',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Sơn La',N'tỉnh Thái Bình',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Tây Ninh',N'tỉnh Thái Nguyên',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Tiền Giang',N'tỉnh Thanh Hóa',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Tuyên Quang',N'tỉnh Thừa Thiên Huế',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Thái Bình',N'tỉnh Trà Vinh',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Thái Nguyên',N'tỉnh Vĩnh Long',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Thanh Hóa',N'tỉnh Vĩnh Phúc',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Thừa Thiên Huế',N'tỉnh Yên Bái',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Trà Vinh',N'thành phố Đà Nẵng',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Vĩnh Long',N'thành phố Hà Nội',NULL,NULL);
        INSERT INTO DM_Tinh VALUES (N'Vĩnh Phúc',N'thành phố Hải Phòng',219,NULL);
        INSERT INTO DM_Tinh VALUES (N'Yên Bái',N'thành phố Hồ Chí Minh',NULL,NULL);

    CREATE TABLE DM_Huyen
    ( 
        HuyenID INT PRIMARY KEY IDENTITY(1,1),
        TenHuyen  NVARCHAR(50) NOT NULL,
        TinhID INT NOT NULL,
        CONSTRAINT FK_TinhID FOREIGN KEY (TinhID) REFERENCES DM_Tinh(TinhID), -- Foreign key constraint
        TenDayDu NVARCHAR(100),
        MappingCode  NVARCHAR(50),
        LoaiDiaDanh INT
    )

    -- Insert records into DM_Huyen
        INSERT INTO DM_Huyen VALUES (N'Bắc Giang',4,N'thành phố Bắc Giang',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Hiệp Hòa',4,N'huyện Hiệp Hòa',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Lạng Giang',4,N'huyện Lạng Giang',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Lục Nam',4,N'huyện Lục Nam',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Lục Ngạn',4,N'huyện Lục Ngạn',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Sơn Động',4,N'huyện Sơn Động',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Tân Yên',4,N'huyện Tân Yên',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Việt Yên',4,N'huyện Việt Yên',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Yên Dũng',4,N'huyện Yên Dũng',NULL,NULL);
        INSERT INTO DM_Huyen VALUES (N'Yên Thế',4,N'huyện Yên Thế',NULL,NULL);

    CREATE TABLE DM_Xa
    (
        XaID INT PRIMARY KEY IDENTITY(1,1),
        TenXa NVARCHAR (50) NOT NULL,
        HuyenID INT NOT NULL,
        CONSTRAINT FK_HuyenID FOREIGN KEY (HuyenID) REFERENCES DM_Huyen (HuyenID),
        TenDayDu NVARCHAR(100),
        MappingCode NVARCHAR (50),
        LoaiDiaDanh INT
    )
    -- Insert records into DM_Xa
    SELECT * from DM_Xa
        INSERT INTO DM_Xa VALUES (N'Dĩnh Kế',1,N'Phường Dĩnh Kế',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đa Mai',1,N'Phường Đa Mai',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hoàng Văn Thụ',1,N'Phường Hoàng Văn Thụ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lê Lợi',1,N'Phường Lê Lợi',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Mỹ Độ',1,N'Phường Mỹ Độ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Ngô Quyền',1,N'Phường Ngô Quyền',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thọ Xương',1,N'Phường Thọ Xương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Trần Nguyên Hãn',1,N'Phường Trần Nguyên Hãn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Trần Phú',1,N'Phường Trần Phú',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Xương Giang',1,N'Phường Xương Giang',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Dĩnh Trì',1,N'Xã Dĩnh Trì',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Sơn',1,N'Xã Đồng Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Song Khê',1,N'Xã Song Khê',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Song Mai',1,N'Xã Song Mai',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Mỹ',1,N'Xã Tân Mỹ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Xương Giang',1,N'Xã Tân Tiến',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bắc Lý',2,N'thị trấn Bắc Lý',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Châu Minh',2,N'xã Châu Minh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Danh Thắng',2,N'xã Danh Thắng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đại Thành',2,N'xã Đại Thành',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đoan Bái',2,N'xã Đoan Bái',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đông Lỗ',2,N'xã Đông Lỗ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Tân',2,N'xã Đồng Tân',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hòa Sơn',2,N'xã Hòa Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hoàng An',2,N'xã Hoàng An',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hoàng Lương',2,N'xã Hoàng Lương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hoàng Thanh',2,N'xã Hoàng Thanh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hoàng Vân',2,N'xã Hoàng Vân',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hợp Thịnh',2,N'xã Hợp Thịnh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hùng Sơn',2,N'xã Hùng Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hương Lâm',2,N'xã Hương Lâm',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lương Phong',2,N'xã Lương Phong',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Mai Đình',2,N'xã Mai Đình',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Mai Trung',2,N'xã Mai Trung',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Ngọc Sơn',2,N'xã Ngọc Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quang Minh',2,N'xã Quang Minh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thái Sơn',2,N'xã Thái Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thanh Vân',2,N'xã Thanh Vân',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thắng',2,N'thị trấn Thắng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thường Thắng',2,N'xã Thường Thắng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Xuân Cẩm',2,N'xã Xuân Cẩm',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'An Hà',3,N'xã An Hà',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Dương Đức',3,N'xã Dương Đức',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đại Lâm',3,N'xã Đại Lâm',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đào Mỹ',3,N'xã Đào Mỹ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hương Lạc',3,N'xã Hương Lạc',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hương Sơn',3,N'xã Hương Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Kép',3,N'thị trấn Kép',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Mỹ Hà',3,N'xã Mỹ Hà',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Mỹ Thái',3,N'xã Mỹ Thái',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nghĩa Hòa',3,N'xã Nghĩa Hòa',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nghĩa Hưng',3,N'xã Nghĩa Hưng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quang Thịnh',3,N'xã Quang Thịnh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Dĩnh',3,N'xã Tân Dĩnh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Hưng',3,N'xã Tân Hưng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Thanh',3,N'xã Tân Thanh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tiên Lục',3,N'xã Tiên Lục',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thái Đào',3,N'xã Thái Đào',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Vôi',3,N'thị trấn Vôi',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Xuân Hương',3,N'xã Xuân Hương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Xương Lâm',3,N'xã Xương Lâm',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Yên Mỹ',3,N'xã Yên Mỹ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồi Ngô',4,N'thị trấn Đồi Ngô',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bắc Lũng',4,N'xã Bắc Lũng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bảo Đài',4,N'xã Bảo Đài',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bảo Sơn',4,N'xã Bảo Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bình Sơn',4,N'xã Bình Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cẩm Lý',4,N'xã Cẩm Lý',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Chu Điện',4,N'xã Chu Điện',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cương Sơn',4,N'xã Cương Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đan Hội',4,N'xã Đan Hội',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đông Hưng',4,N'xã Đông Hưng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đông Phú',4,N'xã Đông Phú',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Huyền Sơn',4,N'xã Huyền Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Khám Lạng',4,N'xã Khám Lạng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lan Mẫu',4,N'xã Lan Mẫu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lục Sơn',4,N'xã Lục Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nghĩa Phương',4,N'xã Nghĩa Phương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phương Sơn',4,N'xã Phương Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tam Dị',4,N'xã Tam Dị',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thanh Lâm',4,N'xã Thanh Lâm',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tiên Nha',4,N'xã Tiên Nha',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Trường Giang',4,N'xã Trường Giang',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Trường Sơn',4,N'xã Trường Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Vô Tranh',4,N'xã Vô Tranh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Vũ Xá',4,N'xã Vũ Xá',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Yên Sơn',4,N'xã Yên Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Chũ',5,N'thị trấn Chũ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Biển Động',5,N'xã Biển Động',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Biên Sơn',5,N'xã Biên Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cấm Sơn',5,N'xã Cấm Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đèo Gia',5,N'xã Đèo Gia',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Cốc',5,N'xã Đồng Cốc',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Giáp Sơn',5,N'xã Giáp Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hộ Đáp',5,N'xã Hộ Đáp',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hồng Giang',5,N'xã Hồng Giang',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Kiên Lao',5,N'xã Kiên Lao',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Kiên Thành',5,N'xã Kiên Thành',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Kim Sơn',5,N'xã Kim Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Mỹ An',5,N'xã Mỹ An',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nam Dương',5,N'xã Nam Dương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phì Điền',5,N'xã Phì Điền',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phong Minh',5,N'xã Phong Minh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phong Vân',5,N'xã Phong Vân',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phú Nhuận',5,N'xã Phú Nhuận',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phượng Sơn',5,N'xã Phượng Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quý Sơn',5,N'xã Quý Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Sa Lý',5,N'xã Sa Lý',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Sơn Hải',5,N'xã Sơn Hải',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Hoa',5,N'xã Tân Hoa',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Lập',5,N'xã Tân Lập',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Mộc',5,N'xã Tân Mộc',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Quang',5,N'xã Tân Quang',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Sơn',5,N'xã Tân Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thanh Hải',5,N'xã Thanh Hải',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Trù Hựu',5,N'xã Trù Hựu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'An Bá',6,N'xã An Bá',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'An Châu',6,N'xã An Châu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'An Lạc',6,N'xã An Lạc',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'An Lập',6,N'xã An Lập',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bồng Am',6,N'xã Bồng Am',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cẩm Đàn',6,N'xã Cẩm Đàn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cấm Sơn',6,N'xã Cấm Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Chiêm Sơn',6,N'xã Chiêm Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Dương Hưu',6,N'xã Dương Hưu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Giáo Liêm',6,N'xã Giáo Liêm',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hữu Sản',6,N'xã Hữu Sản',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lệ Viễn',6,N'xã Lệ Viễn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Long Sơn',6,N'xã Long Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phúc Thắng',6,N'xã Phúc Thắng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quế Sơn',6,N'xã Quế Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'TT An Châu',6,N'thị trấn An Châu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'TT Thanh Sơn',6,N'thị trấn Thanh Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tuấn Đạo',6,N'xã Tuấn Đạo',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tuấn Mậu',6,N'xã Tuấn Mậu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thạch Sơn',6,N'xã Thạch Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thanh Luân',6,N'xã Thanh Luân',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Vân Sơn',6,N'xã Vân Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Vĩnh Khương',6,N'xã Vĩnh Khương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Yên Định',6,N'xã Yên Định',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'An Dương',7,N'xã An Dương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cao Thượng',7,N'thị trấn Cao Thượng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cao Thượng',7,N'xã Cao Thượng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cao Xá',7,N'xã Cao Xá',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đại Hóa',7,N'xã Đại Hóa',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hợp Đức',7,N'xã Hợp Đức',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lam Cốt',7,N'xã Lam Cốt',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lan Giới',7,N'xã Lan Giới',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Liên Chung',7,N'xã Liên Chung',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Liên Sơn',7,N'xã Liên Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Ngọc Châu',7,N'xã Ngọc Châu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Ngọc Lý',7,N'xã Ngọc Lý',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Ngọc Thiện',7,N'xã Ngọc Thiện',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Ngọc Vân',7,N'xã Ngọc Vân',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nhã Nam',7,N'thị trấn Nhã Nam',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nhã Nam',7,N'xã Nhã Nam',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phúc Hòa',7,N'xã Phúc Hòa',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phúc Sơn',7,N'xã Phúc Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quang Tiến',7,N'xã Quang Tiến',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quế Nham',7,N'xã Quế Nham',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Song Vân',7,N'xã Song Vân',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Trung',7,N'xã Tân Trung',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Việt Lập',7,N'xã Việt Lập',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Việt Ngọc',7,N'xã Việt Ngọc',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bích Động',8,N'thị trấn Bích Động',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bích Sơn',8,N'xã Bích Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hoàng Ninh',8,N'xã Hoàng Ninh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hồng Thái',8,N'xã Hồng Thái',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hương Mai',8,N'xã Hương Mai',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Minh Đức',8,N'xã Minh Đức',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nếnh',8,N'thị trấn Nếnh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nghĩa Trung',8,N'xã Nghĩa Trung',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Ninh Sơn',8,N'xã Ninh Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quang Châu',8,N'xã Quang Châu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quảng Minh',8,N'xã Quảng Minh',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tăng Tiến',8,N'xã Tăng Tiến',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Thượng Lan',8,N'xã Thượng Lan',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tiên Sơn',8,N'xã Tiên Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Trung Sơn',8,N'xã Trung Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tự Lạn',8,N'xã Tự Lạn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Vân Hà',8,N'xã Vân Hà',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Vân Trung',8,N'xã Vân Trung',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Việt Tiến',8,N'xã Việt Tiến',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cảnh Thụy',9,N'xã Cảnh Thụy',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Phúc',9,N'xã Đồng Phúc',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Việt',9,N'xã Đồng Việt',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đức Giang',9,N'xã Đức Giang',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hương Gián',9,N'xã Hương Gián',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lãng Sơn',9,N'xã Lãng Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Lão Hộ',9,N'xã Lão Hộ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nội Hoàng',9,N'n',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Nhân Sơn',9,N'xã Nhân Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Quỳnh Sơn',9,N'xã Quỳnh Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân An',9,N'xã Tân An',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Liễu',9,N'xã Tân Liễu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tiến Dũng',9,N'xã Tiến Dũng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tiên Phong',9,N'xã Tiên Phong',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Neo',9,N'thị trấn Neo',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Dân',9,N'thị trấn Tân Dân',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tư Mại',9,N'xã Tư Mại',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tri Yên',9,N'xã Tri Yên',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Xuân Phú',9,N'xã Xuân Phú',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Yên Lư',9,N'xã Yên Lư',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'An Thượng',10,N'xã An Thượng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bố Hạ',10,N'thị trấn Bố Hạ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Bố Hạ',10,N'xã Bố Hạ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Canh Nậu',10,N'xã Canh Nậu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Cầu Gồ',10,N'thị trấn Cầu Gồ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đông Sơn',10,N'xã Đông Sơn',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Hưu',10,N'xã Đồng Hưu',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Kỳ',10,N'xã Đồng Kỳ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Lạc',10,N'xã Đồng Lạc',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Tiến',10,N'xã Đồng Tiến',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Đồng Vương',10,N'xã Đồng Vương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hồng Kỳ',10,N'xã Hồng Kỳ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Hương Vĩ',10,N'xã Hương Vĩ',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'NT Yên Thế',10,N'thị trấn NT Yên Thế',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Phồn Xương',10,N'xã Phồn Xương',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tam Hiệp',10,N'xã Tam Hiệp',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tam Tiến',10,N'xã Tam Tiến',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Hiệp',10,N'xã Tân Hiệp',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tân Sỏi',10,N'xã Tân Sỏi',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Tiến Thắng',10,N'xã Tiến Thắng',NULL,NULL);
        INSERT INTO DM_Xa VALUES (N'Xuân Lương',10,N'xã Xuân Lương',NULL,NULL);

    CREATE TABLE DM_Cap
    (    
        CapID INT PRIMARY KEY IDENTITY(1,1),
        TenCap NVARCHAR (50),
        ThuTu TINYINT
    )
    --Insert records into DM_Cap
        Insert DM_Cap
        VALUES  (N'Cấp Sở, Ngành', 1),
                (N'UBND Cấp Huyện', 2),
                (N'UBND Cấp Xã',3),
                (N'UBND Cấp Tỉnh',4),
                (N'Cấp Trung Ương',5),
                (N'Cấp Phòng Ban',6)


    CREATE TABLE DM_ThamQuyen
    (
        ThamQuyenID INT PRIMARY KEY IDENTITY(1,1),
        TenThamQuyen NVARCHAR(50),
        MaThamQuyen VARCHAR(20),
        GhiChu NVARCHAR(255),
        TrangThai BIT
    )
        Update DM_ThamQuyen
        set TenThamQuyen = 
            case 
                when ThamQuyenID = 1 then N'Cơ Quan Hành Chính Các Cấp'
                when ThamQuyenID = 2 then N'Cơ Quan Tư Pháp Các Cấp'
                when ThamQuyenID = 3 then N'Cơ Quan Đảng'
            end
        where ThamQuyenID in (1,2,3)
        SELECT * from DM_ThamQuyen 
    --Insert records into DM_ThamQuyen
        INSERT DM_ThamQuyen
        VALUES  ('Cơ quan hành chính các cấp', null,null,null),
                ('Cơ quan tư pháp các cấp', null,null,null),
                ('Cơ quan Đảng', null,null,null)


    CREATE TABLE DM_CoQuan
    (
        CoQuanID INT PRIMARY KEY IDENTITY(1,1),
        TenCoQuan NVARCHAR(50),
        MaCoQuan VARCHAR(25),
        CoQuanChaID int,
        CONSTRAINT FK_DMCoQuan_DMCoQuan FOREIGN KEY (CoQuanChaID) REFERENCES DM_CoQuan(CoQuanID),
        CapID INT,
        CONSTRAINT FK_DMCoQuan_DMCap FOREIGN KEY (CapID) REFERENCES DM_Cap(CapID),
        ThamQuyenID INT,
        CONSTRAINT FK_DMCoQuan_DMThamQuyen FOREIGN KEY (ThamQuyenID) REFERENCES DM_ThamQuyen (ThamQuyenID),
        TinhID INT,
        CONSTRAINT FK_DMCoQuan_DMTinh FOREIGN KEY (TinhID) REFERENCES DM_Tinh(TinhID),
        HuyenID INT,
        CONSTRAINT FK_DMCoQuan_DMHuyen FOREIGN KEY (HuyenID) REFERENCES DM_Huyen(HuyenID),
        XaID INT ,
        CONSTRAINT FK_DMCoQuan_DM_Xa FOREIGN KEY (XaID) REFERENCES DM_Xa(XaID),
        CQCoHieuLuc BIT,
        CQCapUBND BIT,
        CQCapThanhTra BIT,
        CQThuocHeThongPM BIT,
        QTCanBoTiepDan BIT,
        QTVanThuTiepNhanDon bit,
        QTTiepCongDanVaXuLyDonPhucTap BIT,
        QTGiaiQuyetPhucTap BIT
    )

    --Insert records into DM_CoQuan

    --DM_CoQuan's Processing
        GO
        CREATE PROCEDURE DMCoQuan_GetAll
            @TenCoQuan NVARCHAR(50) = NULL -- Input variable for agency name
        AS
        BEGIN
            -- Use a CTE for recursive hierarchy
            WITH RecursiveHierarchy AS (
                -- Anchor member: Start from the specified record(s) or root nodes
                SELECT 
                    CoQuanID, 
                    TenCoQuan, 
                    MaCoQuan, 
                    CoQuanChaID,
                    CapID,
                    ThamQuyenID,
                    TinhID,
                    HuyenID,
                    XaID,
                    CQCoHieuLuc,
                    CQCapUBND,
                    CQCapThanhTra,
                    CQThuocHeThongPM,
                    QTCanBoTiepDan,
                    QTVanThuTiepNhanDon,
                    QTTiepCongDanvaXuLyDonPhucTap,
                    QTGiaiQuyetPhucTap,
                    0 AS Level -- Root level starts at 0
                FROM DM_CoQuan
                WHERE 
                    -- If a search term is provided, start from matching records
                    (@TenCoQuan IS NOT NULL AND TenCoQuan LIKE '%' + @TenCoQuan + '%')
                    OR 
                    -- If no search term, start from root nodes (CoQuanChaID IS NULL)
                    (@TenCoQuan IS NULL AND CoQuanChaID IS NULL)

                UNION ALL

                -- Recursive member: Find all children of the current node
                SELECT 
                    c.CoQuanID, 
                    c.TenCoQuan, 
                    c.MaCoQuan, 
                    c.CoQuanChaID,
                    c.CapID,
                    c.ThamQuyenID,
                    c.TinhID,
                    c.HuyenID,
                    c.XaID,
                    c.CQCoHieuLuc,
                    c.CQCapUBND,
                    c.CQCapThanhTra,
                    c.CQThuocHeThongPM,
                    c.QTCanBoTiepDan,
                    c.QTVanThuTiepNhanDon,
                    c.QTTiepCongDanvaXuLyDonPhucTap,
                    c.QTGiaiQuyetPhucTap,
                    rh.Level + 1 -- Increment the level for each child node
                FROM DM_CoQuan c
                INNER JOIN RecursiveHierarchy rh ON c.CoQuanChaID = rh.CoQuanID
            )
            -- Final SELECT statement to display the hierarchy
            SELECT 
                CoQuanID, 
                TenCoQuan, 
                MaCoQuan, 
                CoQuanChaID,
                CapID,
                ThamQuyenID,
                TinhID,
                HuyenID,
                XaID,
                CQCoHieuLuc,
                CQCapUBND,
                CQCapThanhTra,
                CQThuocHeThongPM,
                QTCanBoTiepDan,
                QTVanThuTiepNhanDon,
                QTTiepCongDanvaXuLyDonPhucTap,
                QTGiaiQuyetPhucTap,
                Level -- Include the hierarchical level
            FROM RecursiveHierarchy
            ORDER BY Level, CoQuanID; -- Sort by level and ID for better structure visualization
        END;


--region Authorization Mangement System
    --region Stored procedures of Users
        CREATE TABLE HT_NguoiDung (	
            NguoiDungID INT PRIMARY KEY IDENTITY(1,1),
            TenNguoiDung NVARCHAR(50),
            TenDayDu NVARCHAR (100) null,
            Email NVARCHAR(50),
            MatKhau NVARCHAR(100),
            TrangThai BIT ,
            GhiChu NVARCHAR(100),
        );
        GO

        --Get All Users
            CREATE PROCEDURE NguoiDung_GetListPaging
                @TenNguoiDung NVARCHAR(50) = NULL, -- Updated to match the column size
                @PageNumber INT = 1,
                @PageSize INT = 20
            AS
            BEGIN
                -- Calculate the total number of records matching the search criteria
                DECLARE @TotalRecords INT;
                SELECT @TotalRecords = COUNT(*)
                FROM HT_NguoiDung
                WHERE @TenNguoiDung IS NULL OR TenNguoiDung LIKE '%' + @TenNguoiDung + '%';

                -- Return data for the current page
                SELECT 
                    a.*		 -- Added Note field
                FROM HT_NguoiDung a
                WHERE @TenNguoiDung IS NULL OR TenNguoiDung LIKE '%' + @TenNguoiDung + '%'
                ORDER BY NguoiDungID  -- Can be adjusted based on sorting requirements
                OFFSET (@PageNumber - 1) * @PageSize ROWS
                FETCH NEXT @PageSize ROWS ONLY;

                -- Return the total number of records
                SELECT @TotalRecords AS TotalRecords;
            END
            GO
        --Get User by UserID
            CREATE PROCEDURE NguoiDung_GetByID
                @NguoiDungID int
            AS
            BEGIN
                SELECT * FROM HT_NguoiDung WHERE NguoiDungID = @NguoiDungID;
            END
            GO
        --Get by Email
            CREATE PROCEDURE NguoiDung_GetByEmail
                @Email NVARCHAR(255)
            AS
            BEGIN
                SET NOCOUNT ON;
                
                SELECT * FROM HT_NguoiDung
                WHERE Email = @Email;
                SET NOCOUNT OFF;
            END;
            GO
        --Create User
            CREATE PROCEDURE NguoiDung_Create
                @TenNguoiDung NVARCHAR(50),
                @TenDayDu NVARCHAR (100),
                @Email NVARCHAR(50),
                @MatKhau NVARCHAR(100),
                @TrangThai BIT,
                @GhiChu NVARCHAR(100) = 'Regular user'
            AS
            BEGIN
                -- Insert new user record
                INSERT INTO HT_NguoiDung (TenNguoiDung, Email, MatKhau, TrangThai, GhiChu)
                VALUES (@TenNguoiDung, @Email, @MatKhau, @TrangThai, @GhiChu);
            END
            GO
        --Update User
            CREATE PROCEDURE NguoiDung_Update
                @NguoiDungID INT,
                @TenNguoiDung NVARCHAR(50),
                @TenDayDu NVARCHAR(100),
                @Email NVARCHAR(50),
                @MatKhau NVARCHAR(100),
                @TrangThai BIT,
                @GhiChu NVARCHAR(100)
            AS
            BEGIN
                -- Update existing user record
                UPDATE HT_NguoiDung
                SET 
                    TenNguoiDung = @TenNguoiDung,
                    Email = @Email,
                    MatKhau = @MatKhau,
                    TrangThai = @TrangThai,
                    GhiChu = @GhiChu,
                    TenDayDu = @TenDayDu
                WHERE NguoiDungID = @NguoiDungID;
            END
            GO
        --Delete User
            CREATE PROCEDURE [dbo].[NguoiDung_Delete]
                @NguoiDungID INT
            AS
            BEGIN
                DELETE FROM HT_NhomNguoiDung
                WHERE NguoiDungID = @NguoiDungID;
                DELETE FROM HT_PhienDangNhap
                WHERE @NguoiDungID = @NguoiDungID
                DELETE FROM HT_NguoiDung
                WHERE NguoiDungID = @NguoiDungID;
            END

            GO
        --Veryfy Login
            CREATE PROCEDURE VerifyLogin
                @TenNguoiDung NVARCHAR(50),
                @MatKhau NVARCHAR(100)
            AS
            BEGIN
                SELECT *
                FROM HT_NguoiDung
                WHERE TenNguoiDung = @TenNguoiDung AND MatKhau = @MatKhau;
            END
            GO
    --region Stored procedures of UserGroups
        CREATE TABLE HT_NhomPhanQuyen (
            NhomPhanQuyenID INT PRIMARY KEY IDENTITY(1,1),
            TenNhomPhanQuyen NVARCHAR(50),
            MoTa NVARCHAR(100)
        );
        GO
        --Get All Group
            CREATE PROCEDURE NhomPhanQuyen_GetListPaging
                @TenNhomPhanQuyen NVARCHAR(50) = NULL, -- Updated to match the column size
                @PageNumber INT = 1,
                @PageSize INT = 20
            AS
            BEGIN
                -- Calculate the total number of records matching the search criteria
                DECLARE @TotalRecords INT;
                SELECT @TotalRecords = COUNT(*)
                FROM HT_NhomPhanQuyen sug
                WHERE @TenNhomPhanQuyen IS NULL OR TenNhomPhanQuyen LIKE '%' + @TenNhomPhanQuyen + '%';

                -- Return data for the current page
                SELECT 
                    sug.NhomPhanQuyenID,
                    sug.TenNhomPhanQuyen,
                    sug.MoTa  
                FROM HT_NhomPhanQuyen sug
                WHERE @TenNhomPhanQuyen IS NULL OR TenNhomPhanQuyen LIKE '%' + @TenNhomPhanQuyen + '%'
                ORDER BY sug.NhomPhanQuyenID  -- Can be adjusted based on sorting requirements
                OFFSET (@PageNumber - 1) * @PageSize ROWS
                FETCH NEXT @PageSize ROWS ONLY;

                -- Return the total number of records
                SELECT @TotalRecords AS TotalRecords;
            END
            GO
        --Get Group By ID
                CREATE PROC NhomPhanQuyen_GetByID
                    @NhomPhanQuyenID INT 
                AS 
                BEGIN
                    SELECT * FROM HT_NhomPhanQuyen sg WHERE  sg.NhomPhanQuyenID = @NhomPhanQuyenID
                END
                GO
        --Create Group 
            CREATE PROCEDURE NhomPhanQuyen_Create
                @TenNhomPhanQuyen NVARCHAR(50),
                @MoTa NVARCHAR(100)
            AS
            BEGIN
                -- Insert a new record into Sys_Group
                INSERT INTO HT_NhomPhanQuyen (TenNhomPhanQuyen, MoTa)
                VALUES (@TenNhomPhanQuyen, @MoTa);
            END
            GO
        --Update Group
            CREATE PROCEDURE NhomPhanQuyen_Update
                @NhomPhanQuyenID INT,
                @TenNhomPhanQuyen NVARCHAR(50),
                @MoTa NVARCHAR(100)
            AS
            BEGIN
                -- Update the existing record in Sys_Group
                UPDATE HT_NhomPhanQuyen
                SET TenNhomPhanQuyen = @TenNhomPhanQuyen,
                    MoTa = @MoTa
                WHERE NhomPhanQuyenID = @NhomPhanQuyenID;
            END
            GO
        --Delete Group
            CREATE PROCEDURE NhomPhanQuyen_Delete
                @NhomPhanQuyenID INT
            AS
            BEGIN
                -- Delete the record from Sys_Group
                DELETE FROM HT_NhomPhanQuyen
                WHERE NhomPhanQuyenID = @NhomPhanQuyenID;
            END
            GO
    --region Stored procedures of Function
        CREATE TABLE HT_ChucNang (
            ChucNangID INT PRIMARY KEY IDENTITY(1,1),
            TenChucNang NVARCHAR(50),
            MoTa NVARCHAR(100),
        );
        GO
        -- GetListPaging of Function
            CREATE PROCEDURE ChucNang_GetListPaging
                @TenChucNang NVARCHAR(50) = NULL, -- Updated to match the column size
                @PageNumber INT = 1,
                @PageSize INT = 20
            AS
            BEGIN
                -- Calculate the total number of records matching the search criteria
                DECLARE @TotalRecords INT;
                SELECT @TotalRecords = COUNT(*)
                FROM HT_ChucNang 
                WHERE @TenChucNang IS NULL OR TenChucNang LIKE '%' + @TenChucNang + '%';

                -- Return data for the current page
                SELECT 
                    ChucNangID,
                    TenChucNang,
                    MoTa      
                FROM HT_ChucNang 
                WHERE @TenChucNang IS NULL OR TenChucNang LIKE '%' + @TenChucNang + '%'
                ORDER BY ChucNangID  -- Can be adjusted based on sorting requirements
                OFFSET (@PageNumber - 1) * @PageSize ROWS
                FETCH NEXT @PageSize ROWS ONLY;

                -- Return the total number of records
                SELECT @TotalRecords AS TotalRecords;
            END
            GO
        -- Get Function by ID
            CREATE PROC ChucNang_GetByID
                @ChucNangID int
            AS
            BEGIN
                SELECT * FROM HT_ChucNang sf WHERE sf.ChucNangID = @ChucNangID
            END
            GO
        -- Create Function
            CREATE PROCEDURE ChucNang_Create
                @TenChucNang NVARCHAR(50),
                @MoTa NVARCHAR(100)
            AS
            BEGIN
                -- Insert a new record into Sys_Function
                INSERT INTO HT_ChucNang (TenChucNang, MoTa)
                VALUES (@TenChucNang, @MoTa);
            END
            GO
        -- Update Function
            CREATE PROCEDURE ChucNang_Update
                @ChucNangID INT,
                @TenChucNang NVARCHAR(50),
                @MoTa NVARCHAR(100)
            AS
            BEGIN
                -- Update the existing record in Sys_Function
                UPDATE HT_ChucNang
                SET TenChucNang = @TenChucNang,
                    MoTa = @MoTa
                WHERE ChucNangID = @ChucNangID;
            END
            GO
        -- Delete Function
            CREATE PROCEDURE [dbo].[ChucNang_Delete]
                @ChucNangID INT
            AS
            BEGIN
                -- Delete the record from Sys_Function
                DELETE FROM HT_NhomChucNang
                WHERE @ChucNangID = @ChucNangID;
                DELETE FROM HT_ChucNang
                WHERE ChucNangID = @ChucNangID;
            END
    --region Stored procedures of UserInGroup
        CREATE TABLE HT_NhomNguoiDung (
            NhomNguoiDungID INT PRIMARY KEY IDENTITY(1,1) ,
            NguoiDungID INT NOT NULL,
            NhomPhanQuyenID INT NOT NULL,
            FOREIGN KEY (NguoiDungID) REFERENCES HT_NguoiDung(NguoiDungID),
            FOREIGN KEY (NhomPhanQuyenID) REFERENCES HT_NhomPhanQuyen(NhomPhanQuyenID)
        );
        GO


        -- Add User to Group
            CREATE PROC NhomNguoiDung_AddUserToAuthorizationGroup  
                @NguoiDungID INT ,
                @NhomPhanQuyenID INT
            AS
            BEGIN
                INSERT INTO HT_NhomNguoiDung (NguoiDungID, NhomPhanQuyenID)
                VALUES (@NguoiDungID,@NhomPhanQuyenID);
            END
            GO

        CREATE PROCEDURE NhomNguoiDung_DeleteUserInAuthorizationGroup
            @NguoiDungID INT,
            @NhomNguoiDungID INT
        AS
        BEGIN
            DELETE FROM HT_NhomNguoiDung
            WHERE NguoiDungID = @NguoiDungID AND NhomNguoiDungID = @NhomNguoiDungID
        END;
        GO	
    --region Stored procedures of FunctionInGroup
    CREATE TABLE HT_NhomChucNang (
        NhomChucNangID INT PRIMARY KEY IDENTITY(1,1),
        ChucNangID INT,
        NhomPhanQuyenID INT,
        Quyen INT NOT NULL, 
        FOREIGN KEY (ChucNangID) REFERENCES HT_ChucNang(ChucNangID),
        FOREIGN KEY (NhomPhanQuyenID) REFERENCES HT_NhomPhanQuyen(NhomPhanQuyenID)
    );
    GO

    CREATE PROC NhomChucNang_GetUserFunctionAccess
    @NhomPhanQuyenID INT
    AS
    BEGIN
        SELECT a.TenChucNang,a.[MoTa],b.NhomPhanQuyenID, c.TenNhomPhanQuyen,b.Quyen FROM HT_ChucNang a 
        JOIN HT_NhomChucNang b on a.ChucNangID = b.ChucNangID 
        JOIN HT_NhomPhanQuyen c on b.NhomPhanQuyenID = c.NhomPhanQuyenID 
        where c.NhomPhanQuyenID = @NhomPhanQuyenID
    END
    GO

    CREATE PROCEDURE NhomChucNang_AddFunctionToAuthorizationsGroup
        @ChucNangID INT,
        @NhomPhanQuyenID INT,
        @Quyen INT
    AS
    BEGIN
        INSERT INTO HT_NhomChucNang (ChucNangID, NhomPhanQuyenID, Quyen)
        VALUES (@ChucNangID, @NhomPhanQuyenID, @Quyen);
    END;
    GO

    CREATE PROCEDURE NhomChucNang_UpdateFunctionalAccessPermissions
        @ChucNangID INT,
        @NhomPhanQuyenID INT,
        @Quyen INT
    AS
    BEGIN
        UPDATE HT_NhomChucNang
        SET Quyen = @Quyen
        WHERE ChucNangID = @ChucNangID AND NhomPhanQuyenID = @NhomPhanQuyenID;
    END;
    GO	

    CREATE PROCEDURE NhomChucNang_DeleteFunctionInAuthorizationGroup
        @ChucNangID INT,
        @NhomPhanQuyenID INT
    AS
    BEGIN
        DELETE FROM HT_NhomChucNang
        WHERE ChucNangID = @ChucNangID and NhomPhanQuyenID = @NhomPhanQuyenID;
    END
    GO	

    CREATE PROCEDURE NhomChucNang_GetAllUserFunctionsAndPermissions
        @TenNguoiDung NVARCHAR(50)
    AS
    BEGIN
        SELECT f.TenChucNang, fg.Quyen
        FROM HT_NhomChucNang fg
        INNER JOIN HT_ChucNang f ON fg.ChucNangID = f.ChucNangID
        INNER JOIN HT_NhomNguoiDung ug ON fg.NhomPhanQuyenID = ug.NhomPhanQuyenID
        INNER JOIN HT_NguoiDung u ON ug.NguoiDungID = u.NguoiDungID
        WHERE u.TenNguoiDung = @TenNguoiDung
    END
    GO	
    --region Stored procedures of RefreshToken
        CREATE TABLE HT_PhienDangNhap
        (
            PhienDangNhapID INT IDENTITY PRIMARY KEY,
            NguoiDungID INT FOREIGN KEY REFERENCES HT_NguoiDung(NguoiDungID),
            RefreshToken NVARCHAR(255) NOT NULL,
            ExpiryDate DATETIME NOT NULL,
            IsRevoked BIT NOT NULL DEFAULT 0,   -- Đánh dấu refresh token này đã bị thu hồi hay chưa
            CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        );
        GO

        CREATE PROCEDURE PhienDangNhap_Create
            @NguoiDungID INT,
            @RefreshToken NVARCHAR(255),
            @ExpiryDate DATETIME
        AS
        BEGIN
            -- Tạo phiên (Session) mới cho người dùng với refresh token
            INSERT INTO HT_PhienDangNhap (NguoiDungID, RefreshToken, ExpiryDate, IsRevoked, CreatedAt)
            VALUES (@NguoiDungID, @RefreshToken, @ExpiryDate, 0, GETDATE());
        END
        GO



        CREATE PROCEDURE PhienDangNhap_GetByRefreshToken
            @RefreshToken NVARCHAR(255)
        AS
        BEGIN
            SELECT PhienDangNhapID, NguoiDungID, RefreshToken, ExpiryDate, IsRevoked, CreatedAt
            FROM HT_PhienDangNhap
            WHERE RefreshToken = @RefreshToken AND IsRevoked = 0 AND ExpiryDate > GETDATE();
        END
        GO

        CREATE PROCEDURE PhienDangNhap_UpdateRefreshToken
            @PhienDangNhapID INT,
            @NewRefreshToken NVARCHAR(255),
            @NewExpiryDate DATETIME
        AS
        BEGIN
            UPDATE HT_PhienDangNhap
            SET RefreshToken = @NewRefreshToken, ExpiryDate = @NewExpiryDate, CreatedAt = GETDATE()
            WHERE PhienDangNhapID = @PhienDangNhapID AND IsRevoked = 0;
        END
        GO

        CREATE PROCEDURE PhienDangNhap_Revoke
            @PhienDangNhapID INT
        AS
        BEGIN
            UPDATE HT_PhienDangNhap
            SET IsRevoked = 1, CreatedAt = GETDATE()
            WHERE PhienDangNhapID = @PhienDangNhapID;
        END
        GO

        CREATE PROCEDURE PhienDangNhap_RevokeAllSessionsOfUser
            @NguoiDungID INT
        AS
        BEGIN
            UPDATE HT_PhienDangNhap
            SET IsRevoked = 1, CreatedAt = GETDATE()
            WHERE NguoiDungID = @NguoiDungID AND IsRevoked = 0;
        END
        GO

        CREATE PROCEDURE PhienDangNhap_DeleteAllSessionsOfUser
            @NguoiDungID INT
        AS
        BEGIN
            DELETE FROM HT_PhienDangNhap
            WHERE NguoiDungID = @NguoiDungID;
        END
        GO


--region Category Mangement System
--region Stored procedures of DonViTinh
    CREATE TABLE DM_DonViTinh
    (
        DonViTinhID INT PRIMARY KEY IDENTITY (1,1),
        TenDonViTinh NVARCHAR (100),
        MaDonViTinh NVARCHAR (100),
        TrangThai BIT,
        GhiChu NVARCHAR(300),
    );
    GO

    CREATE PROC DVT_GetAll
    @TenDonViTinh NVARCHAR(100) = NULL,
    @PageNumber INT = 1,
    @PageSize INT = 20
    AS
    BEGIN
        -- Tính tổng số bản ghi phù hợp với điều kiện tìm kiếm
        DECLARE @TotalRecords INT;
        SELECT @TotalRecords = COUNT(*)
        FROM DM_DonViTinh
        WHERE @TenDonViTinh IS NULL OR TenDonViTinh LIKE '%' + @TenDonViTinh + '%';

        -- Trả về dữ liệu cho trang hiện tại
        SELECT 
            DonViTinhID,
            TenDonViTinh,
            MaDonViTinh,
            TrangThai,
            GhiChu
        FROM DM_DonViTinh
        WHERE @TenDonViTinh IS NULL OR TenDonViTinh LIKE '%' + @TenDonViTinh + '%'
        ORDER BY DonViTinhID
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        -- Trả về tổng số bản ghi
        SELECT @TotalRecords AS TotalRecords;
    END
    GO

    CREATE PROC DVT_GetByID
        @DonViTinhID INT
    AS	
    BEGIN
        SELECT*FROM DM_DonViTinh WHERE DonViTinhID=@DonViTinhID;
    END
    GO

    CREATE PROC DVT_Insert
        @TenDonViTinh NVARCHAR(100),
        @MaDonViTinh NVARCHAR(100),
        @TrangThai BIT,
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        INSERT INTO DM_DonViTinh (TenDonViTinh,MaDonViTinh,TrangThai,GhiChu) VALUES (@TenDonViTinh,@MaDonViTinh,@TrangThai,@GhiChu);
    END
    GO

    CREATE PROC DVT_Update
        @DonViTinhID INT,
        @TenDonViTinh NVARCHAR(100),
        @MaDonViTinh NVARCHAR(100),
        @TrangThai BIT,
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        UPDATE DM_DonViTinh
        SET TenDonViTinh = @TenDonViTinh, MaDonViTinh = @MaDonViTinh, TrangThai = @TrangThai, GhiChu = @GhiChu WHERE DonViTinhID = @DonViTinhID;
    END
    GO	

    CREATE PROC DVT_Delete
        @DonViTinhID INT
    AS
    BEGIN 
        DELETE FROM DM_DonViTinh WHERE DonViTinhID = @DonViTinhID;
    END
    GO
--endregion

--region Stored procedures LoaiDiTich
    CREATE TABLE DM_LoaiDiTich(
        LoaiDiTichID INT PRIMARY KEY IDENTITY(1,1),
        LoaiDiTichChaID INT DEFAULT 0,
        TenLoaiDiTich NVARCHAR(100),
        MaLoaiDiTich NVARCHAR(100) DEFAULT '',
        TrangThai BIT DEFAULT 0,
        GhiChu NVARCHAR(300),
        Loai INT DEFAULT 4
    );
    GO

    CREATE PROC LDT_GetAll
    @TenLoaiDiTich NVARCHAR(100) = NULL,
    @PageNumber INT = 1,
    @PageSize INT = 20
    AS
    BEGIN
        -- Tính tổng số bản ghi phù hợp với điều kiện tìm kiếm
        DECLARE @TotalRecords INT;
        SELECT @TotalRecords = COUNT(*)
        FROM DM_LoaiDiTich
        WHERE @TenLoaiDiTich IS NULL OR TenLoaiDiTich LIKE '%' + @TenLoaiDiTich + '%';

        -- Trả về dữ liệu cho trang hiện tại
        SELECT 
            *
        FROM DM_LoaiDiTich
        WHERE @TenLoaiDiTich IS NULL OR TenLoaiDiTich LIKE '%' + @TenLoaiDiTich + '%'
        ORDER BY LoaiDiTichID
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        -- Trả về tổng số bản ghi
        SELECT @TotalRecords AS TotalRecords;
    END
    GO


    CREATE PROC LDT_GetByID
        @LoaiDiTichID INT
    AS	
    BEGIN
        SELECT*FROM DM_LoaiDiTich WHERE LoaiDiTichID=@LoaiDiTichID;
    END
    GO

    CREATE PROC LDT_Insert
        @TenLoaiDiTich NVARCHAR(100),
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        INSERT INTO DM_LoaiDiTich (TenLoaiDiTich,GhiChu) VALUES (@TenLoaiDiTich,@GhiChu);
    END
    GO

    CREATE PROC LDT_Update
        @LoaiDiTichID INT,
        @TenLoaiDiTich NVARCHAR(100),
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        UPDATE DM_LoaiDiTich
        SET TenLoaiDiTich = @TenLoaiDiTich, GhiChu = @GhiChu WHERE LoaiDiTichID = @LoaiDiTichID;
    END
    GO	

    CREATE PROC LDT_Delete
        @LoaiDiTichID INT
    AS
    BEGIN 
        DELETE FROM DM_LoaiDiTich WHERE LoaiDiTichID = @LoaiDiTichID;
    END
    GO
--endregion

--region Stored procedures of DiTichXepHang
    CREATE TABLE DM_DiTichXepHang (
        DiTichXepHangID INT IDENTITY(1,1),
        DiTichXepHangChaID INT DEFAULT 0,
        TenDiTich NVARCHAR(100),
        MaDiTich NVARCHAR(100)  DEFAULT '',
        TrangThai BIT  DEFAULT 0,
        GhiChu NVARCHAR(300),
        Loai INT DEFAULT 0
    );
    GO

    CREATE PROC DTXH_GetAll
        @TenDiTich NVARCHAR(100) = NULL,
        @PageNumber INT = 1,
        @PageSize INT = 20
    AS
    BEGIN
        -- Tính tổng số bản ghi phù hợp với điều kiện tìm kiếm
        DECLARE @TotalRecords INT;
        SELECT @TotalRecords = COUNT(*)
        FROM DM_DITICHXEPHANG
        WHERE @TenDiTich IS NULL OR TenDiTich LIKE '%' + @TenDiTich + '%';

        -- Trả về dữ liệu cho trang hiện tại
        SELECT 
            DiTichXepHangID,
            DiTichXepHangChaID,
            TenDiTich,
            MaDiTich,
            TrangThai,
            GhiChu,
            Loai
        FROM DM_DITICHXEPHANG
        WHERE @TenDiTich IS NULL OR TenDiTich LIKE '%' + @TenDiTich + '%'
        ORDER BY GhiChu
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        -- Trả về tổng số bản ghi
        SELECT @TotalRecords AS TotalRecords;
    END
    GO

    create PROC DTXH_GetByID
        @DiTichXepHangID INT
    AS	
    BEGIN
        SELECT 
            DiTichXepHangID,
            DiTichXepHangChaID,
            TenDiTich,
            MaDiTich,
            TrangThai,
            GhiChu,
            Loai
        FROM DM_DITICHXEPHANG
        WHERE DiTichXepHangID = @DiTichXepHangID;
    END
    GO	

    CREATE PROC DTXH_Insert
        @TenDiTich NVARCHAR(100),
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        INSERT INTO DM_DITICHXEPHANG (TenDiTich, GhiChu) 
        VALUES (@TenDiTich, @GhiChu);
    END
    GO

    CREATE PROC DTXH_Update
        @DiTichXepHangID INT,
        @TenDiTich NVARCHAR(100),
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        UPDATE DM_DITICHXEPHANG
        SET 
            TenDiTich = @TenDiTich,
            GhiChu = @GhiChu
        WHERE DiTichXepHangID = @DiTichXepHangID;
    END
    GO

    create PROC DTXH_Delete
        @DiTichXepHangID INT
    AS
    BEGIN 
        DELETE FROM DM_DITICHXEPHANG 
        WHERE DiTichXepHangID = @DiTichXepHangID;
    END
    GO
--endregion

--region Stored procedures of DM_KyBaoCao
    CREATE TABLE DM_KyBaoCao (
        KyBaoCaoID INT IDENTITY(1,1) PRIMARY KEY,
        KyBaoCaoChaID INT DEFAULT 0,
        TenKyBaoCao NVARCHAR(100) NOT NULL,
        MaKyBaoCao NVARCHAR(100) DEFAULT '',
        TrangThai BIT NOT NULL,
        GhiChu NVARCHAR(300),
        LoaiKyBaoCao INT DEFAULT 2
    ); 
    GO 

    create PROCEDURE KBC_GetAll
        @TenKyBaoCao NVARCHAR(100) = NULL,
        @PageNumber INT = 1,
        @PageSize INT = 20
    AS
    BEGIN
        SET NOCOUNT ON;

        -- Tính tổng số bản ghi phù hợp với điều kiện tìm kiếm (không phân biệt chữ hoa, chữ thường)
        DECLARE @TotalRecords INT;
        SELECT @TotalRecords = COUNT(*)
        FROM DM_KyBaoCao dkbc
        WHERE @TenKyBaoCao IS NULL OR LOWER(TenKyBaoCao) LIKE '%' + LOWER(@TenKyBaoCao) + '%';

        -- Trả về dữ liệu cho trang hiện tại
        SELECT 
            KyBaoCaoID,
            KyBaoCaoChaID,
            TenKyBaoCao,
            TrangThai,
            GhiChu,
            LoaiKyBaoCao
        FROM DM_KyBaoCao
        WHERE @TenKyBaoCao IS NULL OR LOWER(TenKyBaoCao) LIKE '%' + LOWER(@TenKyBaoCao) + '%'
        ORDER BY KyBaoCaoID
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        -- Trả về tổng số bản ghi
        SELECT @TotalRecords AS TotalRecords;
    END;
    GO	

    create PROC KBC_GetByID
        @KyBaoCaoID INT
    AS
    BEGIN
        SELECT * FROM DM_KyBaoCao dkbc  WHERE dkbc.KyBaoCaoID = @KyBaoCaoID 
    END
    GO

    create PROCEDURE KBC_Insert
        @TenKyBaoCao NVARCHAR(100),
        @TrangThai BIT,
        @GhiChu NVARCHAR(100) 
    AS
    BEGIN
        SET NOCOUNT ON;

        INSERT INTO DM_KyBaoCao (TenKyBaoCao, TrangThai, GhiChu)
        VALUES (@TenKyBaoCao, @TrangThai, @GhiChu);

        -- Trả về ID của bản ghi vừa tạo
        SELECT SCOPE_IDENTITY() AS KyBaoCaoID;
    END;
    GO	

    create PROCEDURE KBC_Update
        @KyBaoCaoID INT,
        @TenKyBaoCao NVARCHAR(100),
        @TrangThai BIT,
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        SET NOCOUNT ON;

        UPDATE DM_KyBaoCao
        SET 
            TenKyBaoCao = @TenKyBaoCao,
            TrangThai = @TrangThai,
            GhiChu = @GhiChu
        WHERE 
            KyBaoCaoID = @KyBaoCaoID;

        -- Trả về số bản ghi đã được cập nhật
        SELECT @@ROWCOUNT AS RowsAffected;
    END;
    GO

    create PROCEDURE KBC_Delete
        @KyBaoCaoID INT
    AS
    BEGIN
        SET NOCOUNT ON;

        DELETE FROM DM_KyBaoCao
        WHERE KyBaoCaoID = @KyBaoCaoID;

        -- Trả về số bản ghi đã bị xóa
        SELECT @@ROWCOUNT AS RowsAffected;
    END;
    GO	

--endregion
--endregion

--region Comprehensive Management Of Report Templates
--region Stored Procedure of Report Form Management
    CREATE TABLE BC_MauPhieu(
        MauPhieuID INT PRIMARY KEY IDENTITY (1,1),
        TenMauPhieu NVARCHAR (100),
        MaMauPhieu NVARCHAR (100),
        LoaiMauPhieuID INT FOREIGN KEY (LoaiMauPhieuID) REFERENCES DM_LoaiMauPhieu (LoaiMauPhieuID),
        NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
        NguoiTao NVARCHAR (100) DEFAULT NULL
    )
    GO

-- GetAll MauPhieu
    CREATE PROC MP_GetAll
        @TenMauPhieu NVARCHAR(100) = Null,
        @PageNumber INT = 1,
        @PageSize INT = 20
    AS
    BEGIN	
        -- Tính tổng số bản ghi phù hợp với điều kiện tìm kiếm
        DECLARE @TotalRecords INT;
        SELECT @TotalRecords = COUNT(*) FROM BC_MauPhieu WHERE LOWER(@TenMauPhieu) IS NULL OR TenMauPhieu LIKE '%' + LOWER(@TenMauPhieu) + '%';

        -- Trả về dữ liệu cho trang hiện tại
        SELECT 
            bmp.MauPhieuID,bmp.TenMauPhieu, bmp.MaMauPhieu,bmp.LoaiMauPhieuID,bmp.NgayTao,bmp.NguoiTao
        FROM BC_MauPhieu bmp
        WHERE @TenMauPhieu IS NULL OR  LOWER(@TenMauPhieu) LIKE '%' + LOWER(TenMauPhieu) + '%'
        ORDER BY bmp.MauPhieuID
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY

        -- Trả về tổng số bản ghi
        SELECT @TotalRecords AS TotalRecords
    END
    GO

    CREATE PROC MP_GetByID 
        @MauPhieuID INT
    AS
    BEGIN
        SELECT * FROM BC_MauPhieu 
    END
    GO

    CREATE PROC MP_Insert
        @TenMauPhieu NVARCHAR (100),
        @MaMauPhieu  NVARCHAR (100),
        @LoaiMauPhieuID INT
    AS
    BEGIN
        INSERT INTO BC_MauPhieu (TenMauPhieu, MaMauPhieu, LoaiMauPhieuID)
        VALUES (@TenMauPhieu, @MaMauPhieu, @LoaiMauPhieuID);
    END
    GO

    CREATE PROC MP_Update
        @MauPhieuID INT ,
        @TenMauPhieu NVARCHAR (100),
        @MaMauPhieu  NVARCHAR (100),
        @LoaiMauPhieuID INT
    AS
    BEGIN
        UPDATE BC_MauPhieu
        SET TenMauPhieu = @TenMauPhieu,  LoaiMauPhieuID = @LoaiMauPhieuID
        WHERE MauPhieuID = @MauPhieuID
    END	
    GO	

    CREATE PROC MP_Delete
        @MauPhieuID int
    AS
    BEGIN
        DELETE FROM BC_MauPhieu  WHERE MauPhieuID = @MauPhieuID
    END
    GO	
--endregion	

--region Stored procedures of DM_LoaiMauPieu
    CREATE TABLE DM_LoaiMauPhieu
    (
        LoaiMauPhieuID INT PRIMARY KEY IDENTITY(1,1),
        LoaiMauPhieuChaID INT DEFAULT 0,
        TenLoaiMauPhieu NVARCHAR(100),
        MaLoaiMauPhieu NVARCHAR(100),
        TrangThai BIT DEFAULT 0,
        GhiChu NVARCHAR(300),
        Loai INT DEFAULT 3
    );
    GO 

    ALTER TABLE DM_ChiTieu
    ADD CONSTRAINT FK_DM_ChiTieu_DM_LoaiMauPhieu
    FOREIGN KEY (LoaiMauPhieuID) REFERENCES DM_LoaiMauPhieu(LoaiMauPhieuID)
    ON DELETE CASCADE;
    GO

    CREATE PROC LMP_GetAll
    @TenLoaiMauPhieu NVARCHAR(100) = NULL,
    @PageNumber INT = 1,
    @PageSize INT = 20
    AS
    BEGIN
        -- Tính tổng số bản ghi phù hợp với điều kiện tìm kiếm
        DECLARE @TotalRecords INT;
        SELECT @TotalRecords = COUNT(*)
        FROM DM_LoaiMauPhieu
        WHERE @TenLoaiMauPhieu IS NULL OR TenLoaiMauPhieu LIKE '%' + @TenLoaiMauPhieu + '%';

        -- Trả về dữ liệu cho trang hiện tại
        SELECT 
            LoaiMauPhieuID,
            LoaiMauPhieuChaID,
            TenLoaiMauPhieu,
            MaLoaiMauPhieu,
            TrangThai,
            GhiChu,
            Loai
        FROM DM_LoaiMauPhieu
        WHERE @TenLoaiMauPhieu IS NULL OR TenLoaiMauPhieu LIKE '%' + @TenLoaiMauPhieu + '%'
        ORDER BY LoaiMauPhieuID
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        -- Trả về tổng số bản ghi
        SELECT @TotalRecords AS TotalRecords;
    END
    GO

    CREATE PROC LMP_GetByID
        @LoaiMauPhieuID INT
    AS	
    BEGIN
        SELECT*FROM DM_LoaiMauPhieu WHERE LoaiMauPhieuID=@LoaiMauPhieuID;
    END
    GO

    CREATE PROC LMP_Insert
        @TenLoaiMauPhieu NVARCHAR(100),
        @MaLoaiMauPhieu NVARCHAR(100),
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        INSERT INTO DM_LoaiMauPhieu (TenLoaiMauPhieu,MaLoaiMauPhieu,GhiChu) VALUES (@TenLoaiMauPhieu,@MaLoaiMauPhieu,@GhiChu);
    END
    GO

    CREATE PROC LMP_Update
        @LoaiMauPhieuID INT,
        @TenLoaiMauPhieu NVARCHAR(100),
        @MaLoaiMauPhieu NVARCHAR(100),
        @GhiChu NVARCHAR(100)
    AS
    BEGIN
        UPDATE DM_LoaiMauPhieu
        SET TenLoaiMauPhieu = @TenLoaiMauPhieu, MaLoaiMauPhieu = @MaLoaiMauPhieu, GhiChu = @GhiChu WHERE LoaiMauPhieuID = @LoaiMauPhieuID;
    END
    GO	

    CREATE PROC LMP_Delete
        @LoaiMauPhieuID INT
    AS
    BEGIN 
        DELETE FROM DM_LoaiMauPhieu WHERE LoaiMauPhieuID = @LoaiMauPhieuID;
    END
    GO
--endregion
--endregion

--region Stored procedures of ChiTieu
    CREATE TABLE DM_ChiTieu (
        ChiTieuID INT PRIMARY KEY IDENTITY(1,1),
        MaChiTieu NVARCHAR(100) NOT NULL,        
        TenChiTieu NVARCHAR(100) NOT NULL,      
        ChiTieuChaID INT NULL,                  
        GhiChu NVARCHAR(300) DEFAULT '',               
        TrangThai BIT DEFAULT 0,                 
        LoaiMauPhieuID INT NOT NULL,                 
        FOREIGN KEY (ChiTieuChaID) REFERENCES DM_ChiTieu(ChiTieuID)
    );  
    GO 
    
    --Insert Records into DM_ChiTieu table
        SET IDENTITY_INSERT DM_ChiTieu ON
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (38,'CT001',N'DI TÍCH',NULL,NULL,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (39,'CT1_1',N'Tổng số Di tích xếp hạng cấp tỉnh:',NULL,38,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (45,'CT1_1_001',N'Di tích lịch sử:',NULL,39,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (46,'CT1_1_002',N'Di tích kiến trúc nghệ thuật:',NULL,39,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (47,'CT1_1_003',N'Di tích khảo cổ:',NULL,39,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (48,'CT1_1_004',N'Danh lam thắng cảnh:',NULL,39,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (49,'CT1_1_005',N'Số Di tích cấp tỉnh được xếp hạng trong năm:',NULL,39,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (50,'CT1_2',N'Tổng số Di tích xếp hạng quốc gia:',NULL,38,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (51,'CT1_2_001',N'-Di tích lịch sử: ',NULL,50,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (52,'CT1_2_002',N'Di tích kiến trúc nghệ thuật:',NULL,50,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (53,'CT1_2_003',N'Di tích khảo cổ:',NULL,50,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (54,'CT1_2_004',N'Danh lam thắng cảnh:',NULL,50,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (55,'CT1_2_005',N'Số Di tích quốc gia được xếp hạng trong năm:',NULL,50,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (56,'CT1_3',N'Tổng số Di tích quốc gia đặc biệt được xếp hạng:',NULL,38,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (57,'CT1_3_001',N'Số Di tích quốc gia đặc biệt được xếp hạng trong',NULL,56,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (59,'SLTV',N'Số lượng thư viện',NULL,NULL,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (60,'TSTVCCHC',N'Tổng số thư viện công cộng hiện có',NULL,59,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (61,'STVCC',N'Số thư viện công cộng thành lập trong năm',NULL,59,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (62,'STVCH',N'Số thư viện công cộng cấp huyện trực thuộc UBND',NULL,59,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (63,'STVTNCPVCC',N'Số thư viện tư nhân có phục vụ cộng đồng',NULL,59,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (64,'STVCD',N'Số thư viện cộng đồng',NULL,59,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (66,'NLTV',N'Nhân lực thư viện',NULL,NULL,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (67,'SLNL',N'Số lượng người làm công tác thư viện hiện có Số thư viện công cộng thành lập trong năm',NULL,66,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (68,'CLNL',N'Chất lượng nguồn nhân lực:',NULL,66,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (69,'TDHV',N'Về trình độ học vấn:',NULL,68,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (70,'DHTL',N'Số người có trình độ Đại học trở lên',NULL,69,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (71,'CDTH',N'Số người có trình độ Cao đẳng/ trung học chuyên nghiệp',NULL,69,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (72,'THPT',N'Số người có trình độ trung học phổ thông',NULL,69,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (73,'CMNTV',N'Về chuyên môn ngành thư viện',NULL,68,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (74,'SNDTCNTV',N'Số người đào tạo chuyên ngành thư viện',NULL,73,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (75,'SNDTCNK',N'Số người đào tạo chuyên ngành khác',NULL,73,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (76,'SLCBDDTTHTN',N'Số lượt cán bộ được đào tạo, tập huấn trong năm',NULL,68,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (77,'DTLS',N'Di tích lịch sử: 1',NULL,45,0,1);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (79,'BT',N'Bảo tàng',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (80,'BTTT',N'Tổng số bảo tàng trực thuộc:',NULL,79,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (81,'HVBT',N'Tổng số hiện vật có trong từng bảo tàng:',NULL,79,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (82,'STTN',N'Số hiện vật bảo tàng mới được sưu tầm trong năm (của từng bảo tàng):',NULL,81,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (83,'STHVTBT',N'Tổng số sưu tập hiện vật trong từng bảo tàng',NULL,79,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (84,'HBHTTN',N'Số sưu tập hiện vật được hình thành trong năm của từng bảo tàng:',NULL,83,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (85,'SKTQTN',N'Tổng số khách tham quan trong năm của từng bảo tàng:',NULL,79,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (86,'PTQTN',N'Tổng thu từ phí tham quan trong năm của từng bảo tàng (nếu có):',NULL,79,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (87,'TBCD',N'Tổng số trưng bày chuyên đề của từng bảo tàng:',NULL,79,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (92,'BVQG',N'Bảo vật quốc gia',NULL,NULL,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (102,'007-SLXCPTL',N'Số lượng xin cấp xin phép triển lãm',NULL,NULL,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (103,'TLMT',N'Triển lãm mỹ thuật',NULL,102,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (104,'Trongnuoc',N'Trong nước',NULL,103,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (105,'Ranuocngoai',N'Ra nước ngoài ',NULL,103,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (106,'TLNA',N'Triển lãm nhiếp ảnh',NULL,102,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (107,'TN2',N'Trong nước ',NULL,106,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (108,'RaNuocngoai2',N'Ra nước ngoài ',NULL,106,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (109,'Các TLKVMDTM',N'Các Triển lãm không vì mục đích thương mại',NULL,102,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (110,'TN3',N'Trong nước ',NULL,109,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (111,'RNN3',N'Ra nước ngoài',NULL,109,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (112,'SLGP',N'Số lượng giấy phép/ văn bản phê duyệt nội dung tác phẩm mỹ thuật, nhiếp ảnh xuất, nhập khẩu',NULL,102,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (113,'SLHS,NĐK',N'Số lượng họa sĩ, nhà điêu khắc, nghệ sĩ nhiếp ảnh',NULL,NULL,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (114,'MT1',N'Mỹ thuật',NULL,113,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (115,'HSMTĐP',N'Họa sĩ Hội Mỹ thuật địa phương',NULL,114,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (116,'NĐK',N'Nhà điêu khắc Hội Mỹ thuật địa phương',NULL,114,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (117,'NA',N'Nhiếp ảnh',NULL,113,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (118,'HVHNA',N'Hội viên hội nhiếp ảnh địa phương',NULL,117,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (119,'SL CTTĐ',N'Số lượng công trình tượng đài được xây dựng, trại sáng tác được tổ chức',NULL,NULL,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (120,'TĐ 2',N'Tượng đài',NULL,119,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (121,'THT',N'Tranh hoàng tráng',NULL,119,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (122,'TSTMT',N'Trại sáng tác mỹ thuật',NULL,119,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (123,'TSTNA',N'Trại sáng tác nhiếp ảnh',NULL,119,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (124,'SLNTL',N'Số lượng nhà triển lãm',NULL,NULL,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (125,'SCTTHĐMT',N'Số cuộc thanh tra hoạt động mỹ thuật, nhiếp ảnh và triển lãm',NULL,NULL,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (131,'GD',N'Gia Đình',NULL,NULL,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (132,'TSHGD',N'Tổng số hộ gia đình',NULL,131,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (133,'SHGDCCCHMSCVC',N'Số hộ gia đình chỉ có cha hoặc mẹ sống chung với con',NULL,132,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (134,'SHGDC1TH',N'Số hộ gia đình 1 thế hệ (vợ, chồng)',NULL,132,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (135,'SHGD2TH',N'Số hộ gia đình 2 thế hệ',NULL,132,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (136,'SHGD3THTL',N'Số hộ gia đình 3 thế hệ trở lên',NULL,132,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (137,'SHGDK',N'Số hộ gia đình khác',NULL,132,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (138,'BLGD',N'Bạo lực gia đình',NULL,NULL,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (140,'TSHCBLGD',N'Tổng số hộ có bạo lực gia đình',NULL,138,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (142,'TSVBLGD',N'Tổng số vụ bạo lực gia đình',NULL,138,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (143,'HTBL',N'Hình thức bạo lực',NULL,138,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (145,'TT',N'Tinh thần',NULL,143,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (147,'THANT',N'Thân thể',NULL,143,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (149,'TD',N'Tình dục',NULL,143,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (150,'KT',N'Kinh tế',NULL,143,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (152,'NGBLGDVBPXL',N'Người gây bạo lực gia đình và biện pháp xử lý',NULL,138,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (153,'GT',N'Giới tính',NULL,152,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (155,'N',N'Nam',NULL,153,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (157,'NU',N'Nữ',NULL,153,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (159,'DOTUOI',N'Độ tuổi',NULL,152,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (160,'D16T',N'Dưới 16 tuổi',NULL,159,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (161,'TD60TTL',N'Từ đủ 60 tuổi trở lên',NULL,159,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (163,'BPXL',N'Biện pháp xử lý',NULL,138,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (165,'GYPBTCDDC',N'Góp ý, phê bình trong cộng đồng dân cư',NULL,163,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (167,'ADBPCTX',N'Áp dụng biện pháp cấm tiếp xúc',NULL,163,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (168,'ADCBPGDTXPTT',N'Áp dụng các biện pháp giáo dục tại xã/phường/thị trấn',NULL,163,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (169,'XPVPHC',N'Xử phạt vi phạm hành chính',NULL,163,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (171,'XLHS',N'Xử lý hình sự (phạt tù)',NULL,163,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (173,'NNBBLGDVBPHT',N'Nạn nhân bị bạo lực gia đình và biện pháp hỗ trợ',NULL,138,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (175,'GTNN',N'Giới tính',NULL,173,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (177,'NAMNN',N'Nam',NULL,175,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (178,'NUNN',N'Nữ',NULL,175,0,7);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (181,'DT2',N'Độ tuổi',NULL,173,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (182,'D16T2',N'Dưới 16 tuổi',NULL,181,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (183,'TD60TTL2',N'Từ đủ 60 tuổi trở lên',NULL,181,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (184,'BPHT',N'Biện pháp hỗ trợ',NULL,173,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (185,'DTV',N'Được tư vấn (tâm lý, tinh thần, pháp luật)',NULL,184,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (186,'CSHTSKBL',N'Chăm sóc hỗ trợ sau khi bị bạo lực',NULL,184,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (187,'HTCNRDTRLTTDCGN',N'Hỗ trợ (cai nghiện rượu, điều trị rối loạn tâm thần do chất gây nghiện)',NULL,184,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (188,'DTNGTVL',N'Đào tạo nghề, giới thiệu việc làm',NULL,184,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (189,'CBPPCBLGD',N'Các biện pháp phòng, chống bạo lực gia ',NULL,NULL,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (190,'MHPCBLGD',N'Mô hình phòng, chống bạo lực gia đình (theo chuẩn của Bộ Văn hóa, Thể thao và Du lịch)',NULL,189,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (191,'MHHDDL',N'Mô hình hoạt động độc lập',NULL,189,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (192,'SCLBGDPTBV',N'Số Câu lạc bộ gia đình phát triển bền vững',NULL,191,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (193,'SNPCBLGD',N'Số Nhóm phòng, chống bạo lực gia đình',NULL,191,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (194,'SDCTCOCD',N'Số địa chỉ tin cậy ở cộng đồng',NULL,191,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (195,'SDDN',N'Số đường dây nóng',NULL,191,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (196,'TLNLTTDTX',N'Tỷ lệ người luyện tập thể dục thể thao thường xuyên',NULL,NULL,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (197,'TLGDLTTDTT',N'Tỷ lệ gia đình luyện tập thể dục thể thao',NULL,NULL,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (198,'STHDBCTGDTC',N'Số trường học đảm bảo chương trình giáo dục thể chất',NULL,NULL,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (201,'SVDVCC',N'Số vận động viên cấp cao',NULL,NULL,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (202,'CKT',N'Cấp kiện tướng',NULL,201,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (204,'C1',N'Cấp 1',NULL,201,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (206,'SVDVDTTDT',N'Số vận động viên được tập trung đào tạo (Vận động viên quốc gia)',NULL,NULL,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (207,'VDVT',N'Vận động viên trẻ',NULL,206,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (209,'TSHCDD',N'Tổng số huy chương đạt được',NULL,NULL,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (211,'CGTTQT',N'Các giải thể thao quốc tế',NULL,209,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (213,'SCLBTT',N'Số câu lạc bộ thể thao',NULL,NULL,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (214,'SCTVTT',N'Số cộng tác viên thể thao',NULL,NULL,0,9);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (216,'TSTCCNDTTKT',N'Tổng số tổ chức, cá nhân được thanh tra, kiểm tra',NULL,NULL,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (218,'TTB',N'Thanh tra Bộ',NULL,216,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (220,'TTS',N'Thanh tra Sở',NULL,216,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (222,'TSTCCNBXPVPHC',N'Tổng số tổ chức, cá nhân bị xử phạt vi phạm hành chính',NULL,NULL,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (225,'TTB1',N'Thanh tra Bộ',NULL,222,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (226,'TTS1',N'Thanh tra Sở',NULL,222,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (227,'TSTXPVPHC',N'Tổng số tiền xử phạt vi phạm hành chính (triệu đồng)',NULL,NULL,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (228,'TTB2',N'Thanh tra Bộ',NULL,227,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (230,'TTS2',N'Thanh tra Sở',NULL,227,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (232,'KNXLTT',N'Kiến nghị xử lý sau thanh tra',NULL,NULL,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (233,'TTB3',N'Thanh tra Bộ',NULL,232,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (235,'SLTCD',N'Số lượt tiếp công dân',NULL,NULL,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (237,'TTB4',N'Thanh tra Bộ',NULL,235,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (238,'TTS4',N'Thanh tra Sở',NULL,235,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (240,'SDXL',N'Số đơn xử lý',NULL,NULL,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (241,'TTB5',N'Thanh tra Bộ',NULL,240,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (242,'TTS5',N'Thanh tra Sở',NULL,240,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (243,'KNXLQGQKNTC',N'Kiến nghị xử lý qua giải quyết khiếu nại, tố cáo',NULL,NULL,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (244,'TTB6',N'Thanh tra Bộ',NULL,243,0,10);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (245,'KPBTVPTVHDTTS',N'Khôi phục, bảo tồn và phát triển bản sắc văn hóa truyền thống của các dân tộc thiểu số có dân số ít ',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (246,'HTDTBTVH',N'Hỗ trợ đầu tư bảo tồn làng, bản văn hóa truyền thống tiêu biểu của các dân tộc thiểu số',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (247,'BTPHLHTTDTTS',N'Bảo tồn, phát huy lễ hội truyền thống tiêu biểu các dân tộc thiểu số',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (248,'XDNDXBSDPDTTS',N'Xây dựng nội dung, xuất bản sách, đĩa phim tư liệu về văn hóa truyền thống đồng bào dân tộc thiểu số',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (249,'SDMHBTTTDTTS',N'Xây dựng Mô hình bảo tồn văn hóa truyền thống các dân tộc thiểu số',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (250,'XDCLSHTDC',N'Xây dựng Câu lạc bộ sinh hoạt văn hóa dân gian tại các thôn vùng đồng bào dân tộc thiểu số và miền n',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (251,'NCPHBTPHVHPVT',N'Nghiên cứu, phục hồi, bảo tồn, phát huy văn hóa phi vật thể các dân tộc thiểu số có nguy cơ mai một',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (252,'NHGLLH',N'Ngày hội, Giao lưu, Liên hoan về các loại hình văn hóa, nghệ thuật truyền thống của đồng bào dân tộc',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (253,'LTHBDCMNV',N'Lớp tập huấn, bồi dưỡng chuyên môn nghiệp vụ, nâng cao năng lực bảo tồn, phát huy các giá trị văn hó',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (254,'SLCDVNTTDP',N'Số lượng các đơn vị nghệ thuật tại địa phương',NULL,NULL,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (255,'HTTTQBRD',N'Hỗ trợ tuyên truyền, quảng bá rộng rãi giá trị văn hóa truyền thống tiêu biểu của các dân tộc thiểu ',NULL,NULL,0,3);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (256,'CDVNTCL',N'Các đơn vị nghệ thuật công lập (bao gồm cả Trung tâm văn hóa sau khi sáp nhập)',NULL,254,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (258,'CD',N'Các đơn vị nghệ thuật ngoài công lập',NULL,254,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (259,'TCCNDKKDHDBDNT',N'Tổ chức, cá nhân đăng ký kinh doanh hoạt động biểu diễn nghệ thuật theo quy định của pháp luật',NULL,254,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (260,'VCTCHCQD',N'Về công tác chấp hành các quy định pháp luật lĩnh vực nghệ thuật biểu diễn',NULL,NULL,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (261,'SLCCTBDNT',N'Số lượng các chương trình biểu diễn nghệ thuật được chấp thuận trên địa bàn tỉnh/thành',NULL,260,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (263,'SLCTLHNT',N'Số lượng cuộc thi, liên hoan nghệ thuật được chấp thuận trên địa bàn tỉnh/thành',NULL,260,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (264,'SLCTNDNM',N'Số lượng cuộc thi người đẹp người mẫu được chấp thuận trên địa bàn tỉnh/thành (nêu rõ Vòng Chung kết',NULL,260,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (266,'SLCCBDNT',N'Số lượng chương trình biểu diễn nghệ thuật tiếp nhận từ các đơn vị nghệ thuật, các tổ chức, cá nhân ',NULL,260,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (267,'SLCTLHCLHNT',N'Số lượng cuộc thi, liên hoan các loại hình nghệ thuật biểu diễn tiếp nhận từ các đơn vị nghệ thuật, ',NULL,260,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (269,'SLLCBGAGH',N'Số lượng lưu chiểu bản ghi âm, ghi hình có nội dung biểu diễn nghệ thuật nhằm mục đích thương mại ti',NULL,260,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (272,'SLCCBDNTBYCD',N'Số lượng các chương biểu diễn nghệ thuật bị yêu cầu dừng hoạt động trên địa bàn tỉnh/thành',NULL,260,0,8);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (278,'SLCCTLH',N'Số lượng các cuộc thi, liên hoan các loại hình nghệ thuật biểu diễn bị yêu cầu thu hồi danh hiệu, gi',NULL,260,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (286,'SLCCTLHCLHNTBDBYCHKQ',N'Số lượng các cuộc thi, liên hoan các loại hình nghệ thuật biểu diễn bị yêu cầu hủy kết quả',NULL,260,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (287,'SLCCTBDNT2',N'Số lượng các chương trình biểu diễn nghệ thuật (áp dụng đối với các đơn vị nghệ thuật công lập)',NULL,NULL,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (288,'SVDSK',N'Số vở diễn sân khấu; chương trình ca múa nhạc; tiết mục nghệ thuật mới dàn dựng',NULL,287,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (289,'SVDSKCTCM',N'Số vở diễn sân khấu; chương trình ca múa nhạc; tiết mục nghệ thuật sửa chữa và nâng cao',NULL,287,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (290,'VDH',N'Về Danh hiệu, giải thưởng trong lĩnh vực nghệ thuật biểu diễn (thông qua xét danh hiệu nghệ sỹ; thôn',NULL,NULL,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (291,'SLJCVHCBGNNB',N'Số lượng Huy chương vàng, Huy chương bạc, Giải nhất/nhì/ba',NULL,290,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (292,'SLNSDNNPTDH',N'Số lượng nghệ sỹ được Nhà nước phong tặng danh hiệu',NULL,290,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (293,'TSBBDTN',N'Tổng số buổi biểu diễn trong năm',NULL,NULL,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (294,'TCTHCCDVNTCL',N'Tổ chức thực hiện của các đơn vị nghệ thuật công lập',NULL,293,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (295,'TCTHCCTC',N'Tổ chức thực hiện của các tổ chức, cá nhân đăng ký kinh doanh hoạt động biểu diễn nghệ thuật theo qu',NULL,293,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (296,'USLNXBDNTCN',N'Ước số lượng người xem biểu diễn nghệ thuật chuyên nghiệp (người/năm)',NULL,NULL,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (297,'KPHNCTXVKYX',N'Kinh phí hàng năm cấp thường xuyên và không thường xuyên (đối với các đơn vị nghệ thuật công lập)',NULL,NULL,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (298,'DTDVCDVNTCL',N'Doanh thu (đối với các đơn vị nghệ thuật công lập)',NULL,NULL,0,6);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (322,'SLTV',N'Số lượng thư viện',NULL,NULL,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (323,'TSTVCCHC',N'Tổng số thư viện công cộng hiện có',NULL,322,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (325,'STVCCTLTN',N'Số thư viện công cộng thành lập trong năm',NULL,322,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (326,'STVCCCH',N'Số thư viện công cộng cấp huyện trực thuộc UBND',NULL,322,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (327,'TSHP',N'Tổng số hãng phim',NULL,NULL,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (328,'STVTNCPVCC',N'Số thư viện tư nhân có phục vụ cộng đồng',NULL,322,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (329,'STVCD',N'Số thư viện cộng đồng',NULL,322,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (330,'HPNC',N'Hãng phim nhà nước',NULL,327,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (331,'SPDCC',N'Số phòng đọc cơ sở và không gian đọc',NULL,322,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (332,'NLTV',N'Nhân lực thư viện',NULL,NULL,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (333,'SNLNCTTVHC',N'Số lượng người làm công tác thư viện hiện có',NULL,332,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (334,'CLNL',N'Chất lượng nguồn nhân lực',NULL,332,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (335,'VTDHV',N'Về trình độ học vấn',NULL,334,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (336,'HPNCHNGCP',N'Hãng phim nhà nước nắm giữ cổ phần',NULL,327,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (337,'SNCTDDH',N'Số người có trình độ Đại học trở lên',NULL,335,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (338,'TSGPCCDV',N'Tổng số Giấy phép cung cấp dịch vụ quay phim sử dụng bối cảnh tại Việt Nam được cấp',NULL,NULL,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (339,'TSPVN',N'Tổng số phim Việt Nam sản xuất sử dụng ngân sách Nhà nước được cấp Giấy phép phân loại phim',NULL,NULL,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (340,'SNCOTDCD',N'Số người có trình độ Cao đẳng/ trung học chuyên nghiệp',NULL,335,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (341,'PT',N'Phim truyện',NULL,339,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (342,'SNCTDTHPT',N'Số người có trình độ trung học phổ thông',NULL,335,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (343,'PTL',N'Phim tài liệu',NULL,339,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (344,'PKH',N'Phim khoa học',NULL,339,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (345,'VCMTV',N'Về chuyên môn ngành thư viện',NULL,334,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (346,'SNDTCNTV',N'Số người đào tạo chuyên ngành thư viện',NULL,345,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (347,'PHH',N'Phim hoạt hình',NULL,339,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (348,'SNDTCNK',N'Số người đào tạo chuyên ngành khác',NULL,345,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (349,'SLCBDDTTHTN',N'Số lượt cán bộ được đào tạo, tập huấn trong năm',NULL,332,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (350,'KP',N'Kinh phí',NULL,NULL,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (351,'PKHNLH',N'Phim kết hợp nhiều loại hình',NULL,339,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (352,'TKPDC',N'Tổng kinh phí được cấp',NULL,350,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (353,'SPDPLK',N'Số phim được phân loại K',NULL,339,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (354,'CCCN',N'Chi cho con người',NULL,352,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (355,'TSPVNDCGPPLP',N'Tổng số phim Việt Nam được cấp Giấy phép phân loại phim',NULL,NULL,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (356,'HDCMNV',N'Hoạt động chuyên môn nghiệp vụ',NULL,352,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (357,'PT1',N'Phim truyện',NULL,355,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (358,'BSCTL',N'Bổ sung vốn tài liệu',NULL,356,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (359,'PTL1',N'Phim tài liệu',NULL,355,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (360,'PKH1',N'Phim khoa học',NULL,355,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (361,'TKDVTV',N'Triển khai dịch vụ thư viện',NULL,356,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (362,'PHH1',N'Phim hoạt hình',NULL,355,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (363,'PKHNLH1',N'Phim kết hợp nhiều loại hình',NULL,355,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (364,'CHDDVK',N'Các hoạt động chuyên môn nghiệp vụ khác',NULL,356,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (365,'SPDPLK1',N'Số phim được phân loại K',NULL,355,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (366,'CNDCK',N'Các nội dung chi khác',NULL,352,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (367,'TSPNKDCGPPLP',N'Tổng số phim nhập khẩu được cấp Giấy phép phân loại phim',NULL,NULL,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (368,'PT2',N'Phim truyện',NULL,367,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (369,'PTL2',N'Phim tài liệu',NULL,367,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (370,'STVKDCKP',N'Số thư viện không được cấp kinh phí',NULL,350,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (371,'PKH2',N'Phim khoa học',NULL,367,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (372,'PHH2',N'Phim hoạt hình',NULL,367,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (373,'UDCNTT',N'Ứng dụng công nghệ thông tin',NULL,NULL,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (374,'PKHNLH2',N'Phim kết hợp nhiều loại hình',NULL,367,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (375,'SLMTHC',N'Số lượng máy tính hiện có',NULL,373,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (376,'SPDPLK2',N'Số phim được phân loại K',NULL,367,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (377,'SLTVDCUDCNTTTHD',N'Số lượng thư viện đã ứng dụng công nghệ thông tin trong hoạt động',NULL,373,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (378,'UTDTPBPTRCH',N'Ước tính doanh thu phổ biến phim tại rạp chiếu phim (tỷ đồng)',NULL,NULL,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (379,'SLTVDCTPMQL',N'Số lương thư viện đã có sử dụng phần mềm quản lý thư viện',NULL,373,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (380,'PBPPVNVCTOVC',N'Phổ biến phim phục vụ nhiệm vụ chính trị ở vùng cao, miền núi, biên giới, hải đảo, vùng đồng bào dân',NULL,NULL,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (381,'SLTVDCTWS',N'Số lượng thư viện đã có website',NULL,373,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (382,'TSNSNNDC',N'Tổng số ngân sách nhà nước được cấp',NULL,380,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (383,'TSDCBLD',N'Tổng số đội chiếu bóng lưu động',NULL,380,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (384,'SLTVDXDTVDT',N'Số lượng thư viện đã xây dựng thư viện điện tử',NULL,373,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (385,'TSBC',N'Tổng số biên chế',NULL,380,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (386,'VTL',N'Vốn tài liệu',NULL,NULL,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (387,'TSLMCKTSHD',N'Tổng số lượng máy chiếu phim kỹ thuật số HD',NULL,380,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (388,'S',N'Sách',NULL,386,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (389,'TSDS',N'Tổng số đầu sách',NULL,388,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (390,'TSSBSCTTV',N'Tổng số bản sách hiện có trong thư viện',NULL,388,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (391,'TSLMCP',N'Tổng số lượng máy chiếu phim video',NULL,380,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (392,'TSBSCTKLC',N'Tổng số bản sách trong kho luân chuyển',NULL,390,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (393,'TSLOTOCPLD',N'Tổng số lượng ô tô chiếu phim lưu động',NULL,380,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (394,'TSBSBS',N'Tổng số bản sách bổ sung trong năm',NULL,390,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (395,'TSBC1',N'Tổng số buổi chiếu',NULL,380,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (396,'TSLNX',N'Tổng số lượt người xem',NULL,380,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (397,'TSBSTL',N'Tổng số bản sách được thanh lọc theo quy định tại Thông tư 02/2020/TT-BVHTTDL',NULL,390,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (398,'TSRCP',N'Tổng số rạp chiếu phim',NULL,NULL,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (399,'TSDBTC',N'Tổng số đầu báo, tạp chí',NULL,386,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (400,'TSRCRNC',N'Tổng số rạp, cụm rạp Nhà nước',NULL,398,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (402,'TSRCRTN',N'Tổng số rạp, cụm rạp tư nhân',NULL,398,0,5);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (403,'TSSDTDT',N'Tổng số đầu tài liệu điện tử',NULL,386,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (404,'CT',N'Công tác ',NULL,NULL,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (405,'TBD',N'Thẻ bạn đọc',NULL,404,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (406,'TSTTVHC',N'Tổng số thẻ thư viện hiện có',NULL,405,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (407,'STDGHTN',N'Số thẻ được gia hạn trong năm',NULL,406,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (408,'STDCMTN',N'Số thẻ được cấp mới trong năm',NULL,406,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (409,'STNSDTVDTDCT',N'Đối tượng người sử dụng thư viện đặc thù được cấp thẻ',NULL,405,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (410,'STCCTN',N'Số thẻ cấp cho thiếu nhi',NULL,409,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (411,'STCCCT',N'Số thẻ cấp cho người cao tuổi',NULL,409,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (412,'STCCNKT',N'Số thẻ cấp cho người khuyết tật',NULL,409,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (413,'STCCNDTTS',N'Số thẻ cấp cho người dân tộc thiểu số',NULL,409,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (414,'TLBĐTVPV',N'Tổng lượt bạn đọc được thư viện phục vụ',NULL,404,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (415,'LBDDPVTTSTV',N'Lượt bạn đọc được phục vụ tại trụ sở thư viện',NULL,414,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (416,'LBDDPVLC',N'Lượt bạn đọc được phục vụ lưu động, luân chuyển',NULL,414,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (417,'LBDQM',N'Lượt bạn đọc được phục vụ thông qua mạng internet',NULL,414,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (418,'LTNTTPV',N'Lượt tài nguyên thông tin phục vụ',NULL,404,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (419,'TSLTNTTPVTTS',N'Tổng số lượt tài nguyên thông tin phục vụ tại trụ sở thư viện',NULL,418,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (420,'TSLTNTTPVLDLC',N'Tổng số lượt tài nguyên thông tin phục vụ lưu động, luân chuyển',NULL,418,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (421,'TSSLTNTTPVQM',N'Tổng số lượt tài nguyên thông tin phục vụ thông qua mạng internet',NULL,418,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (422,'PVLDLCVTCSKVHTT',N'Phục vụ lưu động, luân chuyển và tổ chức các sự kiện văn hóa phục vụ phát triển văn hóa đọc',NULL,404,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (423,'SLLCSB',N'Số lần luân chuyển sách, báo',NULL,422,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (424,'TSDTNSLC',N'Tổng số điểm tiếp nhận sách, báo luân chuyển',NULL,422,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (425,'SLPVLD',N'Số lần phục vụ lưu động',NULL,422,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (426,'TSDPVLD',N'Tổng số điểm phục vụ lưu động',NULL,422,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (427,'TSSKDTC',N'Tổng số sự kiện được tổ chức',NULL,422,0,4);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (428,'HTTCVHCS',N'Hệ thống thiết chế văn hoá cơ sở',NULL,NULL,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (429,'TTVHCT',N'Trung tâm Văn hóa cấp tỉnh (Trung tâm Văn hóa Nghệ thuật; Trung tâm Văn hóa - Điện ảnh; Trung tâm Vă',NULL,428,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (430,'STTVHTTCH',N'Số Trung tâm Văn hoá-Thông tin (Thể thao) cấp huyện (Nhà Văn hoá) và tương đương',NULL,428,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (431,'SNVHCX',N'Số Nhà Văn hoá cấp xã và tương đương',NULL,428,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (432,'SNVHCL',N'Số Nhà Văn hoá cấp làng (thôn, ấp, bản...) và tương đương',NULL,428,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (433,'SNVHCCBNDTK',N'Số Nhà Văn hoá (Cung Văn hoá) của các Bộ, ngành, đoàn thể khác',NULL,428,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (434,'TCCDCT',N'Thiết chế Công đoàn cấp tỉnh',NULL,433,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (435,'TCCDCH',N'Thiết chế Công đoàn cấp huyện',NULL,433,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (436,'TCDTNCT',N'Thiết chế Đoàn Thanh niên cấp tỉnh',NULL,433,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (437,'TCDTNCH',N'Thiết chế Đoàn Thanh niên cấp huyện',NULL,433,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (438,'SDVCTE',N'Số điểm vui chơi trẻ em',NULL,428,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (439,'CT1',N'Cấp tỉnh',NULL,438,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (440,'CH',N'Cấp huyện',NULL,438,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (441,'CX',N'Cấp xã',NULL,438,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (442,'CTT',N'Cấp thôn',NULL,438,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (443,'HDVHVNQCCTCH',N'Hoạt động văn hoá, văn nghệ quần chúng tại cấp tỉnh, cấp huyện',NULL,NULL,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (444,'SCLB',N'Số Câu lạc bộ',NULL,443,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (445,'SCLHHTHDDTC',N'Số cuộc liên hoan, hội thi, hội diễn đã tổ chức',NULL,443,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (446,'TSLX',N'Tổng số người xem',NULL,443,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (447,'HDTTLD',N'Hoạt động tuyên truyền lưu động',NULL,NULL,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (448,'SDTTLDCT',N'Số đội thông tin lưu động cấp tỉnh',NULL,447,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (449,'SDTTLDCH',N'Số đội thông tin lưu động cấp huyện',NULL,447,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (450,'TSBHD',N'Tổng số buổi hoạt động (cấp tỉnh, huyện)',NULL,447,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (451,'TSLNX1',N'Tổng số lượt người xem (cấp tỉnh, huyện)',NULL,447,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (452,'HDVT',N'Hoạt động karaoke, vũ trường trên địa bàn tỉnh',NULL,NULL,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (453,'TSCSKDVT',N'Tổng số cơ sở kinh doanh karaoke, vũ trường',NULL,452,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (454,'TSLVP',N'Tổng số lượt vi phạm',NULL,452,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (455,'HDCDTQVTCLKNCT',N'Hoạt động cổ động trực quan và Tổ chức lễ kỷ niệm cấp tỉnh',NULL,NULL,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (456,'SCCD',N'Số cụm cổ động (bao gồm cụm cổ động tại cửa khẩu biên giới)',NULL,455,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (457,'TCLKN',N'Tổ chức Lễ kỷ niệm',NULL,455,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (458,'XDNSVH',N'Xây dựng Nếp sống văn hóa',NULL,NULL,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (459,'SKDCVH',N'Số khu dân cư văn hóa (Làng, thôn, ấp, bản, tổ dân phố văn hóa và tương đương)',NULL,458,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (460,'SGDVH',N'Số gia đình văn hoá',NULL,458,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (461,'HDQC',N'Hoạt động quảng cáo',NULL,NULL,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (462,'SLDNQC',N'Số lượng doanh nghiệp quảng cáo',NULL,461,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (463,'HSTBSPQC',N'Hồ sơ thông báo sản phẩm quảng cáo',NULL,461,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (464,'SVVPDXL',N'Số vụ vi phạm đã xử lý',NULL,461,0,2);
        INSERT DM_ChiTieu (ChiTieuID,MaChiTieu,TenChiTieu,GhiChu,ChiTieuChaID,TrangThai,LoaiMauPhieuID) VALUES (465,'STXPVPDT',N'Số tiền xử phạt vi phạm đã thu (Triệu đồng)',NULL,461,0,2);
        SET IDENTITY_INSERT DM_ChiTieu OFF




    --ChiTieu GetAll
        CREATE PROCEDURE CT_GetAll
            @TenChiTieu NVARCHAR(100) = NULL
            --,@PageNumber INT = 1,
            --@PageSize INT = 100
        AS
        BEGIN
            -- Kiểm tra biến đầu vào
            --IF @PageNumber < 1 SET @PageNumber = 1;
            --IF @PageSize < 1 SET @PageSize = 100;

            -- CTE để xử lý phân cấp và tìm kiếm
            WITH RecursiveCTE AS (
                -- Anchor member: Bắt đầu với các node gốc (nơi ChiTieuChaID là NULL)
                SELECT 
                    ChiTieuID,
                    ChiTieuChaID,
                    MaChiTieu,
                    TenChiTieu,
                    GhiChu,
                    TrangThai,
                    LoaiMauPhieuID,
                    0 AS Level,
                    CAST('/' + CONVERT(NVARCHAR(50), ChiTieuID) AS NVARCHAR(50)) AS Hierarchy
                FROM 
                    DM_ChiTieu
                WHERE 
                    ChiTieuChaID IS NULL

                UNION ALL

                -- Recursive member: Join the table with itself to find children
                SELECT 
                    c.ChiTieuID,
                    c.ChiTieuChaID,
                    c.MaChiTieu,
                    c.TenChiTieu,
                    c.GhiChu,
                    c.TrangThai,
                    c.LoaiMauPhieuID,
                    cte.Level + 1 AS Level,
                    CAST(cte.Hierarchy + '/' + CONVERT(NVARCHAR(50), c.ChiTieuID) AS NVARCHAR(50)) AS Hierarchy
                FROM 
                    DM_ChiTieu c
                INNER JOIN 
                    RecursiveCTE cte ON c.ChiTieuChaID = cte.ChiTieuID
            ),
            -- CTE phụ để lọc các phần tử khớp với từ khóa tìm kiếm
            FilteredCTE AS (
                SELECT 
                    ChiTieuID,
                    ChiTieuChaID,
                    MaChiTieu,
                    TenChiTieu,
                    GhiChu,
                    TrangThai,
                    LoaiMauPhieuID,
                    Level,
                    Hierarchy
                FROM 
                    RecursiveCTE
                WHERE 
                    @TenChiTieu IS NULL
                    OR LOWER(TenChiTieu) LIKE '%' + LOWER(@TenChiTieu) + '%'
            ),
            -- CTE phụ để xác định các phần tử cha và phần tử con của các phần tử cần thiết
            AllParentsCTE AS (
                SELECT 
                    c.*
                FROM 
                    FilteredCTE fc
                INNER JOIN 
                    RecursiveCTE c ON c.ChiTieuID = fc.ChiTieuChaID
                UNION ALL
                SELECT 
                    c.*
                FROM 
                    AllParentsCTE p
                INNER JOIN 
                    RecursiveCTE c ON c.ChiTieuID = p.ChiTieuChaID
            ),
            AllChildrenCTE AS (
                SELECT 
                    c.*
                FROM 
                    FilteredCTE fc
                INNER JOIN 
                    RecursiveCTE c ON c.ChiTieuChaID = fc.ChiTieuID
                UNION ALL
                SELECT 
                    c.*
                FROM 
                    AllChildrenCTE p
                INNER JOIN 
                    RecursiveCTE c ON c.ChiTieuChaID = p.ChiTieuID
            ),
            -- Kết hợp tất cả các phần tử cần thiết và loại bỏ các bản ghi trùng lặp
            CombinedCTE AS (
                SELECT DISTINCT * FROM FilteredCTE
                UNION
                SELECT DISTINCT * FROM AllParentsCTE
                UNION
                SELECT DISTINCT * FROM AllChildrenCTE
            )
            -- Truy vấn phân cấp với phân trang và tính toán tổng số bản ghi
            SELECT 
                ChiTieuID,
                ChiTieuChaID,
                MaChiTieu,
                TenChiTieu,
                GhiChu,
                TrangThai,
                LoaiMauPhieuID,
                Level,
                Hierarchy
                --,TotalRecords = (SELECT COUNT(*) FROM CombinedCTE)
            FROM 
                CombinedCTE
            ORDER BY 
            ChiTieuID, Hierarchy
            --OFFSET (@PageNumber - 1) * @PageSize ROWS 
            --FETCH NEXT @PageSize ROWS ONLY
            OPTION (MAXRECURSION 0);
        END;
        GO

    --ChiTieu GetByID
        CREATE PROCEDURE CT_GetByID
            @ChiTieuID INT
        AS
        BEGIN
            SELECT * FROM DM_ChiTieu WHERE ChiTieuID = @ChiTieuID;
        END; 
        GO

        CREATE PROCEDURE CT_Insert
            @MaChiTieu NVARCHAR(100),
            @TenChiTieu NVARCHAR(100),
            @ChiTieuChaID INT null,
            @GhiChu NVARCHAR(100),
            @LoaiMauPhieuID INT
        AS
        BEGIN
            INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, GhiChu, LoaiMauPhieuID)
            VALUES (@MaChiTieu, @TenChiTieu, @ChiTieuChaID, @GhiChu, @LoaiMauPhieuID);
            
            SELECT SCOPE_IDENTITY() AS NewChiTieuID;  -- Return the newly created ID
        END;
        GO

    --Thêm chỉ tiêu con với LoaiMauPhieuID từ chỉ tiêu cha
        CREATE PROCEDURE CT_InsertChildren 
            @MaChiTieu NVARCHAR(100),
            @ChiTieuChaID INT,
            @TenChiTieu NVARCHAR(100),
            @GhiChu NVARCHAR(300)

        AS
        BEGIN
            DECLARE @LoaiMauPhieuID INT;

            -- Lấy LoaiMauPhieuID từ chỉ tiêu cha
            SELECT @LoaiMauPhieuID = LoaiMauPhieuID 
            FROM DM_ChiTieu 
            WHERE ChiTieuID = @ChiTieuChaID;

            -- Thêm chỉ tiêu con với LoaiMauPhieuID từ chỉ tiêu cha
            INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID, TrangThai)
            VALUES (@MaChiTieu, @TenChiTieu, @ChiTieuChaID, @LoaiMauPhieuID, 1);
        END;
        GO

    --Tạo procedure để lấy các chỉ tiêu phân cấp theo LoaiMauPhieuID
        CREATE PROCEDURE CT_GetByLoaiMauPhieuID 
            @LoaiMauPhieuID INT
        AS
        BEGIN
            -- CTE để lấy tất cả các chỉ tiêu phân cấp
            WITH CTE_ChiTieu AS (
                -- Lấy các chỉ tiêu gốc (không có chỉ tiêu cha)
                SELECT 
                    ChiTieuID, 
                    TenChiTieu, 
                    MaChiTieu,
                    ChiTieuChaID, 
                    LoaiMauPhieuID, 
                    TrangThai,
                    GhiChu
                FROM DM_ChiTieu
                WHERE LoaiMauPhieuID = @LoaiMauPhieuID AND ChiTieuChaID IS NULL

                UNION ALL

                -- Đệ quy để lấy các chỉ tiêu con, cháu,...
                SELECT 
                    ct.ChiTieuID, 
                    ct.TenChiTieu,
                    ct.MaChiTieu,
                    ct.ChiTieuChaID, 
                    ct.LoaiMauPhieuID, 
                    ct.TrangThai,
                    ct.GhiChu
                FROM DM_ChiTieu ct
                INNER JOIN CTE_ChiTieu cte ON ct.ChiTieuChaID = cte.ChiTieuID
            )

            -- Truy vấn kết quả từ CTE
            SELECT *
            FROM CTE_ChiTieu
            ORDER BY ChiTieuChaID, ChiTieuID;
        END;
        GO

    --ChiTieu Update
        CREATE PROCEDURE CT_Update
            @ChiTieuID INT,
            @ChiTieuChaID INT NULL,
            @MaChiTieu NVARCHAR(100),
            @TenChiTieu NVARCHAR(100),
            @LoaiMauPhieuID INT,
            @GhiChu NVARCHAR(100)
        AS
        BEGIN
            UPDATE DM_ChiTieu
            SET MaChiTieu = @MaChiTieu,
                TenChiTieu = @TenChiTieu,
                ChiTieuChaID = @ChiTieuChaID,
                GhiChu = @GhiChu,
                LoaiMauPhieuID = @LoaiMauPhieuID
            WHERE ChiTieuID = @ChiTieuID;
        END;
        GO

    --ChiTieu Delete
        CREATE PROCEDURE CT_Delete
            @ChiTieuID INT
        AS
        BEGIN
            -- Check if the element has children
            IF EXISTS (
                SELECT 1
                FROM DM_ChiTieu
                WHERE ChiTieuChaID = @ChiTieuID
            )
            BEGIN
                -- Delete children recursively
                WITH RecursiveCTE AS (
                    SELECT 
                        ChiTieuID,
                        ChiTieuChaID
                    FROM 
                        DM_ChiTieu
                    WHERE 
                        ChiTieuChaID = @ChiTieuID

                    UNION ALL

                    SELECT 
                        c.ChiTieuID,
                        c.ChiTieuChaID
                    FROM 
                        DM_ChiTieu c
                    INNER JOIN 
                        RecursiveCTE p ON c.ChiTieuChaID = p.ChiTieuID
                )
                DELETE FROM DM_ChiTieu
                WHERE ChiTieuID IN (SELECT ChiTieuID FROM RecursiveCTE);
            END

            -- Delete the parent element
            DELETE FROM DM_ChiTieu
            WHERE ChiTieuID = @ChiTieuID;
        END;
        GO
--endregion

--region Stored procedures of DM_TieuChi
CREATE TABLE DM_TieuChi (
	TieuChiID INT PRIMARY KEY IDENTITY(1,1),
	MaTieuChi NVARCHAR(100),
	TenTieuChi NVARCHAR(100) NOT NULL,
	TieuChiChaID INT NULL,
	CONSTRAINT FK_TieuChi_TieuChiCha FOREIGN KEY (TieuChiChaID) REFERENCES DM_TieuChi(TieuChiID),
	GhiChu NVARCHAR(300) DEFAULT '',
	KieuDuLieuCot INT,
	TrangThai BIT DEFAULT 0,
	LoaiTieuChi INT,
	CapDo INT
);
GO 

-- Procedure to retrieve all criteria with paging and hierarchical data
    CREATE PROCEDURE TC_GetAll
        @TenTieuChi NVARCHAR(100) = NULL
        --,@PageNumber INT = 1,
        --@PageSize INT = 20
    AS
    BEGIN
        -- Validate input parameters
        --IF @PageNumber < 1 SET @PageNumber = 1;
        --IF @PageSize < 1 SET @PageSize = 20;

        -- Recursive Common Table Expression (CTE) to build the hierarchy
        WITH RecursiveCTE AS (
            -- Anchor member: Start with root nodes (where TieuChiChaID is NULL)
            SELECT 
                TieuChiID,
                TieuChiChaID,
                MaTieuChi,
                TenTieuChi,
                GhiChu,
                KieuDuLieuCot,
                TrangThai,
                LoaiTieuChi,
                1 AS CapDo,  -- Set level to 1 for root nodes
                CAST('/' + CONVERT(NVARCHAR(50), TieuChiID) AS NVARCHAR(50)) AS Hierarchy  -- Build hierarchy path
            FROM 
                DM_TieuChi
            WHERE 
                TieuChiChaID IS NULL

            UNION ALL

            -- Recursive member: Join to find child nodes
            SELECT 
                c.TieuChiID,
                c.TieuChiChaID,
                c.MaTieuChi,
                c.TenTieuChi,
                c.GhiChu,
                c.KieuDuLieuCot,
                c.TrangThai,
                c.LoaiTieuChi,
                p.CapDo + 1 AS CapDo,  -- Increase level for child nodes
                CAST(p.Hierarchy + '/' + CONVERT(NVARCHAR(50), c.TieuChiID) AS NVARCHAR(50)) AS Hierarchy  -- Extend hierarchy path
            FROM 
                DM_TieuChi c
            INNER JOIN 
                RecursiveCTE p ON c.TieuChiChaID = p.TieuChiID
        ),
        -- Filter results based on search criteria
        FilteredCTE AS (
            SELECT 
                TieuChiID,
                TieuChiChaID,
                MaTieuChi,
                TenTieuChi,
                GhiChu,
                KieuDuLieuCot,
                TrangThai,
                LoaiTieuChi,
                CapDo,
                Hierarchy
            FROM 
                RecursiveCTE
            WHERE 
                @TenTieuChi IS NULL
                OR LOWER(TenTieuChi) LIKE '%' + LOWER(@TenTieuChi) + '%'  -- Case-insensitive search
        ),
        -- CTE to identify parent elements of the filtered results
        AllParentsCTE AS (
            SELECT 
                c.*
            FROM 
                FilteredCTE fc
            INNER JOIN 
                RecursiveCTE c ON c.TieuChiID = fc.TieuChiChaID
            UNION ALL
            SELECT 
                c.*
            FROM 
                AllParentsCTE p
            INNER JOIN 
                RecursiveCTE c ON c.TieuChiChaID = p.TieuChiChaID
        ),
        -- CTE to identify child elements of the filtered results
        AllChildrenCTE AS (
            SELECT 
                c.*
            FROM 
                FilteredCTE fc
            INNER JOIN 
                RecursiveCTE c ON c.TieuChiChaID = fc.TieuChiID
            UNION ALL
            SELECT 
                c.*
            FROM 
                AllChildrenCTE p
            INNER JOIN 
                RecursiveCTE c ON c.TieuChiChaID = p.TieuChiID
        ),
        -- Combine all relevant elements (filtered, parents, and children) and remove duplicates
        CombinedCTE AS (
            SELECT DISTINCT * FROM FilteredCTE
            UNION
            SELECT DISTINCT * FROM AllParentsCTE
            UNION
            SELECT DISTINCT * FROM AllChildrenCTE
        )
        -- Final query with pagination and total records count
        SELECT 
            TieuChiID,
            TieuChiChaID,
            MaTieuChi,
            TenTieuChi,
            GhiChu,
            KieuDuLieuCot,
            TrangThai,
            LoaiTieuChi,
            CapDo,
            Hierarchy
            --,TotalRecords = (SELECT COUNT(*) FROM CombinedCTE)  -- Total record count
        FROM 
            CombinedCTE
        ORDER BY 
            Hierarchy  -- Order by hierarchy path
        --OFFSET (@PageNumber - 1) * @PageSize ROWS 
        --FETCH NEXT @PageSize ROWS ONLY  -- Pagination
        OPTION (MAXRECURSION 0);  -- Prevent recursion depth limit
    END;
    GO

CREATE PROC TC_GetByID
	@TieuChiID INT
AS
BEGIN
	SELECT *FROM DM_TieuChi  WHERE TieuChiID = @TieuChiID;
END
GO

CREATE PROC TC_Insert
	@MaTieuChi NVARCHAR(100),
    @TenTieuChi NVARCHAR(100),
    @TieuChiChaID INT = NULL,
    @KieuDuLieuCot INT = NULL,
    @LoaiTieuChi INT = NULL
AS
BEGIN
    DECLARE @CapDo INT;

    -- Kiểm tra nếu TieuChiChaID là NULL thì đối tượng là gốc, CapDo sẽ là 1
    IF @TieuChiChaID IS NULL
    BEGIN
        SET @CapDo = 1;
    END
    ELSE
    BEGIN
        -- Lấy CapDo của TieuChiCha và tăng lên 1 để xác định cấp độ của tiêu chí hiện tại
        SELECT @CapDo = CapDo + 1 
        FROM DM_TieuChi 
        WHERE TieuChiID = @TieuChiChaID;

        -- Nếu không tìm thấy TieuChiChaID thì báo lỗi
        IF @CapDo IS NULL
        BEGIN
            RAISERROR('Không tìm thấy Tiêu Chí Cha với ID đã cung cấp.', 16, 1);
            RETURN;
        END
    END

    -- Thêm tiêu chí mới vào bảng DM_TieuChi
    INSERT INTO DM_TieuChi (MaTieuChi, TenTieuChi, TieuChiChaID, KieuDuLieuCot, LoaiTieuChi, CapDo)
    VALUES (@MaTieuChi, @TenTieuChi, @TieuChiChaID, @KieuDuLieuCot, @LoaiTieuChi, @CapDo);
END;
GO

CREATE PROCEDURE TC_Update
    @TieuChiID INT,
    @MaTieuChi NVARCHAR(100),
    @TenTieuChi NVARCHAR(100),
    @TieuChiChaID INT = NULL,
    @GhiChu NVARCHAR(100) = NULL,
    @KieuDuLieuCot INT = NULL,
    @LoaiTieuChi INT = NULL
AS
BEGIN
    UPDATE DM_TieuChi
    SET 
        MaTieuChi = @MaTieuChi,
        TenTieuChi = @TenTieuChi,
        TieuChiChaID = @TieuChiChaID,
        GhiChu = @GhiChu,
        KieuDuLieuCot = @KieuDuLieuCot,
        LoaiTieuChi = @LoaiTieuChi
    WHERE TieuChiID = @TieuChiID;
END;
GO

CREATE PROCEDURE TC_Delete
    @TieuChiID INT
AS
BEGIN
    -- Check if the element has children
    IF EXISTS (
        SELECT 1
        FROM DM_TieuChi
        WHERE TieuChiChaID = @TieuChiID
    )
    BEGIN
        -- Delete children recursively
        WITH RecursiveCTE AS (
            SELECT 
                TieuChiID,
                TieuChiChaID
            FROM 
                DM_TieuChi
            WHERE 
                TieuChiChaID = @TieuChiID

            UNION ALL

            SELECT 
                c.TieuChiID,
                c.TieuChiChaID
            FROM 
                DM_TieuChi c
            INNER JOIN 
                RecursiveCTE p ON c.TieuChiChaID = p.TieuChiID
        )
        DELETE FROM DM_TieuChi
        WHERE TieuChiID IN (SELECT TieuChiID FROM RecursiveCTE);
    END

    -- Delete the parent element
    DELETE FROM DM_TieuChi
    WHERE TieuChiID = @TieuChiID;
END;
GO
--endregion
--endregion





--region Insert Table
--region Insert records into Categories
INSERT INTO DM_DITICHXEPHANG ( TenDiTich,GhiChu ) VALUES
( N'Di Tích Quốc Gia','3' ),
( N'Di Tích Quốc Gia Đặc Biệt','2' ),
( N'Di Tích Cấp Tỉnh','1' )
GO
INSERT INTO DM_DonViTinh (TenDonViTinh, MaDonViTinh, TrangThai, GhiChu)
VALUES (N'Kilogram', N'KG', 1, N'Đơn vị đo khối lượng'),
(N'Hộp', N'HOP', 1, N'Đơn vị đo đếm đóng gói'),
(N'Mét', N'M', 1, N'Đơn vị đo chiều dài'),
(N'Lit', N'L', 1, N'Đơn vị đo thể tích'),
(N'Cái', N'CAI', 1, N'Đơn vị đếm số lượng');
GO
INSERT INTO DM_TieuChi (MaTieuChi, TenTieuChi, TieuChiChaID, KieuDuLieuCot, LoaiTieuChi)
VALUES
('TOP_QHTN', N'Quốc hiệu tiêu ngữ', NULL, 3, 1),
('TOP_DVCQ', N'Đơn vị chủ quản', NULL, 3, 1),
('TOP_DVTHBC', N'Đơn vị thực hiện báo cáo',NULL, 3, 1),
('TOP_TDBC', N'Tiêu đê báo cáo', NULL, 3, 1),
('TOP_PHANNGAYTHANG', N'Phần ngày tháng', NULL, 3, 1),
('TOP_DVT', N'Đơn vị tính', NULL, 3, 1),
('TOP_PHULUC', N'Phụ lục', NULL, 3, 1),
('BODY_STT', N'STT', NULL, 3, 2),
('BODY_ND', N'Nội dung', NULL, 3, 2),
('BODY_GHICHU', N'Ghi chú', NULL, 3, 2),
('BODY_THANGNAM', N'Tháng/năm', NULL, 3, 2),
('BOT_LUUNHAN', N'Lưu nhận', NULL, 3, 3),
('BOT_PHANNGAYTHANG', N'Phần ngày tháng', NULL, 3, 3),
('BOT_CHUCDANH', N'Chức danh', NULL, 3, 3),
('BOT_NGUOIKY', N'Người ký', NULL, 3, 3),
('BODY_T', N'Tỉnh', 11, 3, 2),
('BODY_H', N'Huyện', 11, 3, 2),
('BODY_X', N'Xã', 11, 3, 2);
GO
INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 001-DSVH DỮ LIỆU CƠ BẢN VỀ DI SẢN VĂN HÓA', '001-DSVH', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 002-VHCS SỐ LIỆU CƠ BẢN VỀ VĂN HÓA CƠ SỞ', '002-VHCS', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 003-VHDT SỐ LIỆU CƠ BẢN VỀ VĂN HÓA DÂN TỘC', '003-VHDT', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 004-TV SỐ LIỆU CƠ BẢN VỀ THƯ VIỆN', '004-TV', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 005-ĐA SỐ LIỆU CƠ BẢN VỀ ĐIỆN ẢNH', '005-ĐA', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 006-NTBD SỐ LIỆU CƠ BẢN VỀ NGHỆ THUẬT BIỂU DIỄN', '006-NTBD', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 007-MTNTAL SỐ LIỆU CƠ BẢN VỀ MỸ THUẬT, NHIẾP ẢNH VÀ TRIỂN LÃM', '007-MTNTAL', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 008-GĐ SỐ LIỆU CƠ BẢN VỀ GIA ĐÌNH', '008-GĐ', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 009-TDTT SỐ LIỆU CƠ BẢN VỀ THỂ DỤC, THỂ THAO', '009-TDTT', 0, '', 3);

INSERT INTO DM_LoaiMauPhieu (LoaiMauPhieuChaID, TenLoaiMauPhieu, MaLoaiMauPhieu, TrangThai, GhiChu, Loai)
VALUES (0, N'BIỂU MẪU SỐ LIỆU SỐ 010-TTR SỐ LIỆU CƠ BẢN VỀ THANH TRA', '010-TTR', 0, '', 3);
GO
--region Insert Category ChiTieu
--region Root Level ChiTieus
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT001', N'DI TÍCH', NULL, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT002', N'Số lượng thư viện', NULL, 2);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES
('CT003', N'Nhân lực thư viện', NULL, 3);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT004', N'Bảo tàng', NULL, 4);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT005', N'Số lượng xin cấp xin phép triển lãm', NULL, 5);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT006', N'Số lượng họa sĩ, nhà điêu khắc, nghệ sĩ nhiếp ảnh', NULL, 6);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT007', N'Gia Đình', NULL, 7);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT008', N'Bạo lực gia đình', NULL, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT009', N'Các biện pháp phòng, chống bạo lực gia', NULL, 9);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT0010', N'Số vận động viên cấp cao', NULL, 10);
--endregion

--region Childen level 1
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_1', N'Tổng số Di tích xếp hạng cấp tỉnh:', 1, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_2', N'Tổng số Di tích xếp hạng quốc gia:', 1, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_3', N'Tổng số Di tích quốc gia đặc biệt được xếp hạng:', 1, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT2_1', N'Tổng số thư viện công cộng hiện có', 2, 2);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT2_2', N'Số thư viện công cộng thành lập trong năm', 2, 2);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT2_3', N'Số thư viện công cộng cấp huyện trực thuộc UBND', 2, 2);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT2_4', N'Số thư viện tư nhân có phục vụ cộng đồng', 2, 2);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT2_5', N'Số thư viện cộng đồng', 2, 2);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES
('CT3_1', N'Số lượng người làm công tác thư viện hiện có Số thư viện công cộng thành lập trong năm', 3, 3);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES
('CT3_2', N'Chất lượng nguồn nhân lực:', 3, 3);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT4_1', N'Tổng số bảo tàng trực thuộc:', 4, 4);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT4_2', N'Tổng số hiện vật có trong từng bảo tàng:', 4, 4);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT4_3', N'Tổng số sưu tập hiện vật trong từng bảo tàng', 4, 4);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT4_4', N'Tổng số khách tham quan trong năm của từng bảo tàng:', 4, 4);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT4_5', N'Tổng thu từ phí tham quan trong năm của từng bảo tàng (nếu có):', 4, 4);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT4_6', N'Tổng số trưng bày chuyên đề của từng bảo tàng:', 4, 4);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT5_1', N'Triển lãm mỹ thuật', 5, 5),
('CT5_2', N'Triển lãm nhiếp ảnh', 5, 5),
('CT5_3', N'Các Triển lãm không vì mục đích thương mại', 5, 5),
('CT5_4', N'Số lượng giấy phép/ văn bản phê duyệt nội dung tác phẩm mỹ thuật, nhiếp ảnh xuất, nhập khẩu', 5, 5);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT6_1', N'Mỹ thuật', 6, 6),
('CT6_2', N'Nhiếp ảnh', 6, 6);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT7_1', N'Tổng số hộ gia đình', 7, 7);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_1', N'Tổng số hộ có bạo lực gia đình', 8, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_2', N'Tổng số vụ bạo lực gia đình', 8, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_3', N'Hình thức bạo lực', 8, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_4', N'Người gây bạo lực gia đình và biện pháp xử lý', 8, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_5', N'Biện pháp xử lý', 8, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_6', N'Nạn nhân bị bạo lực gia đình và biện pháp hỗ trợ', 8, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT9_1', N'Mô hình phòng, chống bạo lực gia đình', 9, 9);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT9_2', N'Mô hình hoạt động độc lập', 9, 9);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT10_1', N'Cấp kiện tướng', 10, 10);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT10_2', N'Cấp 1', 10, 10);
--endregion

--region children level 2
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_1_1', N'Di tích lịch sử:', 11, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_1_2', N'Di tích kiến trúc nghệ thuật:', 11, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_1_3', N'Di tích khảo cổ:', 11, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_1_4', N'Danh lam thắng cảnh:', 11, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_1_5', N'Số Di tích cấp tỉnh được xếp hạng trong năm:', 11, 1);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_2_1', N'Di tích lịch sử:', 12, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_2_2', N'Di tích kiến trúc nghệ thuật:', 12, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_2_3', N'Di tích khảo cổ:', 12, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_2_4', N'Danh lam thắng cảnh:', 12, 1);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_2_5', N'Số Di tích quốc gia được xếp hạng trong năm:', 12, 1);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT1_3_1', N'Số Di tích quốc gia đặc biệt được xếp hạng trong', 13, 1);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES
('CT3_2_1', N'Về trình độ học vấn:', 20, 3);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES
('CT3_2_2', N'Về chuyên môn ngành thư viện', 20, 3);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES
('CT3_2_3', N'Số lượt cán bộ được đào tạo, tập huấn trong năm', 20, 3);


INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT4_2_1', N'Số hiện vật bảo tàng mới được sưu tầm trong năm (của từng bảo tàng):', 22, 4);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT4_3_1', N'Số sưu tập hiện vật được hình thành trong năm của từng bảo tàng:', 23, 4);

-- Insert các "thằng cháu" của Triển lãm mỹ thuật
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT5_1_1', N'Trong nước', 27, 5),
('CT5_1_2', N'Ra nước ngoài', 27, 5);

-- Insert các "thằng cháu" của Triển lãm nhiếp ảnh
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT5_2_1', N'Trong nước', 28, 5),
('CT5_2_2', N'Ra nước ngoài', 28, 5);

-- Insert các "thằng cháu" của Các Triển lãm không vì mục đích thương mại
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT5_3_1', N'Trong nước', 29, 5),
('CT5_3_2', N'Ra nước ngoài', 29, 5);

-- Insert các "thằng cháu" của Mỹ thuật
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT6_1_1', N'Họa sĩ Hội Mỹ thuật địa phương', 31, 6),
('CT6_1_2', N'Nhà điêu khắc Hội Mỹ thuật địa phương', 31, 6);

-- Insert các "thằng cháu" của Nhiếp ảnh
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT6_2_1', N'Hội viên hội nhiếp ảnh địa phương', 32, 6);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT7_1_1', N'Số hộ gia đình chỉ có cha hoặc mẹ sống chung với con', 33, 7);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT7_1_2', N'Số hộ gia đình 1 thế hệ (vợ, chồng)', 33, 7);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT7_1_3', N'Số hộ gia đình 2 thế hệ', 33, 7);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT7_1_4', N'Số hộ gia đình 3 thế hệ trở lên', 33, 7);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT7_1_5', N'Số hộ gia đình khác', 33, 7);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_3_1', N'Tinh thần', 36, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_3_2', N'Thân thể', 36, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_3_3', N'Tình dục', 36, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_3_4', N'Kinh tế', 36, 8);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_4_1', N'Giới tính', 37, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_4_2', N'Độ tuổi', 37, 8);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_5_1', N'Góp ý, phê bình trong cộng đồng dân cư', 38, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_5_2', N'Áp dụng biện pháp cấm tiếp xúc', 38, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_5_3', N'Áp dụng các biện pháp giáo dục', 38, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_5_4', N'Xử phạt vi phạm hành chính', 38, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_5_5', N'Xử lý hình sự (phạt tù)', 38, 8);


INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_6_1', N'Giới tính', 39, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_6_2', N'Độ tuổi', 39, 8);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT8_6_3', N'Biện pháp hỗ trợ', 39, 8);

INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT9_2_1', N'Số Câu lạc bộ gia đình phát triển bền vững', 41, 9);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT9_2_2', N'Số Nhóm phòng, chống bạo lực gia đình', 41, 9);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT9_2_3', N'Số địa chỉ tin cậy ở cộng đồng', 41, 9);
INSERT INTO DM_ChiTieu (MaChiTieu, TenChiTieu, ChiTieuChaID, LoaiMauPhieuID)
VALUES 
('CT9_2_4', N'Số đường dây nóng', 41, 9);
--endregion
--endregion
GO
INSERT INTO DM_LoaiDiTich (TenLoaiDiTich, GhiChu)
VALUES (N'Di tích kiến trúc nghệ thuật', '1'),
(N'Di tích lịch sử cách mạng', '2'),
(N'Di tich lịch sử văn hóa', '3')
GO
INSERT INTO DM_KyBaoCao (TenKyBaoCao, TrangThai, GhiChu, LoaiKyBaoCao)
VALUES 
(N'Kỳ báo cáo tháng 1', 1, N'1', 1),
(N'Kỳ báo cáo tháng 2', 1, N'2', 1),
(N'Kỳ báo cáo tháng 3', 1, N'3', 2),
(N'Kỳ báo cáo quý 1', 1, N'1,2,3', 1),
(N'Kỳ báo cáo quý 2', 1, N'4,5,6', 1),
(N'Kỳ báo cáo quý 3', 1, N'7,8,9', 2),
(N'Kỳ báo cáo quý 4', 1, N'10,11,12', 2),
(N'Kỳ báo cáo năm 2023', 1, N'2023', 3),
(N'Kỳ báo cáo năm 2024', 0, N'2024', 3),
(N'Kỳ báo cáo dự án X', 1, N'Báo cáo tiến độ dự án X', 4);
--endregion

--region Insert records into  Authorization Management
-- Thêm người dùng
INSERT INTO Sys_User (UserName, Email, Password, Status, Note)
VALUES
('admin', 'admin@example.com', 'admin', 1, 'Admin user'),
('user1', 'user1@example.com', 'user1', 1, 'Regular user');
GO	

--Thêm chức năng
INSERT INTO Sys_Function (Description,FunctionName )
	VALUES ('ManageUsers', N'Quản lý người dùng'),
	('ManageMonumentRanking', N'Quản lý di tích xếp hạng'),
	('ManageUnitofMeasure', N'Quản lý đơn vị tính'),
	('ManageReportingPeriod', N'Quản lý kỳ báo cáo'),
	('ManageTypeofMonument', N'Quản lý loại di tích'),
	('ManageFormType', N'Quản lý mẫu phiếu'),
	('ManageCriteria', N'Quản lý tiêu chí'),
	('ManageTarget', N'Quản lý chỉ tiêu'),
	('ManageReportForm', N'Quản lý mẫu phiếu báo cáo'),
	('ManageAuthorization', N'Quản lý ủy quyền');
GO

-- Thêm nhóm
INSERT INTO Sys_Group (Description,GroupName)
VALUES
('AdminGroup', N'Nhóm quản trị'),
('UserGroup', N'Nhóm người dùng');
GO
-- Thêm người dùng vào nhóm
INSERT INTO Sys_UserInGroup (UserID, GroupID)
VALUES
(1, 1),  -- admin vào AdminGroup
(2, 2);  -- user1 vào UserGroup
GO	


-- Thêm chức năng vào nhóm và phân quyền
INSERT INTO Sys_FunctionInGroup (FunctionID, GroupID, Permission)
VALUES
(1, 1, 15),
(1, 2, 0),
(2, 1, 15),
(2, 2, 7),
(3, 1, 15),
(3, 2, 7),
(4, 1, 15),
(4, 2, 7),
(5, 1, 15),
(5, 2, 7),
(6, 1, 15),
(6, 2, 7),
(7, 1, 15),
(7, 2, 7),
(8, 1, 15),
(8, 2, 7),
(9,1,15),
(9,2,7),
(10,1,15),
(10,2,0)
GO  
--endregion
--endregion

--region Query
	DELETE FROM Sys_User;
	DBCC CHECKIDENT ('Sys_User', RESEED, 0);
	DELETE FROM Sys_Function;
	DBCC CHECKIDENT ('Sys_Function', RESEED, 0);
	DELETE FROM Sys_Group;
	DBCC CHECKIDENT ('Sys_Group', RESEED, 0);
	DELETE FROM Sys_UserInGroup;
	DBCC CHECKIDENT ('Sys_UserInGroup', RESEED, 0);
	DELETE FROM Sys_FunctionInGroup;
	DBCC CHECKIDENT ('Sys_FunctionInGroup', RESEED, 0);
	DELETE FROM DM_LoaiMauPhieu
	DBCC CHECKIDENT ('DM_LoaiMauPhieu', RESEED, 0);
	DELETE FROM DM_ChiTieu
	DBCC CHECKIDENT ('DM_ChiTieu', RESEED, 0);
	DELETE FROM DM_LoaiDiTich
	DBCC CHECKIDENT ('DM_LoaiDiTich', RESEED, 0);
	DELETE FROM DM_TieuChi
	DBCC CHECKIDENT ('DM_TieuChi', RESEED, 0);
	DELETE FROM DM_DiTichXepHang
	DBCC CHECKIDENT ('DM_DiTichXepHang', RESEED, 0);
	DELETE FROM DM_DonViTinh
	DBCC CHECKIDENT ('DM_DonViTinh', RESEED, 0);
	DELETE FROM DM_KyBaoCao
	DBCC CHECKIDENT ('DM_KyBaoCao', RESEED, 0);
	
	DELETE FROM DM_TieuChi WHERE TieuChiID = 20
	DELETE FROM Sys_User WHERE UserID = 38

	-- Reset giá trị IDENTITY về giá trị mặc định (1)
GO




SELECT * FROM Sys_Function sf
SELECT * FROM Sys_FunctionInGroup sfig
SELECT * FROM Sys_UserInGroup suig
SELECT * FROM Sys_User su
SELECT * FROM Sys_Group sg


SELECT * FROM DM_KyBaoCao dkbc
SELECT * FROM DM_DiTichXepHang 
SELECT * FROM DM_DonViTinh 
SELECT * FROM DM_LoaiDiTich
SELECT * FROM DM_LoaiMauPhieu 


SELECT * FROM DM_TieuChi dtc
SELECT * FROM DM_ChiTieu dtc



UPDATE Sys_User
SET Password = 'user1' WHERE UserID = 2

UPDATE Sys_FunctionInGroup 
SET  Permission = 15 WHERE FunctionInGroupID = 1

UPDATE Sys_Function 
SET FunctionName = 'ManageMonumentRanking'  WHERE FunctionID = 2


EXEC TC_Delete @TieuChiID = 1
EXEC CT_GetAll @TenChiTieu = ''
EXEC TC_GetAll @TenTieuChi = ''
EXEC FIG_GetUserPermissions @UserName = 'admin', @FunctionName = 'ManageTargets' 
EXEC UMS_GetByRefreshToken @RefreshToken = ''
SELECT * FROM	Sys_User su
EXEC CT_Delete @ChiTieuID = 2
EXEC CT_Delete 113

-- Các tiêu chí gốc (CapDo = 1)
EXEC TC_Insert 'TOP_QHTN', N'Quốc hiệu tiêu ngữ', NULL, 3, 1;
EXEC TC_Insert 'TOP_DVCQ', N'Đơn vị chủ quản', NULL, 3, 1;
EXEC TC_Insert 'TOP_DVTHBC', N'Đơn vị thực hiện báo cáo', NULL, 3, 1;
EXEC TC_Insert 'TOP_TDBC', N'Tiêu đê báo cáo', NULL, 3, 1;
EXEC TC_Insert 'TOP_PHANNGAYTHANG', N'Phần ngày tháng', NULL, 3, 1;
EXEC TC_Insert 'TOP_DVT', N'Đơn vị tính', NULL, 3, 1;
EXEC TC_Insert 'TOP_PHULUC', N'Phụ lục', NULL, 3, 1;
EXEC TC_Insert 'BODY_STT', N'STT', NULL, 1, 2;
EXEC TC_Insert 'BODY_ND', N'Nội dung', NULL, 3, 2;
EXEC TC_Insert 'BODY_GHICHU', N'Ghi chú', NULL, 3, 2;
EXEC TC_Insert 'BODY_THANGNAM', N'Tháng/năm', NULL, 3, 2;
EXEC TC_Insert 'BOT_LUUNHAN', N'Lưu nhận', NULL, 3, 3;
EXEC TC_Insert 'BOT_PHANNGAYTHANG', N'Phần ngày tháng', NULL, 3, 3;
EXEC TC_Insert 'BOT_CHUCDANH', N'Chức danh', NULL, 3, 3;
EXEC TC_Insert 'BOT_NGUOIKY', N'Người ký', NULL, 3, 3;

-- Các tiêu chí con của BODY_ND (CapDo = 2 vì có TieuChiChaID là 11)
EXEC TC_Insert 'BODY_T', N'Tỉnh', 11,  1, 2;
EXEC TC_Insert 'BODY_H', N'Huyện', 11,  1, 2;
EXEC TC_Insert 'BODY_X', N'Xã', 11,  1, 2;




ALTER TABLE BC_ChiTietMauPhieu
ADD TieuChiIDs NVARCHAR(MAX);


ALTER TABLE BC_ChiTietMauPhieu
DROP COLUMN TieuChiID;

--endregion
