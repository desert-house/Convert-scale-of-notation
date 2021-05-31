using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertS;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int a, b;
            string s;
            Console.WriteLine("Введите число: ");
            s = Console.ReadLine();
            Console.WriteLine("Введите изначальную систему счисления числа: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите систему счисления, в которую надо перевести: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Итог: ");
            Console.WriteLine(Conv.Toany(a, b, s));
            Console.ReadLine();
        }
    }
}