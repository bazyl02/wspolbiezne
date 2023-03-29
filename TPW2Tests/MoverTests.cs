using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Controls;

namespace TPW2.Tests
{
    public class WpfTestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                return Invoke(testMethod);

            TestResult[] result = null;
            var thread = new Thread(() => result = Invoke(testMethod));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return result;
        }

        private TestResult[] Invoke(ITestMethod testMethod)
        {
            return new[] { testMethod.Invoke(null) };
        }
    }


    [TestClass]
    public class MoverTests
    {
        [WpfTestMethod]
        public void changeMovementTest()
        {
            Vector2 location = new Vector2(230, 230);
            double width = 400;
            double height = 400;
            int ellipseWidth = 50;
            int ellipseHeight = 50;
            Canvas canvas = new Canvas();

            Mover mover = new Mover(width, height, canvas, location.X, location.Y);

            location = mover.changeMovement();

            Assert.IsTrue(location.X >= 190);
            Assert.IsTrue(location.X <= 210);
            Assert.IsTrue(location.Y >= 190);
            Assert.IsTrue(location.Y <= 210);
            Assert.AreEqual(mover.Ellipse.Height, ellipseHeight);
            Assert.AreEqual(mover.Ellipse.Width, ellipseWidth);
        }
    }
}