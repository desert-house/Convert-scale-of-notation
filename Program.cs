using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertS
{
    public static class Conv
    {
        private static string _str;
        private static string _temp;

        private static int ChToI(char a)
        {
            if (a >= 'A') return a - 55;
            if (a > 0) return a - 48;
            return a + 74;
        }

        private static string ToDot(int a, int b)
        {
            string ex = "";
            int temp = 0;

            for (int i = 0; i < _str.Length && _str[i] != '.'; ++i) _temp += _str[i]; 

            temp = _temp.Aggregate(temp, (current, t) => current * a + ChToI(t));

            if (temp == 0) Console.WriteLine("0");
            else
                while (temp != 0)
                {
                    ex = Convert.ToString(temp % b) + ex;
                    temp /= b;
                }

            return ex;
        }

        private static string AfterDot(int at, int bt)
        {
            string ex;
            double tempd = 0;
            ex = _temp;
            _temp = "";
            for (int i = ex.Length + 1; i < _str.Length; ++i) _temp += _str[i];
            if (_temp.Length > 0)
            {
                ex = "";
                for (int i = _temp.Length - 1; i >= 0; --i) tempd = (ChToI(_temp[i]) + tempd) / at;
                while (tempd > 0)
                {
                    tempd *= bt;
                    ex += Convert.ToString(Math.Round(tempd, MidpointRounding.AwayFromZero));
                    tempd -= Math.Round(tempd, MidpointRounding.AwayFromZero);
                }
            }

            return ex;
        }

        public static string Toany(int from, int to, string S)
        {
            if (S == "") return "Не введено число";
            _str = S;
            int a = 0;
            if (from < 2 || from > 36) return "Не верная система счисления";
            if (to < 2 || to > 36) return "Не верная система счисления";
            foreach (char t in _str)
            {
                if (t == '.')
                    a = 1;
                if (Convert.ToInt32(t) >= from)
                    return "В числе встречаются цифры, большие по значению изначальной системы счисления";
            }
            if (a == 1)
                return ToDot(from, to) + "." + AfterDot(from, to);
            return ToDot(from, to);
        }
    }
}