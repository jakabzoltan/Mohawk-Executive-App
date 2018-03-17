using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohawk.Executive.Database;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Database.Entities.UDT;
using Mohawk.Executive.Services.Interfaces;

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

        public bool UpdateStep(Guid opportunityId, int stepOrder, string newStepValue)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStep(Guid opportunityId, int stepOrder)
        {
            throw new NotImplementedException();
        }

        public bool ReorderStep(Guid opportunityId, int stepOrder, int newStepOrder)
        {
            throw new NotImplementedException();
        }

        public void GetStepsForOpportunity(Guid opportunityId)
        {
            throw new NotImplementedException();
        }
    }
}