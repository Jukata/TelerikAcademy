using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main()
        {
            Bank SGC = new Bank("Societe General Express Bank");
            SGC.AddAccount(
                new LoanAccount(new IndividualCustomer("Svetlin Nakov"), DateTime.Now, 1500, 0.4M),
                new LoanAccount(new IndividualCustomer("George Georgiev"), new DateTime(2012, 12, 30), 2500, 1M),
                new LoanAccount(new IndividualCustomer("Nikolay Kostov"), new DateTime(2011, 12, 30), 1500, 0.1M),
                new MortgageAccount(new IndividualCustomer("Doncho Minkov"), new DateTime(2012, 2, 2), 4500, 0.11M),
                new DepositAccount(new IndividualCustomer("Lyubomir Qnchev"), new DateTime(2013, 1, 1), 1500, 0.1M),
                new LoanAccount(new CompanyCustomer("Telerik crop."), DateTime.Now, 1500, 0.21M),
                new DepositAccount(new CompanyCustomer("Telerik"), new DateTime(2012, 12, 30), 2500, 0.11M),
                new LoanAccount(new CompanyCustomer("VM ware"), new DateTime(2013, 1, 1), 1500, 0.21M),
                new MortgageAccount(new CompanyCustomer("Musala soft"), new DateTime(2011, 2, 2), 4500, 0.11M),
                new LoanAccount(new CompanyCustomer("HP"), new DateTime(2003, 1, 1), 1500, 0.37M)
                );

            Console.WriteLine("Bank: " + SGC.Name);
            foreach (Account acc in SGC.Accounts)
            {
                Console.WriteLine(acc);
                Console.WriteLine("Interest = " + acc.CalculateInterest() + "%");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
