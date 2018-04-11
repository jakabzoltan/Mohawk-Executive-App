using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohawk.Executive.Database;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Database.Entities.UDT;
using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Services.Services
{
    public class StepService : IStepHandler
    {
        private readonly ExecutiveContext _context;

        public StepService()
        {
            _context = ExecutiveContext.Create();
        }

        public bool AddStep(Guid opportunityId, string step)
        {
            var currentStep = _context.OpportunitySteps.Count(x => x.OpportunityId == opportunityId) + 1;
            _context.OpportunitySteps.Add(new OpportunityStep()
            {
                Opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId),
                OpportunityId = opportunityId,
                Step = step,
                StepOrder = currentStep,
                Completed = false
            });
            _context.SaveChanges();
            return true;
        }

        public bool UpdateStep(OpportunityStepModel updatedStep)
        {
            var toUpdate = _context.OpportunitySteps.FirstOrDefault(x => x.Id == updatedStep.Id);
            if (toUpdate == null) return false;
            toUpdate.StepOrder = updatedStep.StepOrder;
            toUpdate.Step = updatedStep.Step;
            toUpdate.Completed = updatedStep.Completed;
            _context.SaveChanges();
            return true;
        }

        public bool RemoveStep(int stepId)
        {
            var toRemove = _context.OpportunitySteps.FirstOrDefault(x => x.Id == stepId);
            if (toRemove == null) return false;
            _context.OpportunitySteps.Remove(toRemove);

            var toUpdate = _context.OpportunitySteps.Where(x => x.StepOrder > toRemove.StepOrder);
            foreach(var step in toUpdate)
            {
                step.StepOrder -= 1;
            }

            _context.SaveChanges();
            return true;
        }

        public void GetStepsForOpportunity(Guid opportunityId)
        {
            throw new NotImplementedException();
        }

        public OpportunityStepModel GetStep(int stepId)
        {
            return _context.OpportunitySteps.Where(x => x.Id == stepId).Select(x => new OpportunityStepModel()
                   {
                        Id = x.Id,
                        OpportunityId = x.OpportunityId,
                        Completed = x.Completed,
                        Step = x.Step,
                        StepOrder = x.StepOrder
                   }).FirstOrDefault();
        }

        IEnumerable<OpportunityStepModel> IStepHandler.GetStepsForOpportunity(Guid opportunityId)
        {
            return _context.OpportunitySteps.Where(x => x.OpportunityId == opportunityId).Select(x => new OpportunityStepModel()
            {
                Id = x.Id,
                OpportunityId = x.OpportunityId,
                Completed = x.Completed,
                Step = x.Step,
                StepOrder = x.StepOrder
            });
        }
    }
}