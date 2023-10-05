using AutoMapper;
using MediatR;
using Person.Application.Commands;
using Person.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Handlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public UpdateContactCommandHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contactToUpdate = _mapper.Map<Contact>(request.contact);
            await _contactService.UpdateContact(contactToUpdate);
            return Unit.Value;
        }
    }
}
