# Cấu trúc dự án Clinic Management System

## Tổng quan

Dự án Clinic Management System được xây dựng trên nền tảng C# .NET Core MVC 6.0 với cơ sở dữ liệu SQL Server, nhằm phát triển một hệ thống quản lý phòng khám toàn diện và hiệu quả.

## Kiến trúc phần mềm

Kiến trúc của dự án tuân theo mô hình N-layer với các layer chính:

1. **Presentation Layer:** .NET Core MVC controllers và views
2. **Business Logic Layer:** Services và business logic
3. **Data Access Layer:** Repositories và database context
4. **Domain Layer:** Entities và domain models

## Cấu trúc thư mục

```
ClinicManagement/
├── ClinicManagement.Web/                # MVC Web Application
│   ├── Controllers/                     # MVC Controllers
│   ├── Views/                           # Razor Views
│   │   ├── Home/                        # Home views
│   │   ├── Account/                     # Authentication views
│   │   ├── Patients/                    # Patient management views
│   │   ├── Doctors/                     # Doctor management views
│   │   ├── Appointments/                # Appointment management views
│   │   ├── Medicines/                   # Medicine management views
│   │   ├── Invoices/                    # Invoice management views
│   │   ├── Reports/                     # Reports views
│   │   └── Shared/                      # Shared views and layouts
│   ├── wwwroot/                         # Static assets
│   │   ├── css/                         # CSS files
│   │   ├── js/                          # JavaScript files
│   │   ├── lib/                         # Client-side libraries
│   │   └── images/                      # Image files
│   ├── Areas/                           # Feature areas
│   │   ├── Admin/                       # Admin area
│   │   └── Patient/                     # Patient portal area
│   ├── Models/                          # View models
│   ├── Middleware/                      # Custom middleware
│   ├── Extensions/                      # Extension methods
│   ├── Filters/                         # MVC filters
│   ├── TagHelpers/                      # Custom tag helpers
│   ├── ViewComponents/                  # View components
│   ├── Program.cs                       # Application entry point
│   └── appsettings.json                 # Application settings
│
├── ClinicManagement.Core/               # Business Logic Layer
│   ├── Domain/                          # Domain models
│   │   ├── Entities/                    # Entity classes
│   │   ├── Enums/                       # Enumeration types
│   │   └── ValueObjects/                # Value objects
│   ├── Interfaces/                      # Interfaces
│   │   ├── Repositories/                # Repository interfaces
│   │   └── Services/                    # Service interfaces
│   ├── Services/                        # Service implementations
│   │   ├── AppointmentService.cs
│   │   ├── PatientService.cs
│   │   ├── DoctorService.cs
│   │   ├── MedicineService.cs
│   │   ├── InvoiceService.cs
│   │   └── ...
│   ├── DTOs/                            # Data Transfer Objects
│   └── Extensions/                      # Extension methods
│
├── ClinicManagement.Infrastructure/     # Data Access Layer
│   ├── Data/                            # Database context and configuration
│   │   ├── ApplicationDbContext.cs
│   │   └── Configurations/              # Entity configurations
│   ├── Repositories/                    # Repository implementations
│   │   ├── AppointmentRepository.cs
│   │   ├── PatientRepository.cs
│   │   ├── DoctorRepository.cs
│   │   ├── MedicineRepository.cs
│   │   ├── InvoiceRepository.cs
│   │   └── ...
│   ├── Services/                        # Infrastructure services
│   │   ├── EmailService.cs
│   │   ├── SmsService.cs
│   │   └── FileStorageService.cs
│   └── Migrations/                      # EF Core migrations
│
├── ClinicManagement.Tests/              # Test projects
│   ├── UnitTests/                       # Unit tests
│   │   ├── Services/                    # Services tests
│   │   ├── Controllers/                 # Controllers tests
│   │   └── Repositories/                # Repositories tests
│   └── IntegrationTests/                # Integration tests
│
└── Database/                            # SQL scripts
    ├── Schema/                          # Schema creation scripts
    ├── StoredProcedures/                # Stored procedures
    ├── Functions/                       # SQL functions
    └── SeedData/                        # Initial data scripts
```

## Kiến trúc ứng dụng

Ứng dụng sử dụng các pattern và principles phổ biến như:

- **Repository Pattern:** Để trừu tượng hóa và đóng gói logic truy cập dữ liệu.
- **Dependency Injection:** Để quản lý dependencies và tăng tính kiểm thử của ứng dụng.
- **Unit of Work:** Để duy trì tính nhất quán của dữ liệu và quản lý transactions.
- **MVC Pattern:** Model-View-Controller cho phần frontend.
- **SOLID Principles:** Tuân thủ các nguyên tắc thiết kế hướng đối tượng.
- **DTOs (Data Transfer Objects):** Để tách biệt domain models với presentation layer.

## Các công nghệ và thư viện sử dụng

### Backend
- **ASP.NET Core MVC 6.0:** Framework phát triển web app
- **Entity Framework Core:** ORM để tương tác với cơ sở dữ liệu
- **ASP.NET Core Identity:** Xác thực và phân quyền
- **AutoMapper:** Để mapping giữa các đối tượng
- **FluentValidation:** Validation các đối tượng
- **Serilog:** Logging framework
- **MediatR:** Để triển khai CQRS pattern
- **Swagger/OpenAPI:** API documentation

### Frontend
- **Bootstrap 5:** Framework CSS
- **jQuery:** JavaScript library
- **DataTables:** Advanced table controls
- **Chart.js:** Data visualization
- **Select2:** Enhanced select boxes
- **DatePicker:** Date selection widget
- **Toastr:** Notifications
- **SweetAlert2:** Alerts and dialogs

### Testing
- **xUnit:** Unit testing framework
- **Moq:** Mocking framework
- **FluentAssertions:** Assertions
- **TestContainers:** Integration testing

## Model Classes

### Domain Entities

#### User
```csharp
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation properties
    public ICollection<UserRole> UserRoles { get; set; }
    public Doctor Doctor { get; set; }
}
```

#### Doctor
```csharp
public class Doctor
{
    public int DoctorId { get; set; }
    public int UserId { get; set; }
    public string LicenseNumber { get; set; }
    public int? Experience { get; set; }
    public string Biography { get; set; }
    public string EducationBackground { get; set; }
    public bool IsAvailable { get; set; }
    
    // Navigation properties
    public User User { get; set; }
    public ICollection<DoctorSpecialization> Specializations { get; set; }
    public ICollection<DoctorSchedule> Schedules { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<PatientRecord> PatientRecords { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
}
```

#### Patient
```csharp
public class Patient
{
    public int PatientId { get; set; }
    public int? UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string BloodType { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string EmergencyContactName { get; set; }
    public string EmergencyContactPhone { get; set; }
    public string MedicalInsuranceNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation properties
    public User User { get; set; }
    public ICollection<PatientRecord> PatientRecords { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
```

#### Appointment
```csharp
public class Appointment
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public TimeSpan ScheduledTime { get; set; }
    public int Duration { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation properties
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public ICollection<AppointmentService> Services { get; set; }
    public Payment Payment { get; set; }
}
```

## Controller Structure

Các controllers của ứng dụng sẽ được tổ chức theo các chức năng chính:

### HomeController
- Index
- About
- Contact
- Privacy

### AccountController
- Login
- Register
- ForgotPassword
- ResetPassword
- ChangePassword
- Profile
- Logout

### PatientsController
- Index (List)
- Details
- Create
- Edit
- Delete
- MedicalHistory

### DoctorsController
- Index (List)
- Details
- Create
- Edit
- Delete
- Schedule

### AppointmentsController
- Index (List)
- Details
- Create
- Edit
- Cancel
- Complete
- Calendar

### MedicinesController
- Index (List)
- Details
- Create
- Edit
- Delete
- Stock

### PrescriptionsController
- Index (List)
- Details
- Create
- Edit
- Print

### InvoicesController
- Index (List)
- Details
- Create
- Edit
- Print

### PaymentsController
- Index (List)
- Details
- Process
- Refund

### ReportsController
- DailyAppointments
- MonthlyRevenue
- PatientStatistics
- DoctorPerformance
- MedicineUsage

## Deployment

Dự án có thể được triển khai với các tùy chọn sau:

1. **Azure App Service:** Host trên đám mây Microsoft Azure
2. **IIS Server:** Host trên máy chủ Windows Server với IIS
3. **Docker Containers:** Đóng gói và triển khai dưới dạng containers
4. **AWS Elastic Beanstalk:** Triển khai trên đám mây Amazon Web Services

## CI/CD

Quy trình CI/CD có thể được thiết lập sử dụng:

1. **Azure DevOps:** Build và deploy tự động
2. **GitHub Actions:** Tự động hóa quy trình phát triển
3. **Jenkins:** Continuous Integration server
