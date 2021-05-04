using JASONParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EventLogger;
using PingServer;
using NUnit.Framework;
using Monitor_Windows_Agent;

namespace UnitTestProject
{
    [TestClass]
    public class JSONParserTest
    {
        Logger logger;
        ComputerInfo computer;
        #region Parser.ConfigParser() test
        static IEnumerable<object[]> ConfigData        {
            get
            {
                return new[]
                {
                     new object[] { "..\\..\\configTest.json", "Desktop PC 3","Sarajevo - Ložioničkaaaa","33098e25-c605-4132-ad95-f38ecc3bd7a1", 30,
                     "si-grupa5.herokuapp.com", "https://si-2021.167.99.244.168.nip.io:3000/liveStatus",
                         "https://si-2021.167.99.244.168.nip.io/api/device/GetDeviceByInstallationCode/",
                     "https://si-2021.167.99.244.168.nip.io:3000/errorLog",
                     "ENDPOINT ZA SLANJE FILEOVA", null, "C:\\Users\\Amina\\Documents", "", 0, "", 0, "", 0, "", 0, "", 0 } };
            }
        }
        [TestMethod]
        [DynamicData("ConfigData")]
        public void TestConfigParser(String filepath, String name, String location, String deviceUId, Int64 keepAlive, 
            String webSocketUri, String pingUri, String mainUri, String errorUri, String fileUri, String installationCode,
            String path, String name1, Int64 minutes1, String name2, Int64 minutes2,
            String name3, Int64 minutes3, String name4, Int64 minutes4,
            String name5, Int64 minutes5)
        {
            Parser parser = new Parser(filepath);
            computer = parser.ConfigParser();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.name, name);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.location, location);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.deviceUid, deviceUId);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.keepAlive, keepAlive);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.webSocketUrl, webSocketUri);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.pingUri, pingUri);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.mainUri, mainUri);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.errorUri, errorUri);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileUri, fileUri);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.installationCode, installationCode);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.path, path);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File1.path, name1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File1.minutes, minutes1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File2.path, name2);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File2.minutes, minutes2);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File3.path, name3);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File3.minutes, minutes3);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File4.path, name4);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File4.minutes, minutes4);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File5.path, name5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(computer.fileLocations.File5.minutes, minutes5);
        }
        #endregion
        [TestMethod]
        public void PingTest1()
        {
            string path = "..\\..\\testConfig.json";
            Ping p = new Ping(path);
            NUnit.Framework.Assert.That(() => p.PostJsonAndKeepAlive(), Throws.Nothing);
        }
        [TestMethod]
        public void TestGetJSON()
        {
            CreateJSON create = new CreateJSON("..\\..\\configTest.json");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("\"message\":\"Djes Huso\"", create.getJSON().Split(',')[2]);
        }
        [TestMethod]
        public void PingTest2()
        {
            CreateJSON create = new CreateJSON("..\\..\\configTest.json");
            string path = "..\\..\\configTest.json";
            Ping p = new Ping(path);
            NUnit.Framework.Assert.That(() => p.PostFilesAndKeepAlive(path,5), Throws.Nothing);
        }
        [TestMethod]
        public void PingTest3()
        {
            
            string path = "..\\..\\testConfig.json";
            Ping p = new Ping(path);
            NUnit.Framework.Assert.That(() => p.PostError(), Throws.Nothing);
        }
    }
}
