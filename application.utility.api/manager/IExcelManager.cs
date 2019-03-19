using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.utility.api.manager
{
    public interface IExcelManager
    {
        bool ReadFile(string filepath);
    }
}
