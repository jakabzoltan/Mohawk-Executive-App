using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Mohawk.Executive.Database;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Services.Interfaces;

namespace Mohawk.Executive.Services.Services
{
    public class ContactService : IContactHanlder
    {
        private readonly ExecutiveContext _context;

        public ContactService()
        {
            _context = ExecutiveContext.Create();
        }

        public ViewModels.Contact AddContact(string firstName, string lastName, string role, string phoneNumber, string email, string organizationName,
            string location)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Role = role,
                PhoneNumber = phoneNumber,
                Email = email,
                Organization = organizationName,
                Location = location
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Get(contact.Id);
        }

        public bool RemoveContact(Guid id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return false;

            contact.ModifiedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public ViewModels.Contact UpdateContact(Guid id, string firstName, string lastName, string role, string phoneNumber, string email,
            string organizationName,
            string location)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return null;
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Role = role;
            contact.PhoneNumber = phoneNumber;
            contact.Email = email;
            contact.Organization = organizationName;
            contact.Location = location;
            contact.ModifiedOn = DateTime.Now;
            _context.SaveChanges();
            return Get(contact.Id);
        }

        public IEnumerable<ViewModels.Contact> GetAllContacts()
        {
            return _context.Contacts.Where(c => c.ModifiedOn == null).Select(c => new ViewModels.Contact()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                ModifiedOn = c.ModifiedOn,
                Location = c.Location,
                Organization = c.Organization,
                PhoneNumber = c.PhoneNumber,
                Role = c.Role
            })
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .ThenBy(x => x.Organization)
            .ThenBy(x => x.Location)
            .ThenBy(x => x.Email);
        }

        public IEnumerable<ViewModels.Contact> SearchContacts(string queryString)
        {
            return _context.Contacts
                .Where(c => c.ModifiedOn == null)
                .Where(c => c.FirstName.Contains(queryString) ||
                            c.LastName.Contains(queryString) ||
                            c.Email.Contains(queryString) ||
                            c.Location.Contains(queryString) ||
                            c.Organization.Contains(queryString))
                .Select(c =>
                    new ViewModels.Contact
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        ModifiedOn = c.ModifiedOn,
                        Location = c.Location,
                        Organization = c.Organization,
                        PhoneNumber = c.PhoneNumber,
                        Role = c.Role
                    })
                .OrderBy(x => x.FirstName)
                .ThenBy(x=>x.LastName)
                .ThenBy(x => x.Organization)
                .ThenBy(x => x.Location)
                .ThenBy(x => x.Email);
        }

        public ViewModels.Contact Get(Guid id)
        {
            return _context.Contacts.Where(c => c.ModifiedOn == null && c.Id == id).Select(c => new ViewModels.Contact()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                ModifiedOn = c.ModifiedOn,
                Location = c.Location,
                Organization = c.Organization,
                PhoneNumber = c.PhoneNumber,
                Role = c.Role
            })
            .OrderBy(x => x.FirstName)
            .ThenBy(x=>x.LastName)
            .ThenBy(x => x.Organization)
            .ThenBy(x => x.Location)
            .ThenBy(x => x.Email)
            .FirstOrDefault();
        }
    }
}