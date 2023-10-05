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
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactDTO>>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public GetAllContactsQueryHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<List<ContactDTO>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactService.GetAllContacts();
            var contactsToShow = new List<ContactDTO>();

            foreach(var contact in contacts)
            {
                var dto = _mapper.Map<ContactDTO>(contact);
                contactsToShow.Add(dto);
            }
            return contactsToShow;
        }
    }
}
