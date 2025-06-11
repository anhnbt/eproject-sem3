# Phân tích Yêu cầu Hệ thống Quản lý Phòng khám

## 1. Tổng quan yêu cầu

### Mục tiêu hệ thống
- Xây dựng hệ thống quản lý phòng khám toàn diện, giúp tối ưu hóa quy trình làm việc
- Giúp phòng khám theo dõi doanh thu và quản lý thanh toán hiệu quả
- Hỗ trợ quản lý sản phẩm (thuốc, máy móc khoa học) và bán hàng trực tuyến.
- Quản lý và theo dõi các hoạt động giáo dục.

### Đối tượng sử dụng
1. **Quản trị viên (Admin)**: Quản lý toàn bộ hệ thống, bao gồm dữ liệu khách hàng, chi tiết giao dịch trực tuyến, và theo dõi các hoạt động giáo dục.
2. **Nhân viên (Staff/Instructor)**: Quản lý và thực hiện các hoạt động giáo dục (ví dụ: giảng dạy bài giảng, hướng dẫn thực hành, tổ chức hội thảo).
3. **Khách hàng (Client/Customer)**: Đăng ký tài khoản, thực hiện mua hàng trực tuyến (máy móc, thuốc), và cung cấp phản hồi.

## 2. Yêu cầu chức năng

### Quản lý người dùng
- Đăng ký, đăng nhập, phân quyền
- Quản lý thông tin cá nhân
- Quên mật khẩu
- Đăng xuất hệ thống

### Quản lý nhân viên/giảng viên (Staff/Instructors)
- Thêm/sửa/xóa thông tin nhân viên/giảng viên
- Quản lý thông tin chuyên môn/lĩnh vực giảng dạy

### Quản lý sản phẩm (Product Management)
- Quản lý thông tin thuốc (Medicines).
- Quản lý thông tin máy móc khoa học (Scientific Machines).
- Quản lý danh mục sản phẩm, giá và tồn kho.
- Theo dõi việc sử dụng/bán thuốc (tập trung vào quản lý kho).

### Quản lý mua hàng trực tuyến (Online Purchase Management)
- Chức năng duyệt và tìm kiếm sản phẩm.
- Chức năng giỏ hàng.
- Xử lý đơn hàng (đặt hàng, xác nhận, theo dõi).
- Tích hợp cổng thanh toán trực tuyến (Cân nhắc).
- Quản lý phản hồi của khách hàng về sản phẩm và dịch vụ.

### Quản lý hoạt động giáo dục (Educational Activities Management)
- Tạo và quản lý thông tin các khóa học, hội thảo, bài giảng, buổi thực hành.
- Quản lý lịch trình và địa điểm.
- Quản lý đăng ký tham gia từ khách hàng/học viên.
- Quản lý tài liệu và nội dung học tập.
- Theo dõi và đánh giá hiệu quả hoạt động giáo dục.

### Quản lý thanh toán
- Tạo hóa đơn mới (cho đơn hàng trực tuyến)
- Xử lý thanh toán (qua cổng thanh toán) (Cân nhắc)
- In hóa đơn / Gửi hóa đơn điện tử (Cân nhắc)
- Xem lịch sử thanh toán / giao dịch
- Báo cáo doanh thu

### Báo cáo và thống kê
- Báo cáo doanh thu theo thời gian
- Báo cáo sử dụng thuốc (doanh số, tồn kho)
- Xuất báo cáo dạng Excel/PDF
- Báo cáo về tình hình bán hàng sản phẩm (máy móc, thuốc).
- Báo cáo về hiệu quả các hoạt động giáo dục.
- Báo cáo về tương tác và phản hồi của khách hàng.

## 3. Yêu cầu phi chức năng

### Hiệu năng
- Hệ thống phải xử lý nhanh chóng các yêu cầu người dùng
- Hỗ trợ nhiều người dùng truy cập đồng thời
- Thời gian phản hồi dưới 3 giây cho các thao tác thông thường

### Bảo mật
- Xác thực và phân quyền người dùng chặt chẽ
- Mã hóa dữ liệu nhạy cảm
- Đăng nhập an toàn với HTTPS
- Tuân thủ các quy định về bảo mật thông tin y tế

### Tính sẵn sàng
- Hệ thống hoạt động 24/7
- Có cơ chế sao lưu và khôi phục dữ liệu
- Xử lý lỗi hiệu quả

### Khả năng mở rộng
- Dễ dàng thêm chức năng mới
- Hỗ trợ tăng số lượng người dùng và dữ liệu
- Kiến trúc có thể mở rộng

### Giao diện người dùng
- Giao diện thân thiện, dễ sử dụng
- Đáp ứng trên nhiều thiết bị (responsive)
- Thời gian học sử dụng ngắn

## 4. Quy trình nghiệp vụ

### Quy trình đăng ký tài khoản khách hàng
1. Khách hàng truy cập trang đăng ký trên website/ứng dụng.
2. Khách hàng điền thông tin yêu cầu (tên, email, mật khẩu, thông tin liên hệ).
3. Hệ thống kiểm tra và xác thực thông tin.
4. Tạo tài khoản mới và lưu vào cơ sở dữ liệu.
5. Gửi email xác nhận cho khách hàng.

### Quy trình mua hàng trực tuyến
1. Khách hàng duyệt xem sản phẩm trên website/ứng dụng.
2. Khách hàng thêm sản phẩm mong muốn vào giỏ hàng.
3. Khách hàng tiến hành thanh toán, chọn địa chỉ giao hàng (nếu có) và phương thức thanh toán.
4. Hệ thống chuyển đến cổng thanh toán để xử lý giao dịch.
5. Sau khi thanh toán thành công, hệ thống xác nhận đơn hàng.
6. Hệ thống cập nhật trạng thái đơn hàng, thông báo cho khách hàng và bộ phận xử lý đơn hàng.
7. Tạo và gửi hóa đơn điện tử cho khách hàng.

### Quy trình quản lý hoạt động giáo dục
1. Quản trị viên hoặc nhân viên được phân công tạo mới một hoạt động giáo dục (ví dụ: hội thảo, khóa học).
2. Nhập các thông tin chi tiết: tên hoạt động, mô tả, nội dung, lịch trình, địa điểm, giảng viên, số lượng người tham gia tối đa, chi phí (nếu có).
3. Công khai hoạt động trên hệ thống để khách hàng có thể xem và đăng ký.
4. Khách hàng đăng ký tham gia hoạt động giáo dục.
5. Nhân viên quản lý danh sách đăng ký, gửi thông báo nhắc nhở.
6. Sau khi hoạt động kết thúc, cập nhật trạng thái và thu thập phản hồi (nếu có).

### Quy trình quản lý sản phẩm
1. Quản trị viên thêm mới hoặc cập nhật thông tin sản phẩm (thuốc, máy móc).
2. Nhập các chi tiết: tên sản phẩm, mô tả, hình ảnh, danh mục, nhà cung cấp, giá bán, đơn vị tính.
3. Quản lý số lượng tồn kho, cập nhật khi có giao dịch mua bán hoặc nhập hàng.
4. Thiết lập cảnh báo khi số lượng tồn kho xuống dưới mức quy định.

## 5. Yêu cầu dữ liệu

### Dữ liệu người dùng
- Thông tin tài khoản (username, password)
- Thông tin cá nhân (họ tên, ngày sinh, giới tính)
- Thông tin liên hệ (email, số điện thoại, địa chỉ)
- Vai trò trong hệ thống (Admin, Staff/Instructor, Customer)

### Dữ liệu nhân viên/giảng viên (Staff/Instructors)
- Thông tin cá nhân (họ tên, thông tin liên hệ)
- Chuyên môn/Lĩnh vực giảng dạy hoặc phụ trách
- Kinh nghiệm làm việc, bằng cấp/chứng chỉ liên quan
- Lịch giảng dạy/hoạt động (nếu có)

### Dữ liệu sản phẩm (Products)
- Mã sản phẩm, tên sản phẩm
- Mô tả chi tiết, hình ảnh
- Danh mục sản phẩm
- Đơn vị tính, giá bán, giá nhập (nếu quản lý)
- Số lượng tồn kho
- Nhà cung cấp
- Ngày hết hạn (đối với các sản phẩm như thuốc)
- Thuộc tính đặc thù (ví dụ: thông số kỹ thuật cho máy móc)

### Dữ liệu đơn hàng/giao dịch (Orders/Transactions)
- Mã đơn hàng
- Thông tin khách hàng (liên kết đến Dữ liệu người dùng/khách hàng)
- Danh sách sản phẩm trong đơn hàng (sản phẩm, số lượng, đơn giá, thành tiền)
- Tổng giá trị đơn hàng
- Phương thức thanh toán, trạng thái thanh toán
- Ngày giờ đặt hàng, ngày giờ thanh toán
- Thông tin giao hàng (địa chỉ, trạng thái vận chuyển nếu có)
- Hóa đơn liên quan

### Dữ liệu khách hàng (Customers/Clients)
- Mã khách hàng (liên kết với Dữ liệu người dùng).
- Loại khách hàng (cá nhân, doanh nghiệp).
- Thông tin liên hệ chi tiết (địa chỉ giao hàng mặc định, v.v.).
- Lịch sử mua hàng và giao dịch.
- Lịch sử tham gia hoạt động giáo dục.
- Phản hồi và đánh giá.

### Dữ liệu hoạt động giáo dục (Educational Activities)
- Mã hoạt động, tên hoạt động.
- Mô tả chi tiết, nội dung, mục tiêu.
- Loại hình (hội thảo, khóa học, bài giảng).
- Lịch trình (thời gian bắt đầu, kết thúc), địa điểm (trực tuyến/ngoại tuyến).
- Thông tin giảng viên (liên kết đến Dữ liệu nhân viên/giảng viên).
- Số lượng người tham gia tối đa, chi phí tham gia (nếu có).
- Danh sách người đăng ký/tham gia.
- Tài liệu liên quan.

## 6. Giao diện người dùng

### Màn hình chung
- Màn hình đăng nhập
- Màn hình chính (Dashboard)
- Màn hình quản lý tài khoản
- Màn hình thông báo

### Màn hình quản trị viên
- Quản lý người dùng (Admin, Staff, Customer).
- Quản lý sản phẩm (thuốc, máy móc khoa học) và danh mục.
- Quản lý đơn hàng và giao dịch trực tuyến.
- Quản lý hoạt động giáo dục (tạo, cập nhật, theo dõi).
- Xem báo cáo tổng hợp (doanh thu, bán hàng, hoạt động giáo dục).
- Quản lý cấu hình hệ thống.
- Quản lý nội dung website (tin tức, giới thiệu - nếu có).

### Màn hình nhân viên (Staff/Instructor)
- Xem và quản lý lịch hoạt động giáo dục được phân công.
- Cập nhật nội dung, tài liệu cho hoạt động giáo dục.
- Quản lý danh sách học viên/người tham gia hoạt động.
- Giao tiếp với học viên (gửi thông báo, trả lời câu hỏi - nếu có).
- Nhập điểm/đánh giá kết quả học tập (nếu có).

### Màn hình khách hàng (Customer/Client)
- Đăng ký/Đăng nhập tài khoản.
- Xem trang chủ với các sản phẩm nổi bật, hoạt động giáo dục mới.
- Duyệt, tìm kiếm sản phẩm theo danh mục, từ khóa.
- Xem chi tiết sản phẩm (thông tin, hình ảnh, giá, đánh giá).
- Quản lý giỏ hàng (thêm, xóa, cập nhật số lượng).
- Thực hiện quy trình đặt hàng và thanh toán trực tuyến.
- Quản lý tài khoản cá nhân (cập nhật thông tin, đổi mật khẩu).
- Xem lịch sử đơn hàng và trạng thái xử lý.
- Xem danh sách các hoạt động giáo dục, đăng ký tham gia.
- Xem lịch sử tham gia hoạt động giáo dục.
- Gửi phản hồi, đánh giá sản phẩm, dịch vụ.
