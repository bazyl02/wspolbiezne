using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void MainWindowTest()
        {
            Assert.AreEqual(true, true);

            double i1 = 1;
            int i2 = 2;
            string a = Project.Functions.functionOnClick(i1, i2);

            Assert.AreEqual(a, "1");
        }
    }
}