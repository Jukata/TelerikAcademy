using System;
using System.Collections.Generic;

namespace CalendarSystem
{
    public interface IEventsManager
    {
        /// <summary>
        /// Adds new event to the event manager.
        /// </summary>
        /// <param name="ev">Event to be added.</param>
        /// <remarks>
        /// If the event already exists, it is added again.
        /// </remarks>
        /// <exception cref="System.ArgumentException">throws when null event is inputed.</exception>
        void AddEvent(Event ev);

        /// <summary>
        /// Deletes all events matching given <paramref name="title"/>. Matching is case insensitive.
        /// </summary>
        /// <param name="title">title which events must match to be deleted.</param>
        /// <returns>number of deleted events.</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// List the events starting from the given <paramref name="date"/>. 
        /// The number of listed event is no more than maximum <paramref name="count"/>.
        /// </summary>
        /// <param name="date">Starting date for events to be listed.</param>
        /// <param name="count">Maximum number of events to be listed.
        /// If there is more than given count only first count sorted alphabeticaly are listed
        /// </param>
        /// <returns>List first <paramref name="count"/> events sorted alphabeticaly
        /// by their ToString() representation starting from given date.</returns>
        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}