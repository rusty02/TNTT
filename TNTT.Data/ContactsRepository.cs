using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTT.Data.Contracts;
using TNTT.Model;

namespace TNTT.Data
{
    public class ContactsRepository : EFRepository<Contact>, IContactsRepository
    {
        public ContactsRepository(DbContext context) : base(context) { }

        public IQueryable<Contact> GetContacts()
        {
            var test = DbSet;
            return test;

        }
    }
}
