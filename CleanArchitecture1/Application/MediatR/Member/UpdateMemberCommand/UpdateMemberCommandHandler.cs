using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.UpdateMemberCommand
{
    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommandModel, Guid>
    {
        public Task<Guid> Handle(UpdateMemberCommandModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
