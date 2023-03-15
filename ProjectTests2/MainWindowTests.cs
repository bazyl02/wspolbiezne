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
            var t = new Thread(() =>
            {
                MainWindow window = new MainWindow();

                window.Closed += (s, e) => window.Dispatcher.InvokeShutdown();

                window.Show();

               
                System.Windows.Threading.Dispatcher.Run();
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}