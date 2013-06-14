using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Bank
    {
        private string name;
        private List<Account> accounts = new List<Account>();

        public List<Account> Accounts
        {
            get { return this.accounts; }
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be null, empty, whitespace or less than 2 characters.");
                }
                this.name = value;
            }
        }

        public Bank(string name)
        {
            this.Name = name;
        }

        public void AddAccount(params Account[] accounts)
        {
            foreach (Account account in accounts)
            {
                this.accounts.Add(account);
            }
        }

        public void RemoveAccout(Account account)
        {
            this.accounts.Remove(account);
        }

        public override string ToString()
        {
            StringBuilder toStringResult = new StringBuilder();

            toStringResult.AppendLine("Bank: " + this.Name + Environment.NewLine);

            foreach (Account account in accounts)
            {
                toStringResult.AppendLine(account.ToString());
                toStringResult.AppendLine(new string('-', 40));
            }

            return toStringResult.ToString();
        }
    }
}
