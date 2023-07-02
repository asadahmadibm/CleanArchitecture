
namespace Application.Common.Models.AgGrid
{
    public class ConditionFilterModel
    {
        public string filterType { get; set; }   //TEXT NUMBER  DATE  SET

        public string? type { get; set; } //EQUALS  NOT_EQUAL  STARTS_WITH , ....

        public string? filter { get; set; }

        public string? FilterTo { get; set; }

        public string? DateFrom { get; set; }

        public string? DateTo { get; set; }

        public List<string>? values { get; set; }

        public ConditionFilterModel()
        {
            type = string.Empty;
            filter = string.Empty;
            FilterTo = string.Empty;
            filterType = string.Empty;
            DateFrom = string.Empty;
            DateTo = string.Empty;
            //Values = string.Empty;
        }
    }
}
