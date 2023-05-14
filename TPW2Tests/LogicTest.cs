using Logic;
using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPW2Tests
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void TestLogic()
        {
            LogicAbstractApi logic = LogicAbstractApi.CreateApi(); 
            logic.CreateBalls(1); 
            Vector2 velocity = new Vector2(-2, -1);
            Vector2 location = new Vector2(-3, -7);
            BallData ball1 = new BallData(location, 6, 9, velocity, "#FFFFFF");
            
            Assert.IsTrue(ball1.VelocityX == -2);
            logic.Collisions(800, 400, ball1.Radius, ball1);
            Assert.IsTrue(ball1.VelocityX == 2);

            Vector2 velocity2 = new Vector2(2, 1.5f);
            Vector2 velocity3 = new Vector2(-1, -0.3f);
            Vector2 location2 = new Vector2(30, 20);
            Vector2 location3 = new Vector2(40, 25);
            BallData ball2 = new BallData(location2, 10, 2, velocity, "#FFFFFF");
            BallData ball3 = new BallData(location3, 10, 2, velocity, "#FFFFFF");
            logic.BallCrash(ball2, ball3);
            Assert.IsTrue(ball2.VelocityX != velocity2.X);
            Assert.IsTrue(ball2.VelocityY != velocity2.Y);
            Assert.IsTrue(ball3.VelocityX != velocity3.X);
            Assert.IsTrue(ball3.VelocityY != velocity3.Y);
        }
    }
}
