# Kanban — Minimal API (ASP.NET Core) ready for EF Core

This repository is a **practice project for REST API architecture** built with **ASP.NET Core Minimal APIs**, structured to be **ready for Entity Framework Core** integration. :contentReference[oaicite:0]{index=0}

The repo contains:
- `src/` (application source) :contentReference[oaicite:1]{index=1}
- `Kanban.http` (HTTP scratch file for calling the API from VS/VS Code) :contentReference[oaicite:2]{index=2}
- `Kanban.slnx` (solution in the newer `.slnx` format) 

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

> The repository description explicitly states it’s “ready for EF Core”. :contentReference[oaicite:4]{index=4}

---

## Getting started

### Prerequisites
- .NET SDK installed

### Run the API
From the repo root:

```bash
dotnet restore
dotnet run --project src
