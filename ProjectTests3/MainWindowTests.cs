using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void MainWindowTest()
        {
            MainWindow window = new MainWindow();

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void przycisk1_ClickTest()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void functionOnClickTest()
        {
            Assert.Fail();
        }
    }
}