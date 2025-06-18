# Phân tích yêu cầu cho các chức năng cốt lõi

## 1. Tổng quan về hệ thống

Phiên bản cốt lõi của Hệ thống Quản lý Phòng khám tập trung vào bốn chức năng chính:
1. Quản lý người dùng (User Management)
2. Quản lý sản phẩm (Product Management) 
3. Quản lý mua hàng trực tuyến (Online Purchase Management)
4. Tạo báo cáo (Report Generation)

Phiên bản này loại bỏ các chức năng phụ như quản lý hoạt động giáo dục, quản lý nội dung website và quản lý phản hồi khách hàng để tập trung vào trải nghiệm cốt lõi của người dùng.

## 2. Mục tiêu dự án cốt lõi

- Xây dựng hệ thống quản lý phòng khám tập trung vào việc bán và quản lý sản phẩm y tế
- Tạo trải nghiệm mua hàng trực tuyến thuận tiện cho khách hàng
- Cung cấp hệ thống quản lý người dùng với phân quyền phù hợp
- Xây dựng công cụ báo cáo hiệu quả để theo dõi hoạt động kinh doanh

## 3. Yêu cầu chức năng cốt lõi

### 3.1. Quản lý người dùng (User Management)

#### 3.1.1. Quản lý người dùng dành cho Quản trị viên
- Xem danh sách tất cả người dùng với khả năng lọc theo vai trò, trạng thái
- Tìm kiếm người dùng theo tên, email, số điện thoại
- Quản lý vai trò và phân quyền người dùng (thêm, sửa, xóa vai trò)
- Kích hoạt/vô hiệu hóa tài khoản người dùng

#### 3.1.2. Quản lý người dùng dành cho Nhân viên
- Xem và chỉnh sửa thông tin cá nhân
- Đăng nhập/đăng xuất an toàn
- Đổi mật khẩu

#### 3.1.3. Quản lý người dùng dành cho Khách hàng
- Đăng ký tài khoản mới
- Đăng nhập/đăng xuất an toàn
- Xem và cập nhật thông tin cá nhân
- Thay đổi mật khẩu
- Khôi phục mật khẩu qua email

### 3.2. Quản lý sản phẩm (Product Management)

#### 3.2.1. Quản lý thuốc
- Thêm, sửa, xóa thông tin thuốc
- Quản lý danh mục thuốc
- Tìm kiếm thuốc theo tên, danh mục, giá
- Quản lý số lượng tồn kho
- Cảnh báo hết hàng/sắp hết hàng

#### 3.2.2. Quản lý thiết bị khoa học/y tế
- Thêm, sửa, xóa thông tin thiết bị
- Quản lý danh mục thiết bị
- Tìm kiếm thiết bị theo tên, danh mục, giá, thông số kỹ thuật
- Quản lý tình trạng thiết bị (còn hàng, hết hàng, đặt trước)

#### 3.2.3. Hiển thị sản phẩm cho khách hàng
- Hiển thị danh sách sản phẩm theo danh mục
- Tìm kiếm sản phẩm
- Xem thông tin chi tiết sản phẩm
- Hiển thị giá, khuyến mãi, tình trạng tồn kho

### 3.3. Quản lý mua hàng trực tuyến (Online Purchase Management)

#### 3.3.1. Giỏ hàng và đặt hàng
- Thêm sản phẩm vào giỏ hàng
- Cập nhật số lượng, xóa sản phẩm trong giỏ hàng
- Tính tổng tiền (bao gồm thuế, phí vận chuyển)
- Tiến hành đặt hàng, nhập thông tin giao hàng
- Chọn phương thức thanh toán

#### 3.3.2. Thanh toán
- Hỗ trợ nhiều phương thức thanh toán
- Xử lý thanh toán an toàn
- Gửi email xác nhận đơn hàng và thanh toán
- Lưu trữ thông tin thanh toán an toàn

#### 3.3.3. Quản lý đơn hàng
- Theo dõi trạng thái đơn hàng
- Cập nhật trạng thái đơn hàng
- Hủy đơn hàng và xử lý hoàn tiền
- Xem lịch sử đơn hàng

### 3.4. Tạo báo cáo (Report Generation)

#### 3.4.1. Báo cáo doanh số
- Báo cáo doanh thu theo khoảng thời gian
- Báo cáo doanh thu theo sản phẩm/danh mục
- Báo cáo doanh thu theo khách hàng
- So sánh doanh số giữa các kỳ

#### 3.4.2. Báo cáo tồn kho
- Báo cáo tồn kho hiện tại
- Báo cáo sản phẩm sắp hết hàng
- Báo cáo giá trị tồn kho
- Báo cáo sản phẩm không có hoạt động

#### 3.4.3. Báo cáo khách hàng
- Báo cáo khách hàng mới
- Báo cáo khách hàng theo doanh số
- Báo cáo hành vi mua hàng

#### 3.4.4. Xuất báo cáo
- Xuất báo cáo dạng PDF
- Xuất báo cáo dạng Excel
- Lưu trữ và chia sẻ báo cáo

## 4. Yêu cầu phi chức năng cho phiên bản cốt lõi

### 4.1. Hiệu suất
- Thời gian phản hồi trang < 2 giây
- Xử lý thanh toán < 5 giây
- Khả năng xử lý tối thiểu 1000 người dùng đồng thời

### 4.2. Bảo mật
- Mã hóa dữ liệu người dùng và thông tin thanh toán
- Sử dụng HTTPS cho toàn bộ trang web
- Bảo vệ chống SQL injection, XSS và CSRF
- Tuân thủ các quy định về bảo vệ dữ liệu

### 4.3. Độ tin cậy
- Uptime > 99.5%
- Sao lưu dữ liệu hàng ngày
- Cơ chế khôi phục sau sự cố

### 4.4. Khả năng sử dụng
- Giao diện người dùng trực quan, dễ sử dụng
- Hỗ trợ đa ngôn ngữ (Tiếng Việt và Tiếng Anh)
- Thiết kế responsive cho điện thoại di động và máy tính bảng

## 5. Đối tượng người dùng

### 5.1. Quản trị viên (Admin)
- Nhân viên IT hoặc quản lý cấp cao của phòng khám
- Có quyền truy cập đầy đủ vào hệ thống
- Quản lý người dùng, sản phẩm, đơn hàng và báo cáo

### 5.2. Nhân viên (Staff)
- Nhân viên phòng khám, nhân viên bán hàng, nhân viên kho
- Có quyền truy cập vào các chức năng liên quan đến công việc của họ
- Quản lý sản phẩm, xử lý đơn hàng, xem báo cáo

### 5.3. Khách hàng (Customer)
- Người mua thuốc và thiết bị y tế
- Đăng ký, đăng nhập, mua hàng trực tuyến
- Xem lịch sử đơn hàng và thông tin cá nhân

## 6. Công nghệ đề xuất

### 6.1. Backend
- ASP.NET Core
- Entity Framework Core
- SQL Server

### 6.2. Frontend
- HTML5, CSS3, JavaScript
- Bootstrap
- jQuery/React

### 6.3. Bảo mật
- ASP.NET Identity
- JWT (JSON Web Tokens)
- HTTPS

### 6.4. Công cụ báo cáo
- SSRS (SQL Server Reporting Services)
- Chart.js cho hiển thị biểu đồ
