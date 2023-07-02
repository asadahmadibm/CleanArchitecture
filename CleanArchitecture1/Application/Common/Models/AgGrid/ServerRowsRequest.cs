using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.AgGrid
{
    public class ServerRowsRequest
    {
        // start from 0

        [Required]
        public int PageIndex { set; get; }
        [Required]
        public int PageSize { set; get; }

        //public int StartRow { set; get; }

        //public int EndRow { set; get; }

        //// row group columns
        //public List<ColumnVO> RowGroupCols { set; get; }

        //// value columns
        //public List<ColumnVO> ValueCols { set; get; }

        //// pivot columns
        //public List<ColumnVO> PivotCols { set; get; }

        //// true if pivot mode is one, otherwise false
        //public Boolean IsPivotMode { set; get; }

        //// what groups the user is viewing
        //public List<String> GroupKeys { set; get; }


        // if filtering, what the filter model is
        public List<ColumnFilter>? filterModels { get; set; }
        // if sorting, what the sort model is
        public List<SortModel>? sortModels { set; get; }

        //public ServerRowsRequest()
        //{
        //    //RowGroupCols = new List<ColumnVO>();
        //    //ValueCols = new List<ColumnVO>();
        //    ////PivotCols = new List<ColumnVO>();
        //    ////GroupKeys = new List<String>();
        //    //FilterModels = new List<ColumnFilter>();
        //    //SortModels = new List<SortModel>();
        //}

        public ResultMessage checkPageIndexSize()
        {
            ResultMessage resultDTO = new ResultMessage();
            #region Check PageNumber

            if (PageIndex < 1)
            {
                resultDTO.errors.Add(new ErrorDTO()
                {
                    code = ErrorEnum.Status90010.ToString(),
                    Desc = ErrorEnum.Status90010.ToString()
                });
                return resultDTO;
            }
            #endregion
            #region check PageSize
            if (PageSize < 1)
            {
                resultDTO.errors.Add(new ErrorDTO()
                {
                    code = ErrorEnum.Status90011.ToString(),
                    Desc = ErrorEnum.Status90011.ToString()
                });
                return resultDTO;
            }
            if (PageSize > 50)
            {
                resultDTO.errors.Add(new ErrorDTO()
                {
                    code = ErrorEnum.Status90013.ToString(),
                    Desc = ErrorEnum.Status90013.ToString()
                });
                return resultDTO;
            }
            #endregion

            return resultDTO;
        }


    }
}
