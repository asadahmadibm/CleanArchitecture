using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.AgGrid
{
    public class ColumnFilter
    {
        public string Field { get; set; }
        public string? FilterOperator { get; set; }
        public ConditionFilterModel? Condition1 { get; set; }
        public ConditionFilterModel? Condition2 { get; set; }

        public ColumnFilter()
        {
            Condition1 = new ConditionFilterModel();
            Condition2 = new ConditionFilterModel();
        }
    }
}
