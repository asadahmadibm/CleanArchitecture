using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.Commands.AddMemberCommand
{
    public class AddMemberCommandModel : IRequest<Guid>
    {
    }
}
