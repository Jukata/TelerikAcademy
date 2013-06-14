namespace Events
{
    using System;
    using System.Text;

    internal static class Message
    {
        private static readonly StringBuilder output = new StringBuilder();

        public static string Output
        {
            get
            {
                return output.ToString();
            }
        }

        public static void EventAdded()
        {
            output.Append("Event added" + Environment.NewLine);
        }

        public static void EventDeleted(int count)
        {
            if (count == 0)
            {
                EventNotFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted{1}", count, Environment.NewLine);
            }
        }

        public static void EventNotFound()
        {
            output.Append("No events found" + Environment.NewLine);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + Environment.NewLine);
            }
        }
    }
}