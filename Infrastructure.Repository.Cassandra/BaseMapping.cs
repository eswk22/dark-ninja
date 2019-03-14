using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Cassandra
{
    public abstract class BaseMapping<T> : Mappings where T : class
    {
        public BaseMapping()
        {
           
        }

        protected void setMapping(Map<T> mapping)
        {
            MappingConfiguration.Global.Define(mapping);
        }
    }
}
