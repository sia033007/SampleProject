using AutoMapper;
using MediatR;
using Person.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Handlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactDTO>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public GetContactByIdQueryHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<ContactDTO> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactService.GetContactById(request.id);
            var contactToShow = _mapper.Map<ContactDTO>(contact);

            return contactToShow;
        }
    }
}
