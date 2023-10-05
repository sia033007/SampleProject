using Person.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(int id);
        Task<List<DeletedContact>> GetAllDeletedContacts();
    }
}
