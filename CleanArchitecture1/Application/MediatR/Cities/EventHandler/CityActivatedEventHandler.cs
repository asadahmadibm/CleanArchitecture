
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Event;
using Microsoft.Extensions.Logging;

namespace Application.Cities.EventHandler
{
    public class CityActivatedEventHandler : INotificationHandler<CityActivatedEvent>
    {
        private readonly ILogger<CityActivatedEventHandler> _logger;
        private readonly IEmailService _emailService;

        public CityActivatedEventHandler(ILogger<CityActivatedEventHandler> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task Handle(CityActivatedEvent notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("cleanarchitecture4 cleanarchitecture4.Domain Event: {DomainEvent}", notification.GetType().Name);

            if (notification.City != null)
            {
                await _emailService.SendAsync(new EmailRequest
                {
                    Subject = notification.City.Name + " is activated.",
                    Body = "City is activated successfully.",
                    FromDisplayName = "Clean Architecture",
                    FromMail = "test@test.com",
                    ToMail = new List<string> { "to@test.com" }
                });
            }
        }
    }
}
