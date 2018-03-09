using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mohawk.Executive.Web.Controllers
{
    [Authorize]
    public class OpportunitiesController : Controller
    {

        public IOpportunityHandler OpportunityHandler { get; set; }
        public OpportunitiesController()
        {

        }

        public OpportunitiesController(IOpportunityHandler opportunityHandler)
        {
            OpportunityHandler = opportunityHandler;
        }
        // GET: Opportunities
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOpportunity(Guid id)
        {
            var opportunity = OpportunityHandler.Get(id);
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
            return View();
        }
    }
}