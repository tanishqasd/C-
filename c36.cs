using System;

class RandomNumberGenerator
{
    static void Main()
    {
        Random random = new Random();
        
        // Generate 5 random numbers between 1 and 100
        Console.WriteLine("Random numbers between 1 and 100:");
        for (int i = 0; i < 5; i++)
        {
            int randomNum = random.Next(1, 101);
            Console.WriteLine(randomNum);
        }
        
        // Generate a random double between 0.0 and 1.0
        Console.WriteLine("\nRandom double:");
        double randomDouble = random.NextDouble();
        Console.WriteLine(randomDouble);
    }
}