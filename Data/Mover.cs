using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class Mover
    {
        public static int borderWidth = 1280;
        public static int borderHeight = 650;
        private BallGenerator generator = new BallGenerator();
        private ObservableCollection<BallData> balls = new ObservableCollection<BallData>();
        private readonly List<Task> tasks = new List<Task>();
        private object lockFile = new object();
        string fileName = "logs.json";

        public Mover()
        {
        }
        public int Width { get => borderWidth; }
        public int Height { get => borderHeight; }
        public ObservableCollection<BallData> Balls { get => balls; }

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
            tasks.Add(Task.Run(async () =>
            {
                System.IO.File.WriteAllText(fileName, string.Empty);
                while (true)
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };

                    string jsonString = "[ \"Date/Time\": \"" + DateTime.Now.ToString() 
                    + "\",\n  \"Balls list\": " + JsonSerializer.Serialize(balls, options) + " ]\n";

                    lock (lockFile)
                    {
                        File.AppendAllText(fileName, jsonString);
                    }
                    await Task.Delay(1000);
                }
            }));
        }

        public object LockFile
        {
            get => lockFile;
        }

        public string FileName
        {
            get => fileName;
        }
    }
}