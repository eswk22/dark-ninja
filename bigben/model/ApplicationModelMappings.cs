using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bigben.model
{
    public static class ApplicationModelMappings
    {
       
        public static void Initialize()
        {
            new JobItemMappings();
        }
    }
}
