using System;
using System.Diagnostics;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер первой матрицы в формате a b: ");
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите размер второй матрицы: ");
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());

            if (y1 != x2)
            {
                Console.WriteLine("Матрицы невозможно перемножить!");
                Console.Read();
                return;
            }
            else if (x1 < 1 || x2 < 1 || y1 < 1 || y2 < 1) {
                Console.WriteLine("Ошибка!");
                Console.Read();
                return;
            }

            double[,] matrix1 = new double[x1, y1];
            double[,] matrix2 = new double[x2, y2];
            double[][] matrix3 = new double[x1][];
            double[][] matrix4 = new double[x2][];
            double[,] result1 = new double[x1, y2];
            double[][] result2 = new double[x1][];

            Random random = new Random();

            //Инициализация
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    matrix1[i, j] = random.NextDouble();
                }
            }

            for (int i = 0; i < x2; i++)
            {
                for (int j = 0; j < y2; j++)
                {
                    matrix2[i, j] = random.NextDouble();
                }
               
            }

            for (int i = 0; i < x1; i++) {
                matrix3[i] = new double[y1];

                for (int j = 0; j < y1; j++) {
                    matrix3[i][j] = matrix1[i, j];
                }
            }

            for (int i = 0; i < x2; i++)
            {
                matrix4[i] = new double[y2];

                for (int j = 0; j < y2; j++)
                {
                    matrix4[i][j] = matrix2[i, j];
                }
            }

            //Перемножение

            Stopwatch sw = new Stopwatch();
            //2D Array
            sw.Start();
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y2; j++)
                {
                    for (int k = 0; k < y1; k++)
                    {
                        result1[i,j] += matrix1[i,k] * matrix2[k,j];
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Время умножения с помощью прямоугольных массивов: {0}", sw.ElapsedMilliseconds);

            //Jagged array
            sw.Restart();
            for (int i = 0; i < x1; i++) {
                result2[i] = new double[y2];
                for (int j = 0; j < y2; j++) {
                    for (int k = 0; k < y1; k++) {
                        result2[i][j] += matrix3[i][k] * matrix4[k][j];
                    }
                }
            }
            sw.Stop();

            Console.WriteLine("Время умножения с помощью вложенных массивов: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("Производительность в ГФлопс: {0}", 2*Math.Pow(x1,3) / (Math.Pow(10, 6) * sw.ElapsedMilliseconds));
        }
    }
}
