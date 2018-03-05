using System;
using Mohawk.Executive.Services.Enumerables;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IContactHanlder
    {
        bool AddContact(string name, string role, string phoneNumber, string email, string organizationName, string location);
        bool RemoveContact(Guid id);
        bool UpdateContact(Guid id, string name, string role, string phoneNumber, string email, string organizationName, string location);
        void GetAllContacts();
        void SearchContacts(string queryValues, params SearchFilter[] searchFilters);
    }
}