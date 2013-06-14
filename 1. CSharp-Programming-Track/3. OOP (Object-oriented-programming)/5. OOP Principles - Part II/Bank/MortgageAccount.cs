using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    //Mortgage accounts can only deposit money.
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer customer, DateTime creationDate, decimal balance = 0, decimal interest = 0)
            : base(customer, creationDate, balance, interest)
        {
        }

        public void DepositMoney(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException("You can't deposite negative amount of money.");
            }
            this.Balance += money;
        }

        public override decimal CalculateInterest()
        {
            //Mortgage accounts have ½ interest for the first 12 months for companies 
            if (this.Cutomer.GetType().Name == "CompanyCustomer")
            {
                if (this.NumberOfMonths > 12)
                {
                    return base.CalculateInterest();
                }
                else
                {
                    return this.NumberOfMonths * (this.Interest / 2);
                }
            }

            //Mortgage accounts have no interest for the first 6 months for individuals.
            else  //if(this.Cutomer.GetType().Name == "IndividualCustomer")
            {
                if (this.NumberOfMonths > 6)
                {
                    return base.CalculateInterest();
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
