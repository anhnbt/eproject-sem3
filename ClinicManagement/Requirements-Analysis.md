# Phân tích Yêu cầu Hệ thống Quản lý Phòng khám

## 1. Tổng quan yêu cầu

### Mục tiêu hệ thống
- Xây dựng hệ thống quản lý phòng khám toàn diện, giúp tối ưu hóa quy trình làm việc
- Cải thiện hiệu quả quản lý thông tin bệnh nhân và hồ sơ y tế
- Tự động hóa các quy trình đặt lịch và quản lý lịch hẹn
- Giúp phòng khám theo dõi doanh thu và quản lý thanh toán hiệu quả

### Đối tượng sử dụng
1. **Quản trị viên (Admin)**: Quản lý toàn bộ hệ thống
2. **Bác sĩ**: Xem và cập nhật thông tin bệnh nhân, lịch hẹn, kê đơn thuốc
3. **Y tá**: Hỗ trợ bác sĩ, quản lý thông tin bệnh nhân
4. **Lễ tân (Receptionist)**: Đặt lịch hẹn, quản lý tiếp đón bệnh nhân
5. **Bệnh nhân**: Xem lịch hẹn, lịch sử khám bệnh, đơn thuốc

## 2. Yêu cầu chức năng

### Quản lý người dùng
- Đăng ký, đăng nhập, phân quyền
- Quản lý thông tin cá nhân
- Phục hồi mật khẩu
- Đăng xuất hệ thống

### Quản lý bệnh nhân
- Đăng ký bệnh nhân mới
- Cập nhật thông tin bệnh nhân
- Tìm kiếm thông tin bệnh nhân
- Xem lịch sử khám bệnh
- Quản lý hồ sơ y tế

### Quản lý bác sĩ
- Thêm/sửa/xóa thông tin bác sĩ
- Quản lý chuyên khoa
- Quản lý lịch làm việc của bác sĩ
- Xem thống kê khám bệnh của từng bác sĩ

### Quản lý lịch hẹn
- Đặt lịch hẹn mới
- Chỉnh sửa/hủy lịch hẹn
- Tìm kiếm lịch hẹn
- Gửi thông báo nhắc lịch hẹn
- Xem lịch làm việc của bác sĩ

### Quản lý dược phẩm
- Thêm/sửa/xóa thông tin thuốc
- Quản lý kho thuốc
- Cảnh báo thuốc sắp hết hàng
- Theo dõi việc sử dụng thuốc

### Quản lý đơn thuốc
- Tạo đơn thuốc mới
- Tìm kiếm đơn thuốc
- In đơn thuốc
- Xem lịch sử đơn thuốc

### Quản lý thanh toán
- Tạo hóa đơn mới
- Xử lý thanh toán
- In hóa đơn
- Xem lịch sử thanh toán
- Báo cáo doanh thu

### Báo cáo và thống kê
- Báo cáo bệnh nhân theo thời gian
- Báo cáo doanh thu theo thời gian
- Thống kê lượt khám bệnh
- Báo cáo sử dụng thuốc
- Xuất báo cáo dạng Excel/PDF

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

### Quy trình đăng ký bệnh nhân mới
1. Tiếp nhận thông tin cá nhân của bệnh nhân
2. Nhập thông tin vào hệ thống
3. Tạo mã bệnh nhân
4. Lưu thông tin vào cơ sở dữ liệu

### Quy trình đặt lịch khám
1. Bệnh nhân/lễ tân chọn ngày và giờ mong muốn
2. Hệ thống kiểm tra lịch làm việc của bác sĩ
3. Xác nhận lịch hẹn
4. Gửi thông báo cho bệnh nhân và bác sĩ

### Quy trình khám bệnh
1. Bệnh nhân đến khám theo lịch hẹn
2. Lễ tân xác nhận bệnh nhân đã đến
3. Bác sĩ khám và ghi nhận kết quả
4. Kê đơn thuốc nếu cần
5. Chuyển bệnh nhân đến thanh toán

### Quy trình kê đơn thuốc
1. Bác sĩ chọn các thuốc cần kê
2. Nhập liều lượng và hướng dẫn sử dụng
3. Lưu và in đơn thuốc
4. Cập nhật vào hồ sơ bệnh án

### Quy trình thanh toán
1. Tính tổng chi phí (khám bệnh, thuốc, dịch vụ)
2. Bệnh nhân thanh toán
3. In hóa đơn
4. Cập nhật trạng thái thanh toán

## 5. Yêu cầu dữ liệu

### Dữ liệu người dùng
- Thông tin tài khoản (username, password)
- Thông tin cá nhân (họ tên, ngày sinh, giới tính)
- Thông tin liên hệ (email, số điện thoại, địa chỉ)
- Vai trò trong hệ thống

### Dữ liệu bệnh nhân
- Thông tin cá nhân
- Tiền sử bệnh án
- Dị ứng
- Nhóm máu
- Thông tin liên hệ khẩn cấp
- Số bảo hiểm y tế

### Dữ liệu bác sĩ
- Thông tin cá nhân
- Chuyên khoa
- Kinh nghiệm
- Lịch làm việc
- Số giấy phép hành nghề

### Dữ liệu lịch hẹn
- Thông tin bệnh nhân
- Thông tin bác sĩ
- Ngày giờ hẹn
- Thời gian dự kiến
- Trạng thái lịch hẹn
- Ghi chú

### Dữ liệu thuốc
- Tên thuốc
- Thông tin chi tiết
- Đơn vị
- Giá
- Số lượng trong kho
- Ngày hết hạn

### Dữ liệu đơn thuốc
- Thông tin bệnh nhân
- Thông tin bác sĩ
- Danh sách thuốc
- Liều lượng
- Hướng dẫn sử dụng
- Ngày kê đơn

### Dữ liệu thanh toán
- Thông tin bệnh nhân
- Chi tiết dịch vụ
- Tổng tiền
- Phương thức thanh toán
- Trạng thái thanh toán
- Ngày thanh toán

## 6. Giao diện người dùng

### Màn hình chung
- Màn hình đăng nhập
- Màn hình chính (Dashboard)
- Màn hình quản lý tài khoản
- Màn hình thông báo

### Màn hình quản trị viên
- Quản lý người dùng
- Quản lý cấu hình hệ thống
- Xem báo cáo tổng hợp
- Quản lý dịch vụ và giá cả

### Màn hình bác sĩ
- Xem lịch hẹn trong ngày
- Quản lý hồ sơ bệnh nhân
- Kê đơn thuốc
- Ghi chép bệnh án

### Màn hình lễ tân
- Đăng ký bệnh nhân mới
- Quản lý lịch hẹn
- Quản lý hàng đợi bệnh nhân
- Xử lý thanh toán

### Màn hình bệnh nhân
- Xem thông tin cá nhân
- Xem lịch hẹn
- Xem lịch sử khám bệnh
- Xem đơn thuốc
