# Dự án Hệ thống Quản lý Phòng khám - Phiên bản Cốt lõi (Minimal Project)

## Giới thiệu

Đây là phiên bản tối giản của Hệ thống Quản lý Phòng khám, tập trung vào bốn chức năng cốt lõi:
1. Quản lý người dùng (User Management)
2. Quản lý sản phẩm (Product Management)
3. Quản lý mua hàng trực tuyến (Online Purchase Management)
4. Tạo báo cáo (Report Generation)

Mục đích của phiên bản tối giản này là cung cấp một giải pháp nhanh chóng và hiệu quả cho việc quản lý hoạt động kinh doanh cơ bản của phòng khám, đặc biệt là bán thuốc và thiết bị y tế trực tuyến.

## Cấu trúc thư mục

```
MinimalProject/
│
├── Documentation/
│   ├── Core-DFD-Design.md       # Sơ đồ luồng dữ liệu
│   ├── Core-ERD-Design.md       # Sơ đồ quan hệ thực thể
│   ├── Core-Flowcharts.md       # Sơ đồ luồng quy trình
│   └── Core-Requirements-Analysis.md  # Phân tích yêu cầu
│
├── source/
│   ├── ClinicManagement.Core/           # Lớp domain và business logic
│   ├── ClinicManagement.Infrastructure/ # Lớp truy cập dữ liệu và dịch vụ ngoài
│   ├── ClinicManagement.Web/            # Giao diện người dùng web
│   └── ClinicManagement.Tests/          # Unit tests và integration tests
│
└── README.md
```

## Chức năng cốt lõi

### 1. Quản lý người dùng (User Management)
- Đăng ký tài khoản mới
- Đăng nhập/đăng xuất
- Quản lý thông tin cá nhân
- Phân quyền (Admin, Staff, Customer)
- Quản lý người dùng (dành cho Admin)

### 2. Quản lý sản phẩm (Product Management)
- Quản lý danh mục thuốc và thiết bị y tế
- Thêm, sửa, xóa sản phẩm
- Quản lý kho (số lượng tồn kho)
- Tìm kiếm sản phẩm
- Hiển thị thông tin sản phẩm cho khách hàng

### 3. Quản lý mua hàng trực tuyến (Online Purchase Management)
- Giỏ hàng
- Đặt hàng
- Thanh toán
- Theo dõi trạng thái đơn hàng
- Quản lý đơn hàng (dành cho Staff/Admin)

### 4. Tạo báo cáo (Report Generation)
- Báo cáo doanh số
- Báo cáo tồn kho
- Báo cáo khách hàng
- Xuất báo cáo (PDF, Excel)

## Công nghệ sử dụng

- **Backend**: ASP.NET Core, Entity Framework Core
- **Database**: SQL Server
- **Frontend**: HTML, CSS, JavaScript, Bootstrap
- **Authentication**: ASP.NET Identity
- **Reporting**: SSRS, Chart.js

## Hướng dẫn cài đặt

1. Clone repository:
```
git clone <repository-url>
```

2. Mở solution trong Visual Studio

3. Cập nhật connection string trong appsettings.json

4. Chạy migration để tạo database:
```
Update-Database
```

5. Build và run project

## Đối tượng người dùng

- **Admin**: Quản lý toàn bộ hệ thống
- **Staff**: Quản lý sản phẩm, xử lý đơn hàng
- **Customer**: Đăng ký, mua hàng trực tuyến

## Tài liệu thiết kế

Xem các tài liệu thiết kế chi tiết trong thư mục Documentation:

- [Sơ đồ luồng dữ liệu (DFD)](./Documentation/Core-DFD-Design.md)
- [Sơ đồ quan hệ thực thể (ERD)](./Documentation/Core-ERD-Design.md)
- [Sơ đồ luồng quy trình](./Documentation/Core-Flowcharts.md)
- [Phân tích yêu cầu](./Documentation/Core-Requirements-Analysis.md)

## Liên hệ

Để biết thêm thông tin hoặc hỗ trợ, vui lòng liên hệ: [email@example.com]
