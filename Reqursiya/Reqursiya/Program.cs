using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemanT_Library;

namespace Reqursiya
{
    class Program
    {
        #region Первые числа последовательности и массив для их хранения
        private static double a1, a2, a3;
        private static double[] mas;
        #endregion
        #region Ищет число для дальнейшей обработки. Работает по принципу рекурсивного метода. Возвращает найденное число последовательности.
        private static double FindChislo(int N)
        {
            if (N == 1)
            {
                return a1;
            }
            if (N == 2)
            {
                return a2;
            }
            if (N == 3)
            {
                return a3;
            }
            return 13 * FindChislo(N - 1) - 10 * FindChislo(N - 2) + FindChislo(N - 3);
        }
        #endregion
        #region Запрашивает у пользователя ввод данных последовательности и печатает результат обработки.
        static void Main()
        {
            ColorMess.Yellow("\n Задайте первое число последовательности а1: ");
            a1 = Input.Check(double.MinValue, double.MaxValue);
            ColorMess.Yellow("\n Задайте второе число последовательности а2: ");
            a2 = Input.Check(double.MinValue, double.MaxValue);
            ColorMess.Yellow("\n Задайте третье число последовательности а3: ");
            a3 = Input.Check(double.MinValue, double.MaxValue);
            ColorMess.Yellow("\n Задайте колличество чисел в последовательности N (от 4 до 30): ");
            int N = Input.Check(4, 30);
            mas = new double[N];
            ColorMess.Yellow("\n Ваша последовательность выглядит так: ");
            for (int i = N; i > 0; i--)
            {
                mas[i - 1] = FindChislo(i);
            }
            bool z = true;
            mas.Reverse();
            for (int i = 1; i < N; i += 2)
            {
                try
                {
                    if (mas[i] > mas[i + 2])
                    {
                        z = false;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            for (int i = 0; i < N; i++)
                ColorMess.Cyan(Convert.ToString(mas[i]) + " ");
            if (z)
                ColorMess.Magenta("\n\n Строго возрастающая последовательность (по элементам стоящим на четных местах).\n");
            else
                ColorMess.Magenta("\n\n Последовательность (по элементам стоящим на четных местах) не является строго возрастающей.\n");
            Message.GoToBack();
        }
        #endregion
    }
}
