namespace Application.Common.Models.AgGrid
{
    public class SortModel
    {
        public String ColId { set; get; }
        public String Sort { set; get; }

        public SortModel() { }

        public SortModel(String colId, String sort)
        {
            this.ColId = colId;
            this.Sort = sort;
        }
    }
}
