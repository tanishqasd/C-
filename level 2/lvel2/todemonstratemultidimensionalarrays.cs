using System;

class MultidimensionalArrayDemo
{
    static void Main()
    {
        // 2D Array - 3 rows, 4 columns
        int[,] matrix = new int[3, 4]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 }
        };

        Console.WriteLine("2D Array (Matrix):");
        PrintMatrix(matrix);

        // 3D Array - 2x3x4
        int[,,] cube = new int[2, 3, 4];
        cube[0, 0, 0] = 1;
        cube[1, 2, 3] = 99;

        Console.WriteLine("\n3D Array Element at [0,0,0]: " + cube[0, 0, 0]);
        Console.WriteLine("3D Array Element at [1,2,3]: " + cube[1, 2, 3]);

        // Jagged Array
        int[][] jagged = new int[3][];
        jagged[0] = new int[2] { 1, 2 };
        jagged[1] = new int[4] { 3, 4, 5, 6 };
        jagged[2] = new int[3] { 7, 8, 9 };

        Console.WriteLine("\nJagged Array:");
        PrintJagged(jagged);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void PrintJagged(int[][] jagged)
    {
        for (int i = 0; i < jagged.Length; i++)
        {
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}