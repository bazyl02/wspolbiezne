using System.Collections.ObjectModel;

namespace Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi CreateApi()
        {
            return new DataApi();
        }
        public abstract void CreateBalls(int number);
        public abstract void StopBalls();
        public abstract ObservableCollection<BallData> GetBalls { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }
    }

    public class DataApi : DataAbstractApi
    {
        public Mover mover = new Mover();
        public DataApi() { }
        public override void CreateBalls(int number)
        {
            mover = new Mover();
            mover.CreateBalls(number);
        }
        public override void StopBalls()
        {
            mover.StopBalls();
        }

        public override ObservableCollection<BallData> GetBalls { get => mover.Balls; }
        public override int Height { get => mover.Height; }
        public override int Width { get => mover.Width; }
    }
}