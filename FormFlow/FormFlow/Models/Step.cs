//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Step
    {
        public Step()
        {
            this.CurrentFlowSteps = new HashSet<FlowStep>();
            this.FromFlowSteps = new HashSet<FlowStep>();
            this.FlowRuns = new HashSet<FlowRun>();
            this.FromTransitions = new HashSet<Transition>();
            this.ToTransitions = new HashSet<Transition>();
        }
    
        public System.Guid ID { get; set; }
        public System.Guid StepTypeID { get; set; }
        public System.Guid FlowID { get; set; }
    
        public virtual Flow Flow { get; set; }
        public virtual ICollection<FlowStep> CurrentFlowSteps { get; set; }
        public virtual ICollection<FlowStep> FromFlowSteps { get; set; }
        public virtual StepType StepType { get; set; }
        public virtual ICollection<FlowRun> FlowRuns { get; set; }
        public virtual ICollection<Transition> FromTransitions { get; set; }
        public virtual ICollection<Transition> ToTransitions { get; set; }
    }
}