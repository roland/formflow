using System.Data.Entity;
using FormFlow.Models;

namespace FormFlow
{
    public class FormFlowEntities : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<FormFlow.FormFlowEntities>());

        public FormFlowEntities() : base("name=FormFlowEntities")
        {
        }

        public DbSet<Flow> Flows { get; set; }

        public DbSet<StepType> StepTypes { get; set; }

        public DbSet<TransitionType> TransitionTypes { get; set; }

        public DbSet<Transition> Transitions { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<WebService> WebServices { get; set; }
    }
}
