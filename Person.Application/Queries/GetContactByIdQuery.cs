using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Queries
{
    public record GetContactByIdQuery(int id) : IRequest<ContactDTO>
    {
    }
}
