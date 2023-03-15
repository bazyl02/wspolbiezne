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
            var mainWindow = new MainWindow();
            mainWindow.Show();
            //Assert.IsNotNull(mainWindow);
        }
    }
}