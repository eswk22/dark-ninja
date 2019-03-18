using bigben.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bigben.manager
{
    public interface IScheduleManager
    {
        void SaveJob(JobItem job);
    }
}
