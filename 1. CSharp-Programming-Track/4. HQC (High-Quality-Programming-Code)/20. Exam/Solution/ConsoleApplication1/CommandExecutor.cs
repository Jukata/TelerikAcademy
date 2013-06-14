using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CalendarSystem
{
    public class CommandExecutor
    {
        private const string AddEventCommand = "AddEvent";
        private const string DeleteEventsCommand = "DeleteEvents";
        private const string ListEventsCommand = "ListEvents";

        private readonly IEventsManager eventsManager;

        public CommandExecutor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public IEventsManager EventsManager
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(Command command)
        {
            switch (command.CommandName)
            {
                case AddEventCommand:
                    return ProcessCommandAddEvent(command);
                case DeleteEventsCommand:
                    return ProcessDeleteEventsCommand(command);
                case ListEventsCommand:
                    return ProcessListEventsCommand(command);
                default:
                    throw new ArgumentException("Invalid command name " + command.CommandName);
            }
        }

        private string ProcessCommandAddEvent(Command command)
        {
            if (command.Params.Length != 2 && command.Params.Length != 3)
            {
                throw new ArgumentException("Invalid number of command parameters.");
            }

            DateTime date = DateTime.ParseExact(command.Params[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string title = command.Params[1];
            string location;

            if (command.Params.Length == 2) // there isn't location
            {
                location = null;
            }
            else
            {
                location = command.Params[2];
            }

            Event newEvent = new Event()
            {
                Date = date,
                Title = title,
                Location = location
            };

            this.eventsManager.AddEvent(newEvent);

            return "Event added";
        }

        private string ProcessDeleteEventsCommand(Command command)
        {
            if (command.Params.Length != 1)
            {
                throw new ArgumentException("Invalid number of command parameters.");
            }

            int deletedEventsCount = this.eventsManager.DeleteEventsByTitle(command.Params[0]);

            if (deletedEventsCount == 0)
            {
                return "No events found";
            }
            else
            {
                return deletedEventsCount + " events deleted";
            }
        }

        private string ProcessListEventsCommand(Command command)
        {
            if (command.Params.Length != 2)
            {
                throw new ArgumentException("Invalid number of command parameters.");
            }

            DateTime eventDate = DateTime.ParseExact(command.Params[0],
                "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            int listedEventsCount = int.Parse(command.Params[1]);
            var events = this.eventsManager.ListEvents(eventDate, listedEventsCount).ToList();

            if (events.Count == 0)
            {
                return "No events found";
            }
            else
            {
                var result = new StringBuilder();

                foreach (Event ev in events)
                {
                    result.AppendLine(ev.ToString());
                }

                return result.ToString().Trim();
            }
        }
    }
}