using Mohawk.Executive.Services.ViewModels;
using System;
using System.Collections.Generic;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IStepHandler
    {
        //Steps
        bool AddStep(Guid opportunityId, string step);
        bool UpdateStep(OpportunityStepModel updatedStep);
        bool RemoveStep(int stepId);
        IEnumerable<OpportunityStepModel> GetStepsForOpportunity(Guid opportunityId);
        OpportunityStepModel GetStep(int stepId);
    }
}