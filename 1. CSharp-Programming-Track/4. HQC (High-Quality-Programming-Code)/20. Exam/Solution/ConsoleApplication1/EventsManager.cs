using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem
{
    public class EventsManager : IEventsManager
    {
        private readonly List<Event> events = new List<Event>();

        public void AddEvent(Event ev)
        {
            if (ev == null)
            {
                throw new ArgumentNullException("Event can't be null.");
            }

            this.events.Add(ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleToLower = title.ToLower();
            int deletedEvents = this.events.RemoveAll(ev => ev.Title.ToLower() == titleToLower);
            return deletedEvents;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var eventsToList =
                (from ev in this.events
                 where ev.Date >= date
                 orderby ev.Date, ev.Title, ev.Location
                 select ev).Take(count);

            return eventsToList;
        }
    }
}