using System;
using System.Collections.Generic;
using System.Linq;

namespace Kitchen
{
    public class Bowl
    {
        private readonly List<Vegetable> vegetables = new List<Vegetable>();

        public List<Vegetable> Vegetables
        {
            get
            {
                // return shallow copy of original array
                Vegetable[] vegetablesCopy = new Vegetable[this.vegetables.Count];
                this.vegetables.CopyTo(vegetablesCopy);
                return vegetablesCopy.ToList();
            }
        }

        public void Add(Vegetable vegetable)
        {
            if (vegetable == null)
            {
                throw new ArgumentNullException("Can't add null object to bowl.");
            }

            this.vegetables.Add(vegetable);
        }
    }
}
