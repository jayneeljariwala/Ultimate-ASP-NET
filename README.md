# Ultimate ASP.NET

An ASP.NET Web API sample for managing companies and employees, built with a layered architecture, EF Core, and PostgreSQL. The API exposes CRUD endpoints, supports JSON Patch, and can return CSV for company lists.

**Architecture**
This project uses a layered (N-tier) architecture with clear separation of concerns and dependency inversion via contracts:
- Presentation layer: API controllers in `CompanyEmployees.Presentation`.
- API host: `CompanyEmployees` (composition root, middleware, DI, OpenAPI).
- Service layer: business logic in `Service` with interfaces in `Service.Contracts`.
- Repository layer: data access in `Repository` with interfaces in `Contracts`.
- Core domain: entities and exceptions in `Entities`.
- Shared models: DTOs in `Shared`.
- Logging: `LoggerService` with NLog.

**Project Structure**
- `CompanyEmployees`: Web API host (Program, middleware, DI setup).
- `CompanyEmployees.Presentation`: Controllers and API contracts.
- `Service` and `Service.Contracts`: Business logic and service interfaces.
- `Repository` and `Contracts`: EF Core data access and repository interfaces.
- `Entities`: Domain models and exceptions.
- `Shared`: DTOs and cross-layer shared models.
- `LoggerService`: NLog integration.

**Key Features**
- Companies and employees CRUD endpoints.
- JSON Patch support for partial employee updates.
- CSV output formatter for company data (`Accept: text/csv`).
- OpenAPI document available in Development environment.
- NLog file-based logging.

**Tech Stack**
- .NET 10 (`net10.0`)
- ASP.NET Core Web API
- Entity Framework Core with Npgsql (PostgreSQL)
- AutoMapper
- NLog

**Getting Started**
1. Ensure PostgreSQL is running and update the connection string in `CompanyEmployees/appsettings.json`.
2. Restore and run:

```bash
dotnet restore
dotnet run --project CompanyEmployees/CompanyEmployees.csproj
```

The API defaults to `https://localhost:7049` and `http://localhost:5263` in Development. The OpenAPI document is mapped when `ASPNETCORE_ENVIRONMENT=Development`.

**Notes**
- Logs are written to `CompanyEmployees/logs/` via NLog.
- CSV responses are available for company endpoints when the client sends `Accept: text/csv`.
