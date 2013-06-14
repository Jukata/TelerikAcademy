//Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhone
{
    public class Call
    {
        //fields
        private DateTime date;
        private int duration;
        private string dialedNumber;

        //constructors
        public Call(string dialedNumber)
        {
            this.DialedNumber = dialedNumber;
        }

        public Call(DateTime date, int duration, string dialedNumber)
        {
            this.Date = date;
            this.Duration = duration;
            this.DialedNumber = dialedNumber;
        }

        //properties
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("Date and time can't be in the future.");
                }
                this.date = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (duration < 0)
                {
                    throw new ArgumentOutOfRangeException("Call duration can't be negative.");
                }
                this.duration = value;
            }
        }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }
            set
            {
                if (value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("Number too long");
                }
                int countDigits = 0;
                foreach (char symbol in value)
                {
                    if (!char.IsDigit(symbol) && symbol != '-' && symbol != '+')
                    {
                        throw new ArgumentException("Wrong number.");
                    }
                    if (char.IsDigit(symbol))
                    {
                        countDigits++;
                    }
                }
                if (countDigits < 3)
                {
                    throw new ArgumentOutOfRangeException("Number too short.");
                }
                this.dialedNumber = value;
            }
        }

        // Display the information about the calls.
        public override string ToString()
        {
            string result = string.Format("Call datetime - {0:hh:mm:ss dd.MM.yyyy}", this.date) + Environment.NewLine +
                string.Format("Call duration - {0}", this.duration) + Environment.NewLine +
                string.Format("Nubmer - {0}", this.dialedNumber);
            return result;
        }
    }
}
