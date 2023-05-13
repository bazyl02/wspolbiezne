using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using Logic;

namespace TPW2.ViewModel
{
    public class BallViewModel : ObservableObject
    {
        private string _amount;

        public string Amount
        {
            get
            {
                if (string.IsNullOrEmpty(_amount))
                {
                    return "0";
                }

                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public void Update(bool newItem, Canvas myCanvas, Ellipse ellipse, Vector2 location)
        {
            Canvas.SetLeft(ellipse, location.X);
            Canvas.SetTop(ellipse, location.Y);
            if (newItem)
            {
                myCanvas.Children.Add(ellipse);
            }
        }
    }
}
