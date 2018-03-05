using System;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IStepHandler
    {
        //Steps
        bool AddStep(Guid opportunityId, string step);
        bool UpdateStep(Guid opportunityId, int stepOrder, string newStepValue);
        bool RemoveStep(Guid opportunityId, int stepOrder);
        bool ReorderStep(Guid opportunityId, int stepOrder, int newStepOrder);
        void GetStepsForOpportunity(Guid opportunityId);
    }
}