using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mohawk.Executive.Web.Models
{
    public class AttachContact
    {
        public Guid OpportunityId { get; set; }
        public Guid ContactId { get; set; }
        public AttachContact()
        {
            Contacts = new List<SelectListItem>();
        }

        public AttachContact(Guid opportunityId) : this()
        {
            OpportunityId = opportunityId;
        }
        public Guid[] Selected { get; set; }

        public IEnumerable<SelectListItem> Contacts { get; set; }
    }
}