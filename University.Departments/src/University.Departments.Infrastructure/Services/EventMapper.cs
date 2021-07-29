using System.Collections.Generic;
using System.Linq;
using MicroPack.CQRS.Events;
using MicroPack.Types;
using University.Departments.Application.Events;
using University.Departments.Application.Services;
using University.Departments.Core.Events;

namespace University.Departments.Infrastructure.Services
{
    internal sealed class EventMapper : IEventMapper
    {
        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
            => events.Select(Map);

        public IEvent Map(IDomainEvent @event)
            => @event switch
            {
                DepartmentCreatedDomainEvent e => new DepartmentCreated(e.Id),
                _ => null
            };
    }
}