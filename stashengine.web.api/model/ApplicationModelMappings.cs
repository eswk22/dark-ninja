using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stashengine.web.api.model
{
    public static class ApplicationModelMappings
    {
       
        public static void Initialize()
        {
            new JobItemMappings();
        }
    }
}
