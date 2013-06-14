//Define a class that holds information about a mobile phone device: model, manufacturer, price, owner,

using System;
using System.Collections.Generic;

namespace MobilePhone
{
    public class GSM
    {
        //static fields
        //Add a static field IPhone4S in the GSM class to hold the information about iPhone 4S.
        private static GSM iPhone4S = new GSM("IPhone 4S", "Apple", 700, "Apple", new Battery("Met", 48, 96, BatteryType.NiCd), new Display(4.5f, 16000000));

        //fields
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();


        //Define several constructors for the defined classes that take different 
        //sets of arguments (the full information for the class or part of it). 
        //Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

        //constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, new Battery(BatteryType.LiIon), new Display())
        {
        }
        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        //static properties
        //Add a static property IPhone4S in the GSM class to hold the information about iPhone 4S.
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        //properties
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (value == null) throw new ArgumentNullException("Model musn't be NULL.");
                    else throw new ArgumentException("Model musn't be empty string.");
                }
                this.model = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (value == null) throw new ArgumentNullException("Manufacturer musn't be NULL.");
                    else throw new ArgumentException("Manufacturer musn't be empty string.");
                }
                this.manufacturer = value;
            }
        }
        public decimal? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be non-negative.");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (value.Length < 2 && value != null )
                {
                    throw new ArgumentException("Owner name must be at least 2 characters.");
                }
                this.owner = value;
            }
        }
        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }
        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        //Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the system class List<Call>.
        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        //Add a method in the GSM class for displaying all information about it. Try to override ToString().
        public override string ToString()
        {
            string result = new string('-', 12) + "GSM" + new string('-', 12) + Environment.NewLine +
                string.Format("Model = {0}\nManufacturer = {1}\nPrice = {2:C}\nOwner = {3}", this.model, this.manufacturer, this.price, this.owner) + Environment.NewLine +
                new string('-', 10) + "Battery" + new string('-', 10) + Environment.NewLine +
                string.Format("Model = {0}\nHours idle = {1}\nHours talk = {2}\nBattery type = {3}", this.battery.Model, this.battery.HoursIdle, this.battery.HoursTalk, this.battery.BatteryType) + Environment.NewLine +
                new string('-', 10) + "Display" + new string('-', 10) + Environment.NewLine +
                string.Format("Size = {0} inches \nColors = {1}", this.display.Size, this.display.Colors);
            return result;
        }

        //Add methods in the GSM class for adding and deleting calls from the calls history
        public void AddCall(Call call)
        {
            callHistory.Add(call);
        }
        public void DeleteCall(Call call)
        {
            callHistory.Remove(call);
        }
        public void DeleteCall(int index)
        {
            callHistory.RemoveAt(index);
        }

        //Add a method to clear the call history.
        public void ClearCallHistory()
        {
            callHistory.Clear();
        }

        //Add a method that calculates the total price of the calls in the call history. 
        //Assume the price per minute is fixed and is provided as a parameter.
        public decimal TotalCallsPrice(decimal pricePerMinute)
        {
            return pricePerMinute * TotalCallsMinutes();
        }

        public decimal TotalCallsMinutes()
        {
            decimal totalMinutes = 0;
            foreach (Call call in callHistory)
            {
                totalMinutes += Math.Ceiling(call.Duration / 60.0M); // Counting is per minute -> rounding up!
            }
            return totalMinutes;
        }

        //Remove the longest call from the history 
        internal void RemoveLongestDurationCall()
        {
            int longestCallDuration = 0;
            int indexForRemove = 0;
            for (int i = 0; i < this.CallHistory.Count; i++)
            {
                if (this.CallHistory[i].Duration > longestCallDuration)
                {
                    longestCallDuration = this.CallHistory[i].Duration;
                    indexForRemove = i;
                }
            }
            this.DeleteCall(indexForRemove);
        }

        //Print call history
        public void PrintAllCalls()
        {
            Console.WriteLine(new string('-', 35));
            foreach (Call call in this.CallHistory)
            {
                Console.WriteLine(call);
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}
