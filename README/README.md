# Employee Leave Management System API

---

## 📌 Project Overview
This project is a backend system built using ASP.NET Core Web API for managing employee leave requests with authentication and role-based access control.

---

## 🚀 Features
- User Registration & Login
- JWT Authentication
- Role-based Authorization (Admin / Employee)
- Apply Leave
- View My Leaves
- Approve / Reject Leave (Admin)
- SQL Server Database Integration
- Global Exception Handling
- Swagger API Documentation

---

## 🛠 Technologies Used
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)

---

### ⚙️ Setup Instructions

### 1. Clone the project
git clone (https://github.com/ankushv1499/EmployeeLeaveManagementSystemAPI.git)

---

### 2. Configure Database
Update connection string in:"Server=localhost\\SQLEXPRESS;Database=EmployeeLeaveDB;Trusted_Connection=True;TrustServerCertificate=True;"
appsettings.json

---

### 3. Run Migrations
dotnet ef database update

---

### 4. Run Application
dotnet run

---

### 5. Open Swagger
https://localhost:5004/swagger
 
---

## 👥 Roles
- Employee = 2
- Admin = 1

---

## 🔐 API Flow
Register → Login → Get Token → Access Protected APIs

---

## 📦 Sample Endpoints

### Auth
- POST /api/auth/register[role: ADMIN]
- POST /api/auth/login

### Employee
- POST /api/leaves
- GET /api/leaves/my

### Admin
- PUT /api/admin/leaves/{id}/approve
- PUT /api/admin/leaves/{id}/reject

---

## 📬 Postman Collection

Link : https://web.postman.co/workspace/d680570c-00bf-4394-8556-1d8ed812a287/collection/35338124-fbdff752-62f1-4adb-a72c-9ceed9fba0f4?action=share&source=copy-link&creator=35338124
