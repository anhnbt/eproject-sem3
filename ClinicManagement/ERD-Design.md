# Entity Relationship Diagram (ERD) - Clinic Management System

## ERD Diagram

```mermaid
erDiagram
    %% User Management Entities
    USER_ROLE {
        int role_id PK
        string role_name UK "customer, staff, admin"
        string description
        datetime created_at
        datetime updated_at
    }

    USER {
        int user_id PK
        int role_id FK
        string username UK
        string email UK
        string password_hash
        string first_name
        string last_name
        string phone
        string address
        enum status "active, inactive, suspended"
        datetime created_at
        datetime updated_at
        datetime last_login
    }

    %% Product Management Entities
    CATEGORY {
        int category_id PK
        string category_name
        string description
        enum type "medicine, machine"
        datetime created_at
        datetime updated_at
    }

    MEDICINE {
        int medicine_id PK
        int category_id FK
        string medicine_name
        string description
        decimal price
        int stock_quantity
        date expiry_date
        string manufacturer
        string dosage
        string instructions
        enum status "available, out_of_stock, discontinued"
        datetime created_at
        datetime updated_at
    }

    MACHINE {
        int machine_id PK
        int category_id FK
        string machine_name
        string model
        string description
        decimal price
        int stock_quantity
        text specifications
        string manufacturer
        text technical_docs
        enum status "available, out_of_stock, discontinued"
        datetime created_at
        datetime updated_at
    }

    %% Order Management Entities
    ORDER {
        int order_id PK
        int customer_id FK
        int staff_id FK
        decimal total_amount
        enum status "pending, processing, shipped, delivered, cancelled"
        text shipping_address
        text billing_address
        datetime order_date
        datetime delivery_date
        text notes
        datetime created_at
        datetime updated_at
    }

    ORDER_ITEM {
        int order_item_id PK
        int order_id FK
        int medicine_id FK
        int machine_id FK
        int quantity
        decimal unit_price
        decimal total_price
        enum item_type "medicine, machine"
        datetime created_at
    }

    %% Payment Management Entities
    PAYMENT {
        int payment_id PK
        int order_id FK
        decimal amount
        enum payment_method "credit_card, bank_transfer, cash, digital_wallet"
        enum status "pending, completed, failed, refunded"
        string transaction_id
        text payment_details
        datetime payment_date
        datetime created_at
        datetime updated_at
    }

    %% Educational Activity Entities
    EDUCATIONAL_ACTIVITY {
        int activity_id PK
        int instructor_id FK
        int category_id FK
        string activity_name
        text description
        datetime start_date
        datetime end_date
        int max_participants
        int current_participants
        decimal price
        text prerequisites
        enum status "planned, active, completed, cancelled"
        datetime created_at
        datetime updated_at
    }

    ACTIVITY_CATEGORY {
        int activity_category_id PK
        string category_name
        string description
        datetime created_at
        datetime updated_at
    }

    LEARNING_SESSION {
        int session_id PK
        int activity_id FK
        string session_name
        text session_content
        datetime session_date
        int duration_minutes
        text learning_objectives
        enum status "scheduled, completed, cancelled"
        datetime created_at
        datetime updated_at
    }

    ACTIVITY_REGISTRATION {
        int registration_id PK
        int activity_id FK
        int customer_id FK
        datetime registration_date
        enum status "registered, attended, completed, cancelled"
        decimal paid_amount
        datetime created_at
        datetime updated_at
    }

    LEARNING_MATERIAL {
        int material_id PK
        int activity_id FK
        int session_id FK
        string material_name
        string file_path
        enum material_type "document, video, presentation, image"
        text description
        datetime uploaded_at
        datetime created_at
    }

    %% Feedback Management Entities
    FEEDBACK {
        int feedback_id PK
        int customer_id FK
        int product_id FK
        int activity_id FK
        enum feedback_type "product, service, activity, general"
        enum subject_type "medicine, machine, activity, general"
        int rating
        text feedback_text
        enum status "submitted, reviewed, responded, closed"
        datetime submitted_at
        datetime reviewed_at
        text admin_response
        datetime created_at
        datetime updated_at
    }

    %% Website Content Management Entities
    WEBSITE_CONTENT {
        int content_id PK
        string page_name
        string section_name
        text content_text
        text content_html
        enum status "draft, published, archived"
        int updated_by FK
        datetime published_at
        datetime created_at
        datetime updated_at
    }

    %% Report Management Entities
    REPORT {
        int report_id PK
        int created_by FK
        string report_name
        enum report_type "user, sales, product, activity, feedback"
        text report_parameters
        string file_path
        enum status "generating, completed, failed"
        datetime generated_at
        datetime expires_at
        datetime created_at
        datetime updated_at
    }

    %% Staff Assignment Entity
    STAFF_ASSIGNMENT {
        int assignment_id PK
        int staff_id FK
        int activity_id FK
        enum role "instructor, assistant, coordinator"        datetime assigned_date
        datetime created_at
        datetime updated_at
    }

    %% Relationships
    USER_ROLE ||--o{ USER : "has_role"
    
    USER ||--o{ ORDER : "places/processes"
    USER ||--o{ ACTIVITY_REGISTRATION : "registers"
    USER ||--o{ FEEDBACK : "submits"
    USER ||--o{ EDUCATIONAL_ACTIVITY : "instructs"
    USER ||--o{ WEBSITE_CONTENT : "updates"
    USER ||--o{ REPORT : "generates"
    USER ||--o{ STAFF_ASSIGNMENT : "assigned"

    CATEGORY ||--o{ MEDICINE : "categorizes"
    CATEGORY ||--o{ MACHINE : "categorizes"

    ORDER ||--o{ ORDER_ITEM : "contains"
    ORDER ||--o{ PAYMENT : "paid_by"

    ORDER_ITEM }o--|| MEDICINE : "includes"
    ORDER_ITEM }o--|| MACHINE : "includes"

    ACTIVITY_CATEGORY ||--o{ EDUCATIONAL_ACTIVITY : "categorizes"

    EDUCATIONAL_ACTIVITY ||--o{ LEARNING_SESSION : "includes"
    EDUCATIONAL_ACTIVITY ||--o{ ACTIVITY_REGISTRATION : "registered_for"
    EDUCATIONAL_ACTIVITY ||--o{ LEARNING_MATERIAL : "contains"
    EDUCATIONAL_ACTIVITY ||--o{ STAFF_ASSIGNMENT : "assigned_to"
    EDUCATIONAL_ACTIVITY ||--o{ FEEDBACK : "receives"

    LEARNING_SESSION ||--o{ LEARNING_MATERIAL : "uses"

    MEDICINE ||--o{ FEEDBACK : "receives"
    MACHINE ||--o{ FEEDBACK : "receives"
```

## Entity Descriptions

### Core Entities

1. **USER_ROLE**: Defines user roles (Customer, Staff, Admin) with descriptions
2. **USER**: Represents all system users with role-based access control through USER_ROLE
3. **CATEGORY**: Product categories for both medicines and machines
4. **MEDICINE**: Pharmaceutical products with detailed medical information
5. **MACHINE**: Scientific equipment with technical specifications
6. **ORDER**: Customer purchase orders with status tracking
7. **ORDER_ITEM**: Individual items within orders (medicines or machines)
8. **PAYMENT**: Payment transactions linked to orders

### Educational System Entities

9. **EDUCATIONAL_ACTIVITY**: Training courses, workshops, seminars
10. **ACTIVITY_CATEGORY**: Categories for educational activities
11. **LEARNING_SESSION**: Individual sessions within activities
12. **ACTIVITY_REGISTRATION**: Customer enrollments in activities
13. **LEARNING_MATERIAL**: Educational resources and materials
14. **STAFF_ASSIGNMENT**: Staff assignments to educational activities

### Management Entities

15. **FEEDBACK**: Customer feedback on products and services
16. **WEBSITE_CONTENT**: CMS for website content management
17. **REPORT**: System-generated business and educational reports

## Key Relationships

- **UserRole-User**: One-to-many (each role can have multiple users, each user has one role)
- **User-Order**: One-to-many (customers place multiple orders, staff process orders)
- **Order-OrderItem**: One-to-many (each order contains multiple items)
- **Product-OrderItem**: Many-to-many through OrderItem (products can be in multiple orders)
- **User-ActivityRegistration**: One-to-many (customers register for multiple activities)
- **Activity-Session**: One-to-many (activities have multiple sessions)
- **Activity-StaffAssignment**: Many-to-many (activities can have multiple staff, staff can teach multiple activities)
- **Product-Feedback**: One-to-many (products receive multiple feedback)
- **User-Feedback**: One-to-many (users can submit multiple feedback)

## Business Rules Implemented

1. **Role-based Access**: User roles are now normalized in a separate table for better data integrity
2. **Product Management**: Separate entities for medicines and machines with shared categorization
3. **Order Processing**: Complete order lifecycle from placement to delivery
4. **Educational Activities**: Full learning management with sessions, materials, and registrations
5. **Feedback System**: Comprehensive feedback collection for products and activities
6. **Content Management**: Admin control over website content
7. **Reporting**: Data-driven reports for business intelligence