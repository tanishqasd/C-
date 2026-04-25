using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var items = new List<string> { "Apple", "Banana", "Apricot", "Blueberry", "Cherry" };

        // Grouping by the first letter
        var groupedItems = items.GroupBy(i => i[0]);

        foreach (var group in groupedItems)
        {
            Console.WriteLine($"Letter {group.Key}: {string.Join(", ", group)}");
        }
    }
}