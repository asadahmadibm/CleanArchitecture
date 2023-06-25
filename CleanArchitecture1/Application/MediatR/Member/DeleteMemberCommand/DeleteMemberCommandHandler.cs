using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.DeleteMemberCommand
{
    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommandModel, Guid>
    {
        public Task<Guid> Handle(DeleteMemberCommandModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
