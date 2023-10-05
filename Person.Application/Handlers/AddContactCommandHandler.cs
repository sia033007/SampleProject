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
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, Unit>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public AddContactCommandHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contactToSave = _mapper.Map<Contact>(request.contact);
            await _contactService.AddContact(contactToSave);
            return Unit.Value;
        }
    }
}
