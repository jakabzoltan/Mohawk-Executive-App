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
                StepOrder = currentStep
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

        public bool ReorderStep(Guid opportunityId, int stepId, int step)
        {
            var toSwap = _context.OpportunitySteps.FirstOrDefault(x => x.Id == stepId);
            var toSwapWith = _context.OpportunitySteps.Where(x => x.StepOrder == toSwap.StepOrder + step).FirstOrDefault();
            var stepCount = _context.OpportunitySteps.Where(x => x.OpportunityId == opportunityId).Count();

            if ((toSwap == null) || (step + toSwap.StepOrder > stepCount) || (step + toSwap.StepOrder <= 0)) return false;
            toSwap.StepOrder += step;

            if(toSwapWith != null)
                toSwapWith.StepOrder -= step;
            _context.SaveChanges();
            return true;

        }

        public void GetStepsForOpportunity(Guid opportunityId)
        {
            throw new NotImplementedException();
        }
    }
}