using System;

namespace Lesson_2_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Сжать массив, удалив из него все 0 и, заполнить
             * освободившиеся справа элементы значениями –1
             */

            Console.WriteLine("\tЗадание №1");

            int[] iArray = new int[10] { 0, 2, 0, 3, 0, 6, 5, 0, 5, 1 };
            Console.Write("Исходный массив:\t");
            foreach (var item in iArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            int[] bufArray = new int[iArray.Length];
            for (int i = 0, j = 0; i < iArray.Length; i++)
            {
                if (iArray[i] != 0)
                {
                    bufArray[j] = iArray[i];
                    j++;
                }
            }

            for (int i = 0; i < bufArray.Length; i++)
            {
                if (bufArray[i] == 0)
                {
                    bufArray[i] = -1;
                }
            }

            bufArray.CopyTo(iArray, index: 0);

            Console.Write("Преобразованный массив: ");
            foreach (var item in iArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            // #############################

            /*
             * 2. Преобразовать массив так, чтобы сначала шли все
             * отрицательные элементы, а потом положительные (0 считать положительным)
             */

            Console.WriteLine("\tЗадание №2");

            int[] iArray1 = new int[15];
            Random random = new Random();
            for (int i = 0; i < iArray1.Length; i++)
            {
                iArray1[i] = random.Next(-3, 3);
            }
            Console.Write("Исходный массив:\t");
            foreach (var item in iArray1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Array.Clear(bufArray, index: 0, bufArray.Length);
            Array.Resize(ref bufArray, iArray1.Length);

            int startZeroIndex = 0;
            for (int i = 0; i < iArray1.Length; i++)
            {
                if (iArray1[i] < 0)
                {
                    bufArray[startZeroIndex] = iArray1[i];
                    startZeroIndex++;
                }
            }
            for (int i = 0; i < iArray1.Length; i++)
            {
                if (iArray1[i] >= 0)
                {
                    bufArray[startZeroIndex] = iArray1[i];
                    startZeroIndex++;
                }
            }

            bufArray.CopyTo(iArray1, index: 0);

            Console.Write("Преобразованный массив: ");
            foreach (var item in iArray1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            // #############################

            /*
             * 3. Написать программу, которая предлагает пользователю
             * ввести число и считает, сколько раз это число встречается в массиве.
             */

            Console.WriteLine("\tЗадание №3");

            Array array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array.SetValue(random.Next(0, 10), index: i);
            }

            Console.Write("Массив:\t");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Array.Clear(bufArray, index: 0, bufArray.Length);
            Array.Resize(ref bufArray, array.Length);
            array.CopyTo(bufArray, index: 0);

            Array.Sort(bufArray);
            int firstIndex = Array.IndexOf(bufArray, number);
            if (firstIndex == -1)
            {
                Console.WriteLine("Совпадений не найдено"); ;
            }
            else
            {
                Console.SetCursorPosition(0, 9);
                Console.Write("Массив:\t");
                foreach (var item in array)
                {
                    if ((int)item == number)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(item + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(item + " ");
                    }
                }
                Console.WriteLine();
                int lastIndex = Array.LastIndexOf(bufArray, number);
                if (firstIndex == lastIndex)
                {
                    Console.WriteLine($"Число {number} встречается в массиве 1 раз");
                }
                else
                {
                    Console.WriteLine($"Число {number} найдено, совпадений: {lastIndex - firstIndex + 1}");
                }
            }
            Console.WriteLine();
            // #############################

            /*
             * 4. В двумерном массиве порядка M на N поменяйте
             * местами заданные столбцы.
             */

            Console.WriteLine("\tЗадание №4");

            int lines = 4;
            int columns = 7;
            char[,] twoDArray = new char[lines, columns];
            Console.WriteLine("Исходный массив:\t");
            for (int i = 0; i < twoDArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDArray.GetLength(1); j++)
                {
                    twoDArray[i, j] = Convert.ToChar(random.Next(65, 80));
                    Console.Write(twoDArray[i, j] + " ");
                }
                Console.WriteLine();
            }

            int? column1 = null;
            int? column2 = null;
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Выбирите столбец для замены: ");
                if (column1 == null)
                {
                    column1 = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    column2 = Convert.ToInt32(Console.ReadLine());
                }
            }

            if ((column1 >= columns || column1 < 0) || (column2 >= columns || column2 < 0))
            {
                Console.WriteLine("Ошибка ввода!");
            }
            else
            {
                char[] columnArray1 = new char[lines];
                for (int i = 0; i < columnArray1.Length; i++)
                {
                    columnArray1[i] = twoDArray[i, (int)column1];
                }
                char[] columnArray2 = new char[lines];
                for (int i = 0; i < columnArray2.Length; i++)
                {
                    columnArray2[i] = twoDArray[i, (int)column2];
                }

                for (int i = 0; i < columnArray1.Length; i++)
                {
                    twoDArray[i, (int)column2] = columnArray1[i];
                }
                for (int i = 0; i < columnArray2.Length; i++)
                {
                    twoDArray[i, (int)column1] = columnArray2[i];
                }

                Console.WriteLine("Преобразованный массив: ");
                for (int i = 0; i < twoDArray.GetLength(0); i++)
                {
                    for (int j = 0; j < twoDArray.GetLength(1); j++)
                    {
                        if (j == (int)column1 || j == (int)column2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(twoDArray[i, j] + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(twoDArray[i, j] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            // #############################
        }
    }
}
