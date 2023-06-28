using System.Collections.Generic;
using Domain.Common;
using Domain.Event;

namespace Domain.Entities
{
    public class City : BaseAuditableEntity
    {
        public City()
        {
            Districts = new List<District>();
        }

        public int Id { get; set; }

        public string Name { get; set; }


        public IList<District> Districts { get; set; }

        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                if (value && _active == false)
                {
                    AddDomainEvent(new CityActivatedEvent(this));
                }

                _active = value;
            }
        }

    }
}
