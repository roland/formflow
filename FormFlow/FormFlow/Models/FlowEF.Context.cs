﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormFlow.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FormFlowEntities : DbContext
    {
        public FormFlowEntities()
            : base("name=FormFlowEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Flow> Flows { get; set; }
        public DbSet<FlowStep> FlowSteps { get; set; }
        public DbSet<StepType> StepTypes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<FlowRun> FlowRuns { get; set; }
        public DbSet<Transition> Transitions { get; set; }
        public DbSet<TransitionType> TransitionTypes { get; set; }
        public DbSet<WebService> WebServices { get; set; }
    }
}
