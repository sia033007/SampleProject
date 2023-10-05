using AutoMapper;
using Person.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
