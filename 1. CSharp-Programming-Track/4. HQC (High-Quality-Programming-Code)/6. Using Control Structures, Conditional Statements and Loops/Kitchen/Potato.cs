using System;

namespace Kitchen
{
    public class Potato : Vegetable
    {
        private bool isPeeled = false;
        private bool isRotten = false;

        public Potato()
        {
            this.IsPeeled = false;
            this.IsRotten = false;
        }

        public bool IsPeeled
        {
            get
            {
                return this.isPeeled;
            }
            set
            {
                this.isPeeled = value;
            }
        }

        public bool IsRotten
        {
            get
            {
                return this.isRotten;
            }
            set
            {
                this.isRotten = value;
            }
        }
    }
}
