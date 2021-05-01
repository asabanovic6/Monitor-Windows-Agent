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

       

        
    }
}
