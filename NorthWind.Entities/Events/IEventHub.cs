using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Events
{
    public interface IEventHub<EventType> where EventType : IEvent
    {
        ValueTask Raise(EventType eventTypeInstance);
    }
}
