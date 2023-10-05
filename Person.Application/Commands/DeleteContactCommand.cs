using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Commands
{
    public record DeleteContactCommand(int id) : IRequest<Unit>
    {
    }
}
