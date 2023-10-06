using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Person.Application;
using Person.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(ContactDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddContact(Contact contact)
        {
            DateTime now = DateTime.Now;
            contact.CreatedTime = PersianDate(now);
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            contact.IsDeleted = true;
            var deletedContact = _mapper.Map<DeletedContactDTO>(contact);
            var dataToAddToDb = _mapper.Map<DeletedContact>(deletedContact);
            await _context.DeletedContacts.AddAsync(dataToAddToDb);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            var movie = await _context.Contacts.FindAsync(id);
            return movie;
        }

        public async Task UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.Entry(contact).Property(x => x.CreatedTime).IsModified = false;
            await _context.SaveChangesAsync();
        }
        public async Task<List<DeletedContact>> GetAllDeletedContacts()
        {
            var contacts = await _context.DeletedContacts.ToListAsync();
            return contacts;
        }
        string PersianDate(DateTime DateTime1)
        {
            PersianCalendar PersianCalendar1 = new PersianCalendar();
            return string.Format(@"{0}/{1}/{2}",
                         PersianCalendar1.GetYear(DateTime1),
                         PersianCalendar1.GetMonth(DateTime1),
                         PersianCalendar1.GetDayOfMonth(DateTime1));
        }
    }
}
