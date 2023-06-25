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

#MediatR
-------------------
nuget MediatR & MediatR.Extensions.Microsoft.DependencyInjection

In Program : builder.Services.AddMediatR(typeof(EmptyClassForAssemblyMediatr).GetTypeInfo().Assembly);

## Send Request & Return Response

1- Make ModelRequest & ModelResponse & Handler

	 public class RequestModel : IRequest<ResponseModel>
	    {
	    }

	public class ResponseModel ()
	 {
  		//props
	 }
  
      public class CommandHandler : IRequestHandler<RequestModel, ResponseModel>
	    {
	        public Task<Guid> Handle(RequestModel request, CancellationToken cancellationToken)
	        {
	            throw new NotImplementedException();
	        }
	    }

2- use  
	
 	private readonly IMediator _mediator;
        
	public MembersController(IMediator mediator)
        {
            _mediator= mediator;
        }

	 [HttpPost]
	        public async Task<ActionResult<IList<Member>>> Get()
	        {
	            return Ok(await _mediator.Send(new RequestModel()));
	        }

## Inotification for send request & not response 

1- Make NotificationModel & Handler

	public class MemberNotificationModel:INotification
	    {
	        public string   Message { get; set; }
	        public MemberNotificationModel(string message)
	        {
	            Message=message;
	        }
	    }
	}

 	public class MemberNotificationHandler : INotificationHandler<MemberNotificationModel>
	    {
	        public async Task Handle(MemberNotificationModel notification, CancellationToken cancellationToken)
	        {
	            Console.WriteLine(notification.Message);
	            
	        }
	    }

2- Use  

	await _mediator.Publish(new MemberNotificationModel("hello"));

 ## PipelineBehaviour Execute Before And After Request 

 1- Make Class

 	public class TracingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	    {
	        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
	        {
	            Console.WriteLine("Tracing Behaviour request : " + request.ToString());
	            var res = await next();
	            Console.WriteLine("Tracing Behaviour response : " + res.ToString());
	            return res;
	        }
	    }

2- Define In Program

	builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(TracingBehaviour<,>));



 
