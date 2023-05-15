﻿using Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;

namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public List<BallLogic> ballList = new List<BallLogic>();
        public static LogicAbstractApi CreateApi(DataAbstractApi? data = default)
        {
            return new AbstractApiLogic(data ?? DataAbstractApi.CreateApi());
        }
        public abstract void CreateBalls(int numer);
        public abstract void StopBalls();
        public abstract ObservableCollection<BallData> Balls { get; }
        public abstract List<BallLogic> GetBalls();
        public abstract int Height { get; }
        public abstract int Width { get; }

        public abstract void Collisions(int i, int i1, int ball1Radius, BallData ball1);
        public abstract void BallCrash(BallData ball2, BallData ball3);
    }

    public class AbstractApiLogic : LogicAbstractApi
    {
        private readonly DataAbstractApi data;
        public override ObservableCollection<BallData> Balls => data.GetBalls;
        public override int Width => data.Width;
        public override int Height => data.Height;

        public AbstractApiLogic(DataAbstractApi dataAbstractApi)
        {
            data = dataAbstractApi;
        }
        public override void CreateBalls(int number)
        {
            data.CreateBalls(number);
            foreach (BallData ball in data.GetBalls)
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
            BallData b = (BallData)sender;
            if (e.PropertyName == "ChangeLocation")
            {
                Collisions(Width, Height, b.Radius, b);
            }
        }
        public override void Collisions(int width, int height, int radius, BallData ball)
        {
            List<String> list = new List<String>();
            foreach (BallLogic thisBall in ballList)
            {
                list.Add(thisBall.Ball.Color);
            }
            foreach (BallLogic thisBall in ballList)
            {
                if (thisBall.Ball == ball)
                {
                    continue;
                }
                float distance = Vector2.Distance(ball.Location, thisBall.Ball.Location);
                if (distance <= (ball.Radius + thisBall.Ball.Radius))
                {
                    if (Vector2.Distance(ball.Location, thisBall.Ball.Location)
                    - Vector2.Distance(ball.Location + ball.Velocity, thisBall.Ball.Location
                    + thisBall.Ball.Velocity) > 0)
                    {
                        if (list.Contains(ball.Color))
                        {
                            BallCrash(ball, thisBall.Ball);
                        }
                    }
                }
            }
            if ((ball.LocationX-1 < 0 && ball.VelocityX < 0) || (ball.LocationX-1 > Width - radius * 2 && ball.VelocityX > 0))
            {
                ball.VelocityX = ball.VelocityX * -1;
            }
            if ((ball.LocationY-1 < 0 && ball.VelocityY < 0) || (ball.LocationY-1 > Height - radius * 2 && ball.VelocityY > 0))
            {
                ball.VelocityY = ball.VelocityY * -1;
            }
        }
        public override void BallCrash(BallData b1, BallData b2)
        {
            Vector2 newVelocity1 = (b1.Velocity * (b1.Mass - b2.Mass) + b2.Velocity * 2 * b2.Mass) / (b1.Mass + b2.Mass);
            Vector2 newVelocity2 = (b2.Velocity * (b2.Mass - b1.Mass) + b1.Velocity * 2 * b1.Mass) / (b1.Mass + b2.Mass);
            b1.Velocity = newVelocity1;
            b2.Velocity = newVelocity2;
        }
    }
}