using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_6
{
    internal class Program
    {
        static int[,] GenerateRandomMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(1, 100);
                }
            }
            return matrix;
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int columns1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int columns2 = matrix2.GetLength(1);

            if (columns1 != rows2)
            {
                throw new ArgumentException("Умножение невозможно.");
            }

            int[,] resultMatrix = new int[rows1, columns2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < columns2; j++)
                {
                    for (int k = 0; k < columns1; k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return resultMatrix;
        }
        static int[,] GenerateTemperatureArray()
        {
            Random random = new Random();
            int[,] temperature = new int[12, 30];
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = random.Next(-30, 31);
                }
            }

            return temperature;
        }
        static double[] CalculateAverageTemperatures(int[,] temperature)
        {
            double[] averageTemperatures = new double[12];
            for (int month = 0; month < 12; month++)
            {
                double sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperature[month, day];
                }
                averageTemperatures[month] = sum / 30;
            }
            return averageTemperatures;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 6.2 Написать программу, реализующую умножению двух матриц, заданных вnвиде двумерного массива. В программе предусмотреть два метода: метод печати матрицы, метод умножения матриц (на вход две матрицы, возвращаемое значение – матрица).");
            int[,] matrix1 = GenerateRandomMatrix(2, 2);
            int[,] matrix2 = GenerateRandomMatrix(2, 2);
            Console.WriteLine("Матрица 1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Матрица 2:");
            PrintMatrix(matrix2);
            int[,] resultMatrix = MultiplyMatrices(matrix1, matrix2);
            Console.WriteLine("Результат умножения матриц:");
            PrintMatrix(resultMatrix);
            Console.WriteLine("Упражнение 6.3 Написать программу, вычисляющую среднюю температуру за год. Создать двумерный рандомный массив temperature[12,30], в котором будет храниться температура для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать значения температур случайным образом. Для каждого месяца распечатать среднюю температуру. Для этого написать метод, который по массиву temperature [12,30] для каждого месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив средних температур. Полученный массив средних температур отсортировать по возрастанию.");
            int[,] temperature = GenerateTemperatureArray();
            double[] averageTemperatures = CalculateAverageTemperatures(temperature);
            Array.Sort(averageTemperatures);
            Console.WriteLine("Средние температуры по месяцам:");
            for (int month = 0; month < 12; month++)
            {
                Console.WriteLine($"Месяц {month + 1}: {averageTemperatures[month]}");
            }
            Console.ReadKey();
        }
    }
}
