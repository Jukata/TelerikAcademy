using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    //Loan accounts can only deposit money.
    //Loan accounts have no interest for the first 3 months if are held 
    //by individuals and for the first 2 months if are held by a company.

    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, DateTime createionDate, decimal balance = 0, decimal interest = 0)
            : base(customer, createionDate, balance, interest)
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
            //if account is individual can't have interest for first 3 months
            if (this.customer.GetType().Name == "IndividualCustomer")
            {
                if (this.NumberOfMonths > 3)
                {
                    return base.CalculateInterest();
                }
                else
                {
                    return 0;
                }
            }
            //if account is company can't have interest for first 2 months
            else //if (this.customer.GetType().Name == "CompanyCustomer")
            {
                if (this.NumberOfMonths > 2)
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