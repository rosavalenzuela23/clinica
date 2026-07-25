# Clinica Workspace

## Layout

- `apps/front-clinica` is the Vue 3/Vite client; `apps/backend-clinica` is the ASP.NET Core API. pnpm workspaces include `apps/*`; Turbo defines cross-package `build`, `lint`, and `dev` tasks.
- The root is not a .NET project or solution. Build the API by targeting `apps/backend-clinica/backend-clinica.csproj`.
- The backend request path is deliberate: controller DTO -> `Mappers/DtoDomainMapper` -> domain -> `Services/Negocio*` -> `Repositories/*Repository` -> `Persistence/DomainEntityMapper` -> EF entity. Do not bind domain/entity types directly in controllers or use EF entities outside persistence.

## Commands

- Install dependencies: `pnpm install` (pnpm 10.33.2; frontend requires Node `^22.18.0 || >=24.12.0`).
- Frontend: `pnpm --filter front-clinica dev`, `pnpm --filter front-clinica build`, `pnpm --filter front-clinica test:unit --run`, `pnpm --filter front-clinica format`.
- Backend: `pnpm --filter backend-clinica dev`, `dotnet build apps/backend-clinica/backend-clinica.csproj`.

## Backend Constraints

- The .NET 10 API uses EF Core/Npgsql. Its model is in `apps/backend-clinica/Persistence/ClinicalDbContext.cs`, and schema changes require a checked-in migration in `Persistence/Migrations`.
- The PostgreSQL connection string key is `ConnectionStrings:ClinicalDatabase` in `apps/backend-clinica/appsettings.json`.
- Swagger runs only in Development; launch profiles use `http://localhost:5005` and `https://localhost:7210`.
- CORS permits only `http://localhost:4200`, while Vite has no configured development port. Align them before browser-based API integration.

## Formatting

- Backend `.editorconfig` forbids single-line C# blocks/statements.
- Frontend uses `oxfmt` with no semicolons and single quotes.
