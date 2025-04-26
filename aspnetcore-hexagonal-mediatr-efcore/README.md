
# 🚀 ASP.NET Core Hexagonal Template - MediatR, EF Core, FluentValidation, Global Exception Middleware

This project is a base template for building ASP.NET Core APIs following **Hexagonal Architecture (Ports and Adapters)** with modern best practices.

---

## 📂 Project Structure

```
aspnetcore-hexagonal-mediatr-efcore/
├── aspnetcore-hexagonal-mediatr-efcore.sln
├── Core/
│   ├── Entities/
│   │   └── User.cs
│   └── Interfaces/
│       └── IUserRepository.cs
├── Application/
│   ├── UserCases/
│   │   └── CreateUser/
│   │       ├── CreateUserCommand.cs
│   │       ├── CreateUserCommandHandler.cs
│   │       ├── CreateUserCommandValidator.cs
│   ├── Behaviors/
│   │   └── ValidationBehavior.cs
├── Infrastructure/
│   └── Persistence/
│       ├── AppDbContext.cs
│       └── UserRepository.cs
├── WebAPI/
│   ├── Controllers/
│   │   └── UserController.cs
│   └── Program.cs
├── README.md
└── .gitignore
```

---

## 🧠 Layered Organization

| Layer | Content |
|:------|:--------|
| **Core** | Entities and interfaces (pure domain, no external dependencies) |
| **Application** | Use Cases (Commands, Handlers, Validators) and MediatR Behaviors |
| **Infrastructure** | Concrete implementations (EF Core persistence) |
| **WebAPI** | HTTP Interface, Controllers, Global Exception Middleware, Dependency Injection |

---

## ⚙️ Technologies Used

- [ASP.NET Core 8](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
- [MediatR](https://github.com/jbogard/MediatR) for CQRS
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/) for input validation
- [Entity Framework Core InMemory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/) for fake persistence
- [Swagger](https://swagger.io/tools/swagger-ui/) for API documentation

---

## 📚 Implemented Features

### ✅ Hexagonal Architecture
Full separation between domain, application, infrastructure, and interface layers. Domain knows nothing about databases, APIs, or frameworks.

### ✅ MediatR with ValidationBehavior
Intercepts all Commands and validates them using FluentValidation before reaching Handlers.

### ✅ FluentValidation
Each Command has an associated Validator ensuring only valid data reaches Handlers.

### ✅ Global Exception Handling Middleware
Captures all exceptions globally, differentiates between validation and application errors, and returns structured JSON responses (ErrorResponse).

### ✅ ErrorResponse Model
All error responses follow a consistent JSON structure with `StatusCode`, `Message`, and `Errors` list.

---

## 🚀 How to Run Locally

1. Clone the repository:

```bash
git clone https://github.com/your-username/project-templates.git
cd aspnetcore-hexagonal-mediatr-efcore
```

2. Restore packages and build:

```bash
dotnet restore
dotnet build
```

3. Run the WebAPI project:

```bash
dotnet run --project WebAPI/WebAPI.csproj
```

4. Access:

- Swagger: `https://localhost:5001/swagger`
- API: `https://localhost:5001/user`

---

## ✍️ Initial Functionalities

- `POST /user` — Create a new user
- Automatic validation of input (`Name` is required, minimum 3 characters)
- Simulated persistence using an in-memory database

---

## 📈 Request Flow

```
Client Request
   ↓
ValidationBehavior (automatic validation)
   ↓
Handler (use case execution)
   ↓
ExceptionHandlingMiddleware (captures any exception)
   ↓
HTTP Response (structured JSON ErrorResponse)
```

---

## 📋 Conventions and Practices Applied

- Clear separation of layers respecting Hexagonal Architecture
- Application layer does not depend on WebAPI or EF Core
- Controlled and user-friendly error handling
- 100% English codebase
- RESTful error patterns

---

## 📎 Final Notes

This template is an excellent starting point for professional, scalable, maintainable APIs.

Feel free to extend it with:
- SQLite, SQL Server, or PostgreSQL support
- API versioning
- JWT Authentication
- Event sourcing
- Message queues like RabbitMQ or Kafka

Contributions are welcome! 🚀
