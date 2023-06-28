using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Event;
using Microsoft.Extensions.Logging;

namespace Application.Cities.EventHandler
{
    public class CityCreatedEventHandler : INotificationHandler<CityCreatedEvent>
    {
        private readonly ILogger<CityActivatedEventHandler> _logger;
        private readonly IEmailService _emailService;

        public CityCreatedEventHandler(ILogger<CityActivatedEventHandler> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task Handle(CityCreatedEvent notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification;

            _logger.LogInformation("cleanarchitecture4 cleanarchitecture4.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            if (domainEvent.City != null)
            {
                await _emailService.SendAsync(new EmailRequest
                {
                    Subject = domainEvent.City.Name + " is created.",
                    Body = "City is created successfully.",
                    FromDisplayName = "Clean Architecture",
                    FromMail = "test@test.com",
                    ToMail = new List<string> { "to@test.com" }
                });
            }
        }
    }
}
