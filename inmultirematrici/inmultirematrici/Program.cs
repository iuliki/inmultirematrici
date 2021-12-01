using System;

namespace inmultirematrici
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[,] matrix1 = ReadMatrix();
            PrintMatrix(matrix1);
            int[,] matrix2 = ReadMatrix();
            PrintMatrix(matrix2);
            Console.WriteLine("\n");
            int[,] P=Produs(matrix1, matrix2);
            PrintMatrix(P);
        }
        public static class ConsoleHelper
        {
            public static int ReadNumber(string label, int maxTries, int defaultValue)
            {
                int currentTry = 0;
                do
                {
                    Console.Write(label);
                    string valueAsString = Console.ReadLine();
                    int valueAsNumber;
                    bool isNumber = int.TryParse(valueAsString, out valueAsNumber);

                    if (isNumber)
                    {
                        return valueAsNumber;
                    }

                    currentTry++;
                    Console.WriteLine($"The value '{valueAsString}' doen't represent a valid number, please try again ...");
                }
                while (currentTry < maxTries);

                return defaultValue;
            }
        }
        public static int[,] ReadMatrix()
        {
            // citesc nr de linii
            int rowsCount = ConsoleHelper.ReadNumber("Nr de linii=", 3, 0);

            // citesc nr de coloane
            int colsCount = ConsoleHelper.ReadNumber("Nr de coloane=", 3, 0);

            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int element = ConsoleHelper.ReadNumber($"Element[{row},{col}]=", 3, 0);
                    matrix[row, col] = element;
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            if (matrix is null)
            {
                Console.WriteLine("Matrix is null");
                return;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col],6}");
                }

                Console.WriteLine();
            }
        }
        public static int[,] Produs(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 is null)
            {
                Console.WriteLine($"{nameof(matrix1)} is null, cannot calculate prod!");
                return new int[0, 0];
            }

            if (matrix2 is null)
            {
                Console.WriteLine($"{nameof(matrix2)} is null, cannot calculate prod!");
                return new int[0, 0];
            }

            // calculate dimensions of matrix1
            int rowsCount1 = matrix1.GetLength(0);
            int colsCount1 = matrix1.GetLength(1);

            // calculate dimensions of matrix2
            int rowsCount2 = matrix2.GetLength(0);
            int colsCount2 = matrix2.GetLength(1);

            if (rowsCount1 != rowsCount2 || colsCount1 != colsCount2)
            {
                Console.WriteLine($"Dimensions of the two matrices are not the same, cannot calculate prod!");
                return new int[0, 0];
            }

            int[,] prod = new int[rowsCount1, colsCount1];
            for (int row = 0; row < rowsCount1; row++)
            {
                for (int col = 0; col < colsCount1; col++)
                {
                   // prod = new int[rowsCount1, colsCount1];
                    for (int k=0;k<rowsCount1; k++)
                       prod[row, col] = prod[row, col] + matrix1[row,k]*matrix2[k,col];
                }
            }

            return prod;
        }
    }
}
