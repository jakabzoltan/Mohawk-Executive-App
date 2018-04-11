using Mohawk.Executive.Services.ViewModels;
using System;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IStepHandler
    {
        //Steps
        bool AddStep(Guid opportunityId, string step);
        bool UpdateStep(OpportunityStepModel updatedStep);
        bool RemoveStep(int stepId);
        bool ReorderStep(Guid opportunityId, int stepOrder, int step);
        void GetStepsForOpportunity(Guid opportunityId);
    }
}