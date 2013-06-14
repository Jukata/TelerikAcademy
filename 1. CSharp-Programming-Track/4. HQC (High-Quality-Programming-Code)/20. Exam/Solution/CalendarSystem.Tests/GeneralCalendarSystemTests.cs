using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class GeneralCalendarSystemTests
    {
        [TestMethod]
        public void GeneralZeroTest()
        {
            var output = new StringWriter();
            var input = new StringReader(
                    "AddEvent 2012-01-21T20:00:00 | party Viki | home" + Environment.NewLine +
                    "AddEvent 2012-03-26T09:00:00 | C# exam" + Environment.NewLine +
                    "AddEvent 2012-03-26T09:00:00 | C# exam" + Environment.NewLine +
                    "AddEvent 2012-03-26T08:00:00 | C# exam" + Environment.NewLine +
                    "AddEvent 2012-03-07T22:30:00 | party | Vitosha" + Environment.NewLine +
                    "ListEvents 2012-03-07T08:00:00 | 3" + Environment.NewLine +
                    "DeleteEvents c# exam" + Environment.NewLine +
                    "DeleteEvents My granny's bushes" + Environment.NewLine +
                    "ListEvents 2013-11-27T08:30:25 | 25" + Environment.NewLine +
                    "AddEvent 2012-03-07T22:30:00 | party | Club XXX" + Environment.NewLine +
                    "ListEvents 2012-01-07T20:00:00 | 10" + Environment.NewLine +
                    "AddEvent 2012-03-07T22:30:00 | Party | Club XXX" + Environment.NewLine +
                    "ListEvents 2012-03-07T22:30:00 | 3" + Environment.NewLine +
                    "End" + Environment.NewLine
                );

            string expected =
               "Event added" + Environment.NewLine +
               "Event added" + Environment.NewLine +
               "Event added" + Environment.NewLine +
               "Event added" + Environment.NewLine +
               "Event added" + Environment.NewLine +
               "2012-03-07T22:30:00 | party | Vitosha" + Environment.NewLine +
               "2012-03-26T08:00:00 | C# exam" + Environment.NewLine +
               "2012-03-26T09:00:00 | C# exam" + Environment.NewLine +
               "3 events deleted" + Environment.NewLine +
               "No events found" + Environment.NewLine +
               "No events found" + Environment.NewLine +
               "Event added" + Environment.NewLine +
               "2012-01-21T20:00:00 | party Viki | home" + Environment.NewLine +
               "2012-03-07T22:30:00 | party | Club XXX" + Environment.NewLine +
               "2012-03-07T22:30:00 | party | Vitosha" + Environment.NewLine +
               "Event added" + Environment.NewLine +
               "2012-03-07T22:30:00 | party | Club XXX" + Environment.NewLine +
               "2012-03-07T22:30:00 | party | Vitosha" + Environment.NewLine +
               "2012-03-07T22:30:00 | Party | Club XXX" + Environment.NewLine;

            using (output)
            {
                using (input)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    CalendarSystemDemo.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
