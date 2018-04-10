using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mohawk.Executive.Services.ViewModels;
using Mohawk.Executive.Web.Models;
using Mohawk.Executive.Services.Interfaces;

namespace Mohawk.Executive.Web.Controllers
{
    [Authorize]
    public class AppSettingsController : Controller
    {
        // GET: AppSettings
        public ISettingsHandler SettingsHandler { get; set; }
        public IOpportunityHandler OpportunityHandler { get; set; }

        public AppSettingsController()
        {

        }

        public AppSettingsController(ISettingsHandler settings, IOpportunityHandler opportunities)
        {
            SettingsHandler = settings;
            OpportunityHandler = opportunities;
        }
        public ActionResult Index()
        {
            return View();
        }


        #region DonationTypes

        [HttpGet]
        public ActionResult GetDonationTypes()
        {
            var donationTypes = SettingsHandler.GetDonationTypes();

            return PartialView("_DonationTypes", donationTypes);
        }

        [HttpPost]
        public ActionResult AddDonationType(DonationTypeModel donationType)
        {
            SettingsHandler.AddDonationType(donationType.DonationTypeString);
            return RedirectToAction("Index"); ;
        }


        [HttpGet]
        public ActionResult ConfirmRemoveDonationType(int id)
        {
            var opportunityIds = SettingsHandler.GetAssociatedOpportunities(id);
            var opportunities = OpportunityHandler.GetOpportunities().Where(opp => opportunityIds.Contains(opp.Id));
            var model = new DontationTypeOpportunitiesViewModel()
            {
                Id = id,
                Opportunities = opportunities
            };

            return PartialView("_RemoveDonationType", model); ;
        }

        [HttpPost]
        public ActionResult RemoveDonationType(int id)
        {
            SettingsHandler.RemoveDonationType(id);
            return RedirectToAction("Index");
        }
        public ActionResult EditDonationType(DonationTypeModel model)
        {
            SettingsHandler.EditDonationType(model.Id, model.DonationTypeString);
            return RedirectToAction("Index");
        }
        #endregion




        #region Priorities

        [HttpGet]
        public ActionResult GetPriorities()
        {
            var priTypes = SettingsHandler.GetPriorities();
            return PartialView("_Priorities", priTypes);
        }

        [HttpPost]
        public ActionResult AddPriority(PriorityTypeModel priority)
        {
            SettingsHandler.AddPriorityType(priority.PriorityString);
            return RedirectToAction("Index");
        }
        public ActionResult RemovePriority(int id)
        {
            SettingsHandler.RemovePriorityType(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditPriorityType(PriorityTypeModel model)
        {
            SettingsHandler.EditPriorityType(model.Id, model.PriorityString);
            return RedirectToAction("Index");
        }
        #endregion



    }
}