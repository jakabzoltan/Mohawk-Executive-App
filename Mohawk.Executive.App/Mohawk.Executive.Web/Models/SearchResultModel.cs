using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class SearchResultModel
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }

        public SearchResultModel()
        {
            Opportunities = new List<Opportunity>();
            Contacts = new List<Contact>();
        }
        public SearchResultModel(IEnumerable<Opportunity> opportunities, IEnumerable<Contact> contacts) : this()
        {
            Opportunities = opportunities;
            Contacts = contacts;
        }
    }
}