# Kế hoạch dự án Clinic Management - 3 tuần
*Ngày lập: 7/6/2025*

## Tổng quan dự án
- **Tên dự án:** Clinic Management System
- **Công nghệ:** C#, .NET Core MVC, SQL Server
- **Thời gian:** 3 tuần

## Phân công vai trò

### Team Leader / Project Manager
- Quản lý tiến độ dự án
- Đảm bảo chất lượng sản phẩm
- Điều phối các cuộc họp và trao đổi
- Báo cáo tiến độ

### Backend Developer
- Thiết kế cơ sở dữ liệu
- Phát triển API và business logic
- Xây dựng các chức năng phía server

### Frontend Developer
- Thiết kế UI/UX
- Triển khai giao diện người dùng
- Tích hợp API với frontend

## Lịch trình chi tiết

### Tuần 1: Phân tích yêu cầu và thiết kế hệ thống (7/6 - 13/6)

#### Ngày 1-2: Phân tích yêu cầu
- [ ] Phân tích tài liệu yêu cầu
- [ ] Xác định scope dự án
- [ ] Liệt kê các chức năng cần thiết
- [ ] Tạo user story và use case

#### Ngày 3-4: Thiết kế cơ sở dữ liệu
- [ ] Thiết kế ERD (Entity Relationship Diagram)
- [ ] Tạo database schema
- [ ] Xác định các ràng buộc và quan hệ
- [ ] Chuẩn bị scripts để tạo database

#### Ngày 5-7: Thiết kế kiến trúc và prototype
- [ ] Thiết kế kiến trúc hệ thống
- [ ] Tạo wireframe/mockup cho UI
- [ ] Thiết kế luồng làm việc (workflow)
- [ ] Xây dựng prototype cơ bản

#### Deliverables tuần 1:
- ERD và database schema
- Wireframe/mockup UI
- Tài liệu phân tích yêu cầu
- Kiến trúc hệ thống
- Prototype cơ bản

### Tuần 2: Phát triển (14/6 - 20/6)

#### Ngày 1-2: Cấu trúc dự án và cài đặt database
- [ ] Tạo project .NET Core MVC
- [ ] Thiết lập các thư mục, namespace
- [ ] Tạo database và áp dụng schema
- [ ] Tạo Entity Framework Core models

#### Ngày 3-5: Phát triển chức năng cốt lõi
- [ ] Xây dựng authentication và authorization
- [ ] Phát triển chức năng quản lý bệnh nhân
- [ ] Phát triển chức năng đặt lịch khám
- [ ] Phát triển chức năng quản lý nhân viên

#### Ngày 6-7: Phát triển chức năng mở rộng
- [ ] Phát triển chức năng quản lý thuốc
- [ ] Phát triển chức năng thanh toán
- [ ] Phát triển chức năng báo cáo
- [ ] Phát triển chức năng thông báo

#### Deliverables tuần 2:
- Codebase với các chức năng cốt lõi
- Database đã được tạo và có dữ liệu mẫu
- API documentation
- Unit tests cho các chức năng chính

### Tuần 3: Hoàn thiện và kiểm thử (21/6 - 27/6)

#### Ngày 1-3: Frontend và UX
- [ ] Hoàn thiện giao diện người dùng
- [ ] Tích hợp frontend với backend
- [ ] Responsive design
- [ ] Cải thiện trải nghiệm người dùng

#### Ngày 4-5: Kiểm thử và sửa lỗi
- [ ] Unit testing
- [ ] Integration testing
- [ ] Performance testing
- [ ] Sửa lỗi và tối ưu hóa

#### Ngày 6-7: Tài liệu và triển khai
- [ ] Viết tài liệu hướng dẫn sử dụng
- [ ] Chuẩn bị tài liệu kỹ thuật
- [ ] Triển khai hệ thống
- [ ] Demonstration và bàn giao

#### Deliverables tuần 3:
- Hệ thống hoàn chỉnh với đầy đủ chức năng
- Tài liệu hướng dẫn sử dụng
- Tài liệu kỹ thuật
- Báo cáo kiểm thử
- Mã nguồn hoàn chỉnh

## Các chức năng chính của hệ thống

1. **Quản lý bệnh nhân**
   - Đăng ký bệnh nhân mới
   - Cập nhật thông tin bệnh nhân
   - Xem lịch sử khám bệnh
   - Quản lý hồ sơ bệnh án

2. **Quản lý lịch hẹn**
   - Đặt lịch hẹn mới
   - Chỉnh sửa/hủy lịch hẹn
   - Thông báo nhắc lịch hẹn
   - Xem lịch làm việc của bác sĩ

3. **Quản lý nhân viên**
   - Thêm/sửa/xóa thông tin nhân viên
   - Phân quyền người dùng
   - Quản lý lịch làm việc
   - Đánh giá hiệu suất

4. **Quản lý thuốc và dịch vụ**
   - Thêm/sửa/xóa thuốc và dịch vụ
   - Quản lý kho thuốc
   - Cảnh báo hết hàng
   - Quản lý giá cả

5. **Thanh toán và hóa đơn**
   - Tạo hóa đơn
   - Xử lý thanh toán
   - Lịch sử thanh toán
   - Báo cáo doanh thu

6. **Báo cáo và thống kê**
   - Báo cáo hoạt động phòng khám
   - Thống kê bệnh nhân
   - Thống kê doanh thu
   - Xuất báo cáo

7. **Quản lý người dùng**
   - Đăng nhập/đăng xuất
   - Phân quyền
   - Đổi mật khẩu
   - Khôi phục mật khẩu

## Cấu trúc dự án

```
ClinicManagement/
├── ClinicManagement.Web/           # MVC Web Application
├── ClinicManagement.Core/          # Business logic & domain models
├── ClinicManagement.Infrastructure/ # Data access & external services
├── ClinicManagement.Tests/         # Unit tests
└── Database/                       # SQL scripts
```

## Công nghệ sử dụng

- **Backend:** C# .NET Core MVC 6.0
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Frontend:** HTML, CSS, JavaScript, Bootstrap
- **Authentication:** ASP.NET Core Identity
- **Reporting:** RDLC/Crystal Reports
- **Version Control:** Git
- **Testing:** xUnit, Moq

## Quy trình làm việc

1. **Daily Stand-up:** Họp ngắn 15 phút mỗi ngày
2. **Code Review:** Mỗi feature cần được review trước khi merge
3. **Testing:** Unit tests cho mỗi chức năng mới
4. **Documentation:** Cập nhật tài liệu song song với phát triển
5. **Weekly Demo:** Demo tiến độ vào cuối mỗi tuần
