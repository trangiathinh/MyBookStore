use MyBookStore
go
--insert data into BookType 
insert into BookType(BookTypeName) values(N'Sách Thiếu Nhi'),
										 (N'Sách Khoa Học'),
										 (N'Sách Giáo Khoa'),
										 (N'Truyện Tranh'),
										 (N'Sách Văn Học'),
										 (N'Sách Tài Chính Kinh Doanh')
									
													
--insert data into Author
insert into Author(Name, PhoneNumber, Birthday, Email, Address)
values(N'Trần Gia Bảo','035061321','01/23/1954','giabao@gmail.com',N'123 Đường Lê Đại Hành Quận 11 TPHCM'),
      (N'Lý Gia Từ','097550613','11/22/1964','lygiatu@gmail.com',N'257 Đường Lê Thánh Tông Quận 1 TPHCM'),
	  (N'Nguyễn Đình Thi','0975123123','10/12/1937','thinguyen123@gmail.com',N'35 Đường 30 Tháng 4 Quận Ninh Kiều TP Cần Thơ'),
	  (N'Lý Gia Từ','097550613','11/22/1964','lygiatu@gmail.com',N'03 Đường Võ Văn Tần Quận Đống Đa Hà Nội')

