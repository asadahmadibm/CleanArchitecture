using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public static List<Domain.Member> lstMembers = new List<Domain.Member>()
        {
           new Domain.Member{  Id =1 ,Name= "Kirtesh Shah", Type ="G" , Address="Vadodara"},
           new Domain.Member{  Id =2 ,Name= "Mahesh Shah", Type ="S" , Address="Dabhoi"},
           new Domain.Member{  Id =3 ,Name= "Nitya Shah", Type ="G" , Address="Mumbai"},
           new Domain.Member{  Id =4 ,Name= "Dilip Shah", Type ="S" , Address="Dabhoi"},
           new Domain.Member{  Id =5 ,Name= "Hansa Shah", Type ="S" , Address="Dabhoi"},
           new Domain.Member{  Id =6 ,Name= "Mita Shah", Type ="G" , Address="Surat"}
        };
        public List<Domain.Member> GetAllMembers()
        {
            return lstMembers;
        }
    }
}
