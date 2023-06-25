# CleanArchitecture
The core inner entities and use cases, also called business and application layers

have no dependencies and are less likely to change

Each layer of this circular diagram has dependencies on the layer next to it. The external layers are most likely to change based on technologies, frameworks and so on, consequently, the solution architecture has less 
impact in core applications’ logic.​

Domain Layer or busines :  entities(domain object), value objects
-----------
No dependencies, no project or class reference, no logic

	Aggregates, entities, value objects, custom domain exceptions, and interfaces for domain services.
 	Interfaces for domain-driven design concepts (i.e. IAggregateRoot, IDomainEvent, IEntity).
 	Base implementations of aggregate root and domain event. Also contains specific domain events pertaining to the business processes.
 
Application Layer       : “what” the system should do
---------------------
Only Domain is added as reference project, Pure business logic or services

	Interfaces for infrastructure components such as repositories, unit-of-work and event sourcing.
	Commands and Queries models and handlers
	Interfaces and DTOs for cross-cutting concerns (i.e. service bus)
	Authorization operations, requirements and handlers implementations
	Interfaces and concrete implementations of application-specific business logic services.
	Mapping profiles between domain entities and CQRS models
 
Infrastructure Layer    : “how” the system should do
--------
This class is responsible for external infrastructure communications like database storage, file system, external systems/APIs/Services and so on

	Generic and specific repositories implementations
	EF DbContexts, data models and migrations
	Event sourcing persistence and services implementations
	Implementations for cross-cutting concerns (i.e, application configuration service, localization service etc.)
	Data entity auditing implementation
	
	This consists of 3 projects in the solution under the Infrastructure folder, the Auditing, Data and Shared projects.

	The Auditing project consists of various extensions methods for DbContext, primarily related to SaveChanges. It is responsible for generating auditing records for each tracked entity’s changes.

	The Data project contains domain and generic (CRUD and event-sourcing) repository implementations, DbContexts, EF Core migrations, entity type configurations (if any), event store implementation (including snapshots), data entity to domain object mappings, and persistence related services (i.e. a database initializer service).

	The Resources project contains localized shared resources and resource keys, along with localization services implementations.

	The Shared project contains service implementations for cross-cutting concerns such as user management and authentication, file storage, service bus, localization, application configuration and a password generator.
