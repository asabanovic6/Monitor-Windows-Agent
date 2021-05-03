using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PingServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    class PingServerTest
    {
        [TestMethod]
        public void PingTest() 
        {
            string path = "..\\..\\testConfig.json";
            Ping p = new Ping(path);
            NUnit.Framework.Assert.That(() => p.PostJsonAndKeepAlive(), Throws.Nothing);
        }
    }
}
