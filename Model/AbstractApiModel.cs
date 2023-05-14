using System.Collections.ObjectModel;
using Logic;

namespace Presentation.Model
{
    public abstract class AbstractApiModel
    {
        private ObservableCollection<BallModel> ballsModel = new ObservableCollection<BallModel>();
        public static AbstractApiModel CreateAPI(LogicAbstractApi? logicApi = default)
        {
            return new ModelLayer(logicApi ?? LogicAbstractApi.CreateApi());
        }
        public abstract ObservableCollection<BallModel> CreateBalls(int number);
        public abstract void StopBalls();
        public abstract int Height { get; }
        public abstract int Width { get; }
        public ObservableCollection<BallModel> BallsModel
        {
            get => ballsModel;
            set => ballsModel = value;
        }

        internal class ModelLayer : AbstractApiModel
        {
            private readonly LogicAbstractApi logic;
            public ModelLayer(LogicAbstractApi logicLayer)
            {
                logic = logicLayer;
            }
            public override int Width { get => logic.Width; }
            public override int Height { get => logic.Height; }


            public override ObservableCollection<BallModel> CreateBalls(int number)
            {
                logic.CreateBalls(number);
                for (int i = 0; i < number; i++)
                {
                    ballsModel.Add(new BallModel(logic.ballList[logic.ballList.Count - 1 - i]));
                }
                return ballsModel;
            }
            public override void StopBalls()
            {
                logic.StopBalls();
                logic.ballList.Clear();
                ballsModel.Clear();
            }
        }
    }
}