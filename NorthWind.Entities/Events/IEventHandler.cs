using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Events
{
    public interface IEventHandler<EventType> where EventType : IEvent
    {
        Task Handle(EventType eventTypeInstance);
    }
}