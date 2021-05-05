using JASONParser;
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
        public void RAMUsageTest()
        {
            ComputerDataJSON cmp = new ComputerDataJSON();
            cmp.ramUsage = (decimal)TerminalCommand.getRAMUsege();
            decimal data = cmp.ramUsage;
            Assert.IsTrue(data > 0 && data < 1);
            
        }

        [TestMethod]
        public void CPUUsageTest()
        {
            ComputerDataJSON cmp = new ComputerDataJSON();
            cmp.cpuUsage = (decimal)TerminalCommand.getCPUUsage();
            decimal data = cmp.cpuUsage;
            Assert.IsTrue(data > 0 && data < 1);
        }

        [TestMethod]
        public void HDDUsageTest()
        {
            ComputerDataJSON cmp = new ComputerDataJSON();
            cmp.hddUsage = (decimal)TerminalCommand.getHDDUsage();
            decimal data = cmp.hddUsage;
            Assert.IsTrue(data > 0 && data < 1);

        }

        [TestMethod]
        public void GPUUsageTest()
        {
            ComputerDataJSON cmp = new ComputerDataJSON();
            cmp.gpuUsage = (decimal)TerminalCommand.getGPUUsage();
            decimal data = cmp.gpuUsage;
            Assert.IsTrue(data > 0 && data < 1);

        }

    }
}
