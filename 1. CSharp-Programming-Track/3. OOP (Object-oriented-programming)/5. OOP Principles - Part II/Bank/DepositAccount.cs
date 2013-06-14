using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    //Deposit accounts are allowed to deposit and with draw money.
    public class DepositAccount : Account, IDepositable, IWithDrawable
    {
        public DepositAccount(Customer customer, DateTime creationDate, decimal balance = 0, decimal interest = 0)
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

        public void WithdrawMoney(decimal money)
        {
            if (this.Balance - money < 0)
            {
                throw new ArgumentException("You can't withdraw more money than your current balance.");
            }
        }

        //Deposit accounts have no interest if their balance is positive and less than 1000.
        public override decimal CalculateInterest()
        {
            if (this.Balance >= 1000)
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
