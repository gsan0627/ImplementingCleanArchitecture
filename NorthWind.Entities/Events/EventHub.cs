using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Events
{
    public class EventHub<EventType> :
        IEventHub<EventType> where EventType : IEvent
    {
        readonly IEnumerable<IEventHandler<EventType>> _eventHandlers;
        public EventHub(IEnumerable<IEventHandler<EventType>> eventHandlers)
            => _eventHandlers = eventHandlers;
        public async ValueTask Raise(EventType eventTypeInstance)
        {
            foreach (var handler in _eventHandlers)
            {
                await handler.Handle(eventTypeInstance);
            }
        }
    }
}
