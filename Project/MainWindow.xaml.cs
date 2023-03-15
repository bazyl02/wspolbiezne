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
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            double i1 = Convert.ToDouble(value1.Text);
            int i2 = int.Parse(value2.Text);

            result.Text = Functions.functionOnClick(i1, i2);
        }
    }
}
