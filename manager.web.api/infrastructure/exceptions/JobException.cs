﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manager.web.api.infrastructure.exceptions
{
    public class JobException : Exception
    {
        public JobException()
        { }

        public JobException(string message)
            : base(message)
        { }

        public JobException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}