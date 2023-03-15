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
    public class FunctionsTests
    {
        [TestMethod()]
        public void functionOnClickTest()
        {
            double i1 = 1;
            int i2 = 2;
            string text = Project.Functions.functionOnClick(i1, i2);
            Assert.AreEqual(text, "1");

            i1 = 2;
            i2 = 5;
            text = Project.Functions.functionOnClick(i1, i2);
            Assert.AreEqual(text, "1,41421");

            i1 = 123;
            i2 = 14;
            text = Project.Functions.functionOnClick(i1, i2);
            Assert.AreNotEqual(text, "11,09053650640943");

            i1 = 123;
            i2 = 14;
            text = Project.Functions.functionOnClick(i1, i2);
            Assert.AreEqual(text, "11,09053650640942");

            i1 = 123;
            i2 = 15;
            text = Project.Functions.functionOnClick(i1, i2);
            Assert.AreEqual(text, "11,090536506409418");

            i1 = 123;
            i2 = 16;
            text = Project.Functions.functionOnClick(i1, i2);
            Assert.AreEqual(text, "Podaj liczbę mniejszą od 15");

            i1 = -2;
            i2 = 5;
            text = Project.Functions.functionOnClick(i1, i2);
            Assert.AreEqual(text, "Nie można policzyć pierwiaska z liczby ujemnej");
        }
    }
}