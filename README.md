# 🧾 Invoice Management System (Web API)

A clean architecture-based Invoice Management System built with ASP.NET Core Web API using Domain-Driven Design (DDD), Repository Pattern, and Stored Procedures for master-detail operations. The system is designed as a backend-only service, exposing RESTful APIs for client applications.

---

## 🚀 Key Features

- ✅ Clean Architecture (Domain, Application, Infrastructure, API layers)
- ✅ Domain-Driven Design (DDD) (Entities, Aggregates, Repositories, Domain Rules)
- ✅ Master-Detail Relationship (Invoice ↔ Product via InvoiceProduct junction table)
- ✅ Code First Approach with Entity Framework Core
- ✅ Fluent API Configurations for relationships, constraints, and indexes
- ✅ Repository Pattern for data access abstraction
- ✅ Stored Procedures Integration (Insert / Update / Delete Invoice with details using JSON)
- ✅ ASP.NET Core Web API (RESTful API)
- ✅ DTO-based architecture for request/response separation
- ✅ Swagger (OpenAPI) documentation
- ✅ Application Service layer for business logic separation
- ✅ Structured logging using ILogger

---

## 🧱 Tech Stack

| Layer            | Technology                            |
|-----------------|----------------------------------------|
| Backend API     | ASP.NET Core 9                         |
| Architecture    | Clean Architecture + DDD               |
| ORM             | Entity Framework Core (Code First)     |
| Mapping         | Fluent API                             |
| Data Access     | Repository Pattern + Stored Procedures |
| Database        | SQL Server                             |
| API Design      | RESTful API                            |
| Documentation   | Swagger / OpenAPI                      |
| Logging         | Microsoft ILogger                      |

---

## 📁 Project Structure
