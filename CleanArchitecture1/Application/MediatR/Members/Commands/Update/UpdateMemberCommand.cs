using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.Commands.UpdateMemberCommand
{
    public class UpdateMemberCommand : IRequestWrapper<Guid>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
    public class UpdateMemberCommandHandler : IRequestHandlerWrapper<UpdateMemberCommand, Guid>
    {
        public Task<ServiceResult<Guid>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
