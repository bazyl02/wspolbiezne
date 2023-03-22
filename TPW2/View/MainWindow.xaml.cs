using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TPW2.Model;

namespace TPW2
{
    public partial class MainWindow : Window
    {
        Mover mover;
        List<Mover> movers = new List<Mover>();
        int speed = 10;
        DispatcherTimer timer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            Load();
        }


        private void Load()
        {
            myCanvas.Focus();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach(var item in movers)
            {
                item.Update();
            }
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
                mover = new Mover(Application.Current.MainWindow.Width, Application.Current.MainWindow.Height, myCanvas, Mouse.GetPosition(myCanvas).X, Mouse.GetPosition(myCanvas).Y);
                movers.Add(mover);
            }
        }
    }
}
