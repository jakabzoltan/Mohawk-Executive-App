using System;
using System.Collections.Generic;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IContactHanlder
    {
        Contact AddContact(string name, string role, string phoneNumber, string email, string organizationName, string location);
        bool RemoveContact(Guid id);
        Contact UpdateContact(Guid id, string name, string role, string phoneNumber, string email, string organizationName, string location);
        IEnumerable<Contact> GetAllContacts();
        IEnumerable<Contact> SearchContacts(string queryString);
        Contact Get(Guid id);
    }
}