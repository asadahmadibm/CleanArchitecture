using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.MemberNotification
{
    public class MemberNotificationModel:INotification
    {
        public string   Message { get; set; }
        public MemberNotificationModel(string message)
        {
            Message=message;
        }
    }
}
