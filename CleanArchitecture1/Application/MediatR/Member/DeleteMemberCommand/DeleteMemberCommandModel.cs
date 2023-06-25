using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.DeleteMemberCommand
{
    public class DeleteMemberCommandModel : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
