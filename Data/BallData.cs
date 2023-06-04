using System.ComponentModel;
using System.Numerics;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public Vector2 Location
        {
            get => location;
            set => location = value;
        }

        [JsonIgnore]
        public Vector2 Velocity
        {
            get => velocity;
            set
            {
                if (value.Y > 5)
                    value.Y = 5;
                else if (value.Y < -5)
                    value.Y = -5;
                velocity.Y = value.Y;

                if (value.X > 5)
                    value.X = 5;
                else if (value.X < -5)
                    value.X = -5;
                velocity.X = value.X;
            }
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