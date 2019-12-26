use MyBookStore
go
--insert role
select * from Author
select * from AccountRole
select * from Account
select * from Customer
select * from Book
select * from OrderStatus
select * from [Order]
select * from OrderDetail
select * from DeliveryInformation
--dbcc checkident ('OrderStatus',reseed,0)
--insert into order status
insert into OrderStatus(Name) values(N'Chưa xử lý'),
										(N'Đang đóng gói'),
										( N'Đang vận chuyển'),
										(N'Hoàn thành'),
										(N'Đã hủy')

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


--new books
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Chuyên đề ôn tập và luyện thi hóa học 12','Images/Chuyen-de-on-tap-va-luyen-thi-hoa-hoa-12.jpg',218,GETDATE(),37000,10,0,N'Cuốn sách "Chuyên đề ôn tập và luyện thi hóa học 12" sẽ cung cấp tài liệu tham khảo cần thiết cho các thầy, cô giáo và các em học sinh ôn tập để nâng cao kiến thức chất lượng kỳ thi tốt nghiệp THPT và kỳ thi tuyển sinh Đại học, Cao đẳng, đảm bảo người tốt nghiệp đạt chuẩn kiến thức, kỹ năng đã quy định cho cấp THPT...
Nội dung cuốn sách gồm 3 phần:
Phần thứ nhất: Đề thi tốt nghiệp trung học phổ thông
Phần thứ hai: Đề thi đại học, cao đẳng
Phần thứ ba: Đáp án
Phần thứ nhất với 11 đề kiểm tra và thi tốt nghiệp THPT; phần thứ hai gồm 27 đề thi đại học, cao đẳng. Cuốn sách giúp các em học sinh ôn tập kiến thức cơ bản và làm quen với các dạng bài tập, các dạng đề thi và kiểm tra.',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Ôn luyện thi THPT quốc gia năm 2020','Images/On-luyen-thi-thpt-quoc-gia-nam-2020.jpg',248,GETDATE(),108000,10,0,N'Bộ sách Ôn luyện thi THPT quốc gia năm 2020 gồm 05 môn và nhóm môn: Toán, Tiếng Anh, Ngữ văn, Khoa học tự nhiên (Vật lí, Hóa học, Sinh học), Khoa học xã hội (Lịch sử, Địa lí, Giáo dục công dân). 
Nội dung bộ sách được biên soạn bám sát chuẩn kiến thức, kĩ năng của chương trình cấp THPT, chủ yếu là chương trình lớp 12. Cấu trúc mỗi cuốn sách gồm hai phần chính:
- Phần 1: Hệ thống câu hỏi ôn tập theo chủ đề môn học
- Phần 2: Đề tham khảo minh họa 
Đặc biệt, theo định hướng tổ chức Kì thi THPT Quốc gia trên máy tính thực hiện từ năm 2021 bộ sách được tích hợp Ứng dụng thi thử trực tuyến theo Công nghệ 4.0 E-test nhằm xây dựng môi trường học tập toàn diện cho Nhà trường và học sinh. Ứng dụng cho phép học sinh ôn luyện, làm bài thi thử miễn phí trên nền tảng website và smartphone với số lượng đề thi đa dạng và phong phú được biên soạn bởi các giáo viên luyện thi uy tín. Các cơ sở giáo dục có thể tạo phòng thi cho học sinh với đề thi được biên soạn riêng, chế độ chấm thi, phân tích năng lực học sinh theo đơn vị kiến thức và kĩ năng làm bài tự động theo yêu cầu của từng đơn vị. ',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Bài tập bổ trợ và phát triển năng lực môn Tiếng Anh THPT','Images/bai-tap-bo-tro-va-phat-trien-nang-luc-mon-tieng-Anh-thpt.jpg',248,GETDATE(),77000,10,0,N'Bộ sách Bài tập bổ trợ và phát triển năng lực môn Tiếng Anh THPT tập 1 gồm 03 cuốn ứng với 3 khối lớp 10, 11, 12.
Mỗi cuốn sách được thiết kế theo các Unit ứng với từng chủ điểm trong sách giáo khoa mới của Bộ Giáo dục và Đào tạo.
Trong mỗi bài học đều có 2 phần:
- Phần 1: Ôn tập và củng cố lý thuyết nền tảng về từ vựng, luyện âm và ngữ pháp theo chủ điểm của bài học.
- Phần 2: bao gồm các bài tập vận dụng ngữ pháp và thực hành các kĩ năng Reading- Listening - Writing - Speaking. Sau mỗi bài học đều có bài tập để kiểm tra, củng cố kiến thức.',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Câu Hỏi Trắc Nghiệm Địa Lý 12','Images/cau-hoi-trac-nghiem-dia-ly-12.jpg',170,GETDATE(),47000,10,0,N'Cuốn sách được biên soạn theo chương trình mới của Bộ Giáo dục và Đào tạo, nội dung gồm có: - Câu hỏi trắc nghiệm khách quan - Để kiểm tra trắc nghiệm và tự luận khách quan
Cuốn sách này có thể giúp cho các học sinh ôn tập và tự kiểm tra.',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Sinh 12 Tự Luận Và Trắc Nghiệm - Tập 1','Images/sinh-12-tu-luan-va-trac-nghiem-tap-1.jpg',180,GETDATE(),49000,10,0,N'Trắc nghiệm là phương pháp thi mà trong đó đề thi bao gồm nhiều câu hỏi, mỗi câu hỏi nêu ra một vấn đề cùng với những thông tin cần thiết, qua đó thí sinh xác định được câu trả lời đúng. Có nhiều loại câu hỏi trắc nghiệm nhưng người ta thường dùng loại câu hỏi trắc nghiệm nhiều lựa chọn để làm đề thi. Nhưng nếu thí sinh không giải được các bài tập tự luận một cách nhuần nhuyễn thì sẽ rất khó chọn câu trả lời đúng đối với các loại đề đòi hỏi phải tính toán.
Cuốn sách “Sinh 12 Tự Luận Và Trắc Nghiệm - Tập 1” được biên soạn nhằm giúp học sinh cách giải nhanh các loại đề trắc nghiệm nói trên. Cuốn sách trình bày toàn bộ các kiến thức cơ bản của chương trình nhằm giúp học sinh củng cố và hệ thống hoá đồng thời bên cạnh các câu hỏi cơ bản cũng có những câu hỏi nâng cao, đòi hỏi suy luận nhằm giúp học sinh ôn luyện để thi đại học.',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','11C4B47A-C697-46AC-89E9-036A684DFAB3',N'Bồi Dưỡng Hình Học 12 (Tự Luận Và Trắc Nghiệm)','Images/boi-duong-hinh-hoc-12.jpg',190,GETDATE(),56000,10,0,N'Nội dung cuốn sách bao gồm:
Chương 1: Phép dời hình và phép đồng dạng trong không gian
Bài 1: Phép dời hình trong không gian
Bài 2: Phép tịnh tiến – Phép đối xứng và phép quay trong không gian
Bài 3: Phép vị tự và đồng dạng
Chương 2: Khối đa diện và thể tích của chúng
Bài 1: Khái niệm về khối đa diện
Bài 2: Thể tích của khối đa diện
Chương 3: Mặt nón, mặt trụ, mặt cầu
Bài 1: Khái niệm về mặt tròn xoay
Bài 2: Mặt nón
Bài 3: Mặt trụ tròn xoay
Bài 4: Mặt cầu
Chương 4: Phương pháp toạ độ trong không gian
Bài 1: Hệ toạ độ trong không gian
Bài 2: Phương trình mặt phẳng
Bài 3: Phương trình đường thẳng trong không gian
Hướng dẫn giải và đáp số',0,GETDATE(),1)
go
--sach thieu nhi
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','BFF56505-860C-4026-ACB0-8883B26B243C',N'Phẩm Chất Nhà Lãnh Đạo Nhí - Sự Khiêm Tốn','Images/pham-chat-nha-lanh-dao-nhi-su-khiem-ton.jpg',189,GETDATE(),49500,10,0,N'Khiêm tốn là thái độ mà người lãnh đạo nhất định cần phải có. Càng là người có năng lực thì càng không được tỏ vẻ ta đây, mà phải đặt khiêm tốn lên hàng đầu. Cần phải thực lòng tôn trọng người khác, biết cách khen ngợi điểm mạnh của người khác và biết  nhún mình. Nếu có được sự khiêm tốn và biết nhún mình như Trống trong dàn nhạc nhí, bạn sẽ có thể trở thành nhà lãnh đạo xuất sắc, được mọi người tôn trọng và mến mộ.',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','BFF56505-860C-4026-ACB0-8883B26B243C',N'Nhà Của Ai Cao Hơn?','Images/nha-cua-ai-cao-hon.jpg',182,GETDATE(),40000,10,0,N'Cú và Thỏ là những người bạn hàng xóm tốt của nhau. Họ sống hạnh phúc trong hai ngôi nhà nằm cạnh nhau trên đồi...
Cuộc sống sẽ êm đềm trôi nếu như một ngày kia những cái cây trong vườn của Thỏ che mất tầm nhìn của Cú. Ai cũng muốn nhà của của mình cao lên một chút, chẳng bao lâu sau có hai ngôi nhà rất rất cao và hai người hàng xóm không còn thân thiết nữa.
Điều gì sẽ giúp họ trở lại thành những người bạn tốt như ngày trước?',0,GETDATE(),1)
go
insert into Book(id, IdPublisher,BookTypeId,Title,ImagePath,NumberPages,PublishDate,Price,Quantity,DiscountPrice,Description, StarsAverage,CreatedDate,IsActive)
values(NEWID(),'8A09A783-6939-4B8F-9286-BEE96B3E24E9','BFF56505-860C-4026-ACB0-8883B26B243C',N'Những Gã Khổng Lồ Trái Đất','Images/nhung-ga-khong-lo-trai-dat.jpg',132,GETDATE(),25000,10,0,N'Bộ sách sử dụng hình ảnh CGI (mô phỏng bằng máy tính) để so sánh mức độ khổng lồ và nguy hiểm của các loài sinh vật thời tiền sử nếu chẳng may chúng còn sống và tồn tại chung một thời đại với chúng ta. NHỮNG GÃ KHỔNG LỒ TRÁI ĐẤT giới thiệu những sinh vật đáng gườm nhất về hình thể, những tổ tiên của loài có vú đã từng thống trị Trái Đất hàng trăm triệu năm trước. Bạn có muốn dạo phố chung với những sinh vật cổ đại này?',0,GETDATE(),1)
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
select Id from Book where Id not in(select BookId from BookAuthor)
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
										---
insert into BookAuthor(BookId,AuthorId) values('3D77006F-0368-48DF-BD89-0D7B6119CA87','A66E551B-EDBC-407A-81B6-38E6CEEE62BD'),
												('20EA7481-4806-4308-B3C2-2186807BB60B','38FA054A-4B05-40B7-B520-40D401FCE8D6'),
												('5F8A4629-6639-4809-815C-369417B0D44A','8C30A414-BC59-44E8-9FDE-6C0BBE76E702'),
												('AAF15311-CDA2-43FC-B568-46B5447538D6','5F900014-D1D7-44A4-87A2-D4F5D308C64C'),
												('EC63EBC0-ADC0-45D9-8346-7876E2AFBD8F','8C30A414-BC59-44E8-9FDE-6C0BBE76E702'),
												('55117699-2022-4D12-8DCA-A14A207B0F31','38FA054A-4B05-40B7-B520-40D401FCE8D6'),
												('66858D25-D0F9-4730-8750-DC38D3BA59AF','5F900014-D1D7-44A4-87A2-D4F5D308C64C'),
												('88054277-5BC8-4AF9-87E3-E6C3F011426B','A66E551B-EDBC-407A-81B6-38E6CEEE62BD'),
												('67409C1D-41F5-463F-803E-EBFC31381D48','38FA054A-4B05-40B7-B520-40D401FCE8D6')
								
