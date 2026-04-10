using System;

class DemonstrateJaggedArrays
{
    static void Main()
    {
        // Declare a jagged array (array of arrays)
        int[][] jaggedArray = new int[3][];
        
        // Initialize each row with different lengths
        jaggedArray[0] = new int[2];
        jaggedArray[1] = new int[4];
        jaggedArray[2] = new int[3];
        
        // Populate the jagged array
        jaggedArray[0][0] = 1;
        jaggedArray[0][1] = 2;
        
        jaggedArray[1][0] = 10;
        jaggedArray[1][1] = 20;
        jaggedArray[1][2] = 30;
        jaggedArray[1][3] = 40;
        
        jaggedArray[2][0] = 100;
        jaggedArray[2][1] = 200;
        jaggedArray[2][2] = 300;
        
        // Display the jagged array
        Console.WriteLine("Jagged Array Contents:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write($"Row {i}: ");
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
        
        // Alternative: Initialize jagged array with values
        int[][] jaggedArray2 = new int[][]
        {
            new int[] { 5, 10 },
            new int[] { 15, 20, 25 },
            new int[] { 30 }
        };
        
        Console.WriteLine("\nAlternative Jagged Array:");
        foreach (int[] row in jaggedArray2)
        {
            foreach (int value in row)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}