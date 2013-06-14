using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class CommandParseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCommandInputted()
        {
            Command cmd = Command.Parse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotSeparatedCommandNameFromParameters()
        {
            string cmdString = "AddEvent2012-01-21T20:00:00|C#exam|";
            Command cmd = Command.Parse(cmdString);
        }

        [TestMethod]
        public void TestValidCommandWithThreeParameters()
        {
            string cmdString = "AddEvent 2012-01-21T20:00:00 | C# exam | Telerik Ultimate lab";
            Command cmd = Command.Parse(cmdString);

            int expectedParams = 3;
            int actualParams = cmd.Params.Length;
            Assert.AreEqual(expectedParams, actualParams);

            string expectedName = "AddEvent";
            string actualName = cmd.CommandName;
            Assert.AreEqual(expectedName, actualName);

            string expectedDate = "2012-01-21T20:00:00";
            string actualDate = cmd.Params[0];
            Assert.AreEqual(expectedDate, actualDate);

            string expectedTitle = "C# exam";
            string actualTitle = cmd.Params[1];
            Assert.AreEqual(expectedTitle, actualTitle);

            string expectedLocation = "Telerik Ultimate lab";
            string actualLocation = cmd.Params[2];
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        public void TestValidCommandWithTwoParameters()
        {
            string cmdString = "AddEvent 2012-05-10T10:00:00 | JS exam";
            Command cmd = Command.Parse(cmdString);

            int expectedParams = 2;
            int actualParams = cmd.Params.Length;
            Assert.AreEqual(expectedParams, actualParams);

            string expectedName = "AddEvent";
            string actualName = cmd.CommandName;
            Assert.AreEqual(expectedName, actualName);

            string expectedDate = "2012-05-10T10:00:00";
            string actualDate = cmd.Params[0];
            Assert.AreEqual(expectedDate, actualDate);

            string expectedTitle = "JS exam";
            string actualTitle = cmd.Params[1];
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void TestDeleteEventsCommand()
        {
            string cmdString = "DleteEvents High quality code exam";
            Command cmd = Command.Parse(cmdString);

            int expectedParams = 1;
            int actualParams = cmd.Params.Length;
            Assert.AreEqual(expectedParams, actualParams);

            string expectedName = "DleteEvents";
            string actualName = cmd.CommandName;
            Assert.AreEqual(expectedName, actualName);

            string expectedTitle = "High quality code exam";
            string actualTitle = cmd.Params[0];
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void TestListEventsCommand()
        {
            string cmdString = "ListEvents 2012-05-11T11:11:11 | 3";
            Command cmd = Command.Parse(cmdString);

            int expectedParams = 2;
            int actualParams = cmd.Params.Length;
            Assert.AreEqual(expectedParams, actualParams);

            string expectedName = "ListEvents";
            string actualName = cmd.CommandName;
            Assert.AreEqual(expectedName, actualName);

            string expectedDate = "2012-05-11T11:11:11";
            string actualDate = cmd.Params[0];
            Assert.AreEqual(expectedDate, actualDate);

            string expectedCount = "3";
            string actualCount = cmd.Params[1];
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestCommandWithManyArgumentsWithWhitespaces()
        {
            string cmdString = "badcmd 3  |  2   |   a b c d | s t  r i ng    | t r i  m   | \tbadarg | \nother args";
            Command cmd = Command.Parse(cmdString);

            int expectedParams = 7;
            int actualParams = cmd.Params.Length;
            Assert.AreEqual(expectedParams, actualParams);

            string expectedName = "badcmd";
            string actualName = cmd.CommandName;
            Assert.AreEqual(expectedName, actualName);

            Assert.AreEqual("3", cmd.Params[0]);
            Assert.AreEqual("2", cmd.Params[1]);
            Assert.AreEqual("a b c d", cmd.Params[2]);
            Assert.AreEqual("s t  r i ng", cmd.Params[3]);
            Assert.AreEqual("t r i  m", cmd.Params[4]);
            Assert.AreEqual("badarg", cmd.Params[5]);
            Assert.AreEqual("other args", cmd.Params[6]);

        }
    }
}
