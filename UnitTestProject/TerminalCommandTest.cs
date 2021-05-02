using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal;


namespace UnitTestProject
{
    [TestClass]
   public class TerminalCommandTest
    {
        [TestMethod]
        public void HDDUsageTest()
        {
            double usage = TerminalCommand.getHDDUsage();
            Assert.IsTrue(0 <= usage && usage <= 1);
        }

       
        [TestMethod]
        public void RAMUsageTest()
        {
            double usage = TerminalCommand.getRAMUsege();
            Assert.IsTrue(0 <= usage && usage <= 1);
        }
        
        [TestMethod]
        public void CPUUsageTest()
        {
            double usage = TerminalCommand.getCPUUsage();
            Assert.IsTrue(0 <= usage && usage <= 1);
        }

        [TestMethod]
        public void GPUUsageTest()
        {
            double usage = TerminalCommand.getGPUUsage();
            Assert.IsTrue(0 <= usage && usage <= 1);
        }

        [TestMethod]
        public void SystemInfoTest1()
        {
            String info = TerminalCommand.SystemInfo("shutdown -r monitor windows", "C://");
            Assert.AreEqual("Nesto", info);
        }

        [TestMethod]
        public void SystemInfoTest2()
        {
            String info = TerminalCommand.SystemInfo("shutdown a", "C://");
            Assert.AreNotEqual("Nesto", info);
        }
    }
}
