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

##  Technologies

This project is built on .NET Core using modern software development techniques and tools. The project includes the following main components and technologies:

- **.NET Core:** The framework that forms the foundation of the project.
- **Entity Framework:** An ORM (Object-Relational Mapping) tool used for database operations.
- **CQRS (Command Query Responsibility Segregation):** A pattern that separates command (write) and query (read) operations.
- **DTO (Data Transfer Objects):** Objects used for transferring data between database entities and services.
- **AutoMapper:** A library that automates object-to-object mapping.
- **MediatR:** A library that manages communication between application layers.
- **Middleware (Global Exception Handling):** Middleware used for global error handling in the application.
- **Pipelines (Authorization, Logging, Validation):** Pipelines that manage authorization, logging, and validation operations.
- **Encryption (Hashing + Salting):** Encryption methods used to ensure the security of user passwords.
- **JWT (JSON Web Token):** A token-based system used for authentication and authorization.
- **Pagination:** A structure that manages pagination in data listings.
- **Mailing (MailKit, MimeKit):** Libraries used for sending emails to users.
- **User Roles System:** A structure that allows the assignment of roles to users. Roles are defined as OperationClaim objects and assigned to users via UserOperationClaim.
- **SignalR:** A library used for real-time web applications.
- **Abstract and Concrete Repositories:** The use of the repository pattern for database operations. Abstract repositories are defined through interfaces, and concrete repositories implement these interfaces.
- **Onion Architecture:** A layered architectural pattern where dependencies flow from the core outward and the structure is organized around a central core.

## Technical Details of the Project

- **Database Management:** Database operations are managed using Entity Framework. Database updates are performed using migration processes.
- **CQRS Pattern:** Commands and queries are separated to improve application performance and scalability. MediatR is used to manage command and query handlers.
- **DTO and AutoMapper Usage:** DTOs facilitate data transfer independently of database models. AutoMapper automates the transformations between DTOs and models.
- **JWT Authentication:** A JWT token is generated when users log in, providing authentication. User permissions are determined by the information within the token.
- **User Roles and Authorization:** Roles are defined as OperationClaim objects for users. Users are assigned roles via UserOperationClaim. Authorization is managed through pipelines.
- **Real-Time Communication:** SignalR enables real-time communication between users.
- **Email Sending:** Users are informed in various scenarios (Patients are notified of their upcoming appointments) using MailKit and MimeKit.
- **Global Error Handling:** Errors are caught and managed globally using middleware.
- **Logging:** Logging operations are managed through pipelines.

## Contributions

Contributions to this project are welcome. Please follow these steps to contribute:

- Fork the repository.
- Create a new branch for your feature or bug fix.
- Make your changes and commit them with clear and concise messages.
- Push your branch to your fork.
- Submit a pull request to the main repository.
- Please ensure that your contributions adhere to the project's coding standards and guidelines.
