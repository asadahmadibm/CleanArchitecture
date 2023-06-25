using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.MemberNotification
{
    public class MemberNotificationHandler : INotificationHandler<MemberNotificationModel>
    {
        public async Task Handle(MemberNotificationModel notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Message);
            
        }
    }
}
