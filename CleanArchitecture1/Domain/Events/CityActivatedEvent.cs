
namespace Domain.Event
{
    public class CityActivatedEvent : BaseEvent
    {
        public CityActivatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
