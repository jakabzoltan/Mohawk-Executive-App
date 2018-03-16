﻿using System;
using System.Collections.Generic;
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

        public ViewModels.Opportunity AddOpportunity(Guid contactId, string subject, string value, int priority)
        {
            if (!ContactExists(contactId)) return null;
            var contact = new Opportunity
            {
                Id = Guid.NewGuid(),
                ContactId = contactId,
                Value = value,
                OpportunitySubject = subject,
                OpportunityPriorityId = priority
            };
            _context.Opportunities.Add(contact);
            _context.SaveChanges();
            return Get(contact.Id);
        }

        public bool RemoveOpportunity(Guid opportunityId)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return false;
            opportunity.RemovedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public ViewModels.Opportunity UpdateOpportunity(Guid opportunityId, string subject, string newValue,
            int? newPriority = null)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return null;
            opportunity.OpportunitySubject = subject;
            opportunity.Value = newValue;
            if (newPriority != null)
                opportunity.OpportunityPriorityId = (int) newPriority;
            _context.SaveChanges();
            return Get(opportunityId);
            ;
        }

        public ViewModels.Opportunity ResolveOpportunity(Guid opportunityId, string resolutionReason)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return null;
            opportunity.ResolvedOn = DateTime.Now;
            opportunity.ResolutionReason = resolutionReason;
            _context.SaveChanges();
            return Get(opportunityId);
        }

        public ViewModels.Opportunity SetPriorityLevel(Guid opportunityId, int priorityLevel)
        {
            if (!PriorityLevelExists(priorityLevel)) return null;
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return null;
            opportunity.OpportunityPriorityId = priorityLevel;
            _context.SaveChanges();
            return Get(opportunityId);
        }

        public IEnumerable<ViewModels.Opportunity> GetOpportunities(bool includePeripheral = false)
        {
            return _context.Opportunities.Select(opportunity => new ViewModels.Opportunity()
            {
                Id = opportunity.Id,
                ContactId = opportunity.ContactId,
                OpportunitySubject = opportunity.OpportunitySubject,
                Value = opportunity.Value,
                OpportunityPriorityId = opportunity.OpportunityPriorityId,
                ResolvedOn = opportunity.ResolvedOn,
                ResolutionReason = opportunity.ResolutionReason,
                RemovedOn = opportunity.RemovedOn,
            });
        }

        public IEnumerable<ViewModels.Opportunity> GetOpportunitiesForContact(Guid contactId,
            bool includePeripheral = false)
        {
            return _context.Opportunities.Where(c => c.ContactId == contactId).Select(opportunity =>
                new ViewModels.Opportunity()
                {
                    Id = opportunity.Id,
                    ContactId = opportunity.ContactId,
                    OpportunitySubject = opportunity.OpportunitySubject,
                    Value = opportunity.Value,
                    OpportunityPriorityId = opportunity.OpportunityPriorityId,
                    ResolvedOn = opportunity.ResolvedOn,
                    ResolutionReason = opportunity.ResolutionReason,
                    RemovedOn = opportunity.RemovedOn,
                });
        }

        public IEnumerable<ViewModels.Opportunity> SearchOpportunities(string query, bool includePeripherals = false)
        {
            return _context.Opportunities.Where(c =>
                    c.Contact.FirstName.Contains(query) ||
                    c.Contact.LastName.Contains(query) ||
                    c.OpportunitySubject.Contains(query) ||
                    c.Value.Contains(query) ||
                    c.ResolutionReason.Contains(query))
                .Select(opportunity => new ViewModels.Opportunity()
                {
                    Id = opportunity.Id,
                    ContactId = opportunity.ContactId,
                    OpportunitySubject = opportunity.OpportunitySubject,
                    Value = opportunity.Value,
                    OpportunityPriorityId = opportunity.OpportunityPriorityId,
                    ResolvedOn = opportunity.ResolvedOn,
                    ResolutionReason = opportunity.ResolutionReason,
                    RemovedOn = opportunity.RemovedOn,
                });
        }

        public ViewModels.Opportunity Get(Guid opportunityId, bool includePeripheral = false)
        {
            var entityOp = _context.Opportunities.FirstOrDefault(c => c.Id == opportunityId);
            var op = _context.Opportunities.Where(c => c.Id == opportunityId).Select(opportunity =>
                new ViewModels.Opportunity()
                {
                    Id = opportunity.Id,
                    ContactId = opportunity.ContactId,
                    OpportunitySubject = opportunity.OpportunitySubject,
                    Value = opportunity.Value,
                    OpportunityPriorityId = opportunity.OpportunityPriorityId,
                    ResolvedOn = opportunity.ResolvedOn,
                    ResolutionReason = opportunity.ResolutionReason,
                    RemovedOn = opportunity.RemovedOn,
                    Priority = new OpportunityPriority()
                    {
                        PriorityString = opportunity.Priority.PriorityString,
                        Id = opportunity.Priority.Id
                    },
                    
                }).FirstOrDefault();

            op.Donations = includePeripheral
                ? entityOp.Donations.Select(d => new OpportunityDonation()
                {
                    Id = d.Id,
                    DonationText = d.DonationText,
                    OpportunityId = d.OpportunityId,
                    DonationTypes = d.DonationTypes.Select(dt =>
                        new DonationType() {DonationTypeString = dt.DonationTypeString, Id = dt.Id})
                })
                : null;
            op.Comments = includePeripheral
                ? entityOp.Comments.Where(c => c.ReplyId == null).Select(c => new Comment()
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
                    Replies = entityOp.Comments.Where(cr => cr.ReplyId == c.Id).Select(x => new Comment()
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
                    })
                }): null;
            op.Steps = includePeripheral
                ? entityOp.Steps.Select(s => new OpportunityStep()
                {
                    OpportunityId = s.OpportuntityId,
                    Step = s.Step,
                    StepOrder = s.StepOrder
                })
                : null;

            return op;
        }


        private bool ContactExists(Guid contactId)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == contactId) != null;
        }

        private bool PriorityLevelExists(int priorityId)
        {
            return _context.OpportunityPriorities.FirstOrDefault(x => x.Id == priorityId) != null;
        }
    }
}