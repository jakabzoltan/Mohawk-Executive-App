﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mohawk.Executive.Services.ViewModels
{
    public class OpportunityStepModel
    {
        public int Id { get; set; }
        public Guid OpportunityId { get; set; }
        public int StepOrder { get; set; }
        public string Step { get; set; }
        public bool Completed { get; set; }
    }
}