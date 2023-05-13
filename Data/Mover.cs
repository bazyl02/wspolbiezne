using System.Collections.ObjectModel;

namespace Data
{
public class Mover 
    {
        private static int borderWidth = 1280;
        private static int borderHeight = 650;
        private BallGenerator generator = new BallGenerator();
        private ObservableCollection<BallData> balls = new ObservableCollection<BallData>();
        private readonly List<Task> tasks = new List<Task>();


        public Mover()
        {
        }
        public int GetWidth()
        { 
            return borderWidth; 
        }
        public int GetHeight()
        {
            return borderHeight;
        }
        public void CreateBalls(int number)
        {
            if (number > 0)
            {
                for (int i = 0; i < number; i++)
                {
                    BallData ball = generator.GenerateBall();
                    balls.Add(ball);
                }
                Moving();
                
            }
            
        }
        public void StopBalls()
        {
            tasks.Clear();
            balls.Clear();
            Moving();
        }
        public void Moving()
        {
            foreach (BallData ball in balls)
            {
                Task task = Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(10);
                        ball.UpdatePosition();
                    }
                });
                tasks.Add(task);
            }
        }
        public ObservableCollection<BallData> GetBalls()
        {
            return balls;
        }
    }
}