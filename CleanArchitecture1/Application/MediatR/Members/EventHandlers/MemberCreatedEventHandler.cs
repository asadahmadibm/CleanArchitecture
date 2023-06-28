using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.TodoItems.EventHandlers;

public class MemberCreatedEventHandler : INotificationHandler<MemberCreatedEvent>
{
    private readonly ILogger<MemberCreatedEventHandler> _logger;

    public MemberCreatedEventHandler(ILogger<MemberCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(MemberCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
