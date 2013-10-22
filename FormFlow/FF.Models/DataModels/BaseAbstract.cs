using System;

namespace FF.Models.DataModels
{
    public class BaseAbstract : IBase
    {
        public virtual Guid ID { get; set; }
    }
}