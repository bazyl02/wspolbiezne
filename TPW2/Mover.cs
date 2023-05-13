using System;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TPW2.ViewModel;

namespace TPW2
{
    public class Mover
    {
        static Random r = new Random();
        private Vector2 location;
        private Vector2 velocity;
        private int radius = 25;
        private int width;
        private int height;
        private double posX;
        private double posY;
        private Ellipse ellipse;
        private Brush customColor;

        BallViewModel ball = new BallViewModel();

        public Mover(int width, int height, Canvas myCanvas, double posX, double posY)
        {
            this.width = width;
            this.height = height;
            this.posX = posX;
            this.posY = posY;

            float X = r.Next(2 + radius, width - radius - 2);
            float Y = r.Next(2 + radius, height - radius - 2);
            location = new Vector2(X, Y);
            velocity = new Vector2((float)r.NextDouble() * 8 - 4, (float)r.NextDouble() * 8 - 4);

            customColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
            ellipse = new Ellipse()
            {
                Tag = "ball1",
                Width = radius * 2,
                Height = radius * 2,
                Fill = customColor,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };

            ball.Update(true, myCanvas, ellipse, changeMovement());
        }

        public Ellipse Ellipse { get { return ellipse; } }


        public Vector2 changeMovement()
        {
            if (location.X < 0 || location.X > width - radius * 2)
            {
                velocity.X = velocity.X * -1;
            }
            if (location.Y < 0 || location.Y > height - radius * 2)
            {
                velocity.Y = velocity.Y * -1;
            }
            location = Vector2.Add(location, velocity);

            return location;
        }
    }
}
