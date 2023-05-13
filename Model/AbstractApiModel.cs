using System.Collections.ObjectModel;
using Logic;
using Presentation.Model;

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
        public abstract int GetHeight();
        public abstract int GetWidth();
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
            public override int GetWidth()
            {
                return logic.GetWidth();
            }
            public override int GetHeight()
            {
                return logic.GetHeight();
            }
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