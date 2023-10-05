using AutoMapper;
using Person.Application;
using Person.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DeletedContact, DeletedContactDTO>().ReverseMap();
        }
    }
}
