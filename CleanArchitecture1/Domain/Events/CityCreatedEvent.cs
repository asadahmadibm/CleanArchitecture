
namespace Domain.Event
{
    public class CityCreatedEvent : BaseEvent
    {
        public CityCreatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
