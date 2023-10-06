using Person.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task AddContact(Contact contact)
        {
            await _contactRepository.AddContact(contact);
        }

        public async Task DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();
            return contacts;
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _contactRepository.GetContactById(id);
        }

        public async Task UpdateContact(Contact contact)
        {
            await _contactRepository.UpdateContact(contact);
        }
        public async Task<List<DeletedContactDTO>> GetAllDeletedContacts()
        {
            return await _contactRepository.GetAllDeletedContacts();
        }
        public async Task<List<ContactDTO>> LiveSearchForContacts(string search)
        {
            return await _contactRepository.LiveSearchForContacts(search);

        }
        public async Task<List<DeletedContactDTO>> LiveSearchForDeletedContacts(string search)
        {
            return await _contactRepository.LiveSearchForDeletedContacts(search);

        }
        public List<string> GetAllCities()
        {
            return _contactRepository.GetAllCities();
        }
    }
}
