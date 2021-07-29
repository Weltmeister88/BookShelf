# Book Shelf

## Basic information

Solution is based on ASP.NET Core 3.1 (LTS) using a template-generated Angular SPA client app.
Database storage is implemented via Entity Framework Core using in-memory database, seeded on startup using code first approach.
Build and run should be done using Visual Studio 2019 by using BookShelf.Web as a startup project.

## BookShelf Architecture

Architecture is based on Onion Architecture principles, but rather simplified due to the low complexity of the solution.
Autofac is used together with native .NET Core DI container to allow complex configuration scenarios.
BookShelf.Core project contains application models, general interfaces and Core functionalities.
BookShelf.Infrastructure is an implementation layer for repositories and services defined in BookShelf.Core project.
Autofac Modules are used to define the lifetime scope of interfaces defined in BookShelf.Core.
GenericRepository and UnitOfWork patterns are implemented for working with EF Core database objects.
