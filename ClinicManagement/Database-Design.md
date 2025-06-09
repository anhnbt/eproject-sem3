# Thiết kế cơ sở dữ liệu - Clinic Management System

## Sơ đồ ERD

```
[Users] 1---* [UserRoles] *---1 [Roles]
   |
   |----1---* [Appointments]
   |             |
   |             *
   |         [AppointmentServices]
   |             *
   |             |
[Doctors] *-----* [Specializations]
   |
   *
[DoctorSchedules]
   
[Patients] 1---* [PatientRecords]
   |          |
   |          *
   |      [Prescriptions] *---* [Medicines]
   |          |
   |          *
   *      [PrescriptionItems]
[Appointments]
   |
   *
[Payments] *---1 [PaymentMethods]
   |
   *
[Invoices] 1---* [InvoiceItems]
```

## Các bảng dữ liệu

### 1. Users
```sql
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(255),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
```

### 2. Roles
```sql
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255)
);
```

### 3. UserRoles
```sql
CREATE TABLE UserRoles (
    UserRoleId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    UNIQUE (UserId, RoleId)
);
```

### 4. Doctors
```sql
CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    LicenseNumber NVARCHAR(50) NOT NULL UNIQUE,
    Experience INT,
    Biography NVARCHAR(MAX),
    EducationBackground NVARCHAR(MAX),
    IsAvailable BIT DEFAULT 1,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
```

### 5. Specializations
```sql
CREATE TABLE Specializations (
    SpecializationId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(MAX)
);
```

### 6. DoctorSpecializations
```sql
CREATE TABLE DoctorSpecializations (
    DoctorSpecializationId INT PRIMARY KEY IDENTITY,
    DoctorId INT NOT NULL,
    SpecializationId INT NOT NULL,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (SpecializationId) REFERENCES Specializations(SpecializationId),
    UNIQUE (DoctorId, SpecializationId)
);
```

### 7. DoctorSchedules
```sql
CREATE TABLE DoctorSchedules (
    ScheduleId INT PRIMARY KEY IDENTITY,
    DoctorId INT NOT NULL,
    DayOfWeek INT NOT NULL, -- 0 = Sunday, 1 = Monday, etc.
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    UNIQUE (DoctorId, DayOfWeek, StartTime)
);
```

### 8. Patients
```sql
CREATE TABLE Patients (
    PatientId INT PRIMARY KEY IDENTITY,
    UserId INT,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    BloodType NVARCHAR(5),
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100),
    Address NVARCHAR(255),
    EmergencyContactName NVARCHAR(100),
    EmergencyContactPhone NVARCHAR(20),
    MedicalInsuranceNumber NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
```

### 9. PatientRecords
```sql
CREATE TABLE PatientRecords (
    RecordId INT PRIMARY KEY IDENTITY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    RecordDate DATETIME NOT NULL DEFAULT GETDATE(),
    Symptoms NVARCHAR(MAX),
    Diagnosis NVARCHAR(MAX),
    Notes NVARCHAR(MAX),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);
```

### 10. Appointments
```sql
CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    ScheduledDate DATE NOT NULL,
    ScheduledTime TIME NOT NULL,
    Duration INT DEFAULT 30, -- in minutes
    Status NVARCHAR(20) DEFAULT 'Scheduled', -- Scheduled, Completed, Cancelled, No-Show
    Notes NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);
```

### 11. Services
```sql
CREATE TABLE Services (
    ServiceId INT PRIMARY KEY IDENTITY,
    ServiceName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(MAX),
    Cost DECIMAL(10, 2) NOT NULL,
    Duration INT, -- in minutes
    IsActive BIT DEFAULT 1
);
```

### 12. AppointmentServices
```sql
CREATE TABLE AppointmentServices (
    AppointmentServiceId INT PRIMARY KEY IDENTITY,
    AppointmentId INT NOT NULL,
    ServiceId INT NOT NULL,
    Quantity INT DEFAULT 1,
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId),
    FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId)
);
```

### 13. Medicines
```sql
CREATE TABLE Medicines (
    MedicineId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Manufacturer NVARCHAR(100),
    UnitPrice DECIMAL(10, 2) NOT NULL,
    StockQuantity INT DEFAULT 0,
    ReorderLevel INT DEFAULT 10,
    DosageForm NVARCHAR(50), -- Tablet, Liquid, Capsule, etc.
    Strength NVARCHAR(50),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
```

### 14. Prescriptions
```sql
CREATE TABLE Prescriptions (
    PrescriptionId INT PRIMARY KEY IDENTITY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    RecordId INT,
    PrescriptionDate DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(MAX),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (RecordId) REFERENCES PatientRecords(RecordId)
);
```

### 15. PrescriptionItems
```sql
CREATE TABLE PrescriptionItems (
    PrescriptionItemId INT PRIMARY KEY IDENTITY,
    PrescriptionId INT NOT NULL,
    MedicineId INT NOT NULL,
    Dosage NVARCHAR(50),
    Frequency NVARCHAR(50),
    Duration INT, -- in days
    Quantity INT NOT NULL,
    Instructions NVARCHAR(MAX),
    FOREIGN KEY (PrescriptionId) REFERENCES Prescriptions(PrescriptionId),
    FOREIGN KEY (MedicineId) REFERENCES Medicines(MedicineId)
);
```

### 16. PaymentMethods
```sql
CREATE TABLE PaymentMethods (
    PaymentMethodId INT PRIMARY KEY IDENTITY,
    MethodName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255)
);
```

### 17. Payments
```sql
CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY,
    AppointmentId INT,
    PatientId INT NOT NULL,
    PaymentMethodId INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    PaymentStatus NVARCHAR(20) DEFAULT 'Pending', -- Pending, Completed, Failed, Refunded
    TransactionReference NVARCHAR(100),
    Notes NVARCHAR(MAX),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethods(PaymentMethodId)
);
```

### 18. Invoices
```sql
CREATE TABLE Invoices (
    InvoiceId INT PRIMARY KEY IDENTITY,
    PaymentId INT NOT NULL,
    InvoiceNumber NVARCHAR(20) NOT NULL UNIQUE,
    IssuedDate DATETIME DEFAULT GETDATE(),
    DueDate DATETIME,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    TaxAmount DECIMAL(10, 2) DEFAULT 0,
    DiscountAmount DECIMAL(10, 2) DEFAULT 0,
    Notes NVARCHAR(MAX),
    FOREIGN KEY (PaymentId) REFERENCES Payments(PaymentId)
);
```

### 19. InvoiceItems
```sql
CREATE TABLE InvoiceItems (
    InvoiceItemId INT PRIMARY KEY IDENTITY,
    InvoiceId INT NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (InvoiceId) REFERENCES Invoices(InvoiceId)
);
```

## Initial Data Setup

```sql
-- Insert default roles
INSERT INTO Roles (RoleName, Description) VALUES
('Admin', 'System administrator with full access'),
('Doctor', 'Medical staff with patient care access'),
('Nurse', 'Medical support staff'),
('Receptionist', 'Front desk staff'),
('Patient', 'Patient user account');

-- Insert default payment methods
INSERT INTO PaymentMethods (MethodName, Description) VALUES
('Cash', 'Cash payment'),
('Credit Card', 'Credit card payment'),
('Debit Card', 'Debit card payment'),
('Insurance', 'Payment via insurance'),
('Mobile Payment', 'Payment via mobile apps');

-- Insert common specializations
INSERT INTO Specializations (Name, Description) VALUES
('General Medicine', 'Primary health care'),
('Pediatrics', 'Child health care'),
('Cardiology', 'Heart related treatment'),
('Dermatology', 'Skin related treatment'),
('Neurology', 'Nervous system related treatment'),
('Ophthalmology', 'Eye related treatment'),
('Orthopedics', 'Bone and joint related treatment'),
('Gynecology', 'Women health care'),
('Psychiatry', 'Mental health care'),
('Dentistry', 'Dental care');

-- Insert common services
INSERT INTO Services (ServiceName, Description, Cost, Duration, IsActive) VALUES
('General Consultation', 'Basic doctor consultation', 50.00, 30, 1),
('Specialist Consultation', 'Specialist doctor consultation', 100.00, 45, 1),
('Blood Test', 'Basic blood analysis', 30.00, 15, 1),
('X-Ray', 'Radiological examination', 80.00, 20, 1),
('Ultrasound', 'Ultrasound examination', 120.00, 30, 1),
('ECG', 'Electrocardiogram', 70.00, 15, 1),
('Vaccination', 'Immunization services', 40.00, 10, 1),
('Physical Therapy', 'Rehabilitation services', 90.00, 60, 1),
('Dental Cleaning', 'Basic dental hygiene', 60.00, 45, 1),
('Mental Health Assessment', 'Psychological evaluation', 110.00, 60, 1);
```

## Stored Procedures

### 1. GetDoctorAvailability
```sql
CREATE PROCEDURE GetDoctorAvailability
    @DoctorId INT,
    @Date DATE
AS
BEGIN
    DECLARE @DayOfWeek INT = DATEPART(WEEKDAY, @Date) - 1; -- SQL Server weekday starts from 1 (Sunday)
    
    SELECT 
        ds.StartTime, 
        ds.EndTime
    FROM 
        DoctorSchedules ds
    WHERE 
        ds.DoctorId = @DoctorId 
        AND ds.DayOfWeek = @DayOfWeek
        AND ds.IsActive = 1
    
    EXCEPT
    
    SELECT 
        a.ScheduledTime AS StartTime, 
        DATEADD(MINUTE, a.Duration, a.ScheduledTime) AS EndTime
    FROM 
        Appointments a
    WHERE 
        a.DoctorId = @DoctorId 
        AND a.ScheduledDate = @Date
        AND a.Status != 'Cancelled';
END
```

### 2. CreateAppointment
```sql
CREATE PROCEDURE CreateAppointment
    @PatientId INT,
    @DoctorId INT,
    @ScheduledDate DATE,
    @ScheduledTime TIME,
    @Duration INT,
    @Notes NVARCHAR(MAX) = NULL,
    @ServiceIds NVARCHAR(MAX) = NULL
AS
BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Check if doctor is available
        DECLARE @DayOfWeek INT = DATEPART(WEEKDAY, @ScheduledDate) - 1;
        DECLARE @EndTime TIME = DATEADD(MINUTE, @Duration, @ScheduledTime);
        
        DECLARE @IsAvailable BIT = 0;
        
        SELECT @IsAvailable = 1
        FROM DoctorSchedules ds
        WHERE ds.DoctorId = @DoctorId
            AND ds.DayOfWeek = @DayOfWeek
            AND ds.StartTime <= @ScheduledTime
            AND ds.EndTime >= @EndTime
            AND ds.IsActive = 1
            AND NOT EXISTS (
                SELECT 1
                FROM Appointments a
                WHERE a.DoctorId = @DoctorId
                    AND a.ScheduledDate = @ScheduledDate
                    AND a.Status != 'Cancelled'
                    AND (
                        (a.ScheduledTime <= @ScheduledTime AND DATEADD(MINUTE, a.Duration, a.ScheduledTime) > @ScheduledTime)
                        OR
                        (a.ScheduledTime < @EndTime AND DATEADD(MINUTE, a.Duration, a.ScheduledTime) >= @EndTime)
                        OR
                        (a.ScheduledTime >= @ScheduledTime AND DATEADD(MINUTE, a.Duration, a.ScheduledTime) <= @EndTime)
                    )
            );
            
        IF @IsAvailable = 0
        BEGIN
            RAISERROR('Doctor is not available at the specified time', 16, 1);
            RETURN;
        END
        
        -- Create appointment
        DECLARE @AppointmentId INT;
        
        INSERT INTO Appointments (PatientId, DoctorId, ScheduledDate, ScheduledTime, Duration, Notes)
        VALUES (@PatientId, @DoctorId, @ScheduledDate, @ScheduledTime, @Duration, @Notes);
        
        SET @AppointmentId = SCOPE_IDENTITY();
        
        -- Add services if provided
        IF @ServiceIds IS NOT NULL AND LEN(@ServiceIds) > 0
        BEGIN
            DECLARE @ServiceId INT;
            DECLARE @Pos INT;
            
            WHILE LEN(@ServiceIds) > 0
            BEGIN
                SET @Pos = CHARINDEX(',', @ServiceIds);
                IF @Pos = 0
                BEGIN
                    SET @ServiceId = CAST(@ServiceIds AS INT);
                    SET @ServiceIds = '';
                END
                ELSE
                BEGIN
                    SET @ServiceId = CAST(SUBSTRING(@ServiceIds, 1, @Pos - 1) AS INT);
                    SET @ServiceIds = SUBSTRING(@ServiceIds, @Pos + 1, LEN(@ServiceIds) - @Pos);
                END
                
                INSERT INTO AppointmentServices (AppointmentId, ServiceId)
                VALUES (@AppointmentId, @ServiceId);
            END
        END
        
        COMMIT TRANSACTION;
        SELECT @AppointmentId AS AppointmentId;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
```

### 3. GetPatientMedicalHistory
```sql
CREATE PROCEDURE GetPatientMedicalHistory
    @PatientId INT
AS
BEGIN
    -- Return patient records
    SELECT 
        pr.RecordId,
        pr.RecordDate,
        CONCAT(u.FirstName, ' ', u.LastName) AS DoctorName,
        pr.Symptoms,
        pr.Diagnosis,
        pr.Notes
    FROM 
        PatientRecords pr
    INNER JOIN 
        Doctors d ON pr.DoctorId = d.DoctorId
    INNER JOIN 
        Users u ON d.UserId = u.UserId
    WHERE 
        pr.PatientId = @PatientId
    ORDER BY 
        pr.RecordDate DESC;
    
    -- Return prescriptions
    SELECT 
        p.PrescriptionId,
        p.PrescriptionDate,
        CONCAT(u.FirstName, ' ', u.LastName) AS DoctorName,
        m.Name AS MedicineName,
        pi.Dosage,
        pi.Frequency,
        pi.Duration,
        pi.Quantity,
        pi.Instructions
    FROM 
        Prescriptions p
    INNER JOIN 
        Doctors d ON p.DoctorId = d.DoctorId
    INNER JOIN 
        Users u ON d.UserId = u.UserId
    INNER JOIN 
        PrescriptionItems pi ON p.PrescriptionId = pi.PrescriptionId
    INNER JOIN 
        Medicines m ON pi.MedicineId = m.MedicineId
    WHERE 
        p.PatientId = @PatientId
    ORDER BY 
        p.PrescriptionDate DESC;
    
    -- Return appointments
    SELECT 
        a.AppointmentId,
        a.ScheduledDate,
        a.ScheduledTime,
        CONCAT(u.FirstName, ' ', u.LastName) AS DoctorName,
        s.Name AS SpecializationName,
        a.Status,
        a.Notes
    FROM 
        Appointments a
    INNER JOIN 
        Doctors d ON a.DoctorId = d.DoctorId
    INNER JOIN 
        Users u ON d.UserId = u.UserId
    INNER JOIN 
        DoctorSpecializations ds ON d.DoctorId = ds.DoctorId
    INNER JOIN 
        Specializations s ON ds.SpecializationId = s.SpecializationId
    WHERE 
        a.PatientId = @PatientId
    ORDER BY 
        a.ScheduledDate DESC, a.ScheduledTime DESC;
    
    -- Return payments
    SELECT 
        p.PaymentId,
        p.PaymentDate,
        p.Amount,
        pm.MethodName AS PaymentMethod,
        p.PaymentStatus,
        ISNULL(i.InvoiceNumber, 'N/A') AS InvoiceNumber
    FROM 
        Payments p
    INNER JOIN 
        PaymentMethods pm ON p.PaymentMethodId = pm.PaymentMethodId
    LEFT JOIN 
        Invoices i ON p.PaymentId = i.PaymentId
    WHERE 
        p.PatientId = @PatientId
    ORDER BY 
        p.PaymentDate DESC;
END
```

## Indexes

```sql
-- Optimize user lookups
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Users_PhoneNumber ON Users(PhoneNumber);

-- Optimize appointment searches
CREATE INDEX IX_Appointments_PatientId ON Appointments(PatientId);
CREATE INDEX IX_Appointments_DoctorId ON Appointments(DoctorId);
CREATE INDEX IX_Appointments_ScheduledDate ON Appointments(ScheduledDate);
CREATE INDEX IX_Appointments_Status ON Appointments(Status);

-- Optimize patient searches
CREATE INDEX IX_Patients_UserId ON Patients(UserId);
CREATE INDEX IX_Patients_PhoneNumber ON Patients(PhoneNumber);
CREATE INDEX IX_Patients_Email ON Patients(Email);
CREATE INDEX IX_Patients_MedicalInsuranceNumber ON Patients(MedicalInsuranceNumber);

-- Optimize medicine searches
CREATE INDEX IX_Medicines_Name ON Medicines(Name);
CREATE INDEX IX_Medicines_IsActive ON Medicines(IsActive);

-- Optimize payment searches
CREATE INDEX IX_Payments_AppointmentId ON Payments(AppointmentId);
CREATE INDEX IX_Payments_PatientId ON Payments(PatientId);
CREATE INDEX IX_Payments_PaymentStatus ON Payments(PaymentStatus);

-- Optimize invoice searches
CREATE INDEX IX_Invoices_PaymentId ON Invoices(PaymentId);
CREATE INDEX IX_Invoices_InvoiceNumber ON Invoices(InvoiceNumber);
```
