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
    
    public partial class Flow
    {
        public Flow()
        {
            this.Steps = new HashSet<Step>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Step> Steps { get; set; }
    }
}
