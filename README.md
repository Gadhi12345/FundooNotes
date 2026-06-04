# FundooApplication

# Fundoo Notes - User Module

---

## Project Overview

This branch (`feature/user`) contains the complete implementation of the User Module for the Fundoo Notes application.

### Implemented Features

- User Registration
- User Login
- BCrypt Password Hashing
- JWT Authentication
- SMTP Email Notifications
- Entity Framework Core Integration
- SQL Server Database Connectivity
- Dependency Injection
- Async/Await Programming

---

## Technology Stack

| Technology | Purpose |
|------------|----------|
| ASP.NET Core 8 Web API | Backend Framework |
| Entity Framework Core | ORM |
| SQL Server | Database |
| JWT | Authentication |
| BCrypt.Net | Password Hashing |
| SMTP | Email Service |
| Swagger | API Testing |
| Dependency Injection | Service Management |
| Async/Await | Asynchronous Programming |

---

## Branch Structure

```text
main
│
├── dev
│
├── feature/user
│   ├── User Registration
│   ├── User Login
│   ├── BCrypt Password Hashing
│   ├── JWT Authentication
│   ├── SMTP Email Service
│   └── Entity Framework Core Integration
│
└── feature/Notes
```

---

## Project Architecture

```text
Client
  │
  ▼
Controller Layer
  │
  ▼
Business Logic Layer (BLL)
  │
  ▼
Data Access Layer (DAL)
  │
  ▼
SQL Server Database
```

---

## Solution Structure

```text
FundooApplication
│
├── FundooNotes
│   ├── Controllers
│   │   └── UserController.cs
│   │
│   └── Program.cs
│
├── BussinessLogicLayer
│   ├── Interface
│   └── Services
│
├── DataBaseLayer
│   ├── Context
│   ├── Interface
│   └── Repository
│
├── ModelLayer
│   ├── Entity
│   └── DTO
│
└── TestingLayer
```

---

# User Registration

### Endpoint

```http
POST /api/User
```

### Flow

```text
Client
  │
  ▼
UserController
  │
  ▼
UserBLL
  │
  ├── BCrypt Hash Password
  │
  ├── Save User
  │      │
  │      ▼
  │   SQL Server
  │
  └── Send Welcome Email
          │
          ▼
        SMTP
```

### What Happens

1. User enters details.
2. Password is hashed using BCrypt.
3. User data is stored in SQL Server.
4. Welcome email is sent.
5. Success response is returned.

---

# User Login

### Endpoint

```http
POST /api/User/Login
```

### Flow

```text
Client
   │
   ▼
UserController
   │
   ▼
UserBLL
   │
   ├── Fetch User
   │
   ├── BCrypt Verify
   │
   └── Generate JWT Token
           │
           ▼
         Response
```

### What Happens

1. User enters Email and Password.
2. Password is verified using BCrypt.
3. JWT Token is generated.
4. Token is returned to the client.

---

# JWT Authentication

### Purpose

JWT is used to authenticate users without storing session data on the server.

### JWT Flow

```text
User Login
    │
    ▼
Credentials Verified
    │
    ▼
JWT Generated
    │
    ▼
Client Stores Token
    │
    ▼
Authorization Header
    │
    ▼
Protected API Access
```

### Authorization Header

```http
Authorization: Bearer <JWT_TOKEN>
```

### JWT Benefits

- Stateless Authentication
- Faster Performance
- Secure API Access
- Scalable Architecture

---

# BCrypt Password Hashing

### Registration Flow

```text
Password
   │
   ▼
BCrypt Hash
   │
   ▼
Database
```

### Login Flow

```text
Entered Password
       │
       ▼
BCrypt Verify
       │
       ▼
Stored Hash
```

### Benefits

- Passwords are never stored as plain text.
- Automatic Salt Generation.
- Resistant to Brute Force Attacks.
- Industry Standard Security.

---

# SMTP Email Service

### Components Used

- SmtpClient
- MailMessage
- NetworkCredential
- SendMailAsync()

### Flow

```text
Fundoo Notes
      │
      ▼
SMTP Client
      │
      ▼
Gmail SMTP Server
      │
      ▼
User Inbox
```

### Purpose

- Welcome Emails
- Notification Emails
- Account Related Communication

---

# Entity Framework Core

### Purpose

Entity Framework Core is used as an ORM to communicate with SQL Server.

### Flow

```text
Application
    │
    ▼
DbContext
    │
    ▼
Entity Framework Core
    │
    ▼
SQL Server
```

### Benefits

- Simplifies Database Operations
- LINQ Support
- Migration Support
- Reduced SQL Queries

---

# Dependency Injection

### Services Registered

```csharp
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IUserEmail, UserEmail>();
```

### Benefits

- Loose Coupling
- Better Maintainability
- Easy Unit Testing

---

# Async Programming

### Concepts Used

```csharp
async
await
Task
```

### Usage

- User Registration
- User Login
- Email Sending
- Database Operations

### Benefits

- Non-Blocking Operations
- Better Performance
- Improved Scalability

---

# Database Design

## User Table

| Column | Type |
|----------|----------|
| UserId | int |
| FirstName | varchar |
| LastName | varchar |
| Email | varchar |
| Password | varchar |
| CreatedAt | datetime |
| ModifiedAt | datetime |

---

# Request Lifecycle

```text
HTTP Request
     │
     ▼
Controller
     │
     ▼
BLL
     │
     ▼
DAL
     │
     ▼
Database
     │
     ▼
BLL
     │
     ▼
Controller
     │
     ▼
HTTP Response
```

---

# APIs Implemented

| Method | Endpoint | Description |
|----------|----------|----------|
| POST | /api/User | Register User |
| POST | /api/User/Login | Login User |
| GET | /api/User/Test | JWT Protected API |

---

# Concepts Learned

- ASP.NET Core Web API
- Clean Layered Architecture
- Repository Pattern
- Entity Framework Core
- SQL Server
- JWT Authentication
- Authorization
- BCrypt Password Hashing
- SMTP Email Service
- Dependency Injection
- Async/Await
- Swagger API Testing

---

# Future Modules

The following modules will be implemented in upcoming branches:

- Notes Module
- Labels Module
- Reminder Module
- Collaborator Module
- Trash Module
- Archive Module

---

## Author

**Adarsh Gadhiraju**

Backend Development - Fundoo Notes Application

---
