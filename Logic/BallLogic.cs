
using System;
using System.ComponentModel;
using Data;

namespace Logic
{
    public class BallLogic : INotifyPropertyChanged
    {
        private readonly BallData ball;
        public BallLogic(BallData ball)
        {
            this.ball = ball;
            ball.PropertyChanged += DataBallChanged;
        }

        public void DataBallChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("ChangeLocation");
        }
        public BallData Ball { get => ball; }
        public string Color { get => ball.Color; }
        public int Radius { get => ball.Radius; }
        public float Mass1 { get => ball.Mass; }
        public float LocationX
        {
            get => ball.LocationX;
            set
            {
                ball.LocationX = value;
                RaisePropertyChanged(nameof(LocationX));
            }
        }
        public float LocationY
        {
            get => ball.LocationY;
            set
            {
                ball.LocationY = value;
                RaisePropertyChanged(nameof(LocationY));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}