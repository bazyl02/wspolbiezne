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
        private double width;
        private double height;
        private double posX;
        private double posY;
        private Ellipse ellipse;
        private Brush customColor;
        private int ellipseWidth = 50;
        private int ellipseHeight = 50;

        BallViewModel ball = new BallViewModel();

        public Mover(double width, double height, Canvas myCanvas, double posX, double posY)
        {
            this.width = width;
            this.height = height;
            this.posX = posX;
            this.posY = posY;

            location = new Vector2((float)posX - 30, (float)posY - 30);
            velocity = new Vector2(r.Next(-5, 5), r.Next(-5, 5));

            customColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
            ellipse = new Ellipse()
            {
                Tag = "ball1",
                Width = ellipseWidth,
                Height = ellipseHeight,
                Fill = customColor,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };

            ball.Update(true, myCanvas, ellipse, changeMovement());
        }

        public Ellipse Ellipse { get { return ellipse; } }


        public Vector2 changeMovement()
        {
            if (location.X < 0 || location.X > width - ellipseWidth)
            {
                velocity.X = velocity.X * -1;
            }
            if (location.Y < 0 || location.Y > height - ellipseHeight)
            {
                velocity.Y = velocity.Y * -1;
            }
            location = Vector2.Add(location, velocity);

            return location;
        }
    }
}
