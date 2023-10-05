using Microsoft.EntityFrameworkCore;
using Person.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure
{
    public class ContactDbContext : DbContext, IContactDbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DeletedContact> DeletedContacts { get; set; }
    }
}
