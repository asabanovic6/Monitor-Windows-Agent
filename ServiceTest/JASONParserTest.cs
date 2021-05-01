using JASONParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitor_Windows_Agent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    [TestClass]
    public class JASONParserTest

    {
        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void ReadingDirectoryTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\config.json";
            Parser p = new Parser();
            Assert.AreEqual(path, p.ConfigParser().fileUri);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void CreateJSONTest()
        {
            //CreateJSON info = new CreateJSON();
            Assert.AreNotEqual("", CreateJSON.getJSON());
        }
    }
}
