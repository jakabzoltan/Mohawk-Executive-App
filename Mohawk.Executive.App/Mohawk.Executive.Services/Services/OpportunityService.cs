using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mohawk.Executive.Database;
using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.ViewModels;
using Opportunity = Mohawk.Executive.Database.Entities.Opportunity;

namespace Mohawk.Executive.Services.Services
{
    public class OpportunityService : IOpportunityHandler
    {
        private readonly ExecutiveContext _context;

        public OpportunityService()
        {
            _context = ExecutiveContext.Create();
        }

        public OpportunityModel AddOpportunity(Guid contactId, string subject, string description, string estimatedValue, int priority,
            string userId)
        {
            if (!ContactExists(contactId)) return null;
            var opp = new Opportunity
            {
                Id = Guid.NewGuid(),
                ContactId = contactId,
                Description = description,
                EstimatedValue = estimatedValue,
                OpportunitySubject = subject,
                PriorityId = priority,
                IdentityUserId = userId
            };
            _context.Opportunities.Add(opp);
            _context.SaveChanges();
            return Get(opp.Id);
        }

        public bool RemoveOpportunity(Guid opportunityId)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return false;
            opportunity.RemovedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public OpportunityModel UpdateOpportunity(Guid opportunityId, string subject, string description, string newValue,
            int? newPriority = null)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return null;
            opportunity.OpportunitySubject = subject;
            opportunity.EstimatedValue = newValue;
            opportunity.Description = description;
            if (newPriority != null)
                opportunity.PriorityId = (int) newPriority;
            _context.SaveChanges();
            return Get(opportunityId);
            
        }

        public ViewModels.OpportunityModel ResolveOpportunity(Guid opportunityId, string resolutionReason)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return null;
            opportunity.ResolvedOn = DateTime.Now;
            opportunity.ResolutionReason = resolutionReason;
            _context.SaveChanges();
            return Get(opportunityId);
        }

        public ViewModels.OpportunityModel SetPriorityLevel(Guid opportunityId, int priorityLevel)
        {
            if (!PriorityLevelExists(priorityLevel)) return null;
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return null;
            opportunity.PriorityId = priorityLevel;
            _context.SaveChanges();
            return Get(opportunityId);
        }

        public IEnumerable<ViewModels.OpportunityModel> GetOpportunities(bool includePeripheral = false)
        {
            return _context.Opportunities.Select(opportunity => new ViewModels.OpportunityModel()
            {
                Id = opportunity.Id,
                ContactId = opportunity.ContactId,
                Subject = opportunity.OpportunitySubject,
                EstimatedValue = opportunity.EstimatedValue,
                PriorityId = opportunity.PriorityId,
                ResolvedOn = opportunity.ResolvedOn,
                ResolutionReason = opportunity.ResolutionReason,
                RemovedOn = opportunity.RemovedOn,
                Description = opportunity.Description
            });
        }

        public IEnumerable<ViewModels.OpportunityModel> GetOpportunitiesForContact(Guid contactId,
            bool includePeripheral = false)
        {
            var returnList = new List<OpportunityModel>();
            var op1 = _context.Opportunities.Where(c => c.ContactId == contactId);
            var op = op1.Select(opportunity =>
                new OpportunityModel()
                {
                    Id = opportunity.Id,
                    ContactId = opportunity.ContactId,
                    Subject = opportunity.OpportunitySubject,
                    EstimatedValue = opportunity.EstimatedValue,
                    PriorityId = opportunity.PriorityId,
                    ResolvedOn = opportunity.ResolvedOn,
                    ResolutionReason = opportunity.ResolutionReason,
                    RemovedOn = opportunity.RemovedOn,
                });
            foreach (var item in op)
            {
                item.Priority = _context.PriorityTypes.Where(x => x.Id == item.PriorityId).Select(p =>
                    new PriorityTypeModel()
                    {
                        Id = p.Id,
                        PriorityString = p.PriorityString
                    }).FirstOrDefault();
                returnList.Add(item);
            }





            return returnList;
        }

        public IEnumerable<ViewModels.OpportunityModel> SearchOpportunities(string query,
            bool includePeripherals = false)
        {
            return _context.Opportunities.Where(c =>
                    c.Contact.FirstName.Contains(query) ||
                    c.Contact.LastName.Contains(query) ||
                    c.OpportunitySubject.Contains(query) ||
                    c.EstimatedValue.Contains(query) ||
                    c.ResolutionReason.Contains(query))
                .Select(opportunity => new OpportunityModel()
                {
                    Id = opportunity.Id,
                    ContactId = opportunity.ContactId,
                    Subject = opportunity.OpportunitySubject,
                    EstimatedValue = opportunity.EstimatedValue,
                    PriorityId = opportunity.PriorityId,
                    ResolvedOn = opportunity.ResolvedOn,
                    ResolutionReason = opportunity.ResolutionReason,
                    RemovedOn = opportunity.RemovedOn,
                });
        }

        public ViewModels.OpportunityModel Get(Guid opportunityId, bool includePeripheral = false)
        {
            var op1 = _context.Opportunities.Where(c => c.Id == opportunityId);
            var op = op1.Select(opportunity =>
                new ViewModels.OpportunityModel()
                {
                    Id = opportunity.Id,
                    ContactId = opportunity.ContactId,
                    Subject = opportunity.OpportunitySubject,
                    EstimatedValue = opportunity.EstimatedValue,
                    Description = opportunity.Description,
                    PriorityId = opportunity.PriorityId,
                    ResolvedOn = opportunity.ResolvedOn,
                    ResolutionReason = opportunity.ResolutionReason,
                    RemovedOn = opportunity.RemovedOn,
                }).FirstOrDefault();


            if (op == null) return null;
            {
                op.Priority = _context.PriorityTypes.Where(x => x.Id == op.PriorityId).Select(
                    pt => new PriorityTypeModel()
                    {
                        PriorityString = pt.PriorityString,
                        Id = pt.Id
                    }).FirstOrDefault();

                op.Contact = _context.Contacts.Where(x => x.Id == op.ContactId).Select(c => new ContactModel()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    ModifiedOn = c.ModifiedOn,
                    Location = c.Location,
                    Organization = c.Organization,
                    PhoneNumber = c.PhoneNumber,
                    Role = c.Role
                }).FirstOrDefault();
                if (!includePeripheral) return op;
                op.Donations = _context.OpportunityDonations.Where(i => i.OpportunityId == opportunityId).Select(d =>
                    new OpportunityDonationModel()
                    {
                        Id = d.Id,
                        DonationText = d.DonationText,
                        OpportunityId = d.OpportunityId,
                        DonationTypes = d.DonationTypes.Select(dt =>
                            new DonationTypeModel() {DonationTypeString = dt.DonationTypeString, Id = dt.Id}).ToList()
                    }).ToList();

                op.Comments = _context.Comments.Where(i => i.OpportunityId == opportunityId && i.ReplyId == null)
                    .Select(c => new CommentModel()
                    {
                        Id = c.Id,
                        OpportunityId = c.OpportunityId,
                        CommentDate = c.CommentDate,
                        CommentString = c.CommentString,
                        ArchivedOn = c.ArchivedOn,
                        PostedBy =
                            new IdentityUserModel()
                            {
                                Name = c.User.UserName,
                                GuidUserId = c.User.Id,
                                Email = c.User.Email
                            },
                    }).ToList();


                op.Comments.ForEach(c => c.Replies = _context.Comments.Where(i => i.OpportunityId == opportunityId)
                    .Where(cr => cr.ReplyId == c.Id).Select(x => new CommentModel()
                    {
                        Id = x.Id,
                        OpportunityId = x.OpportunityId,
                        CommentDate = x.CommentDate,
                        CommentString = x.CommentString,
                        ArchivedOn = x.ArchivedOn,
                        PostedBy = new IdentityUserModel()
                        {
                            Name = x.User.UserName,
                            GuidUserId = x.User.Id,
                            Email = x.User.Email
                        }
                    }).ToList());


                op.Steps = _context.OpportunitySteps.Where(i => i.OpportunityId == opportunityId).Select(s =>
                    new OpportunityStepModel()
                    {
                        Id = s.Id,
                        OpportunityId = s.OpportunityId,
                        Step = s.Step,
                        StepOrder = s.StepOrder
                    }).ToList();
                return op;
            }
        }

        public OpportunityModel AttachContactToOpportunity(Guid opportunityId, Guid contactId)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return Get(opportunityId);
            opportunity.ContactId = contactId;
            _context.SaveChanges();
            return Get(opportunityId);
        }


        private bool ContactExists(Guid contactId)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == contactId) != null;
        }

        private bool PriorityLevelExists(int priorityId)
        {
            return _context.PriorityTypes.FirstOrDefault(x => x.Id == priorityId) != null;
        }
    }
}