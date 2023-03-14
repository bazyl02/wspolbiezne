using System;
using System.Windows;

namespace Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void przycisk1_Click(object sender, RoutedEventArgs e)
        {
            double i1 = Convert.ToDouble(liczba1.Text);
            int i2 = int.Parse(liczba2.Text);

            functionOnClick(i1, i2);
        }

        private void functionOnClick(double i1, int i2)
        {
            if (i2 > 15)
            {
                wynik1.Text = "Podaj liczbę mniejszą od 15";
            }
            else
            {
                double w = Math.Sqrt(i1);
                wynik1.Text = Math.Round(w, i2).ToString();
            }
        }
    }
}
