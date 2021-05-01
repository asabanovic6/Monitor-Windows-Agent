using EventLogger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ServiceTest
{
    [TestClass]
    public class EventLoggerTest
    {
        [TestMethod]
        public void CreateMessageTest()
        {
            Logger l = new Logger("", "");
            //l.createLog();
            l.createMessage();
            l.deleteLog();
        }
    }
}
