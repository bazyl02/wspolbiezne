using System.Numerics;

namespace Data
{
    public class BallGenerator
    {
        private Random r = new Random();
        private int posX;
        private int posY;
        private static int radius = 25;
        public static int spawnWidth = 1280 - Radius;
        public static int spawnHeight = 650 - Radius;
        private Vector2 location;
        private Vector2 velocity;
        private string color;

        public BallGenerator() { }

        public BallData GenerateBall()
        {
            posX = r.Next(radius, spawnWidth - radius);
            posY = r.Next(radius, spawnHeight - radius);
            location = new Vector2(posX, posY);
            velocity = new Vector2((float)r.NextDouble() * 4 - 2, (float)r.NextDouble() * 4 - 2);
            float mass = (float)r.NextDouble() * 2;
            color = System.String.Format("#{0:X6}", r.Next(0, 0xFFFFFF));
            return new BallData(location, radius, mass, velocity, color);
        }

        public static int Radius { get => radius; }
    }
}