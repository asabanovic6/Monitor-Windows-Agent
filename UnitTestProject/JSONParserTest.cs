using JASONParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class JSONParserTest
    {
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
            Assert.AreEqual(computer.name, name);
            Assert.AreEqual(computer.location, location);
            Assert.AreEqual(computer.deviceUid, deviceUId);
            Assert.AreEqual(computer.keepAlive, keepAlive);
            Assert.AreEqual(computer.webSocketUrl, webSocketUri);
            Assert.AreEqual(computer.pingUri, pingUri);
            Assert.AreEqual(computer.mainUri, mainUri);
            Assert.AreEqual(computer.errorUri, errorUri);
            Assert.AreEqual(computer.fileUri, fileUri);
            Assert.AreEqual(computer.installationCode, installationCode);
            Assert.AreEqual(computer.path, path);
            Assert.AreEqual(computer.fileLocations.File1.path, name1);
            Assert.AreEqual(computer.fileLocations.File1.minutes, minutes1);
            Assert.AreEqual(computer.fileLocations.File2.path, name2);
            Assert.AreEqual(computer.fileLocations.File2.minutes, minutes2);
            Assert.AreEqual(computer.fileLocations.File3.path, name3);
            Assert.AreEqual(computer.fileLocations.File3.minutes, minutes3);
            Assert.AreEqual(computer.fileLocations.File4.path, name4);
            Assert.AreEqual(computer.fileLocations.File4.minutes, minutes4);
            Assert.AreEqual(computer.fileLocations.File5.path, name5);
            Assert.AreEqual(computer.fileLocations.File5.minutes, minutes5);
        }
        #endregion
    }
}
