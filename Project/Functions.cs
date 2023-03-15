using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Functions
    {
        public static string functionOnClick(double i1, int i2)
        {
            if (i2 > 15)
            {
                return "Podaj liczbę mniejszą od 15";
            }
            else if (i1 < 0)
            {
                return "Nie można policzyć pierwiaska z liczby ujemnej";
            }
            else
            {
                double w = Math.Sqrt(i1);
                return Math.Round(w, i2).ToString();
            }
        }
    }
}
