using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Mohawk.Executive.Services.Services;
using Mohawk.Executive.Web.Models;
using DonationType = Mohawk.Executive.Services.ViewModels.DonationTypeModel;

namespace Mohawk.Executive.Web.Controllers
{
    [Authorize]
    public class OpportunitiesController : Controller
    {
        public IOpportunityHandler OpportunityHandler { get; set; }
        public IContactHanlder ContactHanlder { get; set; }
        public IDonationHandler DonationHandler { get; set; }
        public ISettingsHandler SettingsHandler { get; set; }
        public IStepHandler StepHandler { get; set; }
        public ICommentHandler CommentHandler { get; set; }

        public OpportunitiesController()
        {
            if (OpportunityHandler == null)
                OpportunityHandler = new OpportunityService();
            if (ContactHanlder == null)
                ContactHanlder = new ContactService();
            if (DonationHandler == null)
                DonationHandler = new DonationService();
            if (SettingsHandler == null)
                SettingsHandler = new SettingsService();
            if (StepHandler == null)
                StepHandler = new StepService();
            if (CommentHandler == null)
                CommentHandler = new CommentService();
        }

        public OpportunitiesController(IOpportunityHandler opportunityHandler, IContactHanlder contactHanlder,
            IDonationHandler donationHandler, ISettingsHandler settingsHandler, IStepHandler stepHandler,
            ICommentHandler commentHandler) : this()
        {
            OpportunityHandler = opportunityHandler;
            ContactHanlder = contactHanlder;
            DonationHandler = donationHandler;
            SettingsHandler = settingsHandler;
            StepHandler = stepHandler;
            CommentHandler = commentHandler;
        }

        public ActionResult ViewOpportunity(Guid id, string activeTab = null)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            var opportunity = OpportunityHandler.Get(id, true);
            opportunity.ActiveTab = activeTab;
            return View(opportunity);
        }

        [HttpGet]
        public ActionResult CreateOpportunity(Guid contactId)
        {
            var model = new OpportunityCreateViewModel
            {
                PrioritiesList = SettingsHandler.GetPriorities().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.PriorityString
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOpportunity(OpportunityCreateViewModel model)
        {
            var opportunity = OpportunityHandler.AddOpportunity(model.ContactId,model.Description, model.Subject, model.EstimatedValue,
                model.Selected.FirstOrDefault(), User.Identity.GetUserId());
            return RedirectToAction("ViewOpportunity", new {id = opportunity.Id});
        }

        [HttpGet]
        public ActionResult QuickCreate()
        {
            var model = new OpportunityCreateViewModel
            {
                PrioritiesList = SettingsHandler.GetPriorities().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.PriorityString
                }).ToList()
            };


            #region debug

            if (!model.PrioritiesList.Any())
            {
                ((List<SelectListItem>) model.PrioritiesList).Add(new SelectListItem()
                {
                    Value = "0",
                    Text = "Unimportant"
                });
                ((List<SelectListItem>) model.PrioritiesList).Add(new SelectListItem()
                {
                    Value = "1",
                    Text = "Important"
                });
            }

            #endregion

            return View(model);
        }

        [HttpPost]
        public ActionResult QuickCreate(OpportunityCreateViewModel model)
        {
            var generalContact =
                ContactHanlder.SearchContacts("General").FirstOrDefault(x => x.FirstName == "General") ??
                ContactHanlder.AddContact("General", null, null, null, null, "Mohawk College", null);

            var opportunity = OpportunityHandler.AddOpportunity(generalContact.Id, model.Subject,model.Description,
                model.EstimatedValue, model.Selected.FirstOrDefault(), User.Identity.GetUserId());
            return RedirectToAction("ViewOpportunity", new {id = opportunity.Id});
        }

        public ActionResult ResolveOpportunity(OpportunityResolutionViewModel model)
        {
            OpportunityHandler.ResolveOpportunity(model.OpportunityId, model.ResolutionReason);
            return RedirectToAction("ViewOpportunity", new {id = model.OpportunityId});
        }
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var opp = OpportunityHandler.Get(id);

            var model =  new OpportunityCreateViewModel
            {
                Id = id,
                Subject = opp.Subject,
                EstimatedValue = opp.EstimatedValue,
                Description = opp.Description,
                PrioritiesList = SettingsHandler.GetPriorities().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.PriorityString,
                    Selected = opp.PriorityId == x.Id
                }).ToList()
            };
            return PartialView("_EditOpportunity", model);
        }
        [HttpPost]
        public ActionResult Edit(OpportunityCreateViewModel model)
        {
            return RedirectToAction("ViewOpportunity", new {id = model.Id});
        }

        #region Donations

        [HttpGet]
        public ActionResult AddDonation(Guid id)
        {
            //pass through method
            var model = new AddDonationViewModel(id)
            {
                DonationList = SettingsHandler.GetDonationTypes().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.DonationTypeString
                }).ToList()
            };


            return PartialView("_AddDonation", model);
        }

        [HttpPost]
        public ActionResult AddDonation(AddDonationViewModel model)
        {
            DonationHandler.AddDonation(model.OpportunityId, model.DonationText, model.Selected);
            return RedirectToAction("ViewOpportunity", new {id = model.OpportunityId, activeTab = "donations-tab"});
        }

        public ActionResult RenderEditDonation(AddDonationViewModel model)
        {
            //pass through method

            model.DonationList = SettingsHandler.GetDonationTypes().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.DonationTypeString,
                Selected = model.Selected.Contains(x.Id)
            }).ToList();


            return PartialView("_EditDonation", model);
        }

        public ActionResult EditDonation(AddDonationViewModel model)
        {
            DonationHandler.UpdateDonation(model.Id, model.DonationText, model.Selected);
            return RedirectToAction("ViewOpportunity", new { id = model.OpportunityId, activeTab = "donations-tab" });
        }

        public ActionResult RemoveDonation(int id, Guid opportunityId)
        {
            DonationHandler.RemoveDonation(id);
            return RedirectToAction("ViewOpportunity", new { id = opportunityId, activeTab = "donations-tab" });
        }
        #endregion

        #region Steps

        public ActionResult AddStep(OpportunityStepModel model)
        {
            StepHandler.AddStep(model.OpportunityId, model.Step);
            return RedirectToAction("ViewOpportunity", new {id = model.OpportunityId, activeTab = "steps-tab"});
        }

        #endregion

        #region Comments

        [HttpGet]
        public ActionResult PostComment(Guid opportunityId, Guid? replyToId)
        {
            var model = new CommentViewModel(opportunityId, replyToId)
            {
                PostedBy = new IdentityUserModel()
                {
                    GuidUserId = User.Identity.GetUserId(),
                    Name = User.Identity.GetUserName()
                }
            };

            return PartialView("_PostComment", model);
        }

        //TODO implement signalr
        [HttpPost]
        public ActionResult PostComment(CommentViewModel model)
        {
            CommentHandler.AddComment(model.OpportunityId, model.CommentString, User.Identity.GetUserId(),
                model.ReplyToId);
            return RedirectToAction("ViewOpportunity", new {id = model.OpportunityId, activeTab = "comments-tab"});
        }

        #endregion

        #region AttachContact

        public ActionResult RenderAttachContact(Guid id)
        {
            var model = new AttachContact(id)
            {
                Contacts = ContactHanlder.GetAllContacts().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.FirstName} {x.LastName} -- {x.Organization}"
                }).ToList()
            };

            return PartialView("_AttachContact", model);
        }

        public ActionResult AttachContact(AttachContact model)
        {
            OpportunityHandler.AttachContactToOpportunity(model.OpportunityId, model.Selected.FirstOrDefault());
            return RedirectToAction("ViewOpportunity", new {id = model.OpportunityId});
        }

        #endregion
    }
}