using System;

class TransposeMatrix
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        
        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());
        
        // Original matrix
        int[,] matrix = new int[rows, cols];
        
        Console.WriteLine("Enter matrix elements:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        
        // Transpose matrix
        int[,] transpose = new int[cols, rows];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transpose[j, i] = matrix[i, j];
            }
        }
        
        // Display original matrix
        Console.WriteLine("\nOriginal Matrix:");
        DisplayMatrix(matrix, rows, cols);
        
        // Display transpose
        Console.WriteLine("\nTranspose Matrix:");
        DisplayMatrix(transpose, cols, rows);
    }
    
    static void DisplayMatrix(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}