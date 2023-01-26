using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace metod
{
    internal class Program
    {
        /// <summary>
        /// Метод проверяющий введеное значение с консоли на то, что это целое число и оно больше 1
        /// </summary>
        /// <returns>
        /// Возвращает "correctValue" - число которое прошло проверку
        /// </returns>
        static int CheckValue()
        {
            int correctValue;
            while (!int.TryParse(Console.ReadLine(), out correctValue))
            {
                Console.WriteLine("Неправильно! Попробуй еще раз.");
            }
            while ( correctValue < 1)
            {
                Console.Write("Введи число > 0! ");
                correctValue = CheckValue();
            }
            return correctValue;
        }
        /// <summary>
        /// Заполнение двумерного массива рандомными числоми от 0 до 10
        /// </summary>
        /// <param name="arr">
        /// заполняет массив arr[i, j] числами от 0 до 10
        /// </param>

        static Random _random = new Random();
        static void ArrayRange(int[,] arr)
        {
            var rows = arr.GetLength(0);        //GetLength() лучше вызывать раньше самого цикла... так быстрее будет)
            var cols = arr.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = _random.Next(0, 11);
                }
            }
        }
        /// <summary>
        /// Вывод на консоль двумерного массива 
        /// </summary>
        /// <param name="Array"> Двумерный массив </param>
        static void PrintArray(int[,] Array)
        {
            var rows = Array.GetLength(0);
            var cols = Array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($" {Array[i, j],3} ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Уммножение элементов массива на число введеное с консоли
        /// </summary>
        /// <param name="arrayRes"> Массив результата умножения </param>
        /// <param name="ArrNew"> Массив элементы которого умножат на число "number" </param>
        /// <param name="numb"> Число на которое будет умножен массив </param>
        static void ArrayMultip(int[,] arrayRes, int[,] ArrNew, int numb)
        {
            var rows = ArrNew.GetLength(0);
            var cols = ArrNew.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arrayRes[i, j] = ArrNew[i, j] * numb;
                }
            }
        }
        /// <summary>
        /// Выполняет сложение двух матриу
        /// </summary>
        /// <param name="ArrSum"> Матрица с результатом сложения </param>
        /// <param name="Arr_1"> Матрица # 1 </param>
        /// <param name="Arr_2"> Матрица # 2 </param>
        static void ArrPlusArr(int[,] ArrSum, int[,] Arr_1, int[,] Arr_2)
        {
            var rows = ArrSum.GetLength(0);
            var cols = ArrSum.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ArrSum[i, j] = Arr_1[i, j] + Arr_2[i, j];
                }
            }
        }
        /// <summary>
        /// Выполняет вычитание двух матриу
        /// </summary>
        /// <param name="ArrSum"> Матрица с результатом вычитания </param>
        /// <param name="Arr_1"> Матрица # 1 </param>
        /// <param name="Arr_2"> Матрица # 2 </param>
        static void ArrMinusArr(int[,] ArrSum, int[,] Arr_1, int[,] Arr_2)
        {
            var rows = ArrSum.GetLength(0);
            var cols = ArrSum.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ArrSum[i, j] = Arr_1[i, j] - Arr_2[i, j];
                }
            }
        }

        /// <summary>
        /// Метод умножения одной матрицы на другую
        /// </summary>
        /// <param name="ArrMult"> Матрица результата умножений </param>
        /// <param name="Arr_A"> Матрица для умножения #1 </param>
        /// <param name="Arr_B"> Матрица для умножения #2 </param>
        static void ArrayMultip(int[,] ArrMult, int[,] Arr_A, int[,] Arr_B)
        {
            for (int i = 0; i < Arr_A.GetLength(0); i++)
            {
                for (int j = 0; j < Arr_B.GetLength(1); j++)
                {
                    for (int k = 0; k < Arr_B.GetLength(0); k++)
                    {
                        ArrMult[i, j] += Arr_A[i, k] * Arr_B[k, j];
                    }                    
                }
                Console.WriteLine();
                
            }
        }
        static int CheckCols(int Cols_1, int Rows_2) /// сюда приходит два числа
        {

            while (Cols_1 != Rows_2)  // тут их сравнивают
            {
                Console.WriteLine($"Количестао столбцов должно быть = {Cols_1} ");
                int.TryParse(Console.ReadLine(), out Rows_2); // вводят новое чило
            }
            return Rows_2;
            ///  надо сделать так шоб новое число попало в int Cols_2
        }

        static int CheckRows(int Rows_1, int Cols_2) /// сюда приходит два числа
        {
            
            while (  Cols_2 != Rows_1)  // тут их сравнивают
            {
                Console.WriteLine($"Количестао столбцов должно быть = {Rows_1} ");
                int.TryParse(Console.ReadLine(), out Cols_2); // вводят новое чило
            }
            return Cols_2;
            ///  надо сделать так шоб новое число попало в int Cols_2
        }
        static void Main(string[] args)
        {

            /////////////////       ////////////////////           1.1
            // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число

            //Console.Write("Введи кол-во строк: ");
            //int row = CheckValue();

            //Console.Write("Введи кол-во столбцов: ");
            //int col = CheckValue();

            //Console.Write("Введите множитель: ");
            //int numb = CheckValue();

            //int[,] def = new int[row, col];
            //ArrayRange(def);

            //Console.WriteLine("\nИсходная матрица");
            //PrintArray(def);

            //int[,] multip = new int[row, col];
            //ArrayRange(multip);

            //Console.WriteLine($"\nМножитель: {numb} ");

            //Console.WriteLine();
            //Console.WriteLine("Перемноженная матрица");

            //ArrayMultip(multip,def,numb);
            //PrintArray(multip);

            //////////////////      ///////////////////           1.2
            // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму


            //Console.Write("Введи кол-во строк: ");
            //int row = CheckValue();

            //Console.Write("Введи кол-во столбцов: ");
            //int col = CheckValue();

            //int[,] array_1 = new int[row, col];
            //ArrayRange(array_1);
            //Console.WriteLine("\n\tМатрица #1\n");
            //PrintArray(array_1);
            //Console.WriteLine();

            //int[,] array_2 = new int[row, col];
            //ArrayRange(array_2);
            //Console.WriteLine("\n\tМатрица #2\n");
            //PrintArray(array_2);

            //int[,] plus = new int[row, col];
            //ArrPlusArr(plus, array_1, array_2);
            //Console.WriteLine("\n\tРезультат сложения матриц\n");
            //PrintArray(plus);

            //int[,] minus = new int[row, col];
            //ArrMinusArr(minus, array_1, array_2);
            //Console.WriteLine("\n\tРезультат вычитания Матрицы #1 из Матрицы #2 \n");
            //PrintArray(minus);

            //////////////////      ///////////////////           1.3
            // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение


            Console.Write("Введи кол-во строк матрицы А: ");   ////////////
            int rowA = CheckValue();
            
            Console.Write("Введи кол-во столбцов матрицы А: ");
            int colA = CheckValue();
           

            Console.Write("Введи кол-во строк матрицы B: ");  //////////////
            int rowB = CheckValue();
            rowB = CheckCols(colA, rowB);

            Console.Write("Введи кол-во столбцов матрицы B: ");
            
            int colB = CheckValue();
            colB = CheckRows(rowA, colB);            
            Console.WriteLine();

            int[,] arrayA = new int[rowA, colA];
            ArrayRange(arrayA);
            Console.WriteLine("\n\tМатрица A\n");
            PrintArray(arrayA);
            Console.WriteLine();


            int[,] arrayB = new int[rowB, colB];
            ArrayRange(arrayB);
            Console.WriteLine("\n\tМатрица B\n");
            PrintArray(arrayB);
            Console.WriteLine();


            int[,] arrayMultip = new int[rowA, colB];

            ArrayMultip(arrayMultip, arrayA, arrayB);
            Console.WriteLine("\n\tМатрица C = Матрица A * Матрица B \n");
            PrintArray(arrayMultip);
            Console.WriteLine();



        }
    }
}
