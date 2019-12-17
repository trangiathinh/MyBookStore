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
values(NEWID(),'DFCB8E47-8353-46A2-8BFB-3793BD4A51DD','2AF7DE5C-0578-4FEA-AF91-33EEFDEB3B5B',N'Tri thức về vạn vật','Images/tri-thuc-ve-van-vat.jpg',120,GETDATE(),699000,10,0,N'Sử dụng các tác phẩm đồ họa máy tính ngoạn mục, Tri thức về vạn vật sẽ hé lộ những chi tiết kỳ diệu chưa từng thấy về vũ trụ, Trái đất, thiên nhiên, cơ thể người, khoa học và lịch sử. Trọn vẹn những sự thật kinh ngạc, dòng thời gian sinh động và hình ảnh ấn tượng, cuốn bách khoa thư gia đình đầy hấp dẫn này sẽ biến những chủ đề phức tạp nhất hóa dễ dàng chỉ trong nháy mắt.  
Được thành lập năm 1974, DK nổi tiếng với dòng sách mình họa tranh kèm nội dung chú thích bóng bẩy hấp dẫn người đọc. DK được bảo trợ bởi rất nhiều các tổ chức hàn lâm cũng như nhân đạo nổi tiếng và danh giá, như Hiệp hội Y khoa Vương quốc Anh, Hội Làm vườn Hoàng gia và Tổ chức Chữ thập Đỏ Anh.
Ngoài sách truyền thống, DK còn sở hữu một lượng lớn các phần mềm giáo dục và sách điện tử tương tác có nhãn hiệu DK Online (tiền thân là DK Multimedia, 1990). Vào năm 2010, DK thành lập một chợ phần mềm điện thoại nhằm đưa các sản phẩm sách của hãng đến với đông đảo độc giả sử dụng thiết bị thông minh.',0,GETDATE(),1)
go



insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'DFCB8E47-8353-46A2-8BFB-3793BD4A51DD','2AF7DE5C-0578-4FEA-AF91-33EEFDEB3B5B',N'12 Xu hướng công nghệ trong thời đại 4.0','Images/cong-nghe-4-0.png',120,GETDATE(),699000,10,0,N'12 Xu hướng công nghệ trong thời đại 4.0 cung cấp cho đọc giả những cái nhìn cơ bản, tổng quan nhất về các xu hướng công nghệ trong thời đại công nghiệp 4.0',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'DFCB8E47-8353-46A2-8BFB-3793BD4A51DD','2AF7DE5C-0578-4FEA-AF91-33EEFDEB3B5B',N'Cẩm nang công nghệ hóa học','Images/cam-nang-cong-nghe-hoa-hoc.jpg',110,GETDATE(),312000,10,0,N'Cẩm nang công nghệ hóa học cung cấp cho đọc giả các nội dung học tập từ cơ bản đến nâng cao trong lĩnh vực Công nghệ Hóa học. Sách thuộc tủ sách Nhất Nghệ Tinh, được trình bày theo một cách logic dễ hiểu.',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'DFCB8E47-8353-46A2-8BFB-3793BD4A51DD','ABBC5EFA-BC19-48E3-ABAE-643768A9F2B5',N'100 Ý tưởng kinh doanh tuyệt hay','Images/100-y-tuong-kinh-doanh-tuyet-hay-tai-ban.jpeg',135,GETDATE(),515000,10,0,N'Bên cạnh những ý tưởng liên quan đến các lĩnh vực kinh điển của quản trị như quản trị nhân sự, nhượng quyền kinh doanh, cắt giảm lãng phí, lãnh đạo sự đổi mới…
quyển sách tiếp cận rất nhiều lĩnh vực mới trong quản trị mà thế giới kinh doanh phải đối mặt ở hiện tại và tương lai bằng những ý tưởng và kiến thức được trình bày cô đọng, súc tích, dễ nắm bắt và vận dụng.
Có thể nói 100 ý tưởng kinh doanh tuyệt hay là một chiếc thấu kính hội tụ đem nhiều vấn đề đã hiện ra ở đường chân trời lúc này rồi và đang lớn dần về đặt ngay trên bàn làm việc của các nhà quản lý nào còn chưa có sự chuẩn bị, thậm chí là chưa nhận ra chúng.
Quyển sách sẽ có thể giúp doanh nhân, nhà quản lý ngay bây giờ nắm bắt được một cách cơ bản về những gì sắp tác động đến công ăn việc làm và sự nghiệp của họ như: tác động của cơ cấu dân số và tâm lý khách hàng theo cơ cấu dân số, mô hình chuỗi người lao động - khách hàng - lợi nhuận, biến chuỗi cung cấp thành chuỗi lợi nhuận, sự hội tụ của công nghệ, website chính là hình ảnh của doanh nghiệp,…',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'DFCB8E47-8353-46A2-8BFB-3793BD4A51DD','ABBC5EFA-BC19-48E3-ABAE-643768A9F2B5',N'Cẩm nang công nghệ hóa học','Images/Hay_Kinh_Doanh_Nhu_Starbucks.jpeg',100,GETDATE(),372000,10,0,N'Bạn có bao giờ không thể thức dậy nổi vào buổi sáng sớm để đi làm hay đi học mà không nhờ một tách cafe, bạn có bao giờ ngồi tán gẫu cả buổi tối ở một không gian yên tĩnh với người bạn của mình chưa? Cafe, trở thành một sự kết nối giữa những con người với nhau và thậm chí còn trở thành nét văn hóa riêng làm nên tiếng tăm cho những doanh nghiệp triệu đô. Bạn có tự hỏi, tại sao có nhiều hãng cafe đến thế mà Starbucks vẫn đứng vững trên thương trường, điều gì làm nên sự khác biệt trong cách kinh doanh của ông chủ này?
Kinh doanh phải chú trọng đến khách hàng. Khách hàng chính là cốt lỗi của mọi hoạt động kinh doanh. Kinh doanh thành công có nghĩa là bạn phải tạo cho khách hàng cảm giác tin tưởng, trải nghiệm tốt khi sử dụng dịch vụ, chứ không đơn thuần là bán sản phẩm. Starbucks là điển hình của thương hiệu cafe gắn liền với việc kết nối cảm xúc trong những buổi gặp gỡ bạn bè, đoàn tụ gia đình, và trở thành một “phong cách thưởng thức cafe” nổi tiếng trên toàn thế giới. Có thể nói, thương hiệu cafe đến từ Mỹ đã tạo ra hẳn một đế chế khủng khiếp trên phạm vi toàn thế giới.
Không giống như cuốn sách trước đây của Joseph Michelli về nhà lãnh đạo cà phê, cuốn “Hãy kinh doanh như Starbucks” giúp bạn tận dụng những kết nối mà bạn xây dựng ở cấp độ cá nhân đồng thời mở rộng kết nối với khách hàng trên toàn cầu, thông qua công nghệ và thậm chí cả sản phẩm và hàng hóa của bạn. Ông cung cấp những hiểu biết thú vị về các nguyên tắc cơ bản liên quan đến việc tạo ra chuỗi cà phê lớn nhất thế giới. Là một người kinh doanh, bạn sẽ học được cách các nhà lãnh đạo Starbucks thúc đẩy thành công cũng như cách họ học hỏi từ những thất bại, đứng lên từ những sai lầm của mình',0.1,GETDATE(),1)

go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'DFCB8E47-8353-46A2-8BFB-3793BD4A51DD','ABBC5EFA-BC19-48E3-ABAE-643768A9F2B5',N'14 Bài Học Khởi Nghiệp Jack Ma Dành Tặng Các Bạn Trẻ','Images/14_bai_hoc_khoi_nghiep_jack_ma_danh_tang_cac_ban_tre.jpeg',100,GETDATE(),272000,10,0,N'Có thể nói đây là cuốn sách đầu tiên giải mã toàn diện về trí tuệ kinh doanh và triết học nhân sinh “thành công không tự nhiên đến” của Jack Ma.
Vào những thời khắc quan trọng, Jack Ma thường nói rằng: “Khi phàn nàn trở thành thói quen, nó cũng giống như việc uống nước biển, càng uống thì lại càng thấy khát. Cuối cùng ta mới phát hiện ra rằng những người đi trên con đường thành công lại đều là những “kẻ ngốc” không biết phàn nàn. Thế giới sẽ chẳng nhớ bạn đã nói gì, tuy nhiên, nó nhất định sẽ ghi nhớ những gì bạn đã làm ra!
Quan trọng hơn, đây là cuốn sách đầu tiên ghi chép lại những lời khuyên từ tận đáy lòng về đường đời mà ông dành cho giới trẻ. Mình tin rằng, khi bạn đọc cuốn sách này một cách nghiêm túc và tiếp thu kiến thức Jack Ma, bạn sẽ vượt qua những u mê cuộc đời hay trên con đường khởi nghiệp để trở thành một phiên bản tốt hơn của chính mình, trở thành một con người tiệm cận với thành công.',0,GETDATE(),1)

go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'DFCB8E47-8353-46A2-8BFB-3793BD4A51DD','ABBC5EFA-BC19-48E3-ABAE-643768A9F2B5',N'Bộ Ba Xuất Chúng Nhật Bản','Images/bo_ba_xuat_chung_nhat_ban.jpeg',160,GETDATE(),182000,10,0.1,N'Câu chuyện về ba vị doanh nhân huyền thoại của nước nhật.
Matsushita Konosuke, Honda Soichiro và Inamori Kazuo là những con người có xuất thân bình thường, nếu không muốn là nghèo khó trong xã hội Nhật Bản. Matsushita là con nhà nông dân, Honda có cha là thợ rèn, còn Inamori là con thợ in. Nhưng họ đã không ngừng thách thức những giới hạn, vượt qua mọi trở ngại để xây dựng nên những công ty thành công nhất trong tại Nhật Bản, đó là Tập đoàn Matsushita, Tập đoàn Honda và Tập đoàn Kyocera.
Bài học mà người ta có thể rút ra từ ba vị doanh nhân huyền thoại của nước Nhật là gì?
Đó là xuất thân chỉ là điều kiện, không phải cơ hội. Người có xuất thân cao quý, giàu sang chưa chắc có thể làm nên sự nghiệp lớn. Ngược lại, nếu có lòng quyết tâm, khát khao học hỏi và một trái tim rộng mở, thì chúng ta hoàn toàn có thể làm chủ tương lai của mình và trở nên vĩ đại.
Sẽ thế nào nếu Matsushita Konosuke chịu an phận làm nhân viên cho một cửa hàng xe đạp tại Osaka? Ngành công nghiệp xe máy và xe hơi Nhật sẽ ra sao nếu Honda Soichiro chỉ mãi ở lại quê nhà tại Shizuoka? Và nếu Inamori Kazuo cứ mãi tự ti vì mình chỉ là một cậu học trò trường tỉnh, thì liệu có một Tập đoàn Kyocera lừng lẫy như ngày nay?',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Hóa học 12','Images/hoa-hoc-12.jpg',188,GETDATE(),18000,10,0,N'Sách bài tập môn Hóa học lớp 12 dành cho học sinh ban Chuẩn.
Giúp các em ôn tập các bài học đã được học ở trên lớp, đồng thời làm quen với các dạng bài tập Hóa học 12.',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Giải tích 12','Images/giai-tich-12.png',160,GETDATE(),19000,10,0,N'Nội dung sách gồm các phần:
Ứng dụng đạo hàm để khảo sát vẽ đồ thị hàm số, hàm số lũy thừa, hàm số mũ và hàm số logarit, nguyên hàm, tích phân và ứng dụng,Số phức',0,GETDATE(),1)

go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Giải tích 12 Nâng cao','Images/vat-ly-12.jpg',328,GETDATE(),25000,10,0,N'Sách môn Vật lý lớp 12 dành cho học sinh ban Nâng Cao.
Phần lớn các trang sách có 2 cột: cột phụ gồm một số hình vẽ và những biểu bảng, những ghi chú và ví dụ cụ thể để làm rõ hơn kiến thức trình bày ở cột chính. Học sinh không cần ghi nhớ, chỉ cần hiểu sổ liệu trong các biểu bảng, những ví dụ và ghi chú ở cột phụ. Trong cột phụ có những câu hỏi kí hiệu C dùng để nêu vấn đề và gợi mở trong giờ học.',0,GETDATE(),1)
select * from Author
select * from BookType
select * from Publisher
select * from BookAuthor
select * from Book
select * from Author

---AuthorID: 
	--A66E551B-EDBC-407A-81B6-38E6CEEE62BD
	--38FA054A-4B05-40B7-B520-40D401FCE8D6
	--8C30A414-BC59-44E8-9FDE-6C0BBE76E702
	--5F900014-D1D7-44A4-87A2-D4F5D308C64C
--BookID:
select * from BookAuthor
--insert data into BookAuthor
insert into BookAuthor(BookId,AuthorId) values('E73885BB-0DFC-488B-B3D4-0173E09E4F8E','A66E551B-EDBC-407A-81B6-38E6CEEE62BD'),
										('E73885BB-0DFC-488B-B3D4-0173E09E4F8E','38FA054A-4B05-40B7-B520-40D401FCE8D6'),
										('E75B43C3-2200-40C4-9E48-0B72DD26BBD0','8C30A414-BC59-44E8-9FDE-6C0BBE76E702'),
										('029597A6-7F6E-4E5D-9C4C-51D320600044','8C30A414-BC59-44E8-9FDE-6C0BBE76E702'),
										('029597A6-7F6E-4E5D-9C4C-51D320600044','5F900014-D1D7-44A4-87A2-D4F5D308C64C'),
										('AF82E590-DBC3-4424-8BD2-697B186553EB','5F900014-D1D7-44A4-87A2-D4F5D308C64C'),
										('1FADA839-B7A7-4317-AE4A-716F769A9557','38FA054A-4B05-40B7-B520-40D401FCE8D6'),
										('788E2E14-FCBD-49CE-8A88-7E4182A0C01C','8C30A414-BC59-44E8-9FDE-6C0BBE76E702'),
										('852A047A-84DB-4AD0-8C8A-A9A22608C655','A66E551B-EDBC-407A-81B6-38E6CEEE62BD'),
										('62A505B2-99CF-4795-BFF1-A9BCD0A2081A','8C30A414-BC59-44E8-9FDE-6C0BBE76E702'),
										('7537E40F-32D7-4729-A2B2-B972A8F4AAAC','5F900014-D1D7-44A4-87A2-D4F5D308C64C'),
										('A70BA0BB-9489-40C6-A222-B9FC8DCEA0E2','5F900014-D1D7-44A4-87A2-D4F5D308C64C'),
										('A70BA0BB-9489-40C6-A222-B9FC8DCEA0E2','38FA054A-4B05-40B7-B520-40D401FCE8D6'),
										('A70BA0BB-9489-40C6-A222-B9FC8DCEA0E2','8C30A414-BC59-44E8-9FDE-6C0BBE76E702')
