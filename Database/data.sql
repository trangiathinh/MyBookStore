use MyBookStore
go
--insert role
select * from Author
select * from AccountRole
select * from Account
select * from Customer
select * from Book

insert into Role(Id,RoleName) values(NEWID(),'Admin'),(NEWID(),'Customer')
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

--insert data into Publisher
select * from Publisher
insert into Publisher(Id, Name, Address,CreatedDate) values(NEWID(),N'Nhà xuất bản Khoa học Công Nghệ',N'125 Lê Cao Lãng quận 3 TPHCM',GETDATE()),
													        (NEWID(),N'Nhà xuất bản Giáo dục',N'311 Đào Duy Anh quận 1 TPHCM',GETDATE())

--insert data into Book
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'30044C8A-112A-4CCA-B9AA-4214D9A29FEE','8CA1BF1C-1FC3-4D14-9992-EAB34CFD11CB',N'Tri thức về vạn vật','Images/tri-thuc-ve-van-vat.jpg',120,GETDATE(),699000,10,0,N'Sử dụng các tác phẩm đồ họa máy tính ngoạn mục, Tri thức về vạn vật sẽ hé lộ những chi tiết kỳ diệu chưa từng thấy về vũ trụ, Trái đất, thiên nhiên, cơ thể người, khoa học và lịch sử. Trọn vẹn những sự thật kinh ngạc, dòng thời gian sinh động và hình ảnh ấn tượng, cuốn bách khoa thư gia đình đầy hấp dẫn này sẽ biến những chủ đề phức tạp nhất hóa dễ dàng chỉ trong nháy mắt.  
Được thành lập năm 1974, DK nổi tiếng với dòng sách mình họa tranh kèm nội dung chú thích bóng bẩy hấp dẫn người đọc. DK được bảo trợ bởi rất nhiều các tổ chức hàn lâm cũng như nhân đạo nổi tiếng và danh giá, như Hiệp hội Y khoa Vương quốc Anh, Hội Làm vườn Hoàng gia và Tổ chức Chữ thập Đỏ Anh.
Ngoài sách truyền thống, DK còn sở hữu một lượng lớn các phần mềm giáo dục và sách điện tử tương tác có nhãn hiệu DK Online (tiền thân là DK Multimedia, 1990). Vào năm 2010, DK thành lập một chợ phần mềm điện thoại nhằm đưa các sản phẩm sách của hãng đến với đông đảo độc giả sử dụng thiết bị thông minh.',0,GETDATE(),1)

delete from Book