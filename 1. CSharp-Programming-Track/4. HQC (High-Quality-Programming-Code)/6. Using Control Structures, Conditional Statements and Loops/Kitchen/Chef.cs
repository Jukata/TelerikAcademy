using System;

namespace Kitchen
{
    public class Chef
    {
        public void Cook(params Vegetable[] vegetables)
        {
            Bowl bowl = GetBowl();
            foreach (Vegetable vegetable in vegetables)
            {
                bowl.Add(vegetable);
            }
        }

        public void Cook()
        {
            Bowl bowl = GetBowl();

            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);
            bowl.Add(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);
            bowl.Add(carrot);
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Peel(Vegetable vegetable)
        {
            // TODO: Peel vegetable
        }

        private void Cut(Vegetable vegetable)
        {
            // TODO: Cut vegetable
        }
    }
}
