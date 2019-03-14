using manager.web.api.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manager.web.api.manager
{
    public interface IJobManager
    {
        void SaveJob(JobItem job);
    }
}
