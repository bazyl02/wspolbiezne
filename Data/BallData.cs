using System.ComponentModel;
using System.Numerics;

namespace Data
{
    public class BallData : INotifyPropertyChanged
    {
        private Vector2 location;
        private Vector2 velocity;
        private int radius;
        private string color;

        public BallData(Vector2 location, int radius, Vector2 velocity, string color)
        {
            this.location = location;
            this.velocity = velocity;
            this.radius = radius;
            this.color = color;
        }

        public void UpdatePosition()
        {
            location += velocity;
            RaisePropertyChanged("ChangeLocation");
        }
        public int GetRadius()
        {
            return radius;
        }

        public string GetColor()
        {
            return color;
        }

        public Vector2 Location
        {
            get => location;
            set => location = value;
        }

        public Vector2 Velocity
        {
            get => velocity;
            set => velocity = value;
        }

        public float LocationX
        {
            get => location.X;
            set => location.X = value;
        }

        public float LocationY
        {
            get => location.Y;
            set => location.Y = value;
        }

        public float VelocityX
        {
            get => velocity.X;
            set => velocity.X = value;
        }

        public float VelocityY
        {
            get => velocity.Y;
            set => velocity.Y = value;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}