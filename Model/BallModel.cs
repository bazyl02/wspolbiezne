using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logic;

namespace Presentation.Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private float posX;
        private float posY;
        private int radius;
        private string color;
        public BallModel(BallLogic ball)
        {
            Random r = new Random();
            ball.PropertyChanged += BallPropertyChanged;
            XPosition = ball.LocationX;
            YPosition = ball.LocationY;
            Radius = ball.Radius();
            Color = ball.Color();
        }
        public int Size { get => 2 * Radius; }

        public string Color
        {
            get => color;
            set
            {
                color = value;
            }
        }

        public int Radius
        {
            get => radius;
            set
            {
                radius = value;
                RaisePropertyChanged("Radius");
            }
        }
        public float XPosition
        {
            get => posX;
            set
            {
                posX = value;
                RaisePropertyChanged("XPosition");
            }
        }
        public float YPosition
        {
            get => posY;
            set
            {
                posY = value;
                RaisePropertyChanged("YPosition");
            }
        }
        private void BallPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BallLogic ball = (BallLogic)sender;
            XPosition = ball.LocationX;
            YPosition = ball.LocationY;
            RaisePropertyChanged("XPosition");
            RaisePropertyChanged("YPosition");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}