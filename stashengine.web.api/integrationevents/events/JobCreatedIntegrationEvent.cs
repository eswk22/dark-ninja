using Infrastructure.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stashengine.web.api.integrationevents.events
{
    public class JobCreatedIntegrationEvent : IntegrationEvent
    {
        public string UserId { get; set; }

        public JobCreatedIntegrationEvent(string userId)
        {
            this.UserId = userId;
        }
    }
}
