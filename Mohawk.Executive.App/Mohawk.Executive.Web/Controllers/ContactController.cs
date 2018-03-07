using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mohawk.Executive.Services.Interfaces;

namespace Mohawk.Executive.Web.Controllers
{
    public class ContactController : Controller
    {
        public IContactHanlder ContactHanlder { get; set; }
        public IOpportunityHandler OpportunityHandler { get; set; }
        public ContactController()
        {

        }

        public ContactController(IContactHanlder contactHanlder, IOpportunityHandler opportunityHandler)
        {
            ContactHanlder = contactHanlder;
            OpportunityHandler = opportunityHandler;
        }
        // GET: Contact
        public ActionResult ViewContact(Guid id)
        {
            var contact = ContactHanlder.Get(id);
            contact.Opportunities = OpportunityHandler.GetOpportunitiesForContact(id);
            return View(contact);
        }
    }
}