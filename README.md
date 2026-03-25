# Kanban — Minimal API (ASP.NET Core) ready for EF Core

This repository is a **practice project for REST API architecture** built with **ASP.NET Core Minimal APIs**, structured to be **ready for Entity Framework Core** integration.

## The repo contains

- `src/`
  - `Kanban.Api/`  
    ASP.NET Core Minimal API project.  
    Responsible for HTTP endpoints, request/response handling, dependency injection, and application bootstrapping.

  - `Kanban.Application/`  
    Application layer.  
    Contains use cases, application services, DTOs, and orchestration logic.  
    This layer coordinates domain logic but does not depend on infrastructure concerns.

  - `Kanban.Domain/`  
    Core domain model.  
    Contains entities, value objects, business rules, and domain abstractions.  
    This project should remain persistence-agnostic and framework-independent.

- `Kanban.http`  
  HTTP scratch file for testing endpoints directly from Visual Studio / VS Code.

- `Kanban.slnx`  
  Solution file (new `.slnx` format).

---

## Goals

- Keep a **thin HTTP layer** (Minimal API endpoints).
- Keep a **clean internal architecture** so persistence (EF Core) is a replaceable detail.
- Make it easy to evolve into:
  - EF Core + migrations
  - validation
  - auth (JWT)
  - Docker + database
  - tests

---

## Tech (intended)

- .NET (Minimal APIs)
- ASP.NET Core
- EF Core (ready to plug in)
- Swagger / OpenAPI (recommended)

---

## Getting started

### Prerequisites
- .NET SDK installed

### Run the API
From the repo root:

```bash
dotnet restore
dotnet run --project src
