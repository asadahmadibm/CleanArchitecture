using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class MemberGetAllEvent : BaseEvent
    {
        public Member member { get; }
        public MemberGetAllEvent(Member _member) 
        {
            member = _member;
        
        }
    }
}
