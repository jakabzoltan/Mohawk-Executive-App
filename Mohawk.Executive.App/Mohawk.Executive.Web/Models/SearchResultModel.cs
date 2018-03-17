using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class SearchResultModel
    {
        public IEnumerable<OpportunityModel> Opportunities { get; set; }
        public IEnumerable<ContactModel> Contacts { get; set; }

        public SearchResultModel()
        {
            Opportunities = new List<OpportunityModel>();
            Contacts = new List<ContactModel>();
        }
        public SearchResultModel(IEnumerable<OpportunityModel> opportunities, IEnumerable<ContactModel> contacts) : this()
        {
            Opportunities = opportunities;
            Contacts = contacts;
        }
    }
}