# API de Facturacion - DDD y Clean Architecture

Caso de estudio desarrollado como prueba tecnica con .NET 10 y ASP.NET Core para gestionar facturas mediante una API REST.

## Objetivo del proyecto

Construir una API capaz de crear, consultar, actualizar y eliminar facturas, aplicando una separacion clara de responsabilidades y buenas practicas de diseno:

- Domain-Driven Design (DDD).
- Clean Architecture.
- Principios SOLID.
- Inversion de dependencias.
- Casos de uso orientados a la aplicacion.
- Entidades y Value Objects del dominio.
- Persistencia mediante Entity Framework Core.
- DTOs y transformacion de datos con AutoMapper.

## Tecnologias utilizadas

- .NET 10
- ASP.NET Core Web API
- C#
- Entity Framework Core 10
- Base de datos InMemory
- AutoMapper 17
- OpenAPI

## Arquitectura

La solucion esta organizada en cuatro proyectos independientes:

```text
InvoiceManagement
├── InvoiceManagement.API
│   └── Controladores y configuracion de ASP.NET Core
├── InvoiceManagement.Application
│   └── DTOs, casos de uso, mapeos e interfaz de repositorio
├── InvoiceManagement.Domain
│   └── Entidades, Value Objects, estados y excepciones de dominio
└── InvoiceManagement.Infraestructure
    └── DbContext, configuracion EF Core y repositorio
```

### Flujo de una peticion

```text
Cliente HTTP
    -> Controlador de la API
    -> Caso de uso de la capa Application
    -> Entidad o Value Object de Domain
    -> Repositorio de Infrastructure
    -> Entity Framework Core InMemory
```

### Responsabilidad de cada capa

#### API

- Expone los endpoints REST.
- Recibe y devuelve los DTOs HTTP.
- Devuelve codigos de estado y respuestas apropiadas.
- Registra la configuracion de Application e Infrastructure.

#### Application

- Contiene los casos de uso CRUD.
- Define el contrato `IInvoiceRepository`.
- Separa los datos de entrada y salida mediante DTOs.
- Convierte entidades en respuestas con AutoMapper.

#### Domain

- Contiene la entidad `Invoice`.
- Contiene los Value Objects `CustomerName`, `InvoiceNumber` e `InvoiceDate`.
- Define `InvoiceStatus` y las reglas que protegen la integridad del modelo.
- Usa `ExceptionDomain` para representar errores de validacion del dominio.

#### Infrastructure

- Implementa `IInvoiceRepository`.
- Configura `InvoiceDbContext`.
- Mapea los Value Objects como entidades propias mediante EF Core.
- Utiliza la base de datos InMemory `InvoiceManagementDb`.

## Funcionalidades implementadas

- Crear una factura.
- Obtener todas las facturas.
- Obtener una factura por su identificador.
- Actualizar una factura existente.
- Eliminar una factura existente.
- Generar automaticamente un `Guid` para cada nueva factura.
- Validar datos dentro de los Value Objects y de la entidad.
- Transformar Value Objects a DTO mediante AutoMapper.
- Registrar todas las dependencias mediante extension methods.

## Modelo de factura

Una factura contiene:

| Campo | Tipo | Descripcion |
|---|---|---|
| `Id` | `Guid` | Identificador unico generado en el dominio |
| `CustomerName` | `CustomerName` | Nombre del cliente |
| `InvoiceNumber` | `InvoiceNumber` | Numero identificador de la factura |
| `IssueDate` | `DateOnly` | Fecha de emision |
| `DueDate` | `DateOnly` | Fecha de vencimiento |
| `Status` | `InvoiceStatus` | Estado de la factura |
| `Total` | `decimal` | Importe total |

### Estados disponibles

| Valor | Estado |
|---:|---|
| 1 | `Draft` |
| 2 | `Issued` |
| 3 | `Paid` |
| 4 | `Cancelled` |

## Reglas de negocio implementadas

- Toda factura recibe un identificador `Guid`.
- El nombre del cliente no puede estar vacio ni contener solamente espacios.
- El numero de factura no puede estar vacio ni contener solamente espacios.
- Los nombres y numeros se almacenan eliminando espacios externos.
- La fecha de vencimiento no puede ser anterior a la fecha de emision.
- El importe total debe ser mayor que cero.
- El estado debe pertenecer a los valores definidos en `InvoiceStatus`.
- El nombre del cliente, el numero y las fechas no pueden ser nulos durante la creacion o actualizacion.

La regla de que el numero de factura no debe estar duplicado esta definida como requisito del caso de estudio, pero actualmente no dispone de una comprobacion de unicidad ni de una restriccion unica en el repositorio o en `InvoiceDbContext`.

## API REST

Base route: `api/Invoices`

| Metodo | Ruta | Descripcion | Respuesta exitosa |
|---|---|---|---|
| `GET` | `/api/Invoices` | Lista todas las facturas | `200 OK` |
| `GET` | `/api/Invoices/{invoiceId}` | Obtiene una factura | `200 OK` o `404 NotFound` |
| `POST` | `/api/Invoices` | Crea una factura | `201 Created` |
| `PUT` | `/api/Invoices/{invoiceId}` | Actualiza una factura | `200 OK` o `404 NotFound` |
| `DELETE` | `/api/Invoices/{invoiceId}` | Elimina una factura | `204 NoContent` o `404 NotFound` |

### Ejemplo de creacion

```http
POST /api/Invoices
Content-Type: application/json
```

```json
{
  "customerName": "Empresa Ejemplo S.L.",
  "invoiceNumber": "FAC-2026-001",
  "issueDate": "2026-11-27",
  "dueDate": "2026-12-27",
  "status": 1,
  "total": 1250.50
}
```

Tambien es posible enviar el estado como nombre del enum, por ejemplo `"status": "Draft"`, dependiendo de la configuracion de serializacion.

### Ejemplo de respuesta

```json
{
  "id": "4c5a2ca0-52be-4fbd-9d81-70c6ca9c3e3a",
  "customerName": "Empresa Ejemplo S.L.",
  "invoiceNumber": "FAC-2026-001",
  "issueDate": "2026-11-27",
  "dueDate": "2026-12-27",
  "status": "Draft",
  "total": 1250.50
}
```

## Patrones y decisiones de diseno

- **Repository Pattern:** aisla el dominio y la aplicacion de la tecnologia de persistencia.
- **Use Case Pattern:** cada operacion CRUD tiene su propia clase de aplicacion.
- **Value Objects:** encapsulan validaciones y representan conceptos relevantes del dominio.
- **DTO Pattern:** evita exponer directamente las entidades a traves de la API.
- **Dependency Injection:** registra servicios y resuelve las dependencias mediante el contenedor de ASP.NET Core.
- **AutoMapper:** centraliza el proceso de transformacion entre entidades y DTOs.
- **Guid Version 7:** usa `Guid.CreateVersion7()` para generar identificadores.
- **Base de datos temporal:** EF Core InMemory permite probar el CRUD sin configuracion externa de SQL Server.

## Estructura de proyectos

```text
InvoiceManagement.API
├── Controllers/InvoicesController.cs
├── Program.cs
└── appsettings.json

InvoiceManagement.Application
├── DTOs
├── Interfaces/IInvoiceRepository.cs
├── Mappings/InvoiceMappingProfile.cs
├── UseCases
└── DependencyInjection.cs

InvoiceManagement.Domain
├── Entities/Base.cs
├── Entities/Invoice.cs
├── Entities/InvoiceStatus.cs
├── ValueObjects/CustomerName.cs
├── ValueObjects/InvoiceNumber.cs
├── ValueObjects/InvoiceDate.cs
└── Exceptions/ExceptionDomain.cs

InvoiceManagement.Infraestructure
├── Repositories/InvoiceDbContext.cs
├── Repositories/InvoiceRepository.cs
└── DependencyInjection.cs
```

## Ejecucion local

### Requisitos

- .NET 10 SDK
- Visual Studio 2026 o Visual Studio Code

### Ejecutar con Visual Studio

1. Abrir `InvoiceManagement/InvoiceManagement.slnx`.
2. Seleccionar `InvoiceManagement.API` como proyecto de inicio.
3. Ejecutar con `F5` o `Ctrl+F5`.

### Ejecutar con la CLI

Desde la raiz del repositorio:

```powershell
cd InvoiceManagement
 dotnet restore
 dotnet run --project InvoiceManagement.API/InvoiceManagement.API.csproj
```

Durante el desarrollo, ASP.NET Core expone el documento OpenAPI desde la ruta configurada por el SDK. La URL HTTP o HTTPS concreta puede consultarse en la salida de consola y en `Properties/launchSettings.json`.

## Consideraciones

- Los datos se almacenan en memoria y se pierden al reiniciar la aplicacion.
- No hay autenticacion ni autorizacion implementada.
- El API utiliza el endpoint HTTPS redirection configurado por el proyecto web.
- Las excepciones de dominio no tienen todavia un middleware global que las convierta en respuestas HTTP estructuradas.
- Actualmente no se valida desde el repositorio que un numero de factura no se encuentre duplicado.

## Posibles mejoras

- Implementar comprobacion y restriccion de unicidad del numero de factura.
- Incorporar FluentValidation o validacion centralizada de peticiones.
- Crear un middleware global de manejo de excepciones.
- Sustituir la base InMemory por SQL Server o PostgreSQL.
- Agregar migraciones de Entity Framework Core.
- Incorporar pruebas unitarias de dominio y casos de uso.
- Incorporar pruebas de integracion para los endpoints.
- Agregar paginacion y filtros a `GET /api/Invoices`.
- Implementar autenticacion con JWT y politicas de autorizacion.
- Publicar una especificacion OpenAPI completa y documentar ejemplos de respuesta.

## Resultado

Este caso de estudio demuestra la construccion de una API REST basada en capas, con entidades y reglas de dominio, casos de uso separados, persistencia mediante EF Core y operaciones CRUD completas, manteniendo desacopladas las responsabilidades tecnicas y funcionales.