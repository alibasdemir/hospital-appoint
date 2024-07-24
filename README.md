# Hospital Appointment Management System

This is a .NET Onion Architecture project designed to manage hospital appointments, doctors' availability, and patient records. The system allows patients to book appointments based on doctors' available times and includes various other functionalities related to hospital management.

## Project Structure

The project is divided into several layers, each with a specific responsibility:

### Core Layer

The Core layer is designed to be reusable across different projects. It includes:

- **Base Entities:** Common entities that can be used across multiple projects.
- **Middleware:** Global exception handling.
- **Pipeline Structure:** Includes authorization, logging, and validation.
- **Pagination:** Functionality for handling pagination in queries.
- **JWT:** JSON Web Token handling for authentication and authorization.
- **Encryption / Hashing and Salting:** Security features for password management.
- **Mailing:** Functionality for sending emails using MimeKit and MailKit.

### Domain Layer

The Domain layer contains only the domain entities. Business rules and validation are handled in the Application layer.

### Application Layer

The Application layer includes:

- **CQRS:** Command Query Responsibility Segregation to separate read and write operations.
- **DTOs:** Data Transfer Objects.
- **MediatR:** Library for implementing CQRS pattern.
- **Business Rules:** Application-specific business logic.
- **Validation Rules:** Rules for validating commands and queries.
- **Mapping Profiles:** AutoMapper profiles for mapping between entities and DTOs.
- **Services:** Application services.
- **Abstract Repositories:** Interfaces for data access.

### Infrastructure Layer

The Infrastructure layer handles data access, external services, and other infrastructure-related concerns. It includes:

- **SignalR:** For real-time communication.

### Persistence Layer

The Persistence layer includes:

- **Concrete Repositories:** Implementations of the abstract repositories.
- **BaseDbContext:** Base class for database context, handling database operations.
- **Seed Data:** Initial data to populate the database.

### Presentation Layer (WebAPI)

The Presentation layer contains the API endpoints exposed to clients. It includes:

- **Controllers:** Handle HTTP requests and responses.
- **Program.cs:** Main entry point of the application.
- **appsettings.json:** Configuration settings.

### *Service Registrations*

Each layer has its own service registration to manage dependency injection and ensure modular and maintainable code.
