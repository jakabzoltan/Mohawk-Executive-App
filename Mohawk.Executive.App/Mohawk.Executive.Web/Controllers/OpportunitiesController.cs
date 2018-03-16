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
        }

        public OpportunitiesController(IOpportunityHandler opportunityHandler, IContactHanlder contactHanlder, IDonationHandler donationHandler, ISettingsHandler settingsHandler, IStepHandler stepHandler, ICommentHandler commentHandler) : this()
        {
            OpportunityHandler = opportunityHandler;
            ContactHanlder = contactHanlder;
            DonationHandler = donationHandler;
            SettingsHandler = settingsHandler;
            StepHandler = stepHandler;
            CommentHandler = commentHandler;
        }
        public ActionResult ViewOpportunity(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            var opportunity = OpportunityHandler.Get(id,true);

            #region Debug
            if (opportunity == null)
            {
                var opp = new Opportunity()
                {
                    OpportunitySubject = "Get Rich",
                    Value = "This is valuable because I like being rich",
                    ResolvedOn = DateTime.Now,
                    ResolutionReason = "I'm still not rich :(",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = Guid.NewGuid(),
                            CommentDate = DateTime.Now,
                            PostedBy = new IdentityUserModel() {Name = "Zoltan"},
                            CommentString = "Blah blah blah"
                        },
                        new Comment()
                        {
                            Id = Guid.NewGuid(),
                            CommentDate = DateTime.Now,
                            PostedBy = new IdentityUserModel() {Name = "Zoltan"},
                            CommentString = "Blah blah blah"
                        },
                        new Comment()
                        {
                            Id = Guid.NewGuid(),
                            CommentDate = DateTime.Now,
                            PostedBy = new IdentityUserModel() {Name = "Zoltan"},
                            CommentString = "Blah blah blah"
                        },
                        new Comment()
                        {
                            Id = Guid.NewGuid(),
                            CommentDate = DateTime.Now,
                            PostedBy = new IdentityUserModel() {Name = "Zoltan"},
                            CommentString = "Blah blah blah"
                        },
                        new Comment()
                        {
                            Id = Guid.NewGuid(),
                            CommentDate = DateTime.Now,
                            PostedBy = new IdentityUserModel() {Name = "Zoltan"},
                            CommentString = "Blah blah blah",
                            Replies = new List<Comment>()
                            {
                                new Comment()
                                {
                                    Id = Guid.NewGuid(),
                                    CommentDate = DateTime.Now,
                                    PostedBy = new IdentityUserModel() {Name = "Zoltan"},
                                    CommentString = "Blah blah blah"
                                },
                                new Comment()
                                {
                                    Id = Guid.NewGuid(),
                                    CommentDate = DateTime.Now,
                                    PostedBy = new IdentityUserModel() {Name = "Zoltan"},
                                    CommentString = "Blah blah blah"
                                },
                                new Comment()
                                {
                                    Id = Guid.NewGuid(),
                                    CommentDate = DateTime.Now,
                                    PostedBy = new IdentityUserModel() {Name = "Zoltan"},
                                    CommentString = "Blah blah blah"
                                },
                            }
                        },
                    }
                };







                return View(opp);
            }
            //end debug
            #endregion

            return View(opportunity);
        }

        [HttpGet]
        public ActionResult CreateOpportunity(Guid contactId)
        {
            return View(new OpportunityCreateViewModel()
            {
                ContactId = contactId
            });
        }

        [HttpPost]
        public ActionResult CreateOpportunity(OpportunityCreateViewModel model)
        {
            var opportunity = OpportunityHandler.AddOpportunity(model.ContactId, model.OpportunitySubject, model.Value,
                model.Selected.FirstOrDefault());
            return RedirectToAction("ViewOpportunity", new { id = opportunity.Id });
        }

        [HttpGet]
        public ActionResult QuickCreate()
        {
            var model = new OpportunityCreateViewModel();

            model.PrioritiesList = SettingsHandler.GetPriorities().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.PriorityString
            }).ToList();

            #region debug

            if (!model.PrioritiesList.Any())
            {
                ((List<SelectListItem>)model.PrioritiesList).Add(new SelectListItem()
                {
                    Value = "0",
                    Text = "Unimportant"
                });
                ((List<SelectListItem>)model.PrioritiesList).Add(new SelectListItem()
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

            var opportunity = OpportunityHandler.AddOpportunity(generalContact.Id, model.OpportunitySubject,
                model.Value, model.Selected.FirstOrDefault());
            return RedirectToAction("ViewOpportunity", new { id = opportunity.Id });
        }

        public ActionResult ResolveOpportunity(OpportunityResolutionViewModel model)
        {
            OpportunityHandler.ResolveOpportunity(model.OpportunityId, model.ResolutionReason);
            return RedirectToAction("ViewOpportunity", new { id = model.OpportunityId });
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
            //debug
            //if (!model.DonationList.Any())
            //{
            //    model.DonationList.Add(new SelectListItem() { Text = "Oh boy", Value = "1" });
            //    model.DonationList.Add(new SelectListItem() { Text = "2 Oh boy", Value = "2" });
            //}
            return PartialView("_AddDonation", model);
        }

        [HttpPost]
        public ActionResult AddDonation(AddDonationViewModel model)
        {
            DonationHandler.AddDonation(model.OpportunityId, model.DonationText, model.Selected);
            return RedirectToAction("ViewOpportunity", new { id = model.OpportunityId });
        }

        #endregion


        #region Steps

        public ActionResult AddStep(OpportunityStep model)
        {
            StepHandler.AddStep(model.OpportunityId, model.Step);
            return RedirectToAction("ViewOpportunity", new { id = model.OpportunityId });
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
            CommentHandler.AddComment(model.OpportunityId, model.CommentString, model.ReplyToId);
            return RedirectToAction("ViewOpportunity", new { id = model.OpportunityId });
        }

        #endregion
    }
}