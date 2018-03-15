using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mohawk.Executive.Web.Models;
using DonationType = Mohawk.Executive.Services.ViewModels.DonationType;

namespace Mohawk.Executive.Web.Controllers
{
    [Authorize]
    public class OpportunitiesController : Controller
    {

        public IOpportunityHandler OpportunityHandler { get; set; }
        public IContactHanlder ContactHanlder { get; set; }
        public IDonationHandler DonationHandler { get; set; }
        public ISettingsHandler SettingsHandler { get; set; }
        public OpportunitiesController()
        {

        }

        public OpportunitiesController(IOpportunityHandler opportunityHandler, IContactHanlder contactHanlder)
        {
            OpportunityHandler = opportunityHandler;
            ContactHanlder = contactHanlder;
        }

        public ActionResult ViewOpportunity(Guid id)
        {
            var opportunity = OpportunityHandler.Get(id);
            //debug
            if (opportunity == null)
            {
                return View(new Opportunity(){OpportunitySubject = "Get Rich", Value = "This is valuable because I like being rich", ResolvedOn = DateTime.Now, ResolutionReason = "I'm still not rich :("});
            }
            //end debug
            return View(opportunity);
        }
        [HttpGet]
        public ActionResult CreateOpportunity(Guid contactId)
        {

            return View(new Opportunity()
            {
                ContactId = contactId
            });
        }
        [HttpPost]
        public ActionResult CreateOpportunity(Opportunity model)
        {
            var opportunity = OpportunityHandler.AddOpportunity(model.ContactId, model.OpportunitySubject, model.Value, model.OpportunityPriorityId);
            return RedirectToAction("ViewOpportunity", new { id = opportunity.Id });
        }

        [HttpGet]
        public ActionResult QuickCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QuickCreate(Opportunity model)
        {
            var generalContact = ContactHanlder.SearchContacts("General").FirstOrDefault(x=>x.FirstName=="General") ??
                                 ContactHanlder.AddContact("General", null, null, null, null, "Mohawk College", null);

            var opportunity = OpportunityHandler.AddOpportunity(generalContact.Id, model.OpportunitySubject, model.Value, model.OpportunityPriorityId);
            return RedirectToAction("ViewOpportunity", new { id = opportunity.Id });
        }

        public ActionResult ResolveOpportunity(OpportunityResolutionViewModel model)
        {
            OpportunityHandler.ResolveOpportunity(model.OpportunityId, model.ResolutionReason);
            return RedirectToAction("ViewOpportunity", new {id = model.OpportunityId});
        }

        #region Donations
        [HttpGet]
        public ActionResult AddDonation(Guid id)
        {
            //pass through method
            var model = new AddDonationViewModel(id);
                //debug
            if (SettingsHandler != null)
            {
                model.DonationList = SettingsHandler.GetDonationTypes().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.DonationTypeString
                }).ToList();
            }
            if (!model.DonationList.Any())
            {
                model.DonationList.Add(new SelectListItem() {Text = "Oh boy", Value = "1"});
                model.DonationList.Add(new SelectListItem() {Text = "2 Oh boy", Value = "2"});
            }
            return PartialView("_AddDonation",model);
        }
        [HttpPost]
        public ActionResult AddDonation(AddDonationViewModel model)
        {
            return RedirectToAction("ViewOpportunity", new {id = model.OpportunityId});
        }

        #endregion
    }
}