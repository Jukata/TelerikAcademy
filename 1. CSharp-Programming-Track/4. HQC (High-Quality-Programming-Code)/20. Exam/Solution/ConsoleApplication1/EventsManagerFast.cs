using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CalendarSystem
{
    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Event> titles =
            new MultiDictionary<string, Event>(true);
        private readonly OrderedMultiDictionary<DateTime, Event> dates =
            new OrderedMultiDictionary<DateTime, Event>(true);

        public int Count
        {
            get { return this.titles.KeyValuePairs.Count; }
        }

        public void AddEvent(Event ev)
        {
            if (ev == null)
            {
                throw new ArgumentNullException("Event can't be null.");
            }

            string eventTitleLowerCase = ev.Title.ToLower();
            this.titles.Add(eventTitleLowerCase, ev);
            this.dates.Add(ev.Date, ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Title can't be null.");
            }

            string titleToLowerCase = title.ToLower();

            var matchedEvents = this.titles[titleToLowerCase];
            int deleteEventsCount = matchedEvents.Count;

            foreach (Event ev in matchedEvents)
            {
                this.dates.Remove(ev.Date, ev);
            }

            this.titles.Remove(titleToLowerCase);

            return deleteEventsCount;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Count can't be negative.");
            }

            var matchedEvents =
                (from ev in this.dates.RangeFrom(date, true).Values
                 select ev).Take(count);
            return matchedEvents;
        }
    }
}