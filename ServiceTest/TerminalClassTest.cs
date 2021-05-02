using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalLibrary;

namespace ServiceTest
{
    [TestClass]
    public class TerminalClassTest
    {

        [TestMethod, ExpectedException(typeof(System.Security.SecurityException))]
        public void RunCommandTest()
        {

            TerminalCommand.RunCommand("", "");
        }


        [TestMethod]
        public void GetUsageTest()
        {
            
            Assert.IsTrue(TerminalCommand.getRAMUsege() > 0 && TerminalCommand.getRAMUsege() < 1);
            Assert.IsTrue(TerminalCommand.getCPUUsage() > 0 && TerminalCommand.getCPUUsage() < 1);
            Assert.IsTrue(TerminalCommand.getHDDUsage() > 0 && TerminalCommand.getHDDUsage() < 1);
            Assert.IsTrue(TerminalCommand.getGPUUsage() > 0 && TerminalCommand.getGPUUsage() < 1);
        }

    }
}
