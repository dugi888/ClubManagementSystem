# What is ...?
Application project - 
Infrastructure project - 
Domain project -
Persistence project -
Assembly and AssemblyReference -


# How ...?
Core app registers modules and services - common interfaces IModuleInstaller and IServiceInstaller are used to register modules and services. Each module has its own installer class that implements these interfaces and registers its own services and dependencies.

# Why ...?
