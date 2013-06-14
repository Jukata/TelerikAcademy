//Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
//Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
//Ensure all fields hold correct data at any given time.
//Write a class GSMTest to test the GSM class

using System;

namespace MobilePhone
{
    class GSMTest
    {
        static void Main()
        {
            //Create an array of few instances of the GSM class.
            GSM[] mobilePhones = 
            {
                new GSM("Xperia", "Sony", 350.00M, "Viktor", new Battery("3310", 150, 300, BatteryType.NiCd), new Display(3.6f, 16000000)),
                new GSM("Galaxy SIII", "Samsung", 899.99M, "Daniel", new Battery("Me", 120, 240, BatteryType.NiMH), new Display(4.3f, 16000000)),
                new GSM("Galaxy SII", "Samsung", 600, "Valentin", new Battery("Me", 96, 192, BatteryType.NiMH), new Display(4.1f, 16000000)),
                GSM.IPhone4S
            };

            //Display the information about the GSMs in the array.
            //Display the information about the static property IPhone4S.
            foreach (GSM gsm in mobilePhones)
            {
                Console.WriteLine(gsm);
                Console.WriteLine();
            }

            Console.WriteLine("And the calls test now...\n");
            GSMCallHistoryTest.CallHistoryTest();
        }
    }
}