using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mohawk.Executive.Services.ViewModels;
using Mohawk.Executive.Web.Models;

namespace Mohawk.Executive.Web.Controllers
{
    [Authorize]
    public class AppSettingsController : Controller
    {
        // GET: AppSettings
        public ActionResult Index()
        {
            return View();
        }

        #region DonationTypes

        public ActionResult GetDonationTypes()
        {
            return PartialView("_DonationTypes");
        }


        public ActionResult AddDonationType()
        {
            return View();
        }

        public ActionResult EditDonationType(int donationTypeId)
        {
            return View();
        }


        public ActionResult AddDonationType(DonationType donationType)
        {
            return null;
        }
        public ActionResult EditDonationType(DonationType donationType)
        {
            return null;
        }

        public ActionResult RemoveDonationType(int id)
        {
            return RedirectToAction("Index");
        }
        #endregion




        #region Priorities

        public ActionResult GetPriorities()
        {
            return PartialView("_Priorities");
        }

        public ActionResult AddPriority()
        {
            return View();
        }

        public ActionResult EditPriority(int priorityId)
        {
            return View();
        }
        public ActionResult AddPriority(OpportunityPriority priority)
        {
            return View();
        }
        public ActionResult EditPriority(OpportunityPriority priority)
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