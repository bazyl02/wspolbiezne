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

            wynik1.Text = Functions.functionOnClick(i1, i2);
        }
    }
}
