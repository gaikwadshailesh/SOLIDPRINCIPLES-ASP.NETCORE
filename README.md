# SOLID Principles in ASP.NET Core

This project demonstrates the implementation of SOLID principles in an ASP.NET Core Web API project using a simple book management system.

## SOLID Principles Implementation

### 1. Single Responsibility Principle (SRP)
Each class has a single responsibility:
- `Book` - Data model
- `BookRepository` - Data access
- `BookService` - Business logic
- `BooksController` - HTTP request handling

### 2. Open/Closed Principle (OCP)
The system is designed to be extended without modifying existing code:
- New repository types can be added by implementing `IReadRepository` and `IWriteRepository`
- New services can be added by implementing new interfaces
- Existing functionality can be extended through inheritance

### 3. Liskov Substitution Principle (LSP)
- Any class that implements `IBookRepository` can be substituted without affecting the system
- The repository pattern ensures that different implementations (e.g., in-memory, SQL, MongoDB) can be swapped seamlessly

### 4. Interface Segregation Principle (ISP)
Interfaces are segregated based on functionality:
- `IReadRepository<T>` - Read operations
- `IWriteRepository<T>` - Write operations
- `IBookRepository` - Combines both with specific book operations
- `IBookService` - Business logic operations

### 5. Dependency Inversion Principle (DIP)
High-level modules depend on abstractions:
- `BookService` depends on `IBookRepository`
- `BooksController` depends on `IBookService`
- Dependencies are injected through constructor injection

## Project Structure
