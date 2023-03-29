
namespace TPW2.ViewModel
{
    public class MainViewModel
    {
        public BallViewModel Ball { get; private set; }

        public MainViewModel()
        {
            Ball = new BallViewModel();
        }
    }
}
