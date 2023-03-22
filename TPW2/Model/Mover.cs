using System;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TPW2.Model
{
    class Mover
    {
        static Random r = new Random();
        Vector2 location;
        Vector2 velocity;
        private double width;
        private double height;
        private double posX;
        private double posY;
        Ellipse ellipse;
        Brush customColor;

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
                Width = 50,
                Height = 50,
                Fill = customColor,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
            Canvas.SetLeft(ellipse, location.X);
            Canvas.SetTop(ellipse, location.Y);
            myCanvas.Children.Add(ellipse);
        }

        public void Update()
        {
            if (location.X < 0 || location.X > width - 65)
            {
                velocity.X = velocity.X * -1;
            }
            if (location.Y < 0 || location.Y > height - 87)
            {
                velocity.Y = velocity.Y * -1;
            }
            location = Vector2.Add(location, velocity);

            Canvas.SetLeft(ellipse, location.X);
            Canvas.SetTop(ellipse, location.Y);
        }
    }
}
