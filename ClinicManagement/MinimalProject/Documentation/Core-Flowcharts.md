# Flowcharts - Core Process Flows

## 1. User Management Process

```mermaid
flowchart TD
    Start([Start]) --> EnterUserInfo[Enter User Information]
    EnterUserInfo --> ValidateInfo[Validate User Information]
    ValidateInfo --> IsValid{Information Valid?}
    IsValid -->|Yes| SaveInfo[Save Information to Database]
    IsValid -->|No| End([End])
    SaveInfo --> SendConfirmation[Send Confirmation to User]
    SendConfirmation --> End
```

## 1A. Login Process

```mermaid
flowchart TD
    Start([Start]) --> EnterCredentials[Enter Email and Password]
    EnterCredentials --> VerifyCredentials[Verify Credentials]
    VerifyCredentials --> IsValid{Credentials Valid?}
    IsValid -->|Yes| CreateSession[Create Session & Generate Auth Token]
    IsValid -->|No| DisplayError[Display Error Message]
    CreateSession --> RedirectToDashboard[Redirect to Dashboard]
    DisplayError --> ReturnToLogin[Return to Login Form]
```

## 2. Product Management Process

```mermaid
flowchart TD
    Start([Start]) --> SelectProductType[Select Product Type\n(Medicine/Equipment)]
    SelectProductType --> EnterDetails[Enter Product Details]
    EnterDetails --> IsValid{Information Valid?}
    IsValid -->|Yes| SaveProduct[Save Product to Database]
    IsValid -->|No| End([End])
    SaveProduct --> UpdateCatalog[Update Product Catalog]
    UpdateCatalog --> End
```

## 3. Online Purchase Management Process

```mermaid
flowchart TD
    Start([Start]) --> SelectProducts[Customer Selects Products]
    SelectProducts --> AddToCart[Add to Cart]
    AddToCart --> CheckInventory[Check Inventory]
    CheckInventory --> ReviewCart[Review Cart & Proceed to Checkout]
    ReviewCart --> EnterShipping[Enter Shipping Information]
    EnterShipping --> SelectPayment[Select Payment Method]
    SelectPayment --> ConfirmPayment[Confirm Payment]
    ConfirmPayment --> SaveOrder[Save Order to Database]
    SaveOrder --> SendEmail[Send Confirmation Email]
    SendEmail --> End([End])
```

## 4. Report Generation Process

```mermaid
flowchart TD
    Start([Start]) --> SelectReportType[Select Report Type]
    SelectReportType --> SelectTimePeriod[Select Time Period]
    SelectTimePeriod --> AnalyzeData[Analyze Data from Database]
    AnalyzeData --> DisplayReport[Display Report]
    DisplayReport --> ExportReport[Export Report\n(Excel/PDF)]
    ExportReport --> End([End])
```
