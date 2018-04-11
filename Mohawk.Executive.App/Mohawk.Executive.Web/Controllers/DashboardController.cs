using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.Services;
using Mohawk.Executive.Services.ViewModels;
using Mohawk.Executive.Web.Models;

namespace Mohawk.Executive.Web.Controllers
{
    [ValidateInput(false)]
    [Authorize]
    public class DashboardController : Controller
    {
        public IContactHanlder ContactHanlder { get; set; }
        public IOpportunityHandler OpportunityHandler { get; set; }
        public DashboardController()
        {

        }

        public DashboardController(IContactHanlder contactHanlder, IOpportunityHandler opportunityHandler)
         {
            ContactHanlder = contactHanlder;
            OpportunityHandler = opportunityHandler;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var contacts = ContactHanlder.GetAllContacts();
            var opps = OpportunityHandler.GetOpportunities();
            var searchResults = new SearchResultModel()
            {
                Contacts = contacts,
                Opportunities = opps,
            };
            return View(searchResults);
        }

        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            if (model.Query.IsNullOrWhiteSpace())
            {
                var allContacts = ContactHanlder.GetAllContacts();
                var allOpps = OpportunityHandler.GetOpportunities();
                var results = new SearchResultModel()
                {
                    Contacts = allContacts,
                    Opportunities = allOpps,
                };
                return View(results);
            }


            var contacts = ContactHanlder.SearchContacts(model.Query);
            var opps = OpportunityHandler.SearchOpportunities(model.Query);
            var searchResults = new SearchResultModel()
            {
                Contacts = contacts,
                Opportunities = opps,
            };
            return View(searchResults);
        }
    }
}