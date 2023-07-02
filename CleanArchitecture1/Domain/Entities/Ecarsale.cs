using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Ecarsale
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string family { get; set; }
        [Required]
        public string mellicode { get; set; }
        [Required]
        public string shenasnameno { get; set; }
        [Required]
        public string birthdate { get; set; }
        [Required]
        public string sodoordate { get; set; }
        [Required]
        public string fathername { get; set; }
        [Required]
        public int sex { get; set; }
        public string mobile { get; set; }
        public string tel { get; set; }
        public string posticode { get; set; }
        public int ostansodoor { get; set; }
        public int citysodoor { get; set; }
        public int birthostan { get; set; }
        public int birthcity { get; set; }
        public int ostansokoonat { get; set; }
        public int citysokoonat { get; set; }
        public string khiyaban { get; set; }
        public string kooche { get; set; }
        public string pelak { get; set; }
        public string mantaghecode { get; set; }
        public string address { get; set; }
    }
}
