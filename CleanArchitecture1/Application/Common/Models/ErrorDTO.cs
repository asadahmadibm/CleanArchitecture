using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ErrorDTO
    {
        public ErrorDTO()
        {
            //parameters = new List<string>();
        }

        public ErrorDTO(string? key, string message)
        {
            //parameters = new List<string>();
            code = key;
            Desc = message;
        }

        public string code { get; set; }

        public string Desc { get; set; }

        //public List<string> parameters { get; set; }
    }
}
