using Infrastructure.Repository;
using Infrastructure.Repository.Cassandra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stashengine.web.api.model
{
    public class JobItem : Entity,IValidatableObject
    {
        public string Name { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Name))
            {
                results.Add(new ValidationResult("Name can not be empty", new[] { "Name" }));
            }

            return results;
        }
    }

    // Cassandra mapper

    public class JobItemMappings : BaseMapping<JobItem>
    {
        public JobItemMappings()
        {
            
            var mapping = For<JobItem>()
                .TableName("jobitem")
                .PartitionKey(x => x.Id)
                .Column(x => x.Id, cm => cm.WithName("id"))
                .Column(x => x.Name, cm => cm.WithName("name"))
                .Column(x => x.CreatedBy, cm => cm.WithName("created_by"))
                .Column(x => x.CreatedOn, cm => cm.WithName("created_on"))
                .Column(x => x.ModifiedBy, cm => cm.WithName("modified_by"))
                .Column(x => x.ModifiedOn, cm => cm.WithName("modified_on"))
                .KeyspaceName("manager");

            base.setMapping(mapping);
        }
        
    }
}
