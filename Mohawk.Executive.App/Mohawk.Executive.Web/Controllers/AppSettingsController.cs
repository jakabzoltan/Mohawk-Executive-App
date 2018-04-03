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

        public AppSettingsController()
        {

        }

        public AppSettingsController(ISettingsHandler settings)
        {
            SettingsHandler = settings;
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