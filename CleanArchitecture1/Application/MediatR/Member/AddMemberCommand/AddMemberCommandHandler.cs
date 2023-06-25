using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.CreateMemberCommand
{
    public class AddMemberCommandHandler : IRequestHandler<AddMemberCommandModel, Guid>
    {
        public Task<Guid> Handle(AddMemberCommandModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
