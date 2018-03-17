using System;
using System.Collections.Generic;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IContactHanlder
    {
        ContactModel AddContact(string firstName, string lastName, string role, string phoneNumber, string email, string organizationName, string location);
        bool RemoveContact(Guid id);
        ContactModel UpdateContact(Guid id, string firstName, string lastName, string role, string phoneNumber, string email, string organizationName, string location);
        IEnumerable<ContactModel> GetAllContacts();
        IEnumerable<ContactModel> SearchContacts(string queryString);
        ContactModel Get(Guid id);
    }
}