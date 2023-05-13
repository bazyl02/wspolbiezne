using Data;
using Logic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;

namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public List<BallLogic> ballList = new List<BallLogic>();
        public static LogicAbstractApi CreateApi(DataAbstractApi data = default)
        {
            return new AbstractApiLogic(data ?? DataAbstractApi.CreateApi());
        }
        public abstract void CreateBalls(int numer);
        public abstract void StopBalls();
        public abstract ObservableCollection<BallData> Balls { get; }
        public abstract List<BallLogic> GetBalls();
        public abstract int GetHeight();
        public abstract int GetWidth();

        public abstract void Collisions(int i, int i1, int ball1Radius, BallData ball1);
        public abstract void BallCrash(BallData ball2, BallData ball3);
    }

    public class AbstractApiLogic : LogicAbstractApi
    {
        private readonly DataAbstractApi data;
        public override ObservableCollection<BallData> Balls => data.GetBalls();
        public override int GetWidth()
        {
            return data.GetWidth();
        }
        public override int GetHeight()
        {
            return data.GetHeight();
        }
        public AbstractApiLogic(DataAbstractApi dataAbstractApi)
        {
            data = dataAbstractApi;
        }
        public override void CreateBalls(int number)
        {
            data.CreateBalls(number);
            foreach (BallData ball in data.GetBalls())
            {
                ballList.Add(new BallLogic(ball));
                ball.PropertyChanged += checkMovement;
            }
        }
        public override void StopBalls()
        {
            data.StopBalls();
            ballList.Clear();
        }
        public override List<BallLogic> GetBalls()
        {
            return ballList;
        }
        public void checkMovement(object sender, PropertyChangedEventArgs e)
        {
            BallData ball = (BallData)sender;
            if (e.PropertyName == "ChangeLocation")
            {
                Collisions(GetWidth(), GetHeight(), ball.GetRadius(), ball);
            }
        }
        public override void Collisions(int width, int height, int radius, BallData ball)
        {
            List<String> list = new List<String>();
            foreach (BallLogic thisBall in ballList)
            {
                list.Add(thisBall.Ball().GetColor());
            }
            foreach (BallLogic thisBall in ballList)
            {
                if (thisBall.Ball() == ball)
                {
                    continue;
                }
                float distance = Vector2.Distance(ball.Location, thisBall.Ball().Location);
                if (distance <= (ball.GetRadius() + thisBall.Ball().GetRadius()))
                {
                    if (Vector2.Distance(ball.Location, thisBall.Ball().Location)
                    - Vector2.Distance(ball.Location + ball.Velocity, thisBall.Ball().Location
                    + thisBall.Ball().Velocity) > 0)
                    {
                        if (list.Contains(ball.GetColor()))
                        {
                            BallCrash(ball, thisBall.Ball());
                        }
                    }
                }
            }
            if (ball.LocationX < 0 || ball.LocationX > width - radius * 2)
            {
                ball.VelocityX = ball.VelocityX * -1;
            }
            if (ball.LocationY < 0 || ball.LocationY > height - radius * 2)
            {
                ball.VelocityY = ball.VelocityY * -1;
            }
        }
        public override void BallCrash(BallData b1, BallData b2)
        {
            Vector2 newVelocity1 = b2.Velocity;
            Vector2 newVelocity2 = b1.Velocity;
            b1.Velocity = newVelocity1;
            b2.Velocity = newVelocity2;
        }
    }
}