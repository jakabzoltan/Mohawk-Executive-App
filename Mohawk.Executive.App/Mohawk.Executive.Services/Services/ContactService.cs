using System;
using System.Linq;
using Mohawk.Executive.Database;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Services.Enumerables;
using Mohawk.Executive.Services.Interfaces;

namespace Mohawk.Executive.Services.Services
{
    public class ContactService : IContactHanlder
    {
        private readonly ExecutiveContext _context;

        public ContactService(ExecutiveContext context)
        {
            _context = context;
        }
        public bool AddContact(string name, string role, string phoneNumber, string email, string organizationName, string location)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = name,
                Role = role,
                PhoneNumber = phoneNumber,
                Email = email,
                Organization = organizationName,
                Location = location
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return true;
        }

        public bool RemoveContact(Guid id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return false;

            contact.ModifiedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public bool UpdateContact(Guid id, string name, string role, string phoneNumber, string email, string organizationName,
            string location)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return false;
            contact.Name = name;
            contact.Role = role;
            contact.PhoneNumber = phoneNumber;
            contact.Email = email;
            contact.Organization = organizationName;
            contact.Location = location;
            contact.ModifiedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public void GetAllContacts()
        {
            
        }

        public void SearchContacts(string queryValues, params SearchFilter[] searchFilters)
        {
            throw new NotImplementedException();
        }
    }
}