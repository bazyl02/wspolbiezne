using System.Numerics;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPW2Tests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void GenerateBallTest()
        {
            BallGenerator generator = new BallGenerator();
            BallData ball = generator.GenerateBall();
            Assert.IsTrue(ball.Location.X >= ball.Radius && ball.Location.X <= Mover.borderWidth - ball.Radius);
            Assert.IsTrue(ball.Location.Y >= ball.Radius && ball.Location.Y <= Mover.borderHeight - ball.Radius);
            Assert.IsTrue(ball.Mass <= 2 && ball.Mass > 0);
        }

        [TestMethod]
        public void BallConstructor()
        {
            Vector2 velocity = new Vector2(2, 1);
            Vector2 location = new Vector2(3, 7);
            BallData ball = new BallData(location, 6, 9, velocity, "#FFFFFF");
            Assert.IsTrue(ball.VelocityX == 2);
            Assert.IsTrue(ball.VelocityY == 1);
            Assert.IsTrue(ball.Location.X == 3);
            Assert.IsTrue(ball.Location.Y == 7);
            Assert.IsTrue(ball.Radius == 6);
            Assert.IsTrue(ball.Mass == 9);
        }

        [TestMethod]
        public void CreateBallsTest()
        {
            Mover mover = new Mover();
            int ballsAmount = mover.Balls.Count;
            Assert.IsTrue(ballsAmount == 0);
            mover.CreateBalls(0);
            Assert.IsTrue(ballsAmount == mover.Balls.Count);
            mover.CreateBalls(2);
            Assert.IsFalse(ballsAmount == mover.Balls.Count);
            Assert.IsTrue(2 == mover.Balls.Count);
            mover.CreateBalls(3);
            Assert.IsTrue(5 == mover.Balls.Count);
        }

        [TestMethod]
        public void StopBallsTest()
        {
            Mover mover = new Mover();
            mover.CreateBalls(3);
            Assert.IsTrue(3 == mover.Balls.Count);
            mover.StopBalls();
            Assert.IsTrue(0 == mover.Balls.Count);
            mover.CreateBalls(2);
            mover.CreateBalls(2);
            Assert.IsTrue(4 == mover.Balls.Count);
            mover.StopBalls();
            Assert.IsTrue(0 == mover.Balls.Count);
        }
    }
}

