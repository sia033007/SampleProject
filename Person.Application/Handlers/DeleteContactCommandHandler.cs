using AutoMapper;
using MediatR;
using Person.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Handlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IContactService _contactService;
        public DeleteContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            await _contactService.DeleteContact(request.id);
            return Unit.Value;
        }
    }
}
