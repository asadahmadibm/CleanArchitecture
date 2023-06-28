namespace Application.Dto
{
    public class DistrictDto 
    {
        public DistrictDto()
        {
            Villages = new List<VillageDto>();
        }
        public int Id { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        public IList<VillageDto> Villages { get; set; }

       
    }
}
