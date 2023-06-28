using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class MemberCreatedEvent : BaseEvent
    {
        public Member member { get; }
        public MemberCreatedEvent(Member _member) 
        {
            member = _member;
        
        }
    }
}
