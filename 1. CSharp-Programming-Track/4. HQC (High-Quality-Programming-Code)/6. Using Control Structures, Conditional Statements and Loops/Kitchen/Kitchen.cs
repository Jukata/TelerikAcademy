using System;

namespace Kitchen
{
    public class Kitchen
    {
        public static void Main()
        {
            Chef cooker = new Chef();
            Potato potato = new Potato();

            if (potato != null && potato.IsPeeled && potato.IsRotten)
            {
                cooker.Cook(potato);
            }
        }
    }
}
