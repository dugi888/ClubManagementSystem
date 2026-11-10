# What is ...?

**Presentation project** - UI layer, contains controllers, views, view models, and other presentation logic. It is responsible for handling user interactions and displaying data to the user.
 
**Application project** - 

**Infrastructure project** - Composition root of the module (where all the dependencies are registered). It contains the implementation of the services and repositories, as well as the configuration of the module. DI installer, file storage, external services

**Domain project** -

**Persistence project** - EF configurations, migrations, repository implementations

**Assembly** - When we compile any C# project, the compiler outputs a .dll file. That file is an Assembly. It is the fundamental unit of deployment, versioning, and security in .NET.

**AssemblyReference** -  A safe "pointer" used to tell your reflection code which .dll to scan for automatic DI registration, so you don't have to register every single service manually. Without this I would need to register assemblies like this `Assembly.Load("Modules.NewsLetter.Infrastructure")` == **_TL;DR_** automate Dependency Injection (DI) registration. 

**IUnitOfWork** - is a software design pattern interface in .NET (and related object-oriented environments) that groups multiple database operations into a single, atomic transaction.

# How ...?
**Core app registers modules and services** - common interfaces IModuleInstaller and IServiceInstaller are used to register modules and services. Each module has its own installer class that implements these interfaces and registers its own services and dependencies.

**To add migrations** -

`dotnet ef migrations add Initial -p src/Modules/Modules.NewsLetter.Persistence -s src/App -c NewsLetterDbContext -o Migrations`

`dotnet ef database update -p src/Modules/Modules.NewsLetter.Persistence -s src/App -c NewsLetterDbContext`

# Why ...?
