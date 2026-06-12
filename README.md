# 📝 Fundoo Notes

Fundoo Notes is a layered ASP.NET Core Web API application that allows users to manage notes efficiently with features such as authentication, note management, label management, and Redis caching. The project follows a clean architecture using API, Business Logic, and Data Access layers to ensure maintainability, scalability, and separation of concerns.

---

## 🏗️ Architecture

<img width="784" height="835" alt="image" src="https://github.com/user-attachments/assets/45ad1e47-b9f2-454c-9872-0d9fb4772946" />


### Request Flow

```text
User
  ↓
Controller
  ↓
BLL (Business Logic Layer)
  ↓
DAL (Data Access Layer)
  ↓
SQL Server / Redis
```

---

## 📂 Project Structure

### API Layer
Handles incoming HTTP requests and returns responses.

**Controllers**
- UserController
- NoteController
- LabelController
- RedisController

---

### Business Logic Layer (BLL)

**Interfaces**
- IUserBLL
- INoteBLL
- ILabelBLL
- IRedisBLL

**Implementations**
- UserBLL
- NoteBLL
- LabelBLL
- RedisBLL

Responsible for:
- Business rules
- Data processing
- Validation
- Communication with DAL

---

### Data Access Layer (DAL)

**Interfaces**
- IUserDAL
- INoteDAL
- ILabelDAL
- IRedisDAL

**Implementations**
- UserDAL
- NoteDAL
- LabelDAL
- RedisDAL

Responsible for:
- Database operations
- Redis operations
- Data persistence

---

## 🗄️ Database Layer

### SQL Server
Stores:
- User Information
- Notes
- Labels

### Redis Cache
Provides:
- Fast data retrieval
- Reduced database load
- Improved application performance

---

## 🚀 Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Redis
- Docker
- JWT Authentication
- Swagger UI
- Dependency Injection
- Repository Pattern

---

## 🔄 Redis Integration

Redis is integrated using:

- StackExchange.Redis
- RedisDAL
- RedisBLL
- RedisController

### Redis Flow

```text
User
  ↓
RedisController
  ↓
RedisBLL
  ↓
RedisDAL
  ↓
Redis Cache
```

---

## ✨ Features

- User Registration & Login
- JWT Authentication
- Notes Management
- Labels Management
- Redis Caching
- Dockerized Redis Setup
- Layered Architecture
- Dependency Injection
- Swagger API Testing

---

## 📌 Architecture Highlights

- Clean Layered Architecture
- Separation of Concerns
- Interface-Based Design
- Repository Pattern
- Redis Caching Support
- Scalable and Maintainable Code Structure

---

### Author
**Adarsh Gadhiraju**


