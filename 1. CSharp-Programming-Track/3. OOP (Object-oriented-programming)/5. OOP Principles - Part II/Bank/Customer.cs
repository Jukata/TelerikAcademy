using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class Customer
    {
        public string Name { get; protected set; }

        protected Customer(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}\nName: {1}", this.GetType().Name, this.Name);
        }
    }
}
