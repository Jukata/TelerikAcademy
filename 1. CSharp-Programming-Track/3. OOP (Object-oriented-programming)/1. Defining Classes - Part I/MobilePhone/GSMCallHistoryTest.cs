//Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.

using System;
using System.Collections.Generic;

namespace MobilePhone
{
    public static class GSMCallHistoryTest
    {
        static decimal pricePerMinute = 0.37m;

        public static void CallHistoryTest()
        {
            //Create an instance of the GSM class.
            GSM myGsm = GSM.IPhone4S;

            //Add few calls.
            Call someCall = new Call(DateTime.Now, 120, "+359888888888");
            myGsm.AddCall(someCall);
            myGsm.AddCall(someCall);
            myGsm.DeleteCall(someCall);
            myGsm.AddCall(someCall);
            myGsm.AddCall(new Call(new DateTime(2013, 2, 10, 21, 14, 29), 1000, "0885088508"));
            myGsm.AddCall(new Call(new DateTime(2013, 1, 20, 11, 11, 11), 1000, "0885088508"));
            myGsm.AddCall(new Call(DateTime.Now, 119, "+359887121314"));

            //Display the information about the calls.
            Console.WriteLine("All calls:");
            myGsm.PrintAllCalls();

            //Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
            PrintCallPrice(myGsm);

            //Remove the longest call from the historyand calculate the total price again.
            myGsm.RemoveLongestDurationCall();
            Console.WriteLine("\nAfter remove of longest duration call...");
            PrintCallPrice(myGsm);

            //Finally clear the call history and print it.
            myGsm.ClearCallHistory();
            Console.WriteLine("\nAfter clear...");
            myGsm.PrintAllCalls();
            PrintCallPrice(myGsm);
        }

        public static void PrintCallPrice(GSM myGsm)
        {
            Console.WriteLine("Total calls duration = {0} minutes", myGsm.TotalCallsMinutes());
            Console.WriteLine("Price per minute = {0}", pricePerMinute);
            Console.WriteLine("Total calls price = {0:C}", myGsm.TotalCallsPrice(pricePerMinute));
        }
    }
}
