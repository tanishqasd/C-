using System;

class MatrixMultiplication
{
    static void Main()
    {
        Console.WriteLine("Matrix Multiplication");
        
        // First matrix (2x3)
        int[,] matrix1 = { { 1, 2, 3 }, { 4, 5, 6 } };
        
        // Second matrix (3x2)
        int[,] matrix2 = { { 7, 8 }, { 9, 10 }, { 11, 12 } };
        
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);
        
        if (cols1 != rows2)
        {
            Console.WriteLine("Matrix multiplication not possible!");
            return;
        }
        
        // Result matrix (rows1 x cols2)
        int[,] result = new int[rows1, cols2];
        
        // Perform multiplication
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        
        // Display result
        Console.WriteLine("\nResult Matrix:");
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}