using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using TPW2.ViewModel;

namespace TPW2
{
    public partial class MainWindow : Window
    {
        Mover mover;
        List<Mover> movers = new List<Mover>();
        DispatcherTimer timer = new DispatcherTimer();
        MainViewModel _main = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _main;
            myCanvas.Focus();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var item in movers)
            {
                _main.Ball.Update(false, myCanvas, item.Ellipse, item.changeMovement());
            }
            for (int i = 0;  i < Int32.Parse(_main.Ball.Amount); i++)
            {
                mover = new Mover(myCanvas.ActualWidth, myCanvas.ActualHeight, myCanvas, myCanvas.ActualWidth / 2, myCanvas.ActualHeight / 2);
                movers.Add(mover);
            }
            data.Text = "";
        }

        private void AddOrRemoveItems(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse activeElipse = (Ellipse)e.OriginalSource;

                myCanvas.Children.Remove(activeElipse);
            }
            else
            {
                mover = new Mover(myCanvas.ActualWidth, myCanvas.ActualHeight, myCanvas, Mouse.GetPosition(myCanvas).X, Mouse.GetPosition(myCanvas).Y);
                movers.Add(mover);
            }
        }
    }
}
