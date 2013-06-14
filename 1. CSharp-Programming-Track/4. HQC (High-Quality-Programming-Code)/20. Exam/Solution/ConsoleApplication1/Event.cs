using System;

namespace CalendarSystem
{
    public class Event : IComparable<Event>
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(Event other)
        {
            if (this == null && other == null)
            {
                return 0;
            }

            if (this == null)
            {
                return -1;
            }

            if (other == null)
            {
                return 1;
            }

            int result = DateTime.Compare(this.Date, other.Date);

            // Looks like here there was bottleneck because of unnecessary
            // foreach char by char loop on this.Title that lead to many unnecessary comparasions
            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }

            if (result == 0)
            {
                result = string.Compare(this.Location, other.Location);
            }

            return result;
        }

        public override string ToString()
        {
            string format = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";

            if (this.Location != null)
            {
                format += " | {2}";
            }

            string eventAsString = string.Format(format, this.Date, this.Title, this.Location);
            return eventAsString;
        }
    }
}