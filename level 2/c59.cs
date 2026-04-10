using System;

class MatrixAddition
{
    static void Main()
    {
        Console.WriteLine("Matrix Addition Program");
        
        // Get matrix dimensions
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        
        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());
        
        // Declare matrices
        int[,] matrix1 = new int[rows, cols];
        int[,] matrix2 = new int[rows, cols];
        int[,] result = new int[rows, cols];
        
        // Input first matrix
        Console.WriteLine("\nEnter elements of Matrix 1:");
        InputMatrix(matrix1, rows, cols);
        
        // Input second matrix
        Console.WriteLine("\nEnter elements of Matrix 2:");
        InputMatrix(matrix2, rows, cols);
        
        // Add matrices
        AddMatrices(matrix1, matrix2, result, rows, cols);
        
        // Display result
        Console.WriteLine("\nResultant Matrix (Matrix 1 + Matrix 2):");
        DisplayMatrix(result, rows, cols);
    }
    
    static void InputMatrix(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
    
    static void AddMatrices(int[,] mat1, int[,] mat2, int[,] result, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = mat1[i, j] + mat2[i, j];
            }
        }
    }
    
    static void DisplayMatrix(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}