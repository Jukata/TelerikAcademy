using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class EventsManagerFastTests
    {
        #region AddEvent Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingNullEvent()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(null);
        }

        [TestMethod]
        public void AddOneEvent()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event ev = new Event
            {
                Title = "Sleep",
                Date = new DateTime(2013, 5, 20, 18, 0, 0),
                Location = "At home",
            };

            eventsManager.AddEvent(ev);

            int expected = 1;
            int actual = eventsManager.Count;
            Assert.AreEqual(expected, actual);

            var events = eventsManager.ListEvents(new DateTime(2013, 5, 20, 18, 0, 0), 1);
            Assert.AreSame(ev, events.First());
        }

        [TestMethod]
        public void AddSeveralEvents()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event ev1 = new Event
            {
                Title = "Sleep",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 5, 20, 18, 0, 0),
                Location = "At home",
            };

            Event ev2 = new Event
            {
                Title = "Study",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 5, 20, 20, 0, 0),
                Location = "At home",
            };

            Event ev3 = new Event
            {
                Title = "Eat",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 5, 20, 19, 00, 0),
                Location = "At home",
            };

            eventsManager.AddEvent(ev1);
            eventsManager.AddEvent(ev2);
            eventsManager.AddEvent(ev3);

            int expected = 3;
            int actual = eventsManager.Count;
            Assert.AreEqual(expected, actual);

            var eventsList = eventsManager.ListEvents(new DateTime(2013, 5, 20, 18, 0, 0), 1);
            Assert.AreSame(ev1, eventsList.First());

            eventsList = eventsManager.ListEvents(new DateTime(2013, 5, 20, 20, 0, 0), 1);
            Assert.AreSame(ev2, eventsList.First());

            eventsList = eventsManager.ListEvents(new DateTime(2013, 5, 20, 19, 0, 0), 1);
            Assert.AreSame(ev3, eventsList.First());
        }

        [TestMethod]
        public void AddSeveralEventsSomeWithDuplicateTitles()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event ev1 = new Event
            {
                Title = "Sleep",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 5, 20, 20, 0, 0),
                Location = "Paris",
            };

            Event ev2 = new Event
            {
                Title = "Sleep",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 4, 20, 20, 0, 0),
                Location = "London",
            };

            Event ev3 = new Event
            {
                Title = "Sleep",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 9, 20, 20, 15, 0),
                Location = "Sofia",
            };

            Event ev4 = new Event
            {
                Title = "Eat",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 11, 20, 20, 15, 0),
                Location = "Sofia",
            };

            Event ev5 = new Event
            {
                Title = "Work",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 9, 1, 10, 15, 0),
                Location = "Sofia",
            };

            Event ev6 = new Event
            {
                Title = "Play football",
                //"2013-05-20T18:00:00"
                Date = new DateTime(2013, 1, 1, 14, 35, 0),
                Location = "Sofia",
            };

            eventsManager.AddEvent(ev1);
            eventsManager.AddEvent(ev2);
            eventsManager.AddEvent(ev3);
            eventsManager.AddEvent(ev4);
            eventsManager.AddEvent(ev4);
            eventsManager.AddEvent(ev5);
            eventsManager.AddEvent(ev6);

            int expected = 7;
            int actual = eventsManager.Count;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ListEvents Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ListEventsWithNegativeCount()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event ev = new Event
            {
                Title = "Sleep",
                Date = new DateTime(2013, 5, 20, 18, 0, 0),
                Location = "At home",
            };
            eventsManager.AddEvent(ev);
            eventsManager.ListEvents(DateTime.Now, -1);
        }

        [TestMethod]
        public void EmptyEventsList()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            var eventsList = eventsManager.ListEvents(new DateTime(2020, 10, 10, 10, 10, 10), 5);
            Assert.AreEqual(0, eventsList.Count());
        }

        [TestMethod]
        public void ListMatchingElementWithZeroCount()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event ev = new Event
            {
                Title = "Sleep",
                Date = new DateTime(2013, 5, 20, 18, 0, 0),
                Location = "At home",
            };
            eventsManager.AddEvent(ev);

            var listedEvents = eventsManager.ListEvents(new DateTime(2013, 5, 15, 18, 0, 0), 0);
            Assert.AreEqual(0, listedEvents.Count());
        }

        [TestMethod]
        public void ListOneMatchingElementFromSeveralNonMatching()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event ev1 = new Event
            {
                Title = "Eat",
                Date = new DateTime(2013, 5, 20, 18, 0, 0),
                Location = "At home",
            };
            Event ev2 = new Event
            {
                Title = "Sleep",
                Date = new DateTime(2013, 1, 20, 18, 0, 0),
                Location = "At home",
            };
            Event ev3 = new Event
            {
                Title = "Eat",
                Date = new DateTime(2013, 4, 20, 18, 0, 0),
                Location = "At home",
            };

            eventsManager.AddEvent(ev1);
            eventsManager.AddEvent(ev2);
            eventsManager.AddEvent(ev3);

            var listedEvents = eventsManager.ListEvents(new DateTime(2013, 5, 15, 18, 0, 0), 1);
            Assert.AreEqual(1, listedEvents.Count());

            Assert.AreSame(ev1, listedEvents.First());
        }

        [TestMethod]
        public void List2EventsWith4Matching()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event ev1 = new Event
            {
                Title = "Eat",
                Date = new DateTime(2013, 5, 20, 18, 0, 0),
                Location = "At home",
            };
            Event ev2 = new Event
            {
                Title = "Sleep",
                Date = new DateTime(2013, 1, 20, 18, 0, 0),
                Location = "At home",
            };
            Event ev3 = new Event
            {
                Title = "Eat",
                Date = new DateTime(2013, 4, 20, 18, 0, 0),
                Location = "At home",
            };
            Event ev4 = new Event
            {
                Title = "Play",
                Date = new DateTime(2013, 4, 20, 17, 0, 0),
                Location = "School",
            };
            Event ev5 = new Event
            {
                Title = "Play",
                Date = new DateTime(2009, 4, 20, 17, 0, 0),
                Location = "School",
            };

            eventsManager.AddEvent(ev1);
            eventsManager.AddEvent(ev2);
            eventsManager.AddEvent(ev3);
            eventsManager.AddEvent(ev4);
            eventsManager.AddEvent(ev5);

            var listedEvents = eventsManager.ListEvents(new DateTime(2012, 5, 15, 18, 0, 0), 2);
            Assert.AreEqual(2, listedEvents.Count());

            Assert.AreSame(ev2, listedEvents.First());
            Assert.AreSame(ev4, listedEvents.Skip(1).First());
        }

        [TestMethod]
        public void List4EventsWith2Matching()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event ev1 = new Event
            {
                Title = "Eat",
                Date = new DateTime(2013, 5, 20, 18, 0, 0),
                Location = "At home",
            };
            Event ev2 = new Event
            {
                Title = "Sleep",
                Date = new DateTime(2013, 1, 20, 18, 0, 0),
                Location = "At home",
            };
            Event ev3 = new Event
            {
                Title = "Play",
                Date = new DateTime(2010, 1, 20, 18, 0, 0),
                Location = "At home",
            };

            eventsManager.AddEvent(ev1);
            eventsManager.AddEvent(ev2);
            eventsManager.AddEvent(ev3);

            var listedEvents = eventsManager.ListEvents(new DateTime(2011, 5, 15, 18, 0, 0), 4);
            Assert.AreEqual(2, listedEvents.Count());

            Assert.AreSame(ev2, listedEvents.First());
            Assert.AreSame(ev1, listedEvents.Skip(1).First());
        }

        [TestMethod]
        public void CheckSortingOrder()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            Event notInListEv = new Event
            {
                Title = "something",
                Date = new DateTime(1999, 1, 20, 18, 0, 1),
                Location = "somewhere",
            };
            Event firstEv = new Event
            {
                Title = "Eat",
                Date = new DateTime(2005, 1, 1, 1, 1, 1),
                Location = "At home",
            };
            Event secondEv = new Event
            {
                Title = "Eat",
                Date = new DateTime(2006, 1, 20, 18, 0, 1),
                Location = "At home",
            };
            Event thirdEv = new Event
            {
                Title = "Play",
                Date = new DateTime(2006, 1, 20, 18, 0, 1),
                Location = "At home",
            };
            Event fourthEv = new Event
            {
                Title = "Play",
                Date = new DateTime(2006, 1, 20, 18, 0, 1),
                Location = "Outside",
            };
            Event fifthEv = new Event
            {
                Title = "Play",
                Date = new DateTime(2006, 1, 20, 18, 0, 1),
                Location = "Somewhere else",
            };

            eventsManager.AddEvent(fifthEv);
            eventsManager.AddEvent(thirdEv);
            eventsManager.AddEvent(notInListEv);
            eventsManager.AddEvent(secondEv);
            eventsManager.AddEvent(firstEv);
            eventsManager.AddEvent(fourthEv);

            var listedEvents = eventsManager.ListEvents(new DateTime(2001, 5, 15, 19, 0, 0), 5);
            Assert.AreEqual(5, listedEvents.Count());

            Assert.AreSame(firstEv, listedEvents.First());
            Assert.AreSame(secondEv, listedEvents.Skip(1).First());
            Assert.AreSame(thirdEv, listedEvents.Skip(2).First());
            Assert.AreSame(fourthEv, listedEvents.Skip(3).First());
            Assert.AreSame(fifthEv, listedEvents.Skip(4).First());
        }

        #endregion

        #region DeleteEvents Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteEventsByGivenNullTitle()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event()
            {
                Title = "Sleeping",
                Date = new DateTime(2011, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });

            eventsManager.DeleteEventsByTitle(null);
        }

        [TestMethod]
        public void DeleteSingleEvent()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event()
            {
                Title = "Sleeping",
                Date = new DateTime(2011, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });
            eventsManager.AddEvent(new Event()
            {
                Title = "Eating",
                Date = new DateTime(2011, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });
            eventsManager.AddEvent(new Event()
            {
                Title = "Walking",
                Date = new DateTime(2011, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });

            int expected = 1;
            int actual = eventsManager.DeleteEventsByTitle("Sleeping");
            Assert.AreEqual(expected, actual);

            expected = 0;
            actual = eventsManager.DeleteEventsByTitle("Sleeping");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteNonMatchingEvent()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event()
            {
                Title = "not sleeping",
                Date = new DateTime(2011, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });
            eventsManager.AddEvent(new Event()
            {
                Title = "Eating",
                Date = new DateTime(2011, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });
            eventsManager.AddEvent(new Event()
            {
                Title = "Walking",
                Date = new DateTime(2011, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });

            int expected = 0;
            int actual = eventsManager.DeleteEventsByTitle("Sleeping");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteDouplicatingEvents()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event()
            {
                Title = "Sleeping",
                Date = new DateTime(2011, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });
            eventsManager.AddEvent(new Event()
            {
                Title = "Sleeping",
                Date = new DateTime(2012, 10, 10, 10, 10, 10),
                Location = "Sofia"
            });
            eventsManager.AddEvent(new Event()
            {
                Title = "Eating",
                Date = new DateTime(2011, 10, 10, 12, 10, 10),
                Location = "Sofia"
            });
            eventsManager.AddEvent(new Event()
            {
                Title = "Walking",
                Date = new DateTime(2011, 10, 10, 00, 10, 10),
                Location = "Sofia"
            });

            int expected = 2;
            int actual = eventsManager.DeleteEventsByTitle("Sleeping");
            Assert.AreEqual(expected, actual);

            expected = 0;
            actual = eventsManager.DeleteEventsByTitle("Sleeping");
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
