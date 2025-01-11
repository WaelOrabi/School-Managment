# School Management System API

A comprehensive **School Management System API** designed to manage students, instructors, subjects, and departments. This system follows clean architecture principles, incorporates advanced patterns, and ensures modularity, scalability, and maintainability.

---

## Solution Layers

The project is organized into distinct layers, each addressing a specific responsibility to ensure separation of concerns and maintainable code.

### 1. **SchoolProject.API**

This layer handles the API endpoints and serves as the entry point for the application.

- **Controllers**: Manage HTTP requests and responses for resources like students, instructors, subjects, and departments.
- **Dependencies**: Houses configuration files and dependency injection registrations for the API layer.
- **Base**: Contains shared base classes for controllers or other API-related components.

**Key Features:**

- Endpoints grouped by entity (e.g., Students, Instructors, Subjects, Departments, Authentication, Authorization).
- Dynamic pagination, filtering, and CRUD operations.

**Key Files:**

- `appsettings.json`: Stores application configuration settings.
- `Program.cs`: Configures the application pipeline and services.

---

### 2. **SchoolProject.Core**

This is the heart of the application, containing the core business logic and reusable components.

- **Bases**: Contains base classes and interfaces used across the project.
- **Behaviors**: Implements cross-cutting concerns like validation, logging, and exception handling.
- **Features**: Encapsulates business logic for handling various functionalities.
- **Mapping**: Configures object-to-object mappers (e.g., AutoMapper profiles).
- **Middleware**: Defines middleware components for handling requests such as authentication and exception handling.
- **Resources**: Stores static resources like error messages or constants or localization.
- **Wrappers**: Implements utility classes for wrapping responses or other reusable logic.

**Key Feature:** Incorporates the **Mediator Design Pattern** using **MediatR** to handle requests and responses efficiently.

**Key File:**

- `ModuleCoreDependencies.cs`: Manages dependency injection for the Core layer.

---

### 3. **SchoolProject.Data**

This layer handles the definition of the domain's data models and logic for data manipulation.

- **Commons**: Contains shared utility classes or constants.
- **Entities**: Defines the database entities (e.g., Students, Instructors, Subjects, Departments).
- **Enums**: Stores enumerations used across the system.
- **Helpers**: Provides helper classes for data-related tasks.
- **Requests**: Structures representing incoming data for operations like creating or updating entities.
- **Responses**: Structures for sending data back to the client consistently.

---

### 4. **SchoolProject.Infrastructure**

This layer handles database operations and external service integrations.

- **Abstracts**: Contains abstractions (interfaces) for repositories and services.
- **Data**: Manages the database context and configurations.
- **InfrastructureBases**: Provides base classes for common infrastructure operations.
- **Migrations**: Stores database migration files for schema changes.
- **Repositories**: Implements the **Repository Pattern** for data access and manipulation.
- **Seeder**: Initializes the database with default values.

**Key File:**

- `ModuleInfrastructureDependencies.cs`: Configures dependencies specific to the Infrastructure layer.

---

### 5. **SchoolProject.Service**

This layer manages the business logic and service implementations.

- **Abstracts**: Defines service interfaces for core operations.
- **Implementations**: Implements business logic for managing students, instructors, and departments.
- **Dependencies**: Handles dependency injection for the service layer.

**Key File:**

- `ModuleServiceDependencies.cs`: Configures dependencies for the Service layer.

---

## Features

### **Student Management**

- Register, update, and delete students.
- Fetch paginated or filtered lists of students.
- Assign students to subjects.

### **Instructor Management**

- Create, update, and delete instructors.
- Assign subjects and departments to instructors.
- Filter instructors by subjects and departments.

### **Subject Management**

- CRUD operations for subjects.
- Assign subjects to departments and instructors.

### **Department Management**

- Manage departments with CRUD operations.
- Assign instructors and subjects.

### **Authentication and Authorization**

- **Identity-based Authentication** using **JWT tokens**.
- Role-based access control (RBAC) for administrators, instructors, and students.
- Secure endpoints with token validation.

### **Application User Management**

- User registration and profile updates.
- Password management.

### **Authorization**

- Manage user roles and claims.
- Role-based permissions for access control.

---

## Technical Details

### Clean Architecture

- Promotes separation of concerns across layers.
- Ensures that business logic is independent of frameworks.

### Repository Pattern

- Provides a consistent abstraction layer for data access.
- Simplifies querying and CRUD operations.

### Mediator Design Pattern

- Decouples request handling using **MediatR**.
- Centralizes request/response handling and promotes single responsibility.

### JWT Authentication

- Secure endpoints with token-based authentication.
- Provides functionality for token refresh and validation.



--

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/SchoolProjectAPI.git
   cd SchoolProjectAPI
   ```

2. Install dependencies:

   ```bash
   dotnet restore
   ```

3. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

