
namespace TPW2.ViewModel
{
    public class MainWindowViewModel
    {
        public BallViewModel Ball { get; private set; }

        public MainWindowViewModel()
        {
            Ball = new BallViewModel();
        }
    }
}
