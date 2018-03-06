using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }
        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            return View();
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