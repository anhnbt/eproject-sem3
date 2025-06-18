# Core Data Flow Diagram (DFD)

## Context Diagram (DFD Level 0)
```mermaid
graph TD
        Customer[Customer] <--> System[Clinic Management System]
        Staff[Staff] <--> System
        Admin[Admin] <--> System
```

## Level 1 DFD

Each item below represents a main process in DFD Level 1 for the minimal project core functionality.

### 1. User Management (Process 1.0)
This process handles all activities related to user accounts (Customer, Staff, Admin) such as registration, login, personal information management, and authorization.

```mermaid
graph TD
    A[Customer] -->|Registration/Login/Profile Update Request| P1["1.0 User Management"]
    B[Staff] -->|Login/Profile Update Request| P1
    C[Admin] -->|Login/User Management Request| P1
    P1 -->|Confirmation/Account Info| A
    P1 -->|Confirmation/Account Info| B
    P1 -->|Confirmation/User Info| C
    P1 <-->|Read/Write User Data| DS1["User Data Store"]
```

### 2. Product Management (Medicines and Scientific Machines) (Process 2.0)
This process includes displaying product information to Customers and allowing Staff/Admin to manage categories and detailed information of medicines and scientific machines.

```mermaid
graph TD
    A[Customer] -->|View Product Request| P2["2.0 Product Management"]
    P2 -->|Product Information| A
    B["Staff/Admin"] -->|Add/Edit/Delete Product Request, Category Management| P2
    P2 -->|Confirmation| B
    P2 <-->|Read/Write Product Data| DS2["Product Data Store (Medicines, Machines)"]
```

### 3. Online Purchase Management (Process 3.0)
This process handles the entire purchasing process from Customer browsing, selecting products, placing orders, payment processing, to Staff/Admin processing the order.

```mermaid
graph TD
    A[Customer] -->|Order Placement Request, Payment Information| P3["3.0 Online Purchase Management"]
    P3 -->|Order Confirmation, Invoice| A
    B["Staff/Admin"] -->|Order Processing Request| P3
    P3 -->|Order Information| B
    P3 <-->|Read/Write Order Data| DS3["Order Data Store"]
    P3 <-->|Read/Write Payment Data| DS4["Payment Data Store"]
    P3 -->|Check Stock| DS2["Product Data Store (Medicines, Machines)"]
```

### 4. Report Generation (Process 7.0)
This process allows Admin or Staff to request and view summary reports on business performance based on data from relevant Data Stores.

```mermaid
graph TD
    B["Admin/Staff"] -->|Report Request| P7["7.0 Report Generation"]
    P7 -->|Report Data| B
    P7 -->|Read Data| DS2
    P7 -->|Read Data| DS3
    P7 -->|Read Data| DS4
```

## Level 2 DFD for Core Functionality

### 1.1 User Management - Admin User Management (Process 1.1)

This diagram shows how Admin manages user accounts with full administrative privileges including creating, modifying, and managing all user types.

```mermaid
graph TD
    Admin[Admin] -->|View All Users Request| P1_1["1.1 View All Users"]
    Admin -->|Search Users Request| P1_2["1.2 Search Users"]
    Admin -->|Manage User Roles Request| P1_3["1.3 Manage User Roles"]
    
    P1_1 -->|All Users List| Admin
    P1_2 -->|User Search Results| Admin
    P1_3 -->|Role Management Confirmation| Admin

    P1_1 -->|Read User Data| DS1["User Data Store"]
    P1_2 -->|Read User Data| DS1
    P1_3 <-->|Read/Write User Role Data| DS1
```

### 1.2 User Management - Staff User Management (Process 1.2)

This diagram shows how Staff manages limited user account functions, primarily for customer support and basic user assistance.

```mermaid
graph TD
    Staff[Staff] -->|View Staff Profile Request| P1_4["1.4 View Own Profile"]
    Staff -->|Edit Staff Profile Request| P1_5["1.5 Edit Own Profile"]
    
    P1_4 -->|Own Profile Data| Staff
    P1_5 -->|Own Profile Updated Confirmation| Staff
    
    P1_4 -->|Read Own Profile Data| DS1
    P1_5 <-->|Read/Write Own Profile Data| DS1
```

### 1.3 User Management - Customer Self-Management (Process 1.3)

This diagram shows how Customers manage their own accounts including registration, profile updates, and account settings.

```mermaid
graph TD
    Customer[Customer] -->|User Registration Request| P1_6["1.6 User Registration"]
    Customer -->|Login Request| P1_7["1.7 User Login"]
    Customer -->|View Own Profile Request| P1_8["1.8 View Own Profile"]
    Customer -->|Edit Own Profile Request| P1_9["1.9 Edit Own Profile"]
    Customer -->|Change Password Request| P1_10["1.10 Change Password"]
    Customer -->|Forgot Password Request| P1_11["1.11 Forgot Password"]
    
    P1_6 -->|Registration Confirmation| Customer
    P1_7 -->|Login Success/Failure| Customer
    P1_8 -->|Own Profile Data| Customer
    P1_9 -->|Profile Updated Confirmation| Customer
    P1_10 -->|Password Changed Confirmation| Customer
    P1_11 -->|Password Reset Instructions| Customer
    
    P1_6 -->|Write New User Data| DS1["User Data Store"]
    P1_7 -->|Read User Credentials| DS1
    P1_8 -->|Read Own Profile Data| DS1
    P1_9 <-->|Read/Write Own Profile Data| DS1
    P1_10 <-->|Read/Write Own Password| DS1
    P1_11 <-->|Read/Write Password Reset Token| DS1
```

### 2.1 Product Management - Medicine Management (Process 2.1)

This diagram details how Staff manages medicine information within the Product Management system.

```mermaid
graph TD
    Staff[Staff] -->|Add Medicine Request| P2_1["2.1 Add Medicine"]
    Staff -->|Edit Medicine Request| P2_2["2.2 Edit Medicine"]
    Staff -->|Delete Medicine Request| P2_3["2.3 Delete Medicine"]
    Staff -->|View Medicine List Request| P2_4["2.4 View Medicine List"]
    Staff -->|Search Medicine Request| P2_5["2.5 Search Medicine"]
    
    P2_1 -->|Medicine Added Confirmation| Staff
    P2_2 -->|Medicine Updated Confirmation| Staff
    P2_3 -->|Medicine Deleted Confirmation| Staff
    P2_4 -->|Medicine List Data| Staff
    P2_5 -->|Search Results| Staff
    
    P2_1 -->|Write New Medicine Data| DS2_Med["Product Data Store (Medicines)"]
    P2_2 <-->|Read/Write Medicine Data| DS2_Med
    P2_3 -->|Delete Medicine Data| DS2_Med
    P2_4 -->|Read Medicine Data| DS2_Med
    P2_5 -->|Read Medicine Data| DS2_Med
```

### 3.1 Online Purchase Management - Admin Purchase Management (Process 3.1)

This diagram shows how Admin manages the entire purchase process with full administrative control over orders, payments, and system configuration.

```mermaid
graph TD
    Admin[Admin] -->|View All Orders Request| P3_1["3.1 View All Orders"]
    Admin -->|Cancel Order Request| P3_3["3.3 Cancel Order"]
    Admin -->|Process Refund Request| P3_4["3.4 Process Refund"]
    Admin -->|Manage Payment Methods Request| P3_6["3.6 Manage Payment Methods"]
    
    P3_1 -->|All Orders List| Admin
    P3_3 -->|Order Cancelled Confirmation| Admin
    P3_4 -->|Refund Processed Confirmation| Admin
    P3_6 -->|Payment Configuration Confirmation| Admin
    
    P3_1 -->|Read Order Data| DS3["Order Data Store"]
    P3_3 <-->|Read/Write Order Status| DS3
    P3_4 <-->|Read/Write Payment Data| DS4["Payment Data Store"]
    P3_6 <-->|Read/Write Payment Config| DS4
```

### 7.1 Report Generation - Admin/Staff Report Management (Process 7.1)

```mermaid
graph TD
    AdminStaff["Admin/Staff"] -->|Generate Sales Report Request| P7_1["7.1 Generate Sales Report"]
    AdminStaff -->|Generate Inventory Report Request| P7_2["7.2 Generate Inventory Report"]
    AdminStaff -->|Generate Customer Report Request| P7_3["7.3 Generate Customer Report"]
    AdminStaff -->|Export Report Request| P7_4["7.4 Export Report"]
    
    P7_1 -->|Sales Report Data| AdminStaff
    P7_2 -->|Inventory Report Data| AdminStaff
    P7_3 -->|Customer Report Data| AdminStaff
    P7_4 -->|Exported Report File| AdminStaff
    
    P7_1 -->|Read Order/Payment Data| DS3["Order Data Store"]
    P7_1 -->|Read Payment Data| DS4["Payment Data Store"]
    P7_2 -->|Read Product Data| DS2["Product Data Store"]
    P7_3 -->|Read Customer/Order Data| DS1["User Data Store"]
    P7_3 -->|Read Order Data| DS3
```

**Process Descriptions:**

- **7.1 Generate Sales Report**: Admin/Staff can create sales reports with filters for date ranges, product categories, payment methods, and sales channels.
- **7.2 Generate Inventory Report**: Admin/Staff can generate inventory status reports showing stock levels, product movement, low stock alerts, and valuation.
- **7.3 Generate Customer Report**: Admin/Staff can create customer analytics reports with purchasing patterns, demographics, and customer value metrics.
- **7.4 Export Report**: Admin/Staff can export any generated report to various formats (PDF, Excel, CSV) for sharing or archiving.
