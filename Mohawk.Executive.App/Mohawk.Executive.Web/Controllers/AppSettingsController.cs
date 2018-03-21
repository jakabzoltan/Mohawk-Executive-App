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
            return PartialView("_DonationTypes");
        }

        public ActionResult AddDonationType()
        {
            return PartialView("_AddDonationType");
        }

        public ActionResult EditDonationType(int donationTypeId)
        {
            return PartialView("_EditDonationType");
        }

        [HttpPost]
        public ActionResult AddDonationType(DonationTypeModel donationType)
        {
            return null;
        }
        public ActionResult EditDonationType(DonationTypeModel donationType)
        {
            return null;
        }

        public ActionResult RemoveDonationType(int id)
        {
            return RedirectToAction("Index");
        }
        #endregion




        #region Priorities

        [HttpGet]
        public ActionResult GetPriorities()
        {
            return PartialView("_Priorities");
        }
       
        public ActionResult AddPriority()
        {
            return PartialView("_AddPriority");
        }

        public ActionResult EditPriority(int priorityId)
        {
            return PartialView("_EditPriority");
        }

        [HttpPost]
        public ActionResult AddPriority(PriorityTypeModel priority)
        {
            return View();
        }
        public ActionResult EditPriority(PriorityTypeModel priority)
        {
            return View();

        }
        public ActionResult RemovePriority(int id)
        {
            return GetPriorities();
        }

        #endregion



    }
}