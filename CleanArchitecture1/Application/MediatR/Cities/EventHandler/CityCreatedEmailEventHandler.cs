using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Event;
using Microsoft.Extensions.Logging;

namespace Application.Cities.EventHandler
{
    public class CityCreatedEmailEventHandler : INotificationHandler<CityCreatedEvent>
    {
        private readonly IEmailService _emailService;

        public CityCreatedEmailEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(CityCreatedEvent notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification;

            if (domainEvent.City != null)
            {
                await _emailService.SendAsync(new EmailRequest
                {
                    Subject = domainEvent.City.Name + " is created.",
                    Body = "City is created successfully.",
                    FromDisplayName = "Clean Architecture",
                    FromMail = "test@test.com",
                    ToMail = new List<string> { "asad.ahmadi.bm@gmail.com" }
                });
            }
        }
    }
}
