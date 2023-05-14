using System.ComponentModel;
using System.Numerics;

namespace Data
{
    public class BallData : INotifyPropertyChanged
    {
        private Vector2 location;
        private Vector2 velocity;
        private int radius;
        private float mass;
        private string color;

        public BallData(Vector2 location, int radius, float mass, Vector2 velocity, string color)
        {
            this.location = location;
            this.velocity = velocity;
            this.radius = radius;
            this.mass = mass;
            this.color = color;
        }

        public void UpdatePosition()
        {
            location += velocity;
            RaisePropertyChanged("ChangeLocation");
        }
        public int Radius { get => radius; }
        public string Color { get => color; }
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
            set
            {
                if (value > 5)
                    value = 5;
                else if (value < -5)
                    value = -5;
                velocity.X = value;
            }
        }
        public float VelocityY
        {
            get => velocity.Y;
            set
            {
                if (value > 5)
                    value = 5;
                else if (value < -5)
                    value = -5;
                velocity.Y = value;
            }
        }
        public float Mass
        {
            get => mass;
            set => mass = value;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}