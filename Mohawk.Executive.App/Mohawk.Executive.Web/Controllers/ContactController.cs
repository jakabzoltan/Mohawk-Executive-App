using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Controllers
{
    [ValidateInput(false)]
    [Authorize]
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

        public ActionResult ContactBook()
        {
            return View(ContactHanlder.GetAllContacts());
        }



        // GET: Contact
        public ActionResult ViewContact(Guid id)
        {
            var contact = ContactHanlder.Get(id);
            contact.Opportunities = OpportunityHandler.GetOpportunitiesForContact(id,true);
            return View(contact);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View(new ContactModel());
        }
        [HttpPost]
        public ActionResult AddContact(ContactModel model)
        {
            var contact = ContactHanlder.AddContact(model.FirstName, model.LastName, model.Role, model.PhoneNumber, model.Email, model.Organization, model.Location);
            return RedirectToAction("ViewContact", new{id = contact.Id});
        }
    }
}