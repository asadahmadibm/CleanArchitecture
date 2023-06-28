
namespace Application.Dto
{
    public class CityDto 
    {
        public CityDto()
        {
            Districts = new List<DistrictDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CreateDate { get; set; }

        public bool Active { get; set; }

        public IList<DistrictDto> Districts { get; set; }

       
    }
}
