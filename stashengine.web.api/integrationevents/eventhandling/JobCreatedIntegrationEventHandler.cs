using Infrastructure.EventBus.Abstractions;
using stashengine.web.api.integrationevents.events;
using stashengine.web.api.model;
using stashengine.web.api.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stashengine.web.api.integrationevents.eventhandling
{
    public class JobCreatedIntegrationEventHandler : IIntegrationEventHandler<JobCreatedIntegrationEvent>
    {
        private readonly IJobRepository _repository;

        public JobCreatedIntegrationEventHandler(IJobRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Handle(JobCreatedIntegrationEvent @event)
        {
            throw new NotImplementedException();// await _repository.Add(@event.CreationDate.ToString());
        }
    }
}
