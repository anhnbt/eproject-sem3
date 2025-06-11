# Data Flow Diagram (DFD)

## Context Diagram (DFD Level 0)
```mermaid
graph TD
        Customer[Customer] <--> System[Clinic Management System]
        Staff[Staff] <--> System
        Admin[Admin] <--> System
```

## Level 1 DFD

Each item below represents a main process in DFD Level 1. More detailed sub-processes and their specific interactions with Data Stores will be described in DFD Level 2.

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

### 4. Educational Activity Management (Process 4.0)
This process allows Customers to view and register for educational activities. Staff (Lecturers) can create and update content and schedules. Admin manages these activities overall.

```mermaid
graph TD
    A[Customer] -->|View/Register Activity Request| P4["4.0 Educational Activity Management"]
    P4 -->|Activity Information, Registration Confirmation| A
    B["Staff (Lecturer)"] -->|Create/Update Activity Request, Materials| P4
    P4 -->|Confirmation| B
    C[Admin] -->|Overall Activity Management Request| P4
    P4 <-->|Read/Write Educational Activity Data| DS5["Educational Activity Data Store"]
```

### 5. Website Content Management (Process 5.0)
This process allows Admin to update static website content such as the homepage, about us, and contact information. The system will display this content to Customers.

```mermaid
graph TD
    C[Admin] -->|Content Update Request| P5["5.0 Website Content Management"]
    P5 <-->|Read/Write Website Content| DS6["Website Content Data Store"]
    A[Customer] -->|Access Website| P5_View(View Content)
    DS6 --> P5_View
```
*(Note: Customer viewing content is often an implicit query. DFDs focus on data flows initiated by users or explicitly processed by the system. Here, Admin updates the Data Store, and Customers will read from it via page requests.)*

### 6. Customer Feedback Management (Process 6.0)
This process allows Customers to submit feedback on products and services. Staff or Admin can view and process this feedback.

```mermaid
graph TD
    A[Customer] -->|Submit Feedback| P6["6.0 Customer Feedback Management"]
    P6 <-->|Read/Write Feedback| DS7["Feedback Data Store"]
    B["Staff/Admin"] -->|View Feedback Request| P6
    P6 -->|Feedback Information| B
```

### 7. Report Generation (Process 7.0)
This process allows Admin or Staff to request and view summary reports on business performance and educational activity effectiveness, based on data from relevant Data Stores.

```mermaid
graph TD
    B["Admin/Staff"] -->|Report Request| P7["7.0 Report Generation"]
    P7 -->|Report Data| B
    P7 -->|Read Data| DS2
    P7 -->|Read Data| DS3
    P7 -->|Read Data| DS4
    P7 -->|Read Data| DS5
```
