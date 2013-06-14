using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    //All accounts have customer, balance and interest rate (monthly based). 
    public abstract class Account
    {
        //fields
        public Customer customer;
        public decimal balance;
        public decimal interest;
        public DateTime creationDate;

        //properties
        public Customer Cutomer
        {
            get { return this.customer; }
            protected set { this.customer = value; }
        }
        public decimal Balance
        {
            get { return this.balance; }
            protected set { this.balance = value; }
        }
        public decimal Interest
        {
            get { return this.interest; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest can't be negative.");
                }
                this.interest = value;
            }
        }
        public DateTime CreationDate
        {
            get { return this.creationDate; }
            protected set { this.creationDate = value; }
        }
        protected int NumberOfMonths
        {
            get
            {
                //some stupid algorith for calculating months
                return (int)(DateTime.Now - this.CreationDate).TotalDays / 30;
            }
        }

        //constructor
        protected Account(Customer customer, DateTime creationDate, decimal balance = 0, decimal interest = 0)
        {
            this.Cutomer = customer;
            this.Balance = balance;
            this.Interest = interest;
            this.CreationDate = creationDate;
        }

        //All accounts can calculate their interest amount for a given period (in months).
        //In the common case its is calculated as follows: number_of_months * interest_rate.
        public virtual decimal CalculateInterest()
        {
            return this.NumberOfMonths * this.Interest;
        }

        public override string ToString()
        {
            StringBuilder toStringResult = new StringBuilder();
            toStringResult.AppendLine("Type: " + this.GetType().Name);
            toStringResult.AppendLine(this.customer.ToString());
            toStringResult.AppendLine("Balance: " + this.Balance);
            toStringResult.AppendLine("Interest: " + this.Interest);
            toStringResult.AppendLine("Date of create: " + this.CreationDate);
            return toStringResult.ToString();
        }

    }
}
