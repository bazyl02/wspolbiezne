using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Presentation.Model;

namespace Presentation.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IList balls;
        private int height;
        private int width;
        private string textInput;
        private int amount;
        private AbstractApiModel model { get; set; }

        public MainWindowViewModel()
        {
            model = AbstractApiModel.CreateAPI();
            Add = new RelayCommand(() => CreateBalls());
            Remove = new RelayCommand(() => StopBalls());
            height = model.Height;
            width = model.Width;
            balls = model.BallsModel;
        }
        public int Width
        {
            get => width;
            set
            {
                width = value;
                RaisePropertyChanged("Width");
            }
        }
        public int Height
        {
            get => height;
            set
            {
                height = value;
                RaisePropertyChanged("Height");
            }
        }
        public IList Balls
        {
            get => balls;
        }
        public string Amount
        {
            get { return textInput; }
            set
            {
                textInput = value;
                try
                {
                    amount = System.Int32.Parse(textInput);
                }
                catch (System.FormatException)
                {
                    amount = 0;
                }
                RaisePropertyChanged(nameof(amount));
            }
        }
        public ICommand Add { get; set; }
        public ICommand Remove { get; set; }

        private void CreateBalls()
        {
            model.CreateBalls(amount);
        }
        private void StopBalls()
        {
            model.StopBalls();
            balls.Clear();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}