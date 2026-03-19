# Finanzas App API

API backend para una app de finanzas personales desarrollada con ASP.NET Core Web API, PostgreSQL, Entity Framework Core y Docker.

## Tecnologías
- ASP.NET Core Web API
- C#
- Entity Framework Core
- PostgreSQL
- Docker Compose
- Swagger / OpenAPI

## Funcionalidades actuales
- CRUD básico de cuentas
- Persistencia en PostgreSQL
- Documentación y pruebas con Swagger

## Estructura del proyecto
- `Controllers/` → endpoints HTTP
- `Entities/` → entidades del dominio
- `DTOs/` → objetos de transferencia de datos
- `Data/` → contexto de base de datos
- `docker-compose.yml` → infraestructura local de PostgreSQL

## Requisitos
- .NET SDK
- Docker Desktop
- Git

## Cómo levantar PostgreSQL
```bash
docker compose up -d
