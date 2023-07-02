
namespace Application.Common.Models.AgGrid
{
    public class ServerRowsResponse
    {
        //public DataTable Data { get; set; }
        public Object list { get; set; }
        //public int LastRow { get; set; }
        public int totalCount { get; set; }
        //public List<String> SecondaryColumnFields { get; set; }

        public ServerRowsResponse() { }

        //public ServerRowsResponse(DataTable data, List<String> secondaryColumnFields, int lastRow, int totalCount)
        //{
        //    this.Data = data;
        //    //this.LastRow = lastRow;
        //    this.TotalCount = totalCount;
        //    //this.SecondaryColumnFields = secondaryColumnFields;
        //}

    }
}
