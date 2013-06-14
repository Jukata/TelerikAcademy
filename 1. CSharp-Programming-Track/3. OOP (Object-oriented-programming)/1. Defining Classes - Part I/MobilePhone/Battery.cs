//battery characteristics (model, hours idle and hours talk)

using System;

namespace MobilePhone
{
    //Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.
    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd,

    }
    public class Battery
    {
        //fields
        private string model;
        private float? hoursIdle;
        private float? hoursTalk;
        private BatteryType batteryType;

        //constructors
        public Battery(BatteryType batteryType) : this(null,null,null,batteryType)
        {
        }

        public Battery(string model, float? hoursIdle, float? hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
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
                if (value.Length < 1 && value != null)
                {
                    throw new ArgumentException("Model name must be at least 1 characters.");
                }
                this.model = value;
            }
        }

        public float? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours must be positive");
                }
                this.hoursIdle = value;
            }
        }

        public float? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours must be positive");
                }
                this.hoursTalk = value;
            }
        }
        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }
    }
}
