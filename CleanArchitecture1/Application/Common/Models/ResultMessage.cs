
using System.Text.Json;

namespace Application.Common.Models
{
    public class ResultMessage
    {
        public ResultMessage()
        {
            errors = new List<ErrorDTO>();
        }
        ///// <summary>
        ///// کد وضعیت
        ///// </summary>
        ///// <example>200 Ok</example>
        //public int statusCode { get; set; }
        /// <summary>
        /// لیست خطاها
        /// </summary>
        public List<ErrorDTO> errors { get; set; }
        /// <summary>
        /// خروجی داده
        /// </summary>
        public object data { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
