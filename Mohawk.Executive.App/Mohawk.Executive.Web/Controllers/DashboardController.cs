using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.Services;
using Mohawk.Executive.Web.Models;

namespace Mohawk.Executive.Web.Controllers
{
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
            return View(contacts);
        }
        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            if (model.Query.IsNullOrWhiteSpace())
            {
                return View(ContactHanlder.GetAllContacts());
            }
            var contacts = ContactHanlder.SearchContacts(model.Query);
            return View(contacts);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}